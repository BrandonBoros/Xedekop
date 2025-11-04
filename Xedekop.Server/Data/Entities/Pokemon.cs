namespace Xedekop.Server.Data.Entities
{
    public enum Type
    {
        Normal,
        Fire,
        Water,
        Electric,
        Grass,
        Ice,
        Fighting,
        Poison,
        Ground,
        Flying,
        Psychic,
        Bug,
        Rock,
        Ghost,
        Dragon,
        Dark,
        Steel,
        Fairy
    }

    public class Pokemon
    {
        /// <summary>
        /// The Primary Key of the Pokemon (pokedex number).
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The Name of the Pokemon.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The Type(s) of the Pokemon.
        /// </summary>
        public Type[] Types { get; set; } = new Type[2];

        /// <summary>
        /// The description of the Pokemon.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// The price of the Pokemon.
        /// </summary>
        public decimal Price { get; set; }

        // pokemon image url
    }
}
