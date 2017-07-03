namespace Trainings.Infrastructure.Extentions
{
    public static class StringExtention
    {
        public static bool Empty(this string value)
            => string.IsNullOrEmpty(value);
    }
}
