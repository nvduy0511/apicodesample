using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeSampleAPI.Model
{
    public class RunCodeResponse
    {
        public string sourceCode { get; set; }
        public int status { get; set; }
        public int errorCode { get; set; }
        public string error { get; set; }
        public int outputType { get; set; }
        public string output { get; set; }
        public string outputStyle { get; set; }
        public string date { get; set; }
        public string language { get; set; }
        public string input { get; set; }
        public string id { get; set; }
    }
}
