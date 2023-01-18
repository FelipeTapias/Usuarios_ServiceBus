using System;
using System.Collections.Generic;

namespace DrivenAdapters.Sql.Context;

public partial class Usuario
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public int Documento { get; set; }

    public int Edad { get; set; }

    public int IdApartamento { get; set; }

    public virtual Apartamento IdApartamentoNavigation { get; set; } = null!;
}
