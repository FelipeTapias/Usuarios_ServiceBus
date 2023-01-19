namespace DrivenAdapters.Sql.Context;

public partial class Apartamento
{
    public int Id { get; set; }

    public string Ciudad { get; set; } = null!;

    public int Telefono { get; set; }

    public int Numero { get; set; }

    public virtual ICollection<Usuario> Usuarios { get; } = new List<Usuario>();
}
