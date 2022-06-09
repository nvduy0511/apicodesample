using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeSampleAPI.Model
{
    public class RunCodeResponse
    {
        public bool success { get; set; }
        public string timestamp { get; set; }
        public string output { get; set; }
        public string language { get; set; }
        public string version { get; set; }
    }
}
