namespace ImportarProdutos
{
    partial class ImportarProdutos
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnImportar = new System.Windows.Forms.Button();
            this.txtListaDeProdutos = new System.Windows.Forms.TextBox();
            this.btnSelecionarListaDeProdutos = new System.Windows.Forms.Button();
            this.lblListaDeProdutos = new System.Windows.Forms.Label();
            this.selecionarListaDeProdutosDialog = new System.Windows.Forms.OpenFileDialog();
            this.salvarListaDeProdutosDialog = new System.Windows.Forms.SaveFileDialog();
            this.txtDestinoListaDeProdutos = new System.Windows.Forms.TextBox();
            this.lblSelecionarDestino = new System.Windows.Forms.Label();
            this.btnSelecionarDestinoListaDeProdutos = new System.Windows.Forms.Button();
            this.btnSair = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnImportar
            // 
            this.btnImportar.Location = new System.Drawing.Point(291, 181);
            this.btnImportar.Name = "btnImportar";
            this.btnImportar.Size = new System.Drawing.Size(75, 23);
            this.btnImportar.TabIndex = 0;
            this.btnImportar.Text = "Importar";
            this.btnImportar.UseVisualStyleBackColor = true;
            this.btnImportar.Click += new System.EventHandler(this.btnImportar_Click);
            // 
            // txtListaDeProdutos
            // 
            this.txtListaDeProdutos.Location = new System.Drawing.Point(12, 29);
            this.txtListaDeProdutos.Name = "txtListaDeProdutos";
            this.txtListaDeProdutos.Size = new System.Drawing.Size(354, 23);
            this.txtListaDeProdutos.TabIndex = 1;
            // 
            // btnSelecionarListaDeProdutos
            // 
            this.btnSelecionarListaDeProdutos.Location = new System.Drawing.Point(372, 29);
            this.btnSelecionarListaDeProdutos.Name = "btnSelecionarListaDeProdutos";
            this.btnSelecionarListaDeProdutos.Size = new System.Drawing.Size(75, 23);
            this.btnSelecionarListaDeProdutos.TabIndex = 2;
            this.btnSelecionarListaDeProdutos.Text = "Selecionar";
            this.btnSelecionarListaDeProdutos.UseVisualStyleBackColor = true;
            this.btnSelecionarListaDeProdutos.Click += new System.EventHandler(this.btnSelecionarListaDeProdutos_Click);
            // 
            // lblListaDeProdutos
            // 
            this.lblListaDeProdutos.AutoSize = true;
            this.lblListaDeProdutos.Location = new System.Drawing.Point(12, 9);
            this.lblListaDeProdutos.Name = "lblListaDeProdutos";
            this.lblListaDeProdutos.Size = new System.Drawing.Size(98, 15);
            this.lblListaDeProdutos.TabIndex = 3;
            this.lblListaDeProdutos.Text = "Lista de Produtos";
            // 
            // selecionarListaDeProdutosDialog
            // 
            this.selecionarListaDeProdutosDialog.FileName = "selecionarListaDeProdutosDialog";
            // 
            // txtDestinoListaDeProdutos
            // 
            this.txtDestinoListaDeProdutos.Location = new System.Drawing.Point(10, 98);
            this.txtDestinoListaDeProdutos.Name = "txtDestinoListaDeProdutos";
            this.txtDestinoListaDeProdutos.Size = new System.Drawing.Size(356, 23);
            this.txtDestinoListaDeProdutos.TabIndex = 4;
            // 
            // lblSelecionarDestino
            // 
            this.lblSelecionarDestino.AutoSize = true;
            this.lblSelecionarDestino.Location = new System.Drawing.Point(12, 80);
            this.lblSelecionarDestino.Name = "lblSelecionarDestino";
            this.lblSelecionarDestino.Size = new System.Drawing.Size(103, 15);
            this.lblSelecionarDestino.TabIndex = 5;
            this.lblSelecionarDestino.Text = "Selecionar destino";
            // 
            // btnSelecionarDestinoListaDeProdutos
            // 
            this.btnSelecionarDestinoListaDeProdutos.Location = new System.Drawing.Point(372, 98);
            this.btnSelecionarDestinoListaDeProdutos.Name = "btnSelecionarDestinoListaDeProdutos";
            this.btnSelecionarDestinoListaDeProdutos.Size = new System.Drawing.Size(75, 23);
            this.btnSelecionarDestinoListaDeProdutos.TabIndex = 6;
            this.btnSelecionarDestinoListaDeProdutos.Text = "Selecionar";
            this.btnSelecionarDestinoListaDeProdutos.UseVisualStyleBackColor = true;
            this.btnSelecionarDestinoListaDeProdutos.Click += new System.EventHandler(this.btnSelecionarDestinoListaDeProdutos_Click);
            // 
            // btnSair
            // 
            this.btnSair.Location = new System.Drawing.Point(372, 181);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(75, 23);
            this.btnSair.TabIndex = 7;
            this.btnSair.Text = "Sair";
            this.btnSair.UseVisualStyleBackColor = true;
            this.btnSair.Click += new System.EventHandler(this.btnSair_Click);
            // 
            // ImportarProdutos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(459, 216);
            this.Controls.Add(this.btnSair);
            this.Controls.Add(this.btnSelecionarDestinoListaDeProdutos);
            this.Controls.Add(this.lblSelecionarDestino);
            this.Controls.Add(this.txtDestinoListaDeProdutos);
            this.Controls.Add(this.lblListaDeProdutos);
            this.Controls.Add(this.btnSelecionarListaDeProdutos);
            this.Controls.Add(this.txtListaDeProdutos);
            this.Controls.Add(this.btnImportar);
            this.MaximizeBox = false;
            this.Name = "ImportarProdutos";
            this.Text = "Importar Produtos";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button btnImportar;
        private TextBox txtListaDeProdutos;
        private Button btnSelecionarListaDeProdutos;
        private Label lblListaDeProdutos;
        private OpenFileDialog selecionarListaDeProdutosDialog;
        private SaveFileDialog salvarListaDeProdutosDialog;
        private TextBox txtDestinoListaDeProdutos;
        private Label lblSelecionarDestino;
        private Button btnSelecionarDestinoListaDeProdutos;
        private Button btnSair;
    }
}