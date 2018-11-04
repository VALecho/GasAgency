using System;
using System.Collections.Generic;
using System.Text;

namespace GasAgency.Helpers
{
    public interface ILocalDatabaseHelper
    {
        string GetLocalFilePath(string filename);
    }
}
