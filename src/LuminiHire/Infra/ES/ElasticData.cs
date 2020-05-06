using CollegeScorecard.Models;
using CollegeScorecard.Models.Csv;
using CsvHelper;
using Nest;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CollegeScorecard.Infra.ES
{
    public class ElasticData
    {
        
        private const string  _indexName = "scorecard";

        private ElasticClient esClient;

        public ElasticData(ElasticClient client)
        {

            this.esClient = client;
        }


        public async Task LoadData()
        {
          
            var index = esClient.Indices.Exists(_indexName);
            if (index.Exists)
            {
                 await esClient.Indices.DeleteAsync(_indexName);
            }

            var createResult = 
                await esClient.Indices.CreateAsync(_indexName, c => c
                         .Settings(s => s.Analysis(a => a.AddSearchAnalyzer()))
                     .Map<Scorecard>(m => m.AutoMap()));


            
            string[] filePaths = Directory.GetFiles( "C:\\CSV_FILES", "*.csv");
            foreach (var item in filePaths)
            {
                var file = File.Open(item, FileMode.Open);

                using (var csv = new CsvReader(new StreamReader(file)))
                {

                    csv.Configuration.RegisterClassMap<ScorecardMapping>();

                    csv.Configuration.Delimiter = ",";
                    var records = csv
                        .GetRecords<ScorecardRecord>()
                        .Select(record => new ScorecardSearchDocument(record))
                        .ToList();


                    var bullkResult = await esClient.BulkAsync(b => b.Index(_indexName).CreateMany(records));
                }

            }
        }

    }
}
