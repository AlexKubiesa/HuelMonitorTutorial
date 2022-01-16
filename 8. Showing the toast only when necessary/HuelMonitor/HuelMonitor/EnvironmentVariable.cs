namespace HuelMonitor
{
    internal static class EnvironmentVariable
    {
        public static bool? GetBoolean(string name)
        {
            string? valueStr = Environment.GetEnvironmentVariable(name);
            return bool.TryParse(valueStr, out bool value)
                ? value
                : null;
        }

        public static void SetBoolean(string name, bool? value)
        {
            Environment.SetEnvironmentVariable(name, value?.ToString(), EnvironmentVariableTarget.User);
        }

        public static DateTime? GetDateTime(string name)
        {
            string? valueStr = Environment.GetEnvironmentVariable(name);
            return DateTime.TryParse(valueStr, out DateTime value)
                ? value
                : null;
        }

        public static void SetDateTime(string name, DateTime? value)
        {
            Environment.SetEnvironmentVariable(name, value?.ToString(), EnvironmentVariableTarget.User);
        }
    }
}
