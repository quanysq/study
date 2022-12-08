using Microsoft.Extensions.Caching.Memory;

namespace MiniWebAPIDemo1
{
    public class Test1Controller
    {
        private IMemoryCache memoryCache;

        public Test1Controller(IMemoryCache memoryCache)
        {
            this.memoryCache = memoryCache;
        }

        public Person IncAge(Person person)
        {
            person.Age++;
            return person;
        }

        public object[] Get2(HttpContext ctx)
        {
            DateTime now = memoryCache.GetOrCreate("Now", e => DateTime.Now);
            string name = ctx.Request.Query["name"];
            return new object[] { "hello" + name, now };
        }
    }
}