using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using testapphaha.Utilities;

namespace testapphaha.Models
{
    public class RecordLicenser
    {
        private readonly IEnumerable<RecordModel> recordList;
        private readonly IEnumerable<LicenseModel> licenseList;

        public RecordLicenser()
        {

        }

        public RecordLicenser(string[] args)
        {
            var file1Path = args[0];
            var file2Path = args[1];

            string[] linesRecords = File.ReadAllLines(@"C:\testapphaha\testapphaha\InputFiles\input1.txt", Encoding.UTF8);

            string[] linesLicenses = File.ReadAllLines(@"C:\testapphaha\testapphaha\InputFiles\input2.txt", Encoding.UTF8);

            var relevantLinesRecords = linesRecords.Skip(3);
            var relevantLinesLicenses = linesLicenses.Skip(3);

            recordList = relevantLinesRecords.Select(x => new RecordModel(x));

            licenseList = relevantLinesLicenses.Select(x => new LicenseModel(x));

        }
        
        public IEnumerable<string> getValidOnes(string provider, string dateString)
        {
            var date = DateUtilities.parseDate(dateString);

            var licenceTypeString = licenseList.FirstOrDefault(x => x.Name == provider).Type;

            var result = this.recordList.Where(x => x.isAllowedDate(date) && x.isAllowedUsage(licenceTypeString))
                .OrderBy(x=>x.Artist).ThenBy(x=>x.Title);

            return result.Select(x=>x.OriginalStringRead);
        }
    }
}
