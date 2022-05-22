using System;
using System.Collections.Generic;

#nullable disable

namespace CodeSampleAPI.Data
{
    public partial class TestCaseBtcode
    {
        public int Id { get; set; }
        public string Input { get; set; }
        public string Output { get; set; }
        public int IdBaiTap { get; set; }

        public virtual BaiTapCode IdBaiTapNavigation { get; set; }
    }
}
