using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConexaoAWS
{
    public partial class MenuPrincipal: Form
    {
        private Button button2;
        private Button CadastroCidadesButton;
        private Button button3;
        private Button button4;
        private Label usuarioLogadoLabel;
        private Timer timer1;
        private IContainer components;
        private Timer tmr;
        private Button button5;
        private Button button6;
        private Button button7;
        private Button button8;
        private Button button9;
        private Label saudacoes;
        private PictureBox pictureBox1;
        private Button button10;
        private Button button1;

        public MenuPrincipal()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.CadastroCidadesButton = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.usuarioLogadoLabel = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.tmr = new System.Windows.Forms.Timer(this.components);
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.saudacoes = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button10 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(0, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(0, 0);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 0;
            // 
            // CadastroCidadesButton
            // 
            this.CadastroCidadesButton.Location = new System.Drawing.Point(0, 0);
            this.CadastroCidadesButton.Name = "CadastroCidadesButton";
            this.CadastroCidadesButton.Size = new System.Drawing.Size(75, 23);
            this.CadastroCidadesButton.TabIndex = 0;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(0, 0);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 0;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(0, 0);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 0;
            // 
            // usuarioLogadoLabel
            // 
            this.usuarioLogadoLabel.Location = new System.Drawing.Point(0, 0);
            this.usuarioLogadoLabel.Name = "usuarioLogadoLabel";
            this.usuarioLogadoLabel.Size = new System.Drawing.Size(100, 23);
            this.usuarioLogadoLabel.TabIndex = 0;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick_1);
            // 
            // tmr
            // 
            this.tmr.Enabled = true;
            this.tmr.Interval = 5000;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(22, 60);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(86, 52);
            this.button5.TabIndex = 0;
            this.button5.Text = "Cadastro Funcionarios";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(114, 61);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(86, 52);
            this.button6.TabIndex = 1;
            this.button6.Text = "Cadastro Cidades";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(22, 119);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(86, 51);
            this.button7.TabIndex = 2;
            this.button7.Text = "Cadastro XML";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(22, 176);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(86, 48);
            this.button8.TabIndex = 3;
            this.button8.Text = "Consulta Rota";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(114, 119);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(86, 51);
            this.button9.TabIndex = 4;
            this.button9.Text = "Consulta Serviços";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // saudacoes
            // 
            this.saudacoes.AutoSize = true;
            this.saudacoes.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saudacoes.Location = new System.Drawing.Point(59, 7);
            this.saudacoes.Name = "saudacoes";
            this.saudacoes.Size = new System.Drawing.Size(57, 20);
            this.saudacoes.TabIndex = 5;
            this.saudacoes.Text = "label1";
            // 
            // pictureBox1
            // 
            this.pictureBox1.ImageLocation = GlobalVariables.pathImages + @"\logo.bmp";
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(57, 30);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(114, 177);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(86, 47);
            this.button10.TabIndex = 7;
            this.button10.Text = "Logout";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // MenuPrincipal
            // 
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(224, 254);
            this.Controls.Add(this.button10);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.saudacoes);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.FormBorderStyle = FormBorderStyle.None;
            this.Name = "MenuPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.MenuPrincipal_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (GlobalVariables.usuarioLogin == "admin")
            {
                InterfaceCadastro interfaceCadastro = new InterfaceCadastro();
                interfaceCadastro.Show();
            }
            else
            {
                MessageBox.Show("Você não possuí acesso a este menu!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            InterfaceXML interfaceXML = new InterfaceXML();
            interfaceXML.Show();
        }

        private void CadastroCidadesButton_Click(object sender, EventArgs e)
        {
            if (GlobalVariables.usuarioLogin == "admin")
            {
                InterfaceCadastroCidades interfaceCadastroCidades = new InterfaceCadastroCidades();
                interfaceCadastroCidades.Show();
            }
            else
            {
                MessageBox.Show("Você não possuí acesso a este menu!");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            InterfaceConsultaOrdensServicos interfaceConsultaOrdensServicos = new InterfaceConsultaOrdensServicos();
            interfaceConsultaOrdensServicos.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            InterfaceConsultaRota interfaceConsultaRota = new InterfaceConsultaRota();
            interfaceConsultaRota.Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (GlobalVariables.usuarioLogin == "admin")
            {
                InterfaceCadastro interfaceCadastro = new InterfaceCadastro();
                interfaceCadastro.Show();
            }
            else
            {
                MessageBox.Show("Você não possuí permissão");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (GlobalVariables.usuarioLogin == "admin")
            {
                InterfaceCadastroCidades interfaceCadastroCidades = new InterfaceCadastroCidades();
                interfaceCadastroCidades.Show();
            }

            else
            {
                MessageBox.Show("Você não possuí permissão");
            }

        }

        private void button7_Click(object sender, EventArgs e)
        {
            InterfaceXML interfaceXML = new InterfaceXML();
            interfaceXML.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            InterfaceConsultaRota interfaceConsultaRota = new InterfaceConsultaRota();
            interfaceConsultaRota.Show();
        }

        private void MenuPrincipal_Load(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            InterfaceConsultaOrdensServicos interfaceConsultaOrdensServicos = new InterfaceConsultaOrdensServicos();
            interfaceConsultaOrdensServicos.Show();
        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            Saudacoes saudacoes = new Saudacoes();
            this.saudacoes.Text = saudacoes.BomDia() + ", " + GlobalVariables.usuarioLogin;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            InterfaceLogin interfaceLogin = new InterfaceLogin();
            interfaceLogin.Show();
            GlobalVariables.usuarioLogin = "";
            this.Close();
        }
    }
}
