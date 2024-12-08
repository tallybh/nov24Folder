using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Injection;

public class Print
{
    IprintType pType { get; set; }
    public Print(IprintType ptype)
    {
        pType = ptype;
    }
    public void Printing()
    {
        pType.Print();
    }

    public void MethodInjection(IprintType pt)
    {
        pt.Print();
    }
}
