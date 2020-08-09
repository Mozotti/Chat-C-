using System;
using System.Windows.Forms;

namespace Cliente
{
    public partial class PublicChatForm : Form
    {
        public PublicChatForm()
        {
            pChat = new chatPrivado(this);
            InitializeComponent();
        }
        
        public readonly LoginForm formLogin = new LoginForm();

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            formLogin.Cliente.Recebido += _client_Received;
            formLogin.Cliente.desconectado += Client_Desconectado;
            Text = "Chat - " + formLogin.txtIP.Text + " - (Conectado como: " + formLogin.txtApelido.Text + ")";
            formLogin.ShowDialog();
        }

        private static void Client_Desconectado(ClienteConfiguracao cs)
        {
            
        }

        private readonly chatPrivado pChat;

        public void _client_Received(ClienteConfiguracao cs, string received)
        {
            var cmd = received.Split('|');
            switch (cmd[0])
            {
                case "Usuarios":
                    this.Invoke(() =>
                    {
                        userList.Items.Clear();
                        for (int i = 1; i < cmd.Length; i++)
                        {
                            if (cmd[i] != "Conectado" | cmd[i] != "AtualizaChat")
                            {
                                userList.Items.Add(cmd[i]);
                            }
                        }
                    });
                    break;
                case "Mensagem":
                    this.Invoke(() =>
                    {
                        txtReceive.Text += cmd[1] + "\r\n";
                    });
                    break;
                case "atualizaChat":
                    this.Invoke(() =>
                    {
                        txtReceive.Text = cmd[1];
                    });
                    break;
                case "Chat":
                    this.Invoke(() =>
                    {
                        pChat.Text = pChat.Text.Replace("Usuario", formLogin.txtApelido.Text);
                        pChat.Show();
                    });
                    break;
                case "pMensagem":
                    this.Invoke(() =>
                    {
                        pChat.txtRecebido.Text += "Server disse: " + cmd[1] + "\r\n";
                    });
                    break;
                case "Desconectado":
                    Application.Exit();
                    break;
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if (txtInput.Text != string.Empty)
            {
                formLogin.Cliente.enviar("Mensagem|" + formLogin.txtApelido.Text + "|" + txtInput.Text);
                txtReceive.Text += formLogin.txtApelido.Text + " disse: " + txtInput.Text + "\r\n";
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

        private void txtReceive_TextChanged(object sender, EventArgs e)
        {
            txtReceive.SelectionStart = txtReceive.TextLength;
        }

        private void chatPrivado_Click(object sender, EventArgs e)
        {
            formLogin.Cliente.enviar("pChat|" + formLogin.txtApelido.Text);
        }

        private void userList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}