using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitrateCalculationModels.Models
{
    public class NetworkInterfaceCardBitratesModel : BaseNetworkInterfaceCard
    {
        public double RxBitrates { get; set; }
        public double TxBitrates { get; set; }

        public override string ToString()
        {
            return base.ToString() + $"Rx Bitrates: {RxBitrates}\n" +
                $"Tx Bitrates: {TxBitrates}\n ";
                   
        }
    }
}
