using Bitrate_calculation.Models;
using BitrateCalculationModels.Models;


namespace BitrateCalculationServices
{
    public class BitrateCalculator : IBitrateCalculator
    {
        private readonly int _pollingRate;

        public BitrateCalculator(int pollingRate)
        {
            _pollingRate = pollingRate;
        }


        public List<(double, double)> CalculateBitRate()
        {

            List<DeviceData>? networkInterfaces = ReadDataFromJson();

            List<(double, double)> response = new List<(double, double)>();

            if(networkInterfaces != null)
            {
                foreach (var item in networkInterfaces)
                {
                    foreach (var device in item.NIC) 
                    {
                        response.Add((TransformToBitrate(device.Rx), TransformToBitrate(device.Tx)));
                    }
                }

            }

            return response;

        }

        public List<NetworkInterfaceCardBitratesModel> GetCalculatedBitratesOfDevice()
        {

            List<DeviceData>? networkInterfaces = ReadDataFromJson();

            List<NetworkInterfaceCardBitratesModel> response = new List<NetworkInterfaceCardBitratesModel>();

            if(networkInterfaces != null )
            {
                foreach (var item in networkInterfaces)
                {
                    foreach (var device in item.NIC)
                    {

                        response.Add(new NetworkInterfaceCardBitratesModel
                        {
                            Description = device.Description,
                            MAC = device.MAC,
                            TimeStamp = device.TimeStamp,
                            RxBitrates = TransformToBitrate(device.Rx),
                            TxBitrates = TransformToBitrate(device.Tx)
                        });
                    }
                }
            }


            return response;

        }





        public List<(double, double)> CalculateBitRateDeviceDifference()
        {
            List<DeviceData>? networkInterfaces = ReadDataFromJson();
            (double, double) previousBitRate=(0,0);
            List<(double, double)> diferences = new List<(double, double)>();

            if(networkInterfaces != null)
            {
                foreach (var item in networkInterfaces)
                {
                    foreach (var device in item.NIC)
                    {
                        double timeDelta = 0.5;

                        if (previousBitRate.Item1 != 0 && previousBitRate.Item2 != 0)
                        {
                            double rxBitrate = ((device.Rx - previousBitRate.Item1) * 8) / timeDelta;
                            double txBitrate = ((device.Tx - previousBitRate.Item2) * 8) / timeDelta;

                            diferences.Add((rxBitrate, txBitrate));
                        }

                        previousBitRate.Item1 = device.Rx;
                        previousBitRate.Item2 = device.Tx;

                    }
                }
            }

            return diferences;
        }


        private double TransformToBitrate(ulong ocetate)
        {
            double timeInterval = 1.0 / _pollingRate;
            return (ocetate * 8) / (timeInterval * 1000);
        }

        private List<DeviceData>? ReadDataFromJson()
        {
            var jsonReader = new JsonReader("C:\\Users\\Emin Brankovic\\source\\repos\\Bitrate calculation\\BitrateCalculationServices\\DeviceReadings.json");

            var jsonResponse = jsonReader.ReadFromJsonArray("Devices");

            if (jsonResponse == null)
                Console.WriteLine("Response is null");


            List<DeviceData>? networkInterfaces = jsonResponse?.ToObject<List<DeviceData>>();

            return networkInterfaces;
        }

    }
}
