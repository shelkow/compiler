
namespace compiler
{
    static class EnumExtensions
    {
        /// <summary>
        /// Возвращает true, какой-то бит совпал во флагах
        /// </summary>
        public static bool HasAnyFlag(this Enum e, Enum flag)
        {
            //если flag равен NULL пробросить исключение
            if (flag == null)
                throw new ArgumentNullException("flag");
            //если тип не соответсвует тому что в перечислении CharType то пробросить исключение
            if (!e.GetType().IsEquivalentTo(flag.GetType()))
                throw new ArgumentException("Тип перечисления не соответсвует!", "flag");

            return (Convert.ToUInt64(e) & Convert.ToUInt64(flag)) != 0;
        }
    }
}
