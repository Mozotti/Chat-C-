using System;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;

namespace Server
{
    class Listener
    {
        private Socket _socket;

        public bool Listening { get; private set; }

        public int Porta { get; private set; }

        public Listener(int porta)
        {
            Porta = porta;
            _socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        }

        public void Iniciar()
        {
            if (Listening) return;
            _socket.Bind(new IPEndPoint(0, Porta));
            _socket.Listen(0);
            _socket.BeginAccept(Callback, null);
            Listening = true;
        }

        public void Parar()
        {
            if (!Listening) return;
            if (_socket.Connected)
            _socket.Shutdown(SocketShutdown.Both);
            _socket.Close();
            _socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        }

        public delegate void socketAceitoHandler(Socket e);
        public event socketAceitoHandler socketAceito;
        void Callback(IAsyncResult ar)
        {
            try
            {
                var s = _socket.EndAccept(ar);
                if (socketAceito != null) socketAceito(s);
                _socket.BeginAccept(Callback, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}