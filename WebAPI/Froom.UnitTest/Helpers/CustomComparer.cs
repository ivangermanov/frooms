using Newtonsoft.Json;
using NUnit.Framework;

namespace Froom.UnitTest.Helpers
{
    public static class CustomComparer
    {
        public static bool Compare<T>(this T one, T second)
            where T : class
        {
            return JsonConvert.SerializeObject(one) ==
                   JsonConvert.SerializeObject(second);
        }

        public static void AssertEquals<T>(this T one, T second)
            where T : class
        {
            var sets = new JsonSerializerSettings
            {
                PreserveReferencesHandling = PreserveReferencesHandling.Objects
            };
            Assert.AreEqual(JsonConvert.SerializeObject(one, sets),
                   JsonConvert.SerializeObject(second, sets), "Objects are not the same.");
        }
    }
}
