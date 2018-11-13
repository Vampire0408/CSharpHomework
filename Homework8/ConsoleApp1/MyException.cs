using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class MyException: ApplicationException
    {
        private int IdNumber;
        public MyException(String message, int id)
            : base(message)
        {
            this.IdNumber = id;
        }
        public int getId()
        {
            return IdNumber;
        }
    }
}
