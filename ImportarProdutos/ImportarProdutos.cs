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
                //var listaDeProdutos = GetRecords<ListaDeProdutos>(txtListaDeProdutos.Text);

                //var headers = new List<string> { "Código do produto(ID Tray) - deixar sempre o número \"0\"(zero) para cadastro.", "Referência(código fornecedor)", "Nome do produto", "Código da categoria principal(ID) -Encontre o ID no painel da Tray em Produtos > Categorias", "HTML da descrição completa. INSIRA o texto entre os parâmetros.", "SEO - Descrição simplificada(até 256 caracteres)", "Preço de venda em reais", "Estoque do produto", "Prazo de disponibilidade, somente número ex: 2 ou; IMEDIATO - será contado o valor mais o prazo dos Correios.", "Peso do produto(gramas)", "Altura(cm) Largura(cm)", "Comprimento(cm)", "Marca" };

                //var lines = listaDeProdutos.Select(x => GetLine(x));

                CreateFile(txtDestinoListaDeProdutos.Text, lines);

                MessageBox.Show("Arquivo importado com sucesso!");
            }
            else
            {
                MessageBox.Show("Lista de Produtos e Destino são obrigatórios!");
            }
        }

        private string GetLine(ListaDeProdutos item)
        {
            return $"0; {item.REFERENCIA}; {item.NOMEPRODUTO}; {item.CATEGORIA}; {item.DESCRICAO}; {(item.DESCRICAO.Length >= 255 ? item.DESCRICAO[..255] : item.DESCRICAO)}; {item.PRECODROPSHIPPING}; {item.ESTOQUE}; \"IMEDIATO\"; {item.PESOGRAMAS}; {item.DIMENSAOCAIXACM}; {item.DIMENSAOCAIXACM}; {item.DIMENSAOCAIXACM}; {item.MARCA}";
        }

        private string GetLine(RangeColumn[] columns)
        {
            return $"0; {columns[0]}; {columns[1]}; {columns[2]}; {columns[8]}; {GetSEO(columns[8].ToString())}; {columns[5]}; {columns[3]}; \"IMEDIATO\"; {columns[10]}; {GetHeight(columns[9].ToString())}; {GetWidth(columns[9].ToString())}; {GetLength(columns[9].ToString())}; {columns[7]}";
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

        private RangeRow[] ReadFile(string filePath)
        {
            WorkBook workbook = WorkBook.Load(filePath);
            WorkSheet sheet = workbook.WorkSheets.First();

            return sheet.Rows;
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

        private void CreateFile(string filePath, RangeRow[] rows)
        {
            WorkBook workbook = WorkBook.Create(ExcelFileFormat.XLSX);
            var sheet = workbook.CreateWorkSheet("lista_de_produtos");

            // Save Header
            foreach (var item in rows.FirstOrDefault().Columns)
            {
                sheet["A1"].Value = item.ToString();
                sheet["B1"].Value = item.ToString();
                sheet["C1"].Value = item.ToString();
                sheet["D1"].Value = item.ToString();
                sheet["E1"].Value = item.ToString();
                sheet["F1"].Value = item.ToString();
                sheet["G1"].Value = item.ToString();
                sheet["H1"].Value = item.ToString();
                sheet["I1"].Value = item.ToString();
                sheet["K1"].Value = item.ToString();
                sheet["J1"].Value = item.ToString();
                sheet["L1"].Value = item.ToString();
                sheet["M1"].Value = item.ToString();
                sheet["N1"].Value = item.ToString();
            }


            // Save Content
            int rowIndex = 1;
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
                sheet["K" + rowIndex].Value = row.Columns[10].ToString();
                sheet["J" + rowIndex].Value = GetHeight(row.Columns[9].ToString());
                sheet["L" + rowIndex].Value = GetWidth(row.Columns[9].ToString());
                sheet["M" + rowIndex].Value = GetLength(row.Columns[9].ToString());
                sheet["N" + rowIndex].Value = row.Columns[7].ToString();

                rowIndex++;
            }

            workbook.SaveAs(filePath);
        }
    }
}