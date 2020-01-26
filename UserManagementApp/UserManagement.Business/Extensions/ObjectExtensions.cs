namespace System
{
    public static class ObjectExtensions
    {
        public static T ValidateNotNull<T>(this T value, string nameOf = null)
        {
            if (value != null) return value;

            throw new ArgumentNullException(nameOf ?? typeof(T).Name);
        }
    }
}
