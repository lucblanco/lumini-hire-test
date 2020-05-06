using CollegeScorecard.Infra.ES;
using CollegeScorecard.Models;
using Microsoft.AspNetCore.Mvc;
using Nest;

namespace CollegeScorecard.Controllers
{
    public class SearchController : Controller
    {

        private readonly ElasticClient client;



        public SearchController(ElasticClient client)
        {
            this.client = client;
        }

        //public void OnGet()
        //{

        //}


        public IActionResult Index()
        {
            var model = new SearchDoc();

            return View(model);
        }




        public IActionResult GetResult(string searchVal)
        {

            var model = new SearchDoc();
            model.Term = searchVal;

            if (!string.IsNullOrWhiteSpace(model.Term))
            {
                model.Search =
                    client.Search<ScorecardSearchDocument>(s =>
                        s.Query(q => q
                                .Match(m => m
                                    .Field(f => f.Names)
                                    .Query(model.Term)
                                    .Fuzziness(Fuzziness.EditDistance(1))
                                )
                            )
                            .Take(12)
                    );
            }

            return View("Index", model);
        }
    }
}