using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Amazon;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;

namespace ConexaoAWS
{
    public partial class InterfaceXML: Form
    {
        private DataGridView dataGridView1;
        private Button button2;
        private ProgressBar progressBar1;
        private Button button1;

        public InterfaceXML()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button2 = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1200, 585);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Abrir";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1263, 551);
            this.dataGridView1.TabIndex = 6;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(1119, 585);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 7;
            this.button2.Text = "Pesquisar Todos";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(12, 569);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(1263, 10);
            this.progressBar1.TabIndex = 8;
            // 
            // InterfaceXML
            // 
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(1287, 620);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "InterfaceXML";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.Icon = new Icon(GlobalVariables.pathImages + @"\logo.ico");
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Text = "Cadastro de Notas Fiscais";

        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.Multiselect = true;
            openFileDialog.Filter = "xml files (*.xml)|*.xml";
            openFileDialog.ShowDialog();

            LeituraNotaFiscal leituraNotaFiscal = new LeituraNotaFiscal();

            AmazonDynamoDBClient client = new AmazonDynamoDBClient();
            DynamoDBContext context = new DynamoDBContext(client);

            progressBar1.Value = 0;

            for (int i = 0; i < openFileDialog.FileNames.Count(); i++)
            {

                progressBar1.Maximum = openFileDialog.FileNames.Count()-1;

                String caminho = openFileDialog.FileNames[i].ToString();

                String nrNotaEntrega = leituraNotaFiscal.LeituraNrNota(caminho);
                String idMotorista = ComandoAWS.SearchCidades(context, "cidadeDestinatario", leituraNotaFiscal.LeituraCidadeDestinatario(caminho), "id");
                String nomeDestinatarioEntrega  = leituraNotaFiscal.LeituraNomeDestinatario(caminho);
                String remetenteEntrega = leituraNotaFiscal.LeituraCidadeRemetente(caminho);
                String destinatarioEntrega = leituraNotaFiscal.LeituraCidadeDestinatario(caminho);
                String enderecoDestinatario = leituraNotaFiscal.LeituraEnderecoDestinatario(caminho);
                String status = "Aguardando Retirada";
 
                try
                {
                    ComandoAWS.AddJob(context, nrNotaEntrega , idMotorista, nomeDestinatarioEntrega, enderecoDestinatario, destinatarioEntrega, status);
                }

                catch
                {
                    MessageBox.Show("Falha ao salvar!");
                }
              progressBar1.Value = i;
            }

            dataGridView1.DataSource = ComandoAWS.SearchDataTabelaServicos(context, "", "", "", "", "", "");

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            AmazonDynamoDBClient client = new AmazonDynamoDBClient();
            DynamoDBContext context = new DynamoDBContext(client);
            dataGridView1.DataSource = ComandoAWS.SearchDataTabelaServicos(context, "", "", "", "", "", "");
        }
    }
}
