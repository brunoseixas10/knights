namespace Knights.Model
{
    public sealed class Weapon
    {
        public string name { get; set; } = string.Empty;

        public int mod { get; set; }

        public string attr { get; set; } = string.Empty;

        public bool equipped { get; set; }
    }
}
