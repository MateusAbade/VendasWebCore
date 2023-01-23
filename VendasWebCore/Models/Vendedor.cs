namespace VendasWebCore.Models
{
    public class Vendedor
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public double SalarioBase { get; set; }
        public DateTime DataNascimento { get; set;}

        public Departamento Dep { get; set; }
        public ICollection<Vendas> Venda { get; set; } = new List<Vendas>();

        public Vendedor()
        {
        }

        public Vendedor(int id, string nome, string email, double salarioBase, DateTime dataNascimento, Departamento dep)
        {
            Id = id;
            Nome = nome;
            Email = email;
            SalarioBase = salarioBase;
            DataNascimento = dataNascimento;
            Dep = dep;
        }

        public void AddVenda(Vendas vendas)
        {
            Venda.Add(vendas);
        }

        public void RemoveVenda(Vendas vendas)
        {
            Venda.Remove(vendas);
        }

        public double Totalvendas(DateTime inicial, DateTime final)
        {
            return Venda.Where(vendas => vendas.Data >= inicial && vendas.Data <= final).Sum(vendas => vendas.Montante);
        }

    }
}
