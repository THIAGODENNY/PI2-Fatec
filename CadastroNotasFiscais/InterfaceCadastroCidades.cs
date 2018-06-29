using System.Windows.Forms;
using System.Linq;

using Amazon;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using System.Collections.Generic;
using System.Drawing;

namespace ConexaoAWS
{
    public partial class InterfaceCadastroCidades: Form
    {
        private Button button1;
        private DataGridView dataGridView1;
        private Label label2;
        private Label label1;
        private TextBox cidadeDestinatario;
        private TextBox idFuncionario;
        private Button btBuscar;
        private ComboBox comboBox1;
        private Button btCadastrar;

        public InterfaceCadastroCidades()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cidadeDestinatario = new System.Windows.Forms.TextBox();
            this.idFuncionario = new System.Windows.Forms.TextBox();
            this.btBuscar = new System.Windows.Forms.Button();
            this.btCadastrar = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(705, 97);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 23);
            this.button1.TabIndex = 16;
            this.button1.Text = "Apagar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.btDeletar);
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
            this.dataGridView1.TabIndex = 15;
            this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(385, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "id Funcionario";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(357, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Cidade Destinatario";
            // 
            // cidadeDestinatario
            // 
            this.cidadeDestinatario.Location = new System.Drawing.Point(462, 41);
            this.cidadeDestinatario.Name = "cidadeDestinatario";
            this.cidadeDestinatario.Size = new System.Drawing.Size(458, 20);
            this.cidadeDestinatario.TabIndex = 11;
            // 
            // idFuncionario
            // 
            this.idFuncionario.Location = new System.Drawing.Point(462, 68);
            this.idFuncionario.Name = "idFuncionario";
            this.idFuncionario.Size = new System.Drawing.Size(98, 20);
            this.idFuncionario.TabIndex = 9;
            this.idFuncionario.Enabled = false;
            // 
            // btBuscar
            // 
            this.btBuscar.Location = new System.Drawing.Point(599, 97);
            this.btBuscar.Name = "btBuscar";
            this.btBuscar.Size = new System.Drawing.Size(100, 23);
            this.btBuscar.TabIndex = 7;
            this.btBuscar.Text = "Buscar";
            this.btBuscar.UseVisualStyleBackColor = true;
            this.btBuscar.Click += new System.EventHandler(this.btBuscar_Click);
            // 
            // btCadastrar
            // 
            this.btCadastrar.Location = new System.Drawing.Point(493, 97);
            this.btCadastrar.Name = "btCadastrar";
            this.btCadastrar.Size = new System.Drawing.Size(100, 23);
            this.btCadastrar.TabIndex = 8;
            this.btCadastrar.Text = "Cadastrar";
            this.btCadastrar.UseVisualStyleBackColor = true;
            this.btCadastrar.Click += new System.EventHandler(this.btCadastrar_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(566, 67);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(354, 21);
            this.comboBox1.TabIndex = 17;
            this.comboBox1.DropDown += new System.EventHandler(this.comboBox1_DropDown);
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // InterfaceCadastroCidades
            // 
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(1287, 620);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cidadeDestinatario);
            this.Controls.Add(this.idFuncionario);
            this.Controls.Add(this.btBuscar);
            this.Controls.Add(this.btCadastrar);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "InterfaceCadastroCidades";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
            this.Icon = new Icon(GlobalVariables.pathImages + @"\logo.ico");
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Text = "Cadastro Cidades";

        }

        private void dataGridView1_SelectionChanged(object sender, System.EventArgs e)
        {
            cidadeDestinatario.Text = dataGridView1[0, dataGridView1.CurrentCell.RowIndex].Value.ToString();
            idFuncionario.Text = dataGridView1[1, dataGridView1.CurrentCell.RowIndex].Value.ToString();
            
        }

        private void btBuscar_Click(object sender, System.EventArgs e)
        {
            AmazonDynamoDBClient client = new AmazonDynamoDBClient();
            DynamoDBContext context = new DynamoDBContext(client);

            dataGridView1.DataSource = ComandoAWS.SearchDataTabelaCidades(context, cidadeDestinatario.Text, idFuncionario.Text);

            cidadeDestinatario.Clear();
            idFuncionario.Clear();
            comboBox1.SelectedIndex = -1;
        }

        private void label2_Click(object sender, System.EventArgs e)
        {

        }

        private void btCadastrar_Click(object sender, System.EventArgs e)
        {
            AmazonDynamoDBClient client = new AmazonDynamoDBClient();
            DynamoDBContext context = new DynamoDBContext(client);

            try
            {
                ComandoAWS.AddCity(context, cidadeDestinatario.Text, idFuncionario.Text);
            }

            catch
            {
                MessageBox.Show("Erro no cadastro da cidade");
            }


            dataGridView1.DataSource = ComandoAWS.SearchDataTabelaCidades(context, "", "");
        }

        private void btDeletar(object sender, System.EventArgs e)
        {
            AmazonDynamoDBClient client = new AmazonDynamoDBClient();
            DynamoDBContext context = new DynamoDBContext(client);

            try
            {
                ComandoAWS.DeleteCity(context, cidadeDestinatario.Text, idFuncionario.Text);

            }

            catch
            {
                MessageBox.Show("Falha Conexão ou não existente!");
            }

            dataGridView1.DataSource = ComandoAWS.SearchDataTabelaCidades(context, "", "");

        }

        private void comboBox1_DropDown(object sender, System.EventArgs e)
        {
            AmazonDynamoDBClient client = new AmazonDynamoDBClient();
            DynamoDBContext context = new DynamoDBContext(client);

            comboBox1.Items.Clear();

            List<Funcionarios> asList = ComandoAWS.SearchDataTabelaFuncionarios(context, "", "");
            
            for (int i = 0; i < asList.Count() ; i++)
            {
                comboBox1.Items.Add(asList[i].nome);
            }

        }

        private void comboBox1_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (comboBox1.SelectedIndex != -1) { 
            AmazonDynamoDBClient client = new AmazonDynamoDBClient();
            DynamoDBContext context = new DynamoDBContext(client);
            idFuncionario.Text = ComandoAWS.SearchFuncionarios(context, "nome", comboBox1.SelectedItem.ToString(), "id");
            }

        }
    }
}
