using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeSampleAPI.Model
{
    public class RunCodeRequest
    {
        private String code;
        private String language;
        private String input;

        public string Code { get => code; set => code = value; }
        public string Language { get => language; set => language = value; }
        public string Input { get => input; set => input = value; }
    }
}
