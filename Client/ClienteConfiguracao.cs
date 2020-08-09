using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Cliente
{
    public class ClienteConfiguracao
    {
        readonly Socket _s;
        public delegate void ReceivedEventHandler(ClienteConfiguracao cs, string received);
        public event ReceivedEventHandler Recebido = delegate { };
        public event EventHandler Conectado = delegate { };
        public delegate void DisconnectedEventHandler(ClienteConfiguracao cs);
        public event DisconnectedEventHandler desconectado = delegate {};
        bool _conectado;

        public ClienteConfiguracao()
        {
            _s = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        }

        public void Conexao(string ip, int port)
        {
            try
            {
                var ep = new IPEndPoint(IPAddress.Parse(ip), port);
                _s.BeginConnect(ep, retornoConexao, _s);
            }
            catch { }
        }

        public void Close()
        {
            _s.Dispose();
            _s.Close();
        }

        void retornoConexao(IAsyncResult ar)
        {
            _s.EndConnect(ar);
            _conectado = true;
            Conectado(this, EventArgs.Empty);
            var buffer = new byte[_s.ReceiveBufferSize];
            _s.BeginReceive(buffer, 0, buffer.Length, SocketFlags.None, retornoLeitura, buffer);
        }

        private void retornoLeitura(IAsyncResult ar)
        {
            var buffer = (byte[]) ar.AsyncState;
            var rec = _s.EndReceive(ar);
            if (rec != 0)
            {
                var dados = Encoding.ASCII.GetString(buffer, 0, rec);
                Recebido(this, dados);
            }
            else
            {
                desconectado(this);
                _conectado = false;
                Close();
                return;
            }
            _s.BeginReceive(buffer, 0, buffer.Length, SocketFlags.None, retornoLeitura, buffer);
        }

        public void enviar(string data)
        {
            try
            {
                var buffer = Encoding.ASCII.GetBytes(data);
                _s.BeginSend(buffer, 0, buffer.Length, SocketFlags.None, retornoEnviar, buffer);
            }
            catch { desconectado(this); }
        }

        void retornoEnviar(IAsyncResult ar)
        {
            _s.EndSend(ar);
        }
    }
}