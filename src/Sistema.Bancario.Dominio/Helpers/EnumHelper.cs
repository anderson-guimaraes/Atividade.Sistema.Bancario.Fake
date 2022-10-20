using System.ComponentModel;

namespace Sistema.Bancario.Dominio.Helpers
{
    public static class EnumHelper
    {
        public static string Description(this Enum enumValue)
        {
            var descriptionAttribute = enumValue.GetType()
                .GetField(enumValue.ToString())
                .GetCustomAttributes(false)
                .SingleOrDefault(attr => attr.GetType() == typeof(DescriptionAttribute)) as DescriptionAttribute;

            // return description
            return descriptionAttribute?.Description ?? "";
        }
    }
}
