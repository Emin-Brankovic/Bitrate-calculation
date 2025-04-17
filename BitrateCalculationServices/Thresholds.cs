using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitrateCalculationServices
{
    public static class Thresholds
    {
        const ulong RX_CRITICAL_KBPS = 20000;
        const ulong RX_WARNING_KBPS = 40000;

        const ulong TX_CRITICAL_KBPS = 1000;
        const ulong TX_WARNING_KBPS = 2500;

        public static string DetermineRxThreshold(double bitrateKbps)
        {
            if (bitrateKbps < RX_CRITICAL_KBPS)
                return "CRITICAL Rx: Bitrate is critically low!";
            else if (bitrateKbps < RX_WARNING_KBPS)
                return "WARNING Rx: Bitrate below normal.";
            else
                return "NORMAL Rx: Bitrate is healthy.";
        }

        public static string DetermineTxThreshold(double bitrateKbps)
        {
            if (bitrateKbps < TX_CRITICAL_KBPS)
                return "CRITICAL Tx: Bitrate is critically low!";
            else if (bitrateKbps < TX_WARNING_KBPS)
                return "WARNING Tx: Bitrate below normal.";
            else
                return "NORMAL Tx: Bitrate is healthy.";
        }
    }
}
