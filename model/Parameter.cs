using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stone1
{
    class Parameter
    {
        public string Name { get; set; }
        public int Index { get; set; }
        public override string ToString()
        {
            return (Index + 1).ToString()  + ". " + Name;
        }
    }
}
