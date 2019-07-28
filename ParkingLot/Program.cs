using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLot
{
    class Program : MainProcessor
    {
        public static void Main(String[] args)
        {
            MainProcessor processor = null;

            if (args.Length >= 1)
            {
                processor = new FileProcessor(args[0]);
            }
            else
            {
                processor = new InteractiveProcessor();
            }
            processor.Process();
        }
    }
}
