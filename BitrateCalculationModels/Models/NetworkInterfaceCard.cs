using BitrateCalculationModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bitrate_calculation.Models
{
    public class NetworkInterfaceCard : BaseNetworkInterfaceCard
    {
        public ulong Rx { get; set; }
        public ulong Tx { get; set; }

        public override string ToString()
        {
            return base.ToString() + $"Rx: {Rx}\n" +
                $"Tx: {Tx}\n ";

        }
    }
}
