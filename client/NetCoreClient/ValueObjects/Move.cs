using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreClient.ValueObjects
{
    internal class Move
    {
        public int Value { get; private set; }

        public Move(int value)
        {
            this.Value = value;
        }
    }
}
