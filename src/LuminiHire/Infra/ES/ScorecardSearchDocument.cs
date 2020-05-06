using CollegeScorecard.Models.Csv;
using Nest;
using System;
using System.Linq;


namespace CollegeScorecard.Infra.ES
{
    public class ScorecardSearchDocument
    {

        public ScorecardSearchDocument()
        {
        }

        public ScorecardSearchDocument(ScorecardRecord record)
        {
            UnitId = record.UNITID;

            Names = new[]
                {
                    record.CITY,
                    record.ZIP,
                    record.ACCREDAGENCY,
                }
                .Union(record.ZIP.Split(' '))
                .Union(record.ACCREDAGENCY.Split(' '))
                .Distinct(StringComparer.OrdinalIgnoreCase)
                .ToArray();

            City = record.CITY;
            AccredAgency = record.ACCREDAGENCY;

            Data = record;
        }

        public string UnitId { get; set; }

        [Text(
            Analyzer = Indices.IndexAnalyzerName,
            SearchAnalyzer = Indices.SearchAnalyzerName
        )]
        public string[] Names { get; set; }

        [Keyword]
        public string AccredAgency { get; set; }

        [Keyword]
        public string City { get; set; }

        [Object(Enabled = false)]
        public ScorecardRecord Data { get; set; }


    }
}
