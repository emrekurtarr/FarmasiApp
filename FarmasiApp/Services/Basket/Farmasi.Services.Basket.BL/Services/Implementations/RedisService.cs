using StackExchange.Redis;

namespace Farmasi.Services.Basket.BL.Services.Implementations
{
    public class RedisService
    {
        private readonly string _host;

        private readonly int _port;

        private ConnectionMultiplexer _ConnectionMultiplexer;

        public RedisService(string host, int port)
        {
            _host = host;
            _port = port;
        }

        public void Connect()
        {
            ConfigurationOptions option = new ConfigurationOptions
            {
                AbortOnConnectFail = false,
                EndPoints = { $"{_host}:{_port}" }
            };
            _ConnectionMultiplexer = ConnectionMultiplexer.Connect(option);
        }

        public IDatabase GetDb(int db = 1) => _ConnectionMultiplexer.GetDatabase(db);
    }
}
