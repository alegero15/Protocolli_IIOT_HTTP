using NetCoreClient.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace NetCoreClient.Sensors
{
    internal class VirtualSpeedSensor2: ISpeedSensorInterface2, ISensorInterface2
    {
        private readonly Random Random;

        public VirtualSpeedSensor2()
        {
            Random = new Random();
        }

        public int Speed()
        {
            return new Speed(Random.Next(100)).Value; //penso che si debba essere una classe di speed per ogni sensore
        }


        public string ToJson()
        {
            return JsonSerializer.Serialize(Speed());
        }
    }
}
