using Newtonsoft.Json;

namespace SimpleEShop.MVC.Extensions
{
    public static class SessionExtensions
    {
        public static T? GetJson<T>(this ISession session, string key) where T : class {
            var jsonString = session.GetString(key);
            return string.IsNullOrEmpty(jsonString) ? null : JsonConvert.DeserializeObject<T>(jsonString);
        }

        public static void SetJson(this ISession session, string key, object value)
        {
            var jsonString = JsonConvert.SerializeObject(value);
            session.SetString(key, jsonString);
        }
    }
}
