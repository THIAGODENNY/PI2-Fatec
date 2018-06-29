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
    public partial class InterfaceConsultaOrdensServicos: Form
    {
        private Button button2;
        private ComboBox comboBox1;
        private Label label2;
        private ComboBox comboBox2;
        private Label label1;
        private TextBox cidadeDestinatario;
        private TextBox idFuncionario;
        private TextBox xml;
        private Label label3;
        private ComboBox comboBox3;
        private TextBox status;
        private Label label4;
        private DataGridView dataGridView1;

        public InterfaceConsultaOrdensServicos()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button2 = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cidadeDestinatario = new System.Windows.Forms.TextBox();
            this.idFuncionario = new System.Windows.Forms.TextBox();
            this.xml = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.status = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 149);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1263, 459);
            this.dataGridView1.TabIndex = 7;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(677, 119);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 8;
            this.button2.Text = "Pesquisar Todos";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(586, 65);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(354, 21);
            this.comboBox1.TabIndex = 20;
            this.comboBox1.DropDown += new System.EventHandler(this.comboBox1_DropDown);
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(408, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 13);
            this.label2.TabIndex = 19;
            this.label2.Text = "id Funcionario";
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(586, 38);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(354, 21);
            this.comboBox2.TabIndex = 21;
            this.comboBox2.DropDown += new System.EventHandler(this.comboBox2_DropDown);
            this.comboBox2.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(382, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 13);
            this.label1.TabIndex = 22;
            this.label1.Text = "Cidade Destinatario";
            // 
            // cidadeDestinatario
            // 
            this.cidadeDestinatario.Location = new System.Drawing.Point(484, 39);
            this.cidadeDestinatario.Name = "cidadeDestinatario";
            this.cidadeDestinatario.Size = new System.Drawing.Size(100, 20);
            this.cidadeDestinatario.TabIndex = 23;
            // 
            // idFuncionario
            // 
            this.idFuncionario.Location = new System.Drawing.Point(484, 66);
            this.idFuncionario.Name = "idFuncionario";
            this.idFuncionario.Size = new System.Drawing.Size(100, 20);
            this.idFuncionario.TabIndex = 24;
            // 
            // xml
            // 
            this.xml.Location = new System.Drawing.Point(484, 12);
            this.xml.Name = "xml";
            this.xml.Size = new System.Drawing.Size(456, 20);
            this.xml.TabIndex = 25;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(456, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(22, 13);
            this.label3.TabIndex = 22;
            this.label3.Text = "xml";
            // 
            // comboBox3
            // 
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Location = new System.Drawing.Point(586, 92);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(354, 21);
            this.comboBox3.TabIndex = 26;
            this.comboBox3.DropDown += new System.EventHandler(this.comboBox3_DropDown);
            this.comboBox3.SelectedIndexChanged += new System.EventHandler(this.comboBox3_SelectedIndexChanged);
            // 
            // status
            // 
            this.status.Location = new System.Drawing.Point(484, 93);
            this.status.Name = "status";
            this.status.Size = new System.Drawing.Size(100, 20);
            this.status.TabIndex = 27;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(443, 95);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 19;
            this.label4.Text = "status";
            // 
            // InterfaceConsultaOrdensServicos
            // 
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(1287, 620);
            this.Controls.Add(this.status);
            this.Controls.Add(this.comboBox3);
            this.Controls.Add(this.xml);
            this.Controls.Add(this.idFuncionario);
            this.Controls.Add(this.cidadeDestinatario);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "InterfaceConsultaOrdensServicos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
            this.Icon = new Icon(GlobalVariables.pathImages + @"\logo.ico");
            this.Text = "Consulta Ordens de Serviço";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AmazonDynamoDBClient client = new AmazonDynamoDBClient();
            DynamoDBContext context = new DynamoDBContext(client);

            try
            {
                if (idFuncionario.Text != "")
                {
                    dataGridView1.DataSource = ComandoAWS.SearchDataTabelaServicos(context, "", idFuncionario.Text, "", "", "", "");
                }
                else if (cidadeDestinatario.Text != "")
                {
                    dataGridView1.DataSource = ComandoAWS.SearchDataTabelaServicos(context, "", "", cidadeDestinatario.Text, "", "", "");

                }
                else if (xml.Text != "")
                {
                    dataGridView1.DataSource = ComandoAWS.SearchDataTabelaServicos(context, xml.Text, "" , "" , "" , "" , "");
                }
                else
                {
                    dataGridView1.DataSource = ComandoAWS.SearchDataTabelaServicos(context, "", "" , "", "", "", "");
                }

                idFuncionario.Clear();
                cidadeDestinatario.Clear();
                status.Clear();
                comboBox1.SelectedIndex = -1;
                comboBox2.SelectedIndex = -1;
                comboBox3.SelectedIndex = -1;

            }



            catch
            {
                Console.WriteLine("Erro na busca!");
            }


        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex != -1)
            {
                AmazonDynamoDBClient client = new AmazonDynamoDBClient();
                DynamoDBContext context = new DynamoDBContext(client);
                idFuncionario.Text = ComandoAWS.SearchFuncionarios(context , "nome", comboBox1.SelectedItem.ToString(), "id");
            }

        }

        private void comboBox1_DropDown(object sender, System.EventArgs e)
        {
            AmazonDynamoDBClient client = new AmazonDynamoDBClient();
            DynamoDBContext context = new DynamoDBContext(client);

            comboBox1.Items.Clear();

            List<Funcionarios> asList = ComandoAWS.SearchDataTabelaFuncionarios(context, "", "");

            for (int i = 0; i < asList.Count(); i++)
            {
                comboBox1.Items.Add(asList[i].nome);
            }

        }

        private void idFuncionario_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.SelectedIndex != -1)
            {
                AmazonDynamoDBClient client = new AmazonDynamoDBClient();
                DynamoDBContext context = new DynamoDBContext(client);
                cidadeDestinatario.Text = comboBox2.SelectedItem.ToString();
            }

        }

        private void comboBox2_DropDown(object sender, System.EventArgs e)
        {
            AmazonDynamoDBClient client = new AmazonDynamoDBClient();
            DynamoDBContext context = new DynamoDBContext(client);

            comboBox1.Items.Clear();

            List<Servicos> asList = ComandoAWS.SearchDataTabelaServicos(context, "", "","","","","");

            for (int i = 0; i < asList.Count(); i++)
            {
                if(!comboBox2.Items.Contains(asList[i].cidadeDestinatario))
                comboBox2.Items.Add(asList[i].cidadeDestinatario);
            }

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox3.SelectedIndex != -1)
            {
                AmazonDynamoDBClient client = new AmazonDynamoDBClient();
                DynamoDBContext context = new DynamoDBContext(client);
                status.Text = comboBox3.SelectedItem.ToString();
            }
        }

        private void comboBox3_DropDown(object sender, System.EventArgs e)
        {
            AmazonDynamoDBClient client = new AmazonDynamoDBClient();
            DynamoDBContext context = new DynamoDBContext(client);

            comboBox1.Items.Clear();

            List<Servicos> asList = ComandoAWS.SearchDataTabelaServicos(context, "", "", "", "", "", "");

            for (int i = 0; i < asList.Count(); i++)
            {
                if (!comboBox3.Items.Contains(asList[i].status))
                    comboBox3.Items.Add(asList[i].status);
            }

        }
    }
}
