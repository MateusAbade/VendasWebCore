
namespace VendasWebCore.Models.ViewModels
{
    public class FormVendedorViewModel
    {
        public Vendedor Vendedor { get; set; }
        public ICollection<Departamento> Departamentos { get; set; }

    }
}
