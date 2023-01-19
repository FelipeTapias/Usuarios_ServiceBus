namespace Domain.Model.Interfaces
{
    public interface IUsuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int Documento { get; set; }
        public int Edad { get; set; }
        public int IdApartamento { get; set; }
    }
}