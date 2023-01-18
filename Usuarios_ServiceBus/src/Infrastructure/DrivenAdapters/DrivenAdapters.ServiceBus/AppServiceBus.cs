using Azure.Messaging.ServiceBus;
using Domain.Model.Entities;
using Domain.Model.Interfaces;
using Helpers.ObjectUtils;
using Microsoft.Extensions.Options;
using System.Text;
using System.Text.Json;

namespace DrivenAdapters.ServiceBus
{
    public class AppServiceBus: IAppServiceBus
    {
        private readonly IOptionsMonitor<Usuario_ServiceBus> _options;
        private ServiceBusClient? client;

        public AppServiceBus(IOptionsMonitor<Usuario_ServiceBus> options)
        {
            _options = options;
        }

        public async Task<bool> SendMessage(Usuario usuario)
        {
            ServiceBusClientOptions clientOptions = new()
            {
                TransportType = ServiceBusTransportType.AmqpWebSockets
            };
            ServiceBusClient client = new(_options.CurrentValue.ConnectionSB, clientOptions);
            ServiceBusSender sender = client.CreateSender(_options.CurrentValue.QueueName);
            using ServiceBusMessageBatch messageBatch = await sender.CreateMessageBatchAsync();
            string json = JsonSerializer.Serialize(usuario);
            messageBatch.TryAddMessage(new ServiceBusMessage(Encoding.UTF8.GetBytes(json)));
            try
            {
                await sender.SendMessagesAsync(messageBatch);
                return true;
            }
            finally
            {
                await sender.DisposeAsync();
                await client.DisposeAsync();
            }
        }

        public async Task RecieveMessage()
        {
            ServiceBusClientOptions clientOptions = new()
            {
                TransportType = ServiceBusTransportType.AmqpWebSockets
            };
            client = new ServiceBusClient(_options.CurrentValue.ConnectionSB, clientOptions);
            ServiceBusProcessor sender = client.CreateProcessor(_options.CurrentValue.QueueName);
            sender.ProcessMessageAsync += MessageHandler;
            sender.ProcessErrorAsync += ErrorHandler;
                await sender.StartProcessingAsync();      
        }

        async Task MessageHandler(ProcessMessageEventArgs args)
        {
            Usuario usuario;
            string body = args.Message.Body.ToString();
            if (!string.IsNullOrEmpty(body))
            {
                usuario = JsonSerializer.Deserialize<Usuario>(body);
                Console.WriteLine(usuario.Nombre);
            }
            await args.CompleteMessageAsync(args.Message);
        }

        // handle any errors when receiving messages
        Task ErrorHandler(ProcessErrorEventArgs args)
        {
            Console.WriteLine(args.Exception.ToString());
            return Task.CompletedTask;
        }
    }
}
