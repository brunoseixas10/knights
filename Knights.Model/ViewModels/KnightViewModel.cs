namespace Knights.Model.ViewModels
{
    public sealed class KnightViewModel
    {
        public KnightViewModel(
            string id,
            string nome,
            int idade,
            int armas,
            string atributo,
            int ataque,
            int exp)
        {
            this.id = id;
            Nome = nome;
            Idade = idade;
            Armas = armas;
            Atributo = atributo;
            Ataque = ataque;
            Exp = exp;
        }

        public string id { get; set; }

        public string Nome { get; set; }

        public int Idade { get; set; }

        public int Armas { get; set; }

        public string Atributo { get; set; }

        public int Ataque { get; set; }

        public int Exp { get; set; }
    }
}
