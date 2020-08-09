using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;

namespace Server
{
    public partial class Main : Form
    {
        private readonly Listener listener;

        public List<Socket> clientes = new List<Socket>(); // mantem todas os clientes em uma lista

        public void transmissaoDados(string dados) // envia os dados para todos os clientes
        {
            foreach (var socket in clientes)
            {
                try { socket.Send(Encoding.ASCII.GetBytes(dados)); }
                catch (Exception) { }
            }
        }

        public Main()
        {
            pChat = new Chat_privado(this);
            InitializaComponente();
            listener = new Listener(2014);
            listener.socketAceito += listener_SocketAceito;
        }

        private void listener_SocketAceito(Socket e)
        {
            var clientes = new Cliente(e);
            clientes.Recebido += clienteRecebido;
            clientes.Desconectado += clienteDesconectado;
            this.Invoke(() =>
            {
                string ip = clientes.Ip.ToString().Split(':')[0];
                var item = new ListViewItem(ip); // instancia a lista de pessoas e pega inicialmente o ip
                item.SubItems.Add(" "); // depois o apelido (que é o segundo sub item)
                item.SubItems.Add(" "); // depois o status (que é o 3 sub item)
                item.Tag = clientes; //pega os sets e/ou os gets e coloca no cliente
                tabelaClientes.Items.Add(item);
                this.clientes.Add(e);
            });
        }

        private void clienteDesconectado(Cliente sender)
        {
            this.Invoke(() =>
            {
                for (int i = 0; i < tabelaClientes.Items.Count; i++)
                {
                    var client = tabelaClientes.Items[i].Tag as Cliente;
                    if (client.Ip == sender.Ip)
                    {
                        msgRecebidas.Text += " " + tabelaClientes.Items[i].SubItems[1].Text + " Saiu do chat :( \r\n";
                        transmissaoDados("AtualizaChat|" + msgRecebidas.Text);
                        tabelaClientes.Items.RemoveAt(i);
                    }
                }
            });
        }

        private Chat_privado pChat;

        private void clienteRecebido(Cliente sender, byte[] data)
        {
            this.Invoke(() =>
            {
                for (int i = 0; i < tabelaClientes.Items.Count; i++)
                {
                    var client = tabelaClientes.Items[i].Tag as Cliente;
                    if (client == null || client.Ip != sender.Ip) continue;
                    var command = Encoding.ASCII.GetString(data).Split('|');
                    switch (command[0])
                    {
                        case "Conectado":
                            msgRecebidas.Text += " " + command[1] + " Entrou! :D \r\n";
                            tabelaClientes.Items[i].SubItems[1].Text = command[1]; // coloca na lista do chat o apelido 
                            tabelaClientes.Items[i].SubItems[2].Text = command[2]; // coloca na lista do chat o status
                            string users = string.Empty;
                            for (int j = 0; j < tabelaClientes.Items.Count; j++)
                            {
                                users += tabelaClientes.Items[j].SubItems[1].Text + "|";
                            }
                            transmissaoDados("Usuarios|" + users.TrimEnd('|'));
                            transmissaoDados("atualizaChat|" + msgRecebidas.Text);
                            break;
                        case "Mensagem":
                            msgRecebidas.Text += command[1] + " disse: " + command[2] + "\r\n";
                            transmissaoDados("atualizaChat|" + msgRecebidas.Text);
                            break;
                        case "pMensagem":
                            this.Invoke(() =>
                            {
                                pChat.msgRecebidas.Text += command[1] + " disse " + command[2] + "\r\n";
                            });
                            break;
                        case "pChat":

                            break;
                    }
                }
            });
        }

        private void Main_Load(object sender, EventArgs e)
        {
            listener.Iniciar();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            listener.Parar();
        }

        private void btEnviar_Click(object sender, EventArgs e)
        {
            if (area_txt.Text != string.Empty)
            {
                transmissaoDados("Messagem|" + area_txt.Text);
                msgRecebidas.Text += area_txt.Text + "\r\n";
                area_txt.Text = "adm disse: ";
            }
        }

        private void disconnectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (var cliente in from ListViewItem item in tabelaClientes.SelectedItems select (Cliente) item.Tag)
            {
                cliente.enviar("Desconectado|");
            }
        }

        private void chatWithClientToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (var client in from ListViewItem item in tabelaClientes.SelectedItems select (Cliente) item.Tag)
            {
                client.enviar("Chat|");
                pChat = new Chat_privado(this);
                pChat.Show();
            }
        }

        private void txtInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btEnviar.PerformClick();
            }
        }

        private void txtReceive_TextChanged(object sender, EventArgs e)
        {
            msgRecebidas.SelectionStart = msgRecebidas.TextLength;
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // Main
            // 
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Name = "Main";
            this.Load += new System.EventHandler(this.Main_Load_1);
            this.ResumeLayout(false);

        }

        private void Main_Load_1(object sender, EventArgs e)
        {

        }
    }
}