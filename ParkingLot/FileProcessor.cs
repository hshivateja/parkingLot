using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLot
{
    public class FileProcessor : MainProcessor
    {
        //MainProcessor mp = new MainProcessor();
        String filePath = null;

    public FileProcessor(String filePath)
    {
        this.filePath = filePath;
    }

    public override void Process()
    {
            using (StreamReader file = new StreamReader(filePath))
            {
                string ln;
                while ((ln = file.ReadLine()) != null)
                {
                    validateandprocess(ln);
                }
                file.Close();
            }
    }
    }
}