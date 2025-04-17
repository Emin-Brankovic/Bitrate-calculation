using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bitrate_calculation.Models
{
    public class DeviceData
    {
        public string Device { get; set; }
        public string Model { get; set; }
        public List<NetworkInterfaceCard> NIC { get; set; }

    }
}
