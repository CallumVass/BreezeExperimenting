using System.Linq;
using System.Web.Http;
using Breeze.ContextProvider;
using Breeze.WebApi2;
using BreezeExperimenting.Models;
using Newtonsoft.Json.Linq;

namespace BreezeExperimenting.Controllers
{
    [BreezeController]
    public class BreezeController : ApiController
    {
        private readonly BreezeRepository _repository;

        public BreezeController(BreezeRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public string Metadata()
        {
            return _repository.Metadata;
        }

        [HttpPost]
        public SaveResult SaveChanges(JObject saveBundle)
        {
            return _repository.SaveChanges(saveBundle);
        }

        [HttpGet]
        public IQueryable<Person> People()
        {
            return _repository.People;
        }
    }
}
