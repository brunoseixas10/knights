using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Knights.Model
{
    public sealed class Attribute
    {
        public byte strength { get; set; }

        public byte dexterity { get; set; }

        public byte constitution { get; set; }

        public byte intelligence { get; set; }

        public byte wisdom { get; set; }

        public byte charisma { get; set; }

        [JsonIgnore]
        public static List<(byte minValue, byte maxValue, short mod)> Mods =
        [
            new(0,8,-2),
            new(9,10,-1),
            new(11,12,0),
            new(13,15,1),
            new(16,18,2),
            new(19,20,3)
        ];

        public short GetModByAttribute(string attribute)
        {
            byte value = 0;
            switch (attribute)
            {
                case "strength":
                    {
                        value = strength;
                        break;
                    }
                case "dexterity":
                    {
                        value = dexterity;
                        break;
                    }
                case "constitution":
                    {
                        value = constitution;
                        break;
                    }
                case "intelligence":
                    {
                        value = intelligence;
                        break;
                    }
                case "wisdom":
                    {
                        value = wisdom;
                        break;
                    }
                case "charisma":
                    {
                        value = charisma;
                        break;
                    }
                default:
                    return 0;
            }

            return Mods.FirstOrDefault(x => value >= x.minValue && value <= x.maxValue).mod;
        }
    }
}
