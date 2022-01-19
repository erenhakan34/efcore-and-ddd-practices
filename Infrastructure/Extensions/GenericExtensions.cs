namespace Infrastructure.Extensions
{
    public static class GenericExtensions
    {
        public static bool IsNull<T>(this T instance) 
        {
            return instance == null;
        }

        public static bool IsNotNull<T>(this T instance) 
        {
            return !IsNull(instance);
        }
    }
}
