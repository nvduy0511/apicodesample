using System;
using System.Collections.Generic;

#nullable disable

namespace CodeSampleAPI.Data
{
    public partial class TestCaseLuyenTap
    {
        public int Id { get; set; }
        public string Input { get; set; }
        public string Output { get; set; }
        public int IdBtluyenTap { get; set; }

        public virtual BtLuyenTap IdBtluyenTapNavigation { get; set; }
    }
}
