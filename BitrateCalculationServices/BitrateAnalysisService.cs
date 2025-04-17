using BitrateCalculationModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitrateCalculationServices
{
    public class BitrateAnalysisService : IBitrateAnalysisService
    {
        public (BitrateAnalysisViewModel , BitrateAnalysisViewModel ) RunAnalysis(IEnumerable<double> rxBitrates, IEnumerable<double> txBitrates)
        {
            BitrateAnalysisViewModel rxAnalysis = new BitrateAnalysisViewModel()
            {
                Min = rxBitrates.Min(),
                Max = rxBitrates.Max(),
                Average = rxBitrates.Average(),
            };

            BitrateAnalysisViewModel txAnalysis = new BitrateAnalysisViewModel()
            {
                Min = txBitrates.Min(),
                Max = txBitrates.Max(),
                Average = txBitrates.Average(),
            };


            return (rxAnalysis, txAnalysis);
        }
    }
}
