using VendasWebCore.Models.Enums;
namespace VendasWebCore.Models
{
    public class Vendas
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public double Montante { get; set; }

        public StatusVenda Status { get; set;}

        public Vendedor vendedores { get; set; }

        public Vendas()
        {
        }

        public Vendas(int id, DateTime data, double montante, StatusVenda status, Vendedor vendedores)
        {
            Id = id;
            Data = data;
            Montante = montante;
            Status = status;
            this.vendedores = vendedores;
        }
    }
}
