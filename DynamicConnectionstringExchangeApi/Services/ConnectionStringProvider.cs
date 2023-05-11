namespace DynamicConnectionstringExchangeApi.Services
{
    public interface IConnectionStringProvider
    {
        string GetConnectionString();
    }

    public class ConnectionStringProvider : IConnectionStringProvider
    {
        private readonly IConfiguration _configuration;
        private static bool toggle = false;

        public ConnectionStringProvider(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GetConnectionString()
        {
            toggle = !toggle;

            if (toggle)
            {
                return _configuration.GetValue<string>("FirstsourceConnectionString");
            }
            else
            {
                return _configuration.GetValue<string>("SecondarysourceConnectionString");
            }
        }
    }
}
