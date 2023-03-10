using VendasWebCore.Models;
using VendasWebCore.Models.Enums;

namespace VendasWebCore.Data
{
    public class SeedingService
    {

        public static void Seed(VendasWebCoreContext context)
        {
            if(context.Departamento.Any() || context.Vendas.Any() || context.Vendedor.Any() ) 
            {
                return;
            }

            Departamento d1 = new Departamento(1, "Financeiro");
            Departamento d2 = new Departamento(2, "Faturamento");

            Vendedor ven1 = new Vendedor(1, "Mateus", "exemplo@exemplo.com", 2.200, new DateTime(1991, 08, 17), d1);
            Vendas v1 = new Vendas(1, new DateTime(2023, 01, 17), 2.000, StatusVenda.Faturado, ven1);
            Vendas v2 = new Vendas(2, new DateTime(2023, 02, 1), 2.000, StatusVenda.Faturado, ven1);
            Vendas v3 = new Vendas(3, new DateTime(2023, 01, 20), 2.000, StatusVenda.Faturado, ven1);

            context.Departamento.AddRange(d1, d2);
            context.Vendedor.AddRange(ven1);
            context.Vendas.AddRange(v1, v2, v3);

            context.SaveChanges();
        }

    }
}
