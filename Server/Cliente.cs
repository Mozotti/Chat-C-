using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Server
{

    //Classe  para iniciar socket de conexão e tratar eventos (fechar a janela, desconectar...)
    class Cliente  
    {

        //declaração eventos handler e delegates
        public delegate void clienteRecebidoHandler(Cliente sender, byte[] data);
        public delegate void clienteDesconectadoHandler(Cliente sender);
        public event clienteRecebidoHandler Recebido;
        public event clienteDesconectadoHandler Desconectado;
        /*Um delegate é um tipo que representa referências aos métodos com lista de parâmetros e tipo de retorno específicos. 
         *Ao instanciar um delegate, você pode associar sua instância a qualquer método com assinatura e tipo de retorno compatíveis. 
         *Você pode invocar=chamar (invoke ) o método através da instância de delegate.
         *Delegates são usados para passar métodos como argumentos a outros métodos.  */
         /*Handler é um manipulador bastante usado em Java*/
     
        public IPEndPoint Ip { get; private set; }
        public Socket _socket;

        public Cliente(Socket aceito)
        {
            _socket = aceito;
            Ip = (IPEndPoint) _socket.RemoteEndPoint;
            _socket.BeginReceive(new byte[] {0}, 0, 0, 0, Callback, null);
        }
        /*Callback é uma função que é usada como "callback". 
         * Ela é tipicamente passada como argumento de outra função e/ou chamada quando um evento aconteceu
         * ou quando uma parte de código receber uma resposta de que estava à espera */
        void Callback(IAsyncResult ar)
        {
            try
            {
                _socket.EndReceive(ar);
                var buffer = new byte[_socket.ReceiveBufferSize];
                var rec = _socket.Receive(buffer, buffer.Length, 0);
                if (rec < buffer.Length)
                {
                    Array.Resize(ref buffer, rec);
                }
                if (Recebido != null)
                {
                    Recebido(this, buffer);
                }
                _socket.BeginReceive(new byte[] { 0 }, 0, 0, 0, Callback, null);
               
            }
            catch (Exception)
            {
                Close();
                if (Desconectado != null)
                {
                    Desconectado(this);
                }
            }
        }

        public void enviar(string data)
        {
            var buffer = Encoding.ASCII.GetBytes(data);
            _socket.BeginSend(buffer, 0, buffer.Length, SocketFlags.None, ar => _socket.EndSend(ar), buffer);
        }

        public void Close()
        {
            _socket.Dispose();
            _socket.Close();
        }
    }
}