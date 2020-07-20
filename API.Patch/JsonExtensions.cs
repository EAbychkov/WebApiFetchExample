using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace API.Patch
{
    public static class JsonExtensions
    {
        public static void PopulateObject<T>(this JToken jt, T target) =>
            new JsonSerializer().Populate(jt.CreateReader(), target);
    }
}
