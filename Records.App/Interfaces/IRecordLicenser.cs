using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testapphaha.Interfaces
{
    public interface IRecordLicenser
    {
        string[] getValidRecords(string partner, string dateString);
    }
}
