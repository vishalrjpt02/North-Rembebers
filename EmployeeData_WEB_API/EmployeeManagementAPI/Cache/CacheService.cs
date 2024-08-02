using Microsoft.SqlServer;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using StackExchange.Redis;


namespace EmployeeManagementAPI.Cache
{
    public class CacheService : ICacheService
    {
        private IDatabase _redishDb;
        public CacheService()
        {
            ConfigureRedis();
        }

        private void ConfigureRedis()
        {
            _redishDb = ConnectionHelper.Connection.GetDatabase();
        }

        public T GetData<T>(string key)
        {
            var value = _redishDb.StringGet(key);
            if (!string.IsNullOrEmpty(value))
            {
                return JsonConvert.DeserializeObject<T>(value);
            }
            return default;
        }

        public object RemoveData(string key)
        {
            bool _isKeyExist = _redishDb.KeyExists(key);
            if (_isKeyExist == true)
            {
                return _redishDb.KeyDelete(key);
            }
            return false;
        }

        public bool SetData<T>(string key, T value, DateTimeOffset expirationTime)
        {
            TimeSpan expiryTime = expirationTime.DateTime.Subtract(DateTime.Now);
            var isSet = _redishDb.StringSet(key, JsonConvert.SerializeObject(value), expiryTime);
            return isSet;
        }
    }
}
