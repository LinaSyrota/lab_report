using System;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;

namespace TPC_Client_wf
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public void SendMessageFromSocket(int port, bool Array)
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            Console.InputEncoding = System.Text.Encoding.Unicode;

            // Буфер для вхідних даних
            byte[] bytes = new byte[1024];

            // З’єднуємося з віддаленим пристроєм
            IPHostEntry ipHost = Dns.GetHostEntry("localhost");
            IPAddress ipAddr = ipHost.AddressList[0];
            IPEndPoint ipEndPoint = new IPEndPoint(ipAddr, port);
            Socket sender = new Socket(ipAddr.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

            // Встановлюємо віддалену точку для сокету
            sender.Connect(ipEndPoint);

            //Console.Write("Введіть повідомлення: ");
            string message = null;
            if (Array)
                message = "array " + textBox1.Text;
            else
            {
                message = textBox2.Text;
                if (radioButton1.Checked)
                    message += " sortup";
                if (radioButton2.Checked)
                    message += " sortdown";
                if (radioButton3.Checked)
                    message += " sum";
                if (radioButton4.Checked)
                    message += " mean";
                if (radioButton5.Checked)
                {
                    message += " reset";
                    textBox1.Text = "";
                }
                if (radioButton6.Checked)
                    message += " delete";
                if (radioButton7.Checked)
                    message += " end";
            }

            byte[] msg = Encoding.UTF8.GetBytes(message);

            // Надсилаємо дані через сокет
            int bytesSent = sender.Send(msg);

            // Отримуємо відповідь від сервера
            int bytesRec = sender.Receive(bytes);
            label4.Text = Encoding.UTF8.GetString(bytes, 0, bytesRec);

            if (radioButton7.Checked)
            {
                // Звільняємо сокет
                sender.Shutdown(SocketShutdown.Both);
                sender.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                SendMessageFromSocket(11000, false);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                Console.ReadLine();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                SendMessageFromSocket(11000, true);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                Console.ReadLine();
            }
        }
    }
}
