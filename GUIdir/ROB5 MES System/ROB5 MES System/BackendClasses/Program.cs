using System;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;

namespace MESBackendConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {   
            MESsystem mESsystem = new MESsystem();
            mESsystem.AddOrderToEndOfProductionQueu(17, "Syringes", "NovoNordic");
        }
    }
}
