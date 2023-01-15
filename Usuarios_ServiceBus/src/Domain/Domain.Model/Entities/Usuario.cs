using Domain.Model.Interfaces;

namespace Domain.Model.Entities
{
    public class Usuario: IUsuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int Documento { get; set; }
        public int Edad { get; set; }
        public int Id_Apartamento { get; set; }
    }
}
