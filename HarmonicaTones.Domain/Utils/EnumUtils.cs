namespace HT.Domain.Utils
{
    public static class EnumUtils
    {
        public static T IntToEnum<T>(int hole) where T : Enum
        {
            return (T)Enum.Parse(typeof(T), hole.ToString(), true);
        }
    }
}