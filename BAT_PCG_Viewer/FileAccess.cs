using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TestRealTimeCharts
{



    class FileAccess
    {

        private Int32[] dataArray = new int[Form1.packetSize];
        double baseTime;
            

        public void writeToFile(String fileName, Int32[] data, double timeStamp)
        {
            dataArray = data;
            baseTime = timeStamp;
            //data.CopyTo(dataArray, 0);

            Thread t = new Thread(() => fileWriterWorker(fileName));
            t.Start();


        }

        private void fileWriterWorker(String fileName)
        {
            // Set a variable to the Documents path.
            string docPath =
              Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            // Write the string array to a new file named "WriteLines.txt".
            using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, fileName), true))
            {
                try
                {
                    foreach (Int32 number in dataArray)
                    {
                        outputFile.WriteLine("{0:0,0.0000}", baseTime + "," + number + ";");
                        baseTime += Form1.time_step;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error writing to file...");
                }
               
            }
        }


    }

}
