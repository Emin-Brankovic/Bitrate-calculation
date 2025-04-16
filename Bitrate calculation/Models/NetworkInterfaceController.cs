using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bitrate_calculation.Models
{
    public class NetworkInterfaceController
    {
        public required string Description { get; set; }
        public required string MAC { get; set; }
        public DateTime TimeStamp { get; set; }
        public ulong Rx { get; set; }
        public ulong Tx { get; set; }
    }
}
