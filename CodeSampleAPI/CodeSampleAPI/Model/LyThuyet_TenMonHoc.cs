using CodeSampleAPI.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeSampleAPI.Model
{
    public class LyThuyet_TenMonHoc
    {
        public string tenMonHoc { get; set; }
        public List<LyThuyet> lyThuyets { get; set; }
    }
}
