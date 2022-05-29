using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeSampleAPI.Model
{
    public class BaiLamKiemTraCustom
    {
        public float tongDiem { get; set; }
        public string uId { get; set; }
        public int idDeKiemTra { get; set; }
        public List<CauTraLoi> lsCauTraLoi { get; set; }

    }
}
