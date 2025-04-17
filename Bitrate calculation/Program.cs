using Bitrate_calculation.Models;
using System.Net.NetworkInformation;
using BitrateCalculationServices;

namespace Bitrate_calculation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var dataPresent = new DataPresent(new BitrateCalculator(2),new BitrateAnalysisService());

            dataPresent.GetData();
            
        }
    }
}
