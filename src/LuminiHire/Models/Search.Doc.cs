using CollegeScorecard.Infra.ES;
using Microsoft.AspNetCore.Mvc;
using Nest;

namespace CollegeScorecard.Models
{
    public class SearchDoc
    {
        public string Result { get; set; }
        public ISearchResponse<ScorecardSearchDocument> Search { get; set; }
        public bool HasSearch => Search != null;

        [BindProperty(SupportsGet = true)]
        public string Term { get; set; }
    }
}
