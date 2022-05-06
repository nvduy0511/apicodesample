using System;
using System.Collections.Generic;

#nullable disable

namespace CodeSampleAPI.DAL
{
    public partial class TestCase
    {
        public int Id { get; set; }
        public string Intput { get; set; }
        public string Output { get; set; }
        public int IdBaiTap { get; set; }

        public virtual BaiTapCode IdBaiTapNavigation { get; set; }
    }
}
