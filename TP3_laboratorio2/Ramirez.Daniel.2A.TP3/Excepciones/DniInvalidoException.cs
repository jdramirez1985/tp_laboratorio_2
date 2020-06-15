using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class DniInvalidoException : Exception
    {
        public DniInvalidoException() : base("DNI inválido!!")
        {

        }
        public DniInvalidoException(string message) : base(message)
        {

        }
        public DniInvalidoException(Exception e) : base(e.Message,e)
        {

        }
        public DniInvalidoException(string message, Exception e) : base(e.Message,e)
        {

        }
    }
}
