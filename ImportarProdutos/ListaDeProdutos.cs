using CsvHelper.Configuration.Attributes;

namespace ImportarProdutos
{
    public class ListaDeProdutos
    {
        [Name("REFERÊNCIA")]
        public string REFERENCIA { get; set; }
        public string NOMEPRODUTO { get; set; }
        public string CATEGORIA { get; set; }
        public string ESTOQUE { get; set; }
        public string PRECOATACADO { get; set; }
        public string PRECODROPSHIPPING { get; set; }
        public string STATUSPROMOCAO { get; set; }
        public string MARCA { get; set; }
        public string DESCRICAO { get; set; }
        public string DIMENSAOCAIXACM { get; set; }
        public string PESOGRAMAS { get; set; }
        public string DATACADASTRO { get; set; }
        public string REPOSICAOESTOQUE { get; set; }
        public string URLPRODUTO { get; set; }
        public string FOTOS { get; set; }
    }
}
