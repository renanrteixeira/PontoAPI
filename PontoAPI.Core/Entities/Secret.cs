namespace PontoAPI.Core.Entities
{
    public static class Secret
    {
        private static string secretKey = "fedaf7d8863b48e197b9287d492b708e";

        public static string SecretKey { get => secretKey; set => secretKey = value; }
    }
}