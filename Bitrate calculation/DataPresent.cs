using BitrateCalculationServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bitrate_calculation
{
    public class DataPresent(IBitrateCalculator bitrateCalculator, IBitrateAnalysisService bitrateAnalysisService)
    {

        public void GetData()
        {
            var response= bitrateCalculator.GetCalculatedBitratesOfDevice();
            var differences= bitrateCalculator.CalculateBitRateDeviceDifference();

            if(response.Count()==0)
                Console.WriteLine("No data present");

            if (differences.Count() == 0)
                Console.WriteLine("No data present");

            List<double> allRxValuesDuringReading=new List<double>();
            List<double> allTxValuesDuringReading = new List<double>();

            for (int i=0;i<response.Count;i++)
            {
                Console.WriteLine(response[i]);
                if(i>0) 
                    Console.WriteLine($"Difference from last reading Rx: {differences[i-1].Item1} Tx: {differences[i-1].Item2}");
                else
                    Console.WriteLine($"Initial reading, no bitrate difference yet.");

                Console.WriteLine(Thresholds.DetermineRxThreshold(response[i].RxBitrates));
                Console.WriteLine(Thresholds.DetermineTxThreshold(response[i].TxBitrates));

                allRxValuesDuringReading.Add(response[i].RxBitrates);
                allTxValuesDuringReading.Add(response[i].TxBitrates);


                Console.WriteLine("--------------------------------------");

                Thread.Sleep(500);
            }


            var bitrateAnalysisResponse = bitrateAnalysisService.RunAnalysis(allRxValuesDuringReading, allTxValuesDuringReading);

            Console.WriteLine("\n----------- Current reading bitrate analisys -----------------\n");

            Console.WriteLine($"Max Rx {bitrateAnalysisResponse.Item1.Max}");
            Console.WriteLine($"Min Rx {bitrateAnalysisResponse.Item1.Min}");
            Console.WriteLine($"Average Rx {bitrateAnalysisResponse.Item1.Average}\n");




            Console.WriteLine($"Max Tx {bitrateAnalysisResponse.Item2.Max}");
            Console.WriteLine($"Min Tx {bitrateAnalysisResponse.Item2.Min}");
            Console.WriteLine($"Average Tx {bitrateAnalysisResponse.Item2.Average}");

            Console.WriteLine("\n--------------------------------------------------------------\n");

        }
    }
}
