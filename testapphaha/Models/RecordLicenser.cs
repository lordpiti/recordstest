using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testapphaha.Models
{
    public class RecordLicenser
    {
        //http://stackoverflow.com/questions/35747303/how-to-convert-datetime-field-to-string-like-1st-feb-2011

        private readonly IEnumerable<RecordModel> recordList;
        private readonly IEnumerable<LicenseModel> licenseList;

        public RecordLicenser()
        {

        }

        public RecordLicenser(string[] args)
        {
            string[] linesRecords = File.ReadAllLines(@"C:\testapphaha\testapphaha\InputFiles\input1.txt", Encoding.UTF8);

            string[] linesLicenses = File.ReadAllLines(@"C:\testapphaha\testapphaha\InputFiles\input2.txt", Encoding.UTF8);

            var relevantLinesRecords = linesRecords.Skip(3);
            var relevantLinesLicenses = linesLicenses.Skip(3);

            recordList = relevantLinesRecords.Select(x => new RecordModel(x));

            licenseList = relevantLinesLicenses.Select(x => new LicenseModel(x));

        }
        
        public IEnumerable<RecordModel> getValidOnes(string provider, DateTime date)
        {
            var licenceTypeString = licenseList.FirstOrDefault(x => x.Name == provider).Type;

            var result = this.recordList.Where(x => x.isAllowedDate(date) && x.isAllowedUsage(licenceTypeString)).OrderBy(x=>x.Artist).ThenBy(x=>x.Title);

            return result;
        }
    }
}
