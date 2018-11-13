using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIlionar.props
{
    public class Prize
    {
        public int Level{ get; set; }
        public string Value { get; set; }

        public Prize(int lvl, string value)
        {
            Level = lvl;
            Value = value;
        }

        public override string ToString()
        {
            return this.Level.ToString() + this.Value;

        }
    }
}
