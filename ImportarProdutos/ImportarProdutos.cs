using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;
using System.Text;

namespace ImportarProdutos
{
    public partial class ImportarProdutos : Form
    {
        public ImportarProdutos()
        {
            InitializeComponent();
        }

        private void btnImportar_Click(object sender, EventArgs e)
        {
            var listaDeProdutos = GetRecords<ListaDeProdutos>(txtListaDeProdutos.Text);

            var headers = new List<string> { "Código do produto(ID Tray) - deixar sempre o número \"0\"(zero) para cadastro.", "Referência(código fornecedor)", "Nome do produto", "Código da categoria principal(ID) -Encontre o ID no painel da Tray em Produtos > Categorias", "HTML da descrição completa. INSIRA o texto entre os parâmetros.", "SEO - Descrição simplificada(até 256 caracteres)", "Preço de venda em reais", "Estoque do produto", "Prazo de disponibilidade, somente número ex: 2 ou; IMEDIATO - será contado o valor mais o prazo dos Correios.", "Peso do produto(gramas)", "Altura(cm) Largura(cm)", "Comprimento(cm)", "Marca"};

            var lines = listaDeProdutos.Select(x => GetLine(x));

            CreateFile(txtDestinoListaDeProdutos.Text, headers, lines);
        }

        private string GetLine(ListaDeProdutos item)
        {
            return $"0; {item.REFERENCIA}; {item.NOMEPRODUTO}; {item.CATEGORIA}; {item.DESCRICAO}; {item.DESCRICAO.Substring(0, 255)}; {item.PRECODROPSHIPPING}; {item.ESTOQUE}; IMEDIATO; {item.PESOGRAMAS}; {item.DIMENSAOCAIXACM}; {item.DIMENSAOCAIXACM}; {item.DIMENSAOCAIXACM}; {item.MARCA}";
        }

        private void btnSelecionarListaDeProdutos_Click(object sender, EventArgs e)
        {
            if (selecionarListaDeProdutosDialog.ShowDialog() == DialogResult.OK)
            {
                txtListaDeProdutos.Text = selecionarListaDeProdutosDialog.FileName;
            }
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSelecionarDestinoListaDeProdutos_Click(object sender, EventArgs e)
        {
            if (salvarListaDeProdutosDialog.ShowDialog(this) == DialogResult.OK)
            {
                txtDestinoListaDeProdutos.Text = salvarListaDeProdutosDialog.FileName;
            }
        }

        private IEnumerable<T> GetRecords<T>(string filePath)
        {
            List<T> list = new();
            var config = new CsvConfiguration(CultureInfo.InvariantCulture) { Delimiter = ";", Encoding = Encoding.UTF8 };
            using (var reader = new StreamReader(filePath))
            using (var csv = new CsvReader(reader, config))
            {
                list = csv.GetRecords<T>().ToList();
            }

            return list;
        }

        private void CreateFile(string filePath, IEnumerable<string> headers, IEnumerable<string> lines)
        {
            using (var w = new StreamWriter(filePath))
            {
                // Create Headers
                w.WriteLine(string.Join(";", headers));

                // Create Content
                foreach (var line in lines.Skip(1).ToList())
                {
                    w.WriteLine(line);
                    w.Flush();
                }
            }
        }
    }
}