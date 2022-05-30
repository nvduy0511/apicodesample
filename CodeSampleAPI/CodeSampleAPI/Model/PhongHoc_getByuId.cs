using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeSampleAPI.Model
{
    public class PhongHoc_getByuId
    {
        public int Id { get; set; }
        public string TenPhong { get; set; }
        public string TenNguoiTao { get; set; }
        public string LinkAvatar { get; set; }
        public int? SoNguoiThamGia { get; set; }
    }
}
