using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Injection
{
    public interface IprintType
    {
        void Print();
    }

    public class ConsolePrinter : IprintType
        {
        public void Print()
        {
            Console.WriteLine("Printing to console");
        }
     }

    public class SmsPrinter : IprintType
    {
        public void Print()
        {
            Console.WriteLine("Printing to sms");
        }
    }


}
