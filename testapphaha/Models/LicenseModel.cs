using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testapphaha.Models
{
    public class LicenseModel
    {
        public LicenseModel()
        {

        }

        public LicenseModel(string line)
        {
            char delimiter = '|';
            string[] substrings = line.Split(delimiter);

            Name = substrings[0];
            Type = substrings[1];
        }

        public string Name { get; set; }

        public string Type { get; set; }
    }
}
