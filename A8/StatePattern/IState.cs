using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//🔴🔴🔴🔴 Har Mashin Hesabi Niaz be yek amalgar darad 
//yek mosavi, adad haye 0 va gheire 0
//pas Calculator va class haei ke az oon be ers mibaran bayd in method ha ro piadesazi konan
namespace StatePattern
{
    public interface IState
    {
        IState EnterZeroDigit();
        IState EnterNonZeroDigit(char c);
        IState EnterOperator(char c);
        IState EnterPoint();
        IState EnterEqual();
    }
}
