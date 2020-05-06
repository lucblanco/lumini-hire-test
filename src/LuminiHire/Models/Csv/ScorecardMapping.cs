using CsvHelper.Configuration;

namespace CollegeScorecard.Models.Csv
{
    public class ScorecardMapping : ClassMap<ScorecardRecord>
    {
        public ScorecardMapping()
        {
            Map(x => x.UNITID).Name("UNITID");
            Map(x => x.OPEID).Name("OPEID");
            Map(x => x.OPEID6).Name("OPEID6");
            Map(x => x.INSTNM).Name("INSTNM");
            Map(x => x.CITY).Name("CITY");
            Map(x => x.STABBR).Name("STABBR");
            Map(x => x.ZIP).Name("ZIP");
            Map(x => x.ACCREDAGENCY).Name("ACCREDAGENCY");
            Map(x => x.INSTURL).Name("INSTURL");
            Map(x => x.NPCURL).Name("NPCURL");
            Map(x => x.SCH_DEG).Name("SCH_DEG");
            Map(x => x.HCM2).Name("HCM2");
            Map(x => x.MAIN).Name("MAIN");
            Map(x => x.NUMBRANCH).Name("NUMBRANCH");
            Map(x => x.PREDDEG).Name("PREDDEG");
            Map(x => x.HIGHDEG).Name("HIGHDEG");
            Map(x => x.CONTROL).Name("CONTROL");
            Map(x => x.ST_FIPS).Name("ST_FIPS");
            Map(x => x.REGION).Name("REGION");
            Map(x => x.LOCALE).Name("LOCALE");
            Map(x => x.LOCALE2).Name("LOCALE2");
            Map(x => x.LATITUDE).Name("LATITUDE");
            Map(x => x.LONGITUDE).Name("LONGITUDE");
            Map(x => x.CCBASIC).Name("CCBASIC");
            Map(x => x.CCUGPROF).Name("CCUGPROF");
            Map(x => x.CCSIZSET).Name("CCSIZSET");
            Map(x => x.HBCU).Name("HBCU");
            Map(x => x.PBI).Name("PBI");
            Map(x => x.ANNHI).Name("ANNHI");
        }
    }

    public class ScorecardRecord
    {

        public string UNITID { get; set; }
        public string OPEID { get; set; }
        public string OPEID6 { get; set; }
        public string INSTNM { get; set; }
        public string CITY { get; set; }
        public string STABBR { get; set; }
        public string ZIP { get; set; }
        public string ACCREDAGENCY { get; set; }
        public string INSTURL { get; set; }
        public string NPCURL { get; set; }
        public string SCH_DEG { get; set; }
        public string HCM2 { get; set; }
        public string MAIN { get; set; }
        public string NUMBRANCH { get; set; }
        public string PREDDEG { get; set; }
        public string HIGHDEG { get; set; }
        public string CONTROL { get; set; }
        public string ST_FIPS { get; set; }
        public string REGION { get; set; }
        public string LOCALE { get; set; }
        public string LOCALE2 { get; set; }
        public string LATITUDE { get; set; }
        public string LONGITUDE { get; set; }
        public string CCBASIC { get; set; }
        public string CCUGPROF { get; set; }
        public string CCSIZSET { get; set; }
        public string HBCU { get; set; }
        public string PBI { get; set; }
        public string ANNHI { get; set; }

    }
}
