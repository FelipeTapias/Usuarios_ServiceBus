namespace Domain.Model.Entities
{
    public class ApartamentoRequest
    {
        public int Id { get; set; }

        public string Ciudad { get; set; } = null!;

        public int Telefono { get; set; }

        public int Numero { get; set; }

    }
}
