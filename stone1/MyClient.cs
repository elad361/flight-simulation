using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace stone1
{
    class MyClient : Client
    {
        TcpClient client;
        NetworkStream stream;
        private readonly object balanceLock = new object();
        private readonly object balanceLock2 = new object();
        public void Connect(string ip, int port)
        {
            try
            {
                client = new TcpClient(ip, port);
                // Get a client stream for reading and writing.
                stream = client.GetStream();
                stream.ReadTimeout = 10000;
                // FINISHED CONNECTION.
            }
            catch (Exception e)
            {
                this.client = null;
                throw e;
            }
        }
        public bool CheckConnectionStatus()
        {
            // return false when connected
            if (client != null)
            {
                return !this.client.Connected;
            }
            else
            {
                return true;
            }
        }
        public void Disconnect()
        {
            try
            {
                // Close everything.
                stream.Close();
                client.Close();
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        public void Write(string command)
        {

            if (client != null)
            {
                Byte[] data = System.Text.Encoding.ASCII.GetBytes(command);


                // Send the message to the connected TcpServer. 
                stream.Write(data, 0, data.Length);
            }
            else
            {
                Console.WriteLine("not connected to tcp");
            }

        }

        public string Read(string value)
        {

            if (client != null)
            {
                Byte[] data = new Byte[256];
                // String to store the response ASCII representation.
                String responseData = String.Empty;
                try
                {
                    // Read the first batch of the TcpServer response bytes.
                    int bytes = stream.Read(data, 0, data.Length);
                    responseData = System.Text.Encoding.ASCII.GetString(data, 0, bytes);
                    return responseData;
                }
                catch (Exception e)
                {
                    if (CheckConnectionStatus())
                    {
                        throw e;
                    }
                    else
                    {
                        //In case we didnt get the request value  from simulator after timeout, then we ignore and preceed forward
                        return value;
                    }
                }
            }
            else
            {
                Console.WriteLine("not connected to tcp.");
                return "";
            }
        }
        public void SendArrayAsLine(double[] arr)
        {
            string line = "";
            foreach(double x in arr)
            {
                line = line + x.ToString() + ",";
            }
            Write(line);
        }
    }
}
