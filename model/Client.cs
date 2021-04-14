using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stone1
{
    public interface Client
    {
        void Connect(string ip, int port);
        void Write(string command);
        string Read(string value);
        void Disconnect();
        bool CheckConnectionStatus();
    }
}
