using BitrateCalculationModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitrateCalculationServices
{
    public interface IBitrateCalculator
    {
        List<(double, double)> CalculateBitRate();
        List<(double, double)> CalculateBitRateDeviceDifference();
        List<NetworkInterfaceCardBitratesModel> GetCalculatedBitratesOfDevice();
    }
}
