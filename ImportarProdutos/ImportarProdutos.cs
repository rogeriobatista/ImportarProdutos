using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;
using System.Text;
using IronXL;
using System.Linq;

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

            if (!string.IsNullOrWhiteSpace(txtListaDeProdutos.Text) && !string.IsNullOrWhiteSpace(txtDestinoListaDeProdutos.Text))
            {
                var lines = ReadFile(txtListaDeProdutos.Text);

                CreateFile(txtDestinoListaDeProdutos.Text, lines);

                MessageBox.Show("Arquivo importado com sucesso!");
            }
            else
            {
                MessageBox.Show("Lista de Produtos e Destino são obrigatórios!");
            }
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

        private RangeRow[] ReadFile(string filePath)
        {
            WorkBook workbook = WorkBook.Load(filePath);
            WorkSheet sheet = workbook.WorkSheets.First();

            return sheet.Rows;
        }

        private void CreateFile(string filePath, RangeRow[] rows)
        {
            WorkBook workbook = WorkBook.Create(ExcelFileFormat.XLSX);
            var sheet = workbook.CreateWorkSheet("lista_de_produtos");

            var header = rows.FirstOrDefault().Columns;
            // Save Header
            sheet["A1"].Value = "Código do produto (ID Tray) - deixar sempre o número \"0\" (zero) para cadastro.";
            sheet["B1"].Value = "Referência (código fornecedor)";
            sheet["C1"].Value = "Nome do produto";
            sheet["D1"].Value = "Código da categoria principal (ID) - Encontre o ID no painel da Tray em Produtos > Categorias";
            sheet["E1"].Value = "HTML da descrição completa. INSIRA o texto entre os parâmetros.";
            sheet["F1"].Value = "SEO - Descrição simplificada (até 256 caracteres)";
            sheet["G1"].Value = "Preço de venda em reais";
            sheet["H1"].Value = "Estoque do produto";
            sheet["I1"].Value = "Prazo de disponibilidade, somente número ex: 2 ou; IMEDIATO - será contado o valor mais o prazo dos Correios.";
            sheet["J1"].Value = "Peso do produto (gramas)";
            sheet["K1"].Value = "Altura (cm)";
            sheet["L1"].Value = "Largura (cm)";
            sheet["M1"].Value = "Comprimento (cm)";
            sheet["N1"].Value = "Marca";
            sheet["O1"].Value = "Foto";


            // Save Content
            int rowIndex = 2;
            foreach (var row in rows.Skip(1))
            {
                sheet["A" + rowIndex].Value = "0";
                sheet["B" + rowIndex].Value = row.Columns[0].ToString();
                sheet["C" + rowIndex].Value = row.Columns[1].ToString();
                sheet["D" + rowIndex].Value = row.Columns[2].ToString();
                sheet["E" + rowIndex].Value = row.Columns[8].ToString();
                sheet["F" + rowIndex].Value = GetSEO(row.Columns[8].ToString());
                sheet["G" + rowIndex].Value = row.Columns[5].ToString();
                sheet["H" + rowIndex].Value = row.Columns[3].ToString();
                sheet["I" + rowIndex].Value = "IMEDIATO";
                sheet["J" + rowIndex].Value = row.Columns[10].ToString();
                sheet["K" + rowIndex].Value = GetHeight(row.Columns[9].ToString());
                sheet["L" + rowIndex].Value = GetWidth(row.Columns[9].ToString());
                sheet["M" + rowIndex].Value = GetLength(row.Columns[9].ToString());
                sheet["N" + rowIndex].Value = row.Columns[7].ToString();
                sheet["O" + rowIndex].Value = GetImage(row.Columns[14].ToString());

                rowIndex++;
            }

            workbook.SaveAs(filePath);
        }

        private decimal GetHeight(string dimensions)
        {
            var height = Convert.ToDecimal(dimensions.Trim().Split("x").LastOrDefault());
            return Math.Round(height);
        }

        private decimal GetWidth(string dimensions)
        {
            var width = Convert.ToDecimal(dimensions.Trim().Split("x")[1]);
            return Math.Round(width);
        }

        private decimal GetLength(string dimensions)
        {
            var length = Convert.ToDecimal(dimensions.Trim().Split("x")[0]);
            return Math.Round(length);
        }

        private string GetSEO(string text)
        {
            return text.Length >= 255 ? text[..255] : text;
        }

        private string GetImage(string content)
        {
            return content.Split(',').FirstOrDefault() ?? string.Empty;
        }

        private void ImportarProdutos_Load(object sender, EventArgs e)
        {

        }
    }
}