using System;
using System.Linq;
using System.Windows.Forms;

namespace Server
{
    public partial class Chat_privado : Form
    {
        private readonly Main Main;

        public Chat_privado(Main main)
        {
            InitializeComponent();
            Main = main;
        }
        //Função para enviar a mensagem com o botão
        private void btEnviar_Click(object sender, EventArgs e)
        {   // tratamento do texto inserido no textbox
            if (txtInput.Text != string.Empty) //caso seja diferente de vazio 
            {
                foreach (var cliente in from ListViewItem item in Main.tabelaClientes.SelectedItems select (Cliente) item.Tag)              
                //foreach repete cada comando inserido para cada elemento (estrutura de repetição)
                //(
                {
                    cliente.enviar("pMensagem|" + txtInput.Text); //                   
                }
                msgRecebidas.Text += "Server disse: " + txtInput.Text + "\r\n";
                txtInput.Text = string.Empty;
            }
        }


        //fazer o enter funcionar como um botão
        private void txtInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btEnviar.PerformClick();
            }
        }

        private void txtRecebido_Mudatexto(object sender, EventArgs e)
        {
            msgRecebidas.SelectionStart = msgRecebidas.TextLength;
        }
    }
}