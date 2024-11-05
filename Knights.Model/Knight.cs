using System.Text.Json.Serialization;

namespace Knights.Model
{
    public sealed class Knight
    {
        [JsonIgnore]
        public string id { get; set; } = string.Empty;

        public string name { get; set; } = string.Empty;

        public string nickname { get; set; } = string.Empty;

        public DateTime birthday { get; set; }

        public string keyAttribute { get; set; } = string.Empty;

        public List<Weapon> weapons { get; set; } = [];

        public Attribute attributes { get; set; } = new Attribute();

        [JsonIgnore]
        public bool isHero { get; set; } = false;
    }
}
