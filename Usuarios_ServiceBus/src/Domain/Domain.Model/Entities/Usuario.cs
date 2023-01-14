using Domain.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
