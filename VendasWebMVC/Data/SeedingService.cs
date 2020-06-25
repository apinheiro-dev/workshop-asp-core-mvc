using System;
using System.Linq;
using VendasWebMVC.Models;
using VendasWebMVC.Models.Enums;

namespace VendasWebMVC.Data
{
    public class SeedingService
    {
        private VendasWebMVCContext _contexto;

        //Injeção de dependência - Quando o centext for criado ele recebe uma instancia do context também
        public SeedingService(VendasWebMVCContext contexto)
        {
            _contexto = contexto;
        }

        //Responsável por popular a minha base de dados
        public void Seed()
        {
            if (_contexto.Departamento.Any() || _contexto.Vendedor.Any() || _contexto.RegistroVendas.Any())
            {
                return; //A base de dados já foi populada.
            }

            Departamento d1 = new Departamento { Nome = "Computadores" };
            Departamento d2 = new Departamento { Nome = "Eletrônicos" };
            Departamento d3 = new Departamento { Nome = "Vestuário" };
            Departamento d4 = new Departamento { Nome = "Livros" };


            Vendedor v1 = new Vendedor { Nome = "Marcelo Ronaldo", Email = "mronaldo@gmail.com", DataNascimento = new DateTime(1996, 4, 22), Salario = 1000.0, Departamento = d1 };
            Vendedor v2 = new Vendedor { Nome = "Carlos Magno", Email = "cmagno@gmail.com", DataNascimento = new DateTime(1980, 6, 15), Salario = 3800.0, Departamento = d2 };
            Vendedor v3 = new Vendedor { Nome = "Marco Antônio", Email = "manto@gmail.com", DataNascimento = new DateTime(1978, 4, 15), Salario = 4650.0, Departamento = d1 };
            Vendedor v4 = new Vendedor { Nome = "Cristina Aguillar", Email = "aguillar@gmail.com", DataNascimento = new DateTime(1986, 10, 3), Salario = 1800.0, Departamento = d3 };
            Vendedor v5 = new Vendedor { Nome = "Cintia Moraes", Email = "cmoraes@gmail.com", DataNascimento = new DateTime(1988, 2, 14), Salario = 5500.0, Departamento = d2 };
            Vendedor v6 = new Vendedor { Nome = "Flavia Carla", Email = "flaviac@gmail.com", DataNascimento = new DateTime(1991, 11, 9), Salario = 1450.0, Departamento = d3 };
            Vendedor v7 = new Vendedor { Nome = "Otávio Mota", Email = "omota@gmail.com", DataNascimento = new DateTime(1990, 10, 22), Salario = 1480.0, Departamento = d4 };
            Vendedor v8 = new Vendedor { Nome = "Omar Romero", Email = "oreo@gmail.com", DataNascimento = new DateTime(1977, 4, 12), Salario = 5500.0, Departamento = d4 };
            Vendedor v9 = new Vendedor { Nome = "Cristiano Barreto", Email = "cbarreto@gmail.com", DataNascimento = new DateTime(1979, 6, 4), Salario = 5200.0, Departamento = d1 };
            Vendedor v10 = new Vendedor { Nome = "Marcela Novaes", Email = "mnavi@gmail.com", DataNascimento = new DateTime(1983, 4, 6), Salario = 4100.0, Departamento = d3 };


            RegistroVendas rv1 = new RegistroVendas { Data = new DateTime(2018, 09, 25), Quantidade = 11000.0, Status = VendaStatus.Faturado, Vendedor = v3 };
            RegistroVendas rv2 = new RegistroVendas { Data = new DateTime(2018, 09, 4), Quantidade = 7000.0, Status = VendaStatus.Faturado, Vendedor = v5 };
            RegistroVendas rv3 = new RegistroVendas { Data = new DateTime(2018, 09, 13), Quantidade = 4000.0, Status = VendaStatus.Cancelado, Vendedor = v7 };
            RegistroVendas rv4 = new RegistroVendas { Data = new DateTime(2018, 09, 1), Quantidade = 8000.0, Status = VendaStatus.Faturado, Vendedor = v9 };
            RegistroVendas rv5 = new RegistroVendas { Data = new DateTime(2018, 09, 21), Quantidade = 3000.0, Status = VendaStatus.Faturado, Vendedor = v3 };
            RegistroVendas rv6 = new RegistroVendas { Data = new DateTime(2018, 09, 15), Quantidade = 2000.0, Status = VendaStatus.Faturado, Vendedor = v4 };
            RegistroVendas rv7 = new RegistroVendas { Data = new DateTime(2018, 09, 28), Quantidade = 13000.0, Status = VendaStatus.Faturado, Vendedor = v7 };
            RegistroVendas rv8 = new RegistroVendas { Data = new DateTime(2018, 09, 11), Quantidade = 4000.0, Status = VendaStatus.Faturado, Vendedor = v9 };
            RegistroVendas rv9 = new RegistroVendas { Data = new DateTime(2018, 09, 14), Quantidade = 11025.0, Status = VendaStatus.Pendente, Vendedor = v8 };
            RegistroVendas rv10 = new RegistroVendas { Data = new DateTime(2018, 09, 7), Quantidade = 9035.0, Status = VendaStatus.Faturado, Vendedor = v6 };
            RegistroVendas rv11 = new RegistroVendas { Data = new DateTime(2018, 09, 13), Quantidade = 6056.0, Status = VendaStatus.Faturado, Vendedor = v3 };
            RegistroVendas rv12 = new RegistroVendas { Data = new DateTime(2018, 09, 25), Quantidade = 7055.0, Status = VendaStatus.Pendente, Vendedor = v2 };
            RegistroVendas rv13 = new RegistroVendas { Data = new DateTime(2018, 09, 29), Quantidade = 10044.0, Status = VendaStatus.Faturado, Vendedor = v10 };
            RegistroVendas rv14 = new RegistroVendas { Data = new DateTime(2018, 09, 4), Quantidade = 3005.0, Status = VendaStatus.Faturado, Vendedor = v5 };
            RegistroVendas rv15 = new RegistroVendas { Data = new DateTime(2018, 09, 12), Quantidade = 4005.0, Status = VendaStatus.Faturado, Vendedor = v1 };
            RegistroVendas rv16 = new RegistroVendas { Data = new DateTime(2018, 10, 5), Quantidade = 2005.0, Status = VendaStatus.Faturado, Vendedor = v10};
            RegistroVendas rv17 = new RegistroVendas { Data = new DateTime(2018, 10, 1), Quantidade = 12025.0, Status = VendaStatus.Faturado, Vendedor = v8};
            RegistroVendas rv18 = new RegistroVendas { Data = new DateTime(2018, 10, 24), Quantidade = 6015.0, Status = VendaStatus.Faturado, Vendedor = v6};
            RegistroVendas rv19 = new RegistroVendas { Data = new DateTime(2018, 10, 22), Quantidade = 8005.0, Status = VendaStatus.Faturado, Vendedor = v4 };
            RegistroVendas rv20 = new RegistroVendas { Data = new DateTime(2018, 10, 15), Quantidade = 8035.0, Status = VendaStatus.Faturado, Vendedor = v2 };
            RegistroVendas rv21 = new RegistroVendas { Data = new DateTime(2018, 10, 17), Quantidade = 9005.0, Status = VendaStatus.Faturado, Vendedor = v10 };
            RegistroVendas rv22 = new RegistroVendas { Data = new DateTime(2018, 10, 24), Quantidade = 4085.0, Status = VendaStatus.Faturado, Vendedor = v9 };
            RegistroVendas rv23 = new RegistroVendas { Data = new DateTime(2018, 10, 19), Quantidade = 11095.0, Status = VendaStatus.Cancelado, Vendedor = v8 };
            RegistroVendas rv24 = new RegistroVendas { Data = new DateTime(2018, 10, 12), Quantidade = 8075.0, Status = VendaStatus.Faturado, Vendedor = v7 };
            RegistroVendas rv25 = new RegistroVendas { Data = new DateTime(2018, 10, 31), Quantidade = 7045.0, Status = VendaStatus.Faturado, Vendedor = v5 };
            RegistroVendas rv26 = new RegistroVendas { Data = new DateTime(2018, 10, 6), Quantidade = 5065.0, Status = VendaStatus.Faturado, Vendedor = v5 };
            RegistroVendas rv27 = new RegistroVendas { Data = new DateTime(2018, 10, 13), Quantidade = 9010.0, Status = VendaStatus.Pendente, Vendedor = v4 };
            RegistroVendas rv28 = new RegistroVendas { Data = new DateTime(2018, 10, 7), Quantidade = 4020.0, Status = VendaStatus.Faturado, Vendedor = v3 };
            RegistroVendas rv29 = new RegistroVendas { Data = new DateTime(2018, 10, 23), Quantidade = 12030.0, Status = VendaStatus.Faturado, Vendedor = v2 };
            RegistroVendas rv30 = new RegistroVendas { Data = new DateTime(2018, 10, 12), Quantidade = 5040.0, Status = VendaStatus.Faturado, Vendedor = v1 };

            _contexto.Departamento.AddRange(d1,d2,d3,d4);

            _contexto.Vendedor.AddRange(v1, v2, v3, v4, v5,  v6, v7, v8, v9, v10);

            _contexto.RegistroVendas.AddRange(
                rv1, rv2, rv3, rv4, rv5, rv6, rv7, rv8, rv9, rv10,
                rv11, rv12, rv13, rv14, rv15, rv16, rv17, rv18, rv19, rv20,
                rv21, rv22, rv23, rv24, rv25, rv26, rv27, rv28, rv29, rv30
            );

            _contexto.SaveChanges();

        }

    }
}
