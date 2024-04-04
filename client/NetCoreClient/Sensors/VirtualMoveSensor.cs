using NetCoreClient.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace NetCoreClient.Sensors
{
    internal class VirtualMoveSensor: IMoveSensorInterface, ISensorInterface
    {
        private readonly Random Random;

        public VirtualMoveSensor()
        {
            Random = new Random();
        }

        public int Move()
        {
            return new Move(Random.Next(300)).Value;
        }

        public string ToJson()
        {
            return JsonSerializer.Serialize(Move());
        }

    }
}
