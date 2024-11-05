using Knights.Model.ViewModels;

namespace Knights.Model.Extensions
{
    public static class KnightExtensions
    {
        public static KnightViewModel ToKnightViewModel(this Knight knight)
        {
            var idade = DateTime.Now.Year - knight.birthday.Year;

            return new KnightViewModel(
                knight.id,
                knight.name,
                idade,
                knight.weapons.Count,
                knight.keyAttribute,
                10 + knight.attributes.GetModByAttribute(knight.keyAttribute) + knight.attributes.GetModByAttribute(knight.weapons.FirstOrDefault(x => x.equipped)?.attr ?? string.Empty),
                idade < 7 ? 0 : Convert.ToInt32(Math.Floor((idade - 7) * Math.Pow(22, 1.45))));
        }
    }
}
