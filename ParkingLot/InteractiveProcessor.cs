using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLot
{
    class InteractiveProcessor : MainProcessor
    {
        public InteractiveProcessor()
        {

        }
        public override void Process()
        {

            string ln = Console.ReadLine();
            while (ln != "exit")
            {
                validateandprocess(ln);
                Console.WriteLine("Please enter 'exit' to exit");
                ln = Console.ReadLine();
            }
        }
    }
}