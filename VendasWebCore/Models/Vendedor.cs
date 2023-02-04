using System.ComponentModel.DataAnnotations;

namespace VendasWebCore.Models
{
    public class Vendedor
    {

        public int Id { get; set; }
        public string Nome { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display(Name = "Salario base")]
        [DisplayFormat(DataFormatString ="{0:F2}")]
        public double SalarioBase { get; set; }

        [Display(Name = "Data de nascimento")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DataNascimento { get; set;}

        public Departamento Dep { get; set; }

        public int DepId { get; set; }

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
