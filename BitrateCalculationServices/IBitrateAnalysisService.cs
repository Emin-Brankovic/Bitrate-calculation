using BitrateCalculationModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitrateCalculationServices
{
    public interface IBitrateAnalysisService
    {
        (BitrateAnalysisViewModel, BitrateAnalysisViewModel) RunAnalysis(IEnumerable<double> rxValues, IEnumerable<double> txValues);
    }
}
