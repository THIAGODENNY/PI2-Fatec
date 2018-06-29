using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;

using Amazon;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;


namespace ConexaoAWS

{
    public partial class InterfaceCadastro : Form
    {
        private TextBox nomeFuncionario;
        private TextBox idFunconario;
        private Label label1;
        private Label label2;
        private Button btBuscar;
        private DataGridView dataGridView1;
        private Button button1;
        private Button btCadastrar;

        public InterfaceCadastro()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.btCadastrar = new System.Windows.Forms.Button();
            this.nomeFuncionario = new System.Windows.Forms.TextBox();
            this.idFunconario = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btBuscar = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btCadastrar
            // 
            this.btCadastrar.Location = new System.Drawing.Point(528, 96);
            this.btCadastrar.Name = "btCadastrar";
            this.btCadastrar.Size = new System.Drawing.Size(100, 23);
            this.btCadastrar.TabIndex = 0;
            this.btCadastrar.Text = "Cadastrar";
            this.btCadastrar.UseVisualStyleBackColor = true;
            this.btCadastrar.Click += new System.EventHandler(this.button1_Click);
            // 
            // nomeFuncionario
            // 
            this.nomeFuncionario.Location = new System.Drawing.Point(448, 70);
            this.nomeFuncionario.Name = "nomeFuncionario";
            this.nomeFuncionario.Size = new System.Drawing.Size(458, 20);
            this.nomeFuncionario.TabIndex = 1;
            // 
            // idFunconario
            // 
            this.idFunconario.Location = new System.Drawing.Point(448, 44);
            this.idFunconario.Name = "idFunconario";
            this.idFunconario.Size = new System.Drawing.Size(458, 20);
            this.idFunconario.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(427, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(15, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "id";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(407, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Nome";
            // 
            // btBuscar
            // 
            this.btBuscar.Location = new System.Drawing.Point(634, 96);
            this.btBuscar.Name = "btBuscar";
            this.btBuscar.Size = new System.Drawing.Size(100, 23);
            this.btBuscar.TabIndex = 0;
            this.btBuscar.Text = "Buscar";
            this.btBuscar.UseVisualStyleBackColor = true;
            this.btBuscar.Click += new System.EventHandler(this.btBuscar_Click);
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
            this.dataGridView1.TabIndex = 5;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(740, 96);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "Apagar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // InterfaceCadastro
            // 
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(1287, 620);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.idFunconario);
            this.Controls.Add(this.nomeFuncionario);
            this.Controls.Add(this.btBuscar);
            this.Controls.Add(this.btCadastrar);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "InterfaceCadastro";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
            this.Icon = new Icon(GlobalVariables.pathImages + @"\logo.ico");
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Text = "Cadastro Funcionários";

        }

        private void button1_Click(object sender, EventArgs e)
        {
            AmazonDynamoDBClient client = new AmazonDynamoDBClient();

            DynamoDBContext context = new DynamoDBContext(client);

            try
            {
                ComandoAWS.AddEmployer(context, idFunconario.Text, nomeFuncionario.Text);
            }

            catch
            {
                Console.WriteLine("Erro no cadastro do Funcionario");
            }

            dataGridView1.DataSource = ComandoAWS.SearchDataTabelaFuncionarios(context, "", "");


        }

        private void btBuscar_Click(object sender, EventArgs e)
        {
            AmazonDynamoDBClient client = new AmazonDynamoDBClient();

            DynamoDBContext context = new DynamoDBContext(client);

            dataGridView1.DataSource = ComandoAWS.SearchDataTabelaFuncionarios(context, idFunconario.Text, nomeFuncionario.Text);

            try
            {
                if (idFunconario.Text != "" && nomeFuncionario.Text == "")
                {
                    nomeFuncionario.Text = ComandoAWS.SearchFuncionarios(context , "id", idFunconario.Text, "nome");

                }
            }

            catch
            {

            }

            idFunconario.Clear();
            nomeFuncionario.Clear();

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            AmazonDynamoDBClient client = new AmazonDynamoDBClient();
            DynamoDBContext context = new DynamoDBContext(client);

            try
            {
                ComandoAWS.DeleteEmployer(context, idFunconario.Text, nomeFuncionario.Text);

            }

            catch
            {
                MessageBox.Show("Falha Conexão ou não existente!");
            }

            dataGridView1.DataSource = ComandoAWS.SearchDataTabelaFuncionarios(context, "", "");

        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            idFunconario.Text = dataGridView1[0, dataGridView1.CurrentCell.RowIndex].Value.ToString();
            nomeFuncionario.Text = dataGridView1[1, dataGridView1.CurrentCell.RowIndex].Value.ToString();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}