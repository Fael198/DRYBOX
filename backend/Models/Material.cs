using System;


namespace DRYBOX.Models
{

    public class Material
    {
        public int Id { get; set; }

        public string PartNumber { get; set; }

        public int Quantidade { get; set; } 

        public int QuantidadeMinima { get; set; }

        public int QuantidadeMaxima { get; set; }

        public string Descricao { get; set; }

        public Estoque Estoque  { get; set; }

        public Fornecedor Fornecedor  { get; set; }
        
        public Categoria Categoria { get; set; }
    }
}