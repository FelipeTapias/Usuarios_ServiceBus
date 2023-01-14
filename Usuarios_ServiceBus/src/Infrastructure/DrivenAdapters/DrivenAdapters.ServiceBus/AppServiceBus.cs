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

        public AppServiceBus(IOptionsMonitor<Usuario_ServiceBus> options)
        {
            _options = options;
        }

        public async Task SendMessage(Usuario usuario)
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
            }
            finally
            {
                await sender.DisposeAsync();
                await client.DisposeAsync();
            }
        }
    }
}
