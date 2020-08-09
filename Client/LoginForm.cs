using System;
using System.Windows.Forms;

namespace Cliente
{
    public partial class LoginForm : Form
    {
        public ClienteConfiguracao Cliente { get; set; }

        public LoginForm()
        {
            Cliente = new ClienteConfiguracao();
            InitializeComponent();
        }

        private void btConectar_Click(object sender, EventArgs e)
        {
            Cliente.Conectado += clienteConectado;
            Cliente.Conexao(txtIP.Text, 2014);
            Cliente.enviar("Conectar|" + txtApelido.Text + "|conectado");
        }

        private void clienteConectado(object sender, EventArgs e)
        {
            this.Invoke(Close);
        }

        private void txtApelido_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}