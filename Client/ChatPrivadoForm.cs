using System;
using System.Windows.Forms;

namespace Cliente
{
    public partial class chatPrivado : Form
    {
        public PublicChatForm pChat;

        public chatPrivado(PublicChatForm pchat)
        {
            InicializaComponente();
            pChat = pchat;
        }

        private void btEnviar_Click(object sender, EventArgs e)
        {
            if (txtInput.Text != string.Empty)
            {
                string Usuario = Text.Split('-')[1];
                pChat.formLogin.Cliente.enviar("pMensagem|" + Usuario + "|" + txtInput.Text);
                txtRecebido.Text += Usuario + " disse: " + txtInput.Text + "\r\n";
                txtInput.Text = string.Empty;
            }
        }

        private void txtInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSend.PerformClick();
            }
        }

        private void txtRecebido_TextChanged(object sender, EventArgs e)
        {
            txtRecebido.SelectionStart = txtRecebido.TextLength;
        }
    }
}