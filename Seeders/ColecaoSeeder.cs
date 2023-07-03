using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Project_md2.Database;
using Project_md2.Models;
using Project_md2.Models.Enum;

namespace Project_md2.Seeders
{
    public interface IColecoesSeeder
    {
        void SeedColecoes();
    }

    public class ColecoesSeeder : IColecoesSeeder
    {
        private readonly FashionContext _context;

        public ColecoesSeeder(FashionContext context)
        {
            _context = context;
        }

        public void SeedColecoes()
        {
            if (!_context.Colecoes.Any())
            {
                var colecoes = new List<Colecao>
                {
                    new Colecao
                    {
                        NomeColecao = "Coleção Verão 2023",
                        IdResponsavel = 1,
                        Marca = "Marca A",
                        Orcamento = 22500.0,
                        AnoLancamento = new DateTime(2023, 1, 1),
                        Estacao = Estacao.Verao,
                        EstadoSistema = EstadoSistema.Ativo
                    },
                    new Colecao
                    {
                        NomeColecao = "Coleção Primavera 2024",
                        IdResponsavel = 2,
                        Marca = "Marca Balmein",
                        Orcamento = 60200.0,
                        AnoLancamento = new DateTime(2023, 6, 1),
                        Estacao = Estacao.Inverno,
                        EstadoSistema = EstadoSistema.Ativo
                    },
                    new Colecao
                    {
                        NomeColecao = "Coleção inverno 2024",
                        IdResponsavel = 3,
                        Marca = "Marca Nike",
                        Orcamento = 10310.0,
                        AnoLancamento = new DateTime(2023, 9, 1),
                        Estacao = Estacao.Primavera,
                        EstadoSistema = EstadoSistema.Ativo
                    },
                    new Colecao
                    {
                        NomeColecao = "Coleção Outono 2023",
                        IdResponsavel = 4,
                        Marca = "Marca Adidas",
                        Orcamento = 5008.0,
                        AnoLancamento = new DateTime(2023, 12, 1),
                        Estacao = Estacao.Verao,
                        EstadoSistema = EstadoSistema.Ativo
                    }
                };

                _context.Colecoes.AddRange(colecoes);
                _context.SaveChanges();
            }
        }
    }
}
