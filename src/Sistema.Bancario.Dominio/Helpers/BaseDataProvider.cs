using Bogus;

namespace Sistema.Bancario.Dominio.Helpers
{
    public abstract class BaseDataProvider
    {
        public static Faker Faker
            => new Faker("pt_BR");

        public static Randomizer Randomizer
            => new Randomizer();
    }
}
