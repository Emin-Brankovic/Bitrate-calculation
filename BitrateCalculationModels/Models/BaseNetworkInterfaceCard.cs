using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitrateCalculationModels.Models
{
    public class BaseNetworkInterfaceCard
    {
        public string Description { get; set; }
        public string MAC { get; set; }
        public DateTime TimeStamp { get; set; }

        public override string ToString()
        {
            return $"Description: {Description}\n" +
                   $"MAC: {MAC}\n" +
                   $"Time Stamp: {TimeStamp}\n";
        }
    }
}
