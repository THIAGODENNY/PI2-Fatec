using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
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
    public partial class InterfacePasswordAdmin: Form
    {
        private TextBox password;
        private Button button1;
        private Label label1;

        public InterfacePasswordAdmin()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.password = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(7, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(270, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Digite a senha de Administrador do Sistema";
            // 
            // password
            // 
            this.password.Location = new System.Drawing.Point(92, 40);
            this.password.Name = "password";
            this.password.PasswordChar = '*';
            this.password.Size = new System.Drawing.Size(100, 20);
            this.password.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(102, 66);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // InterfacePasswordAdmin
            // 
            this.ClientSize = new System.Drawing.Size(284, 106);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.password);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "InterfacePasswordAdmin";
            this.ResumeLayout(false);
            this.PerformLayout();

            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                AmazonDynamoDBClient client = new AmazonDynamoDBClient();
                DynamoDBContext context = new DynamoDBContext(client);

                String loginConfirm = ComandoAWS.VerificacaoLogin(context, "admin", password.Text);


                if (loginConfirm == "admin")
                {
                    InterfaceAddUser interfaceAddUser = new InterfaceAddUser();
                    interfaceAddUser.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Senha Incorreta!");
                    this.Close();
                }
            }

            catch
            {
                this.Close();
            }

        }
    }
}
