using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Draughts
{
    class MyException : Exception
    {
        private string error;
        public MyException() : base(String.Format("Error Assembly."))
        {
            error = "Error Assembly.";
        }

        public override string ToString()
        {
            return error;
        }
    }
}
