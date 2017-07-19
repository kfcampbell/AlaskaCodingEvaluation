using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Razor.Text;
using CsvHelper;

namespace FlightSearch.Helpers
{
    public class CsvHelper
    {
        private CsvReader _csvReader;
        private TextReader _textReader;

        public CsvHelper()
        {
            //_textReader = File.OpenText(@"");
            //_csvReader = new CsvReader(_textReader);
        }
    }
}