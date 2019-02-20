namespace VacationsTracker.Core.DataAccess
{
    internal static class Info
    {
        public static string ServiceUrl => "https://vts-v2.azurewebsites.net/api/vts/workflow";
        public static string LocalServiceUrl => "https://10.0.2.2:5000/api/vts/workflow";

        public static string LocalIdentityServiceUrl => "https://10.0.2.2:5001";

        public static string IdentityServiceUrl => "https://vts-token-issuer-v2.azurewebsites.net";
        public static string ClientId => "VTS-Mobile-v1";
        public static string ClientSecret => "VTS123456789";
        public static string Scope => "VTS-Server-v2";
    }
}
