using System.Linq;
using Breeze.ContextProvider;
using Newtonsoft.Json.Linq;

namespace BreezeExperimenting.Models
{
    public class BreezeRepository
    {
        private readonly BreezeContextProvider _contextProvider;

        public BreezeRepository(BreezeContextProvider contextProvider)
        {
            _contextProvider = contextProvider;
        }

        private BreezeContext Context { get { return _contextProvider.Context; } }

        public string Metadata
        {
            get { return _contextProvider.Metadata(); }
        }

        public SaveResult SaveChanges(JObject saveBundle)
        {
            return _contextProvider.SaveChanges(saveBundle);
        }

        public IQueryable<Person> People
        {
            get { return Context.People; }
        }
    }
}