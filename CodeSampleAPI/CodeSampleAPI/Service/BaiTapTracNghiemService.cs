using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodeSampleAPI.Data;
using CodeSampleAPI.Model;

namespace CodeSampleAPI.Service
{
    public interface IBaiTapTracNghiemService
    {
        bool addBaiTapTracNghiem(BaiTapTracNghiem_Custom btTN_Custom);
        List<BaiTapTracNghiem> getAll();

        bool deleteBaiTapTN(int id);
    }
    public class BaiTapTracNghiemService : IBaiTapTracNghiemService
    {
        private readonly CodeSampleContext _codeSampleContext;
        public BaiTapTracNghiemService(CodeSampleContext codeSampleContext)
        {
            this._codeSampleContext = codeSampleContext;
        }
        public bool addBaiTapTracNghiem(BaiTapTracNghiem_Custom btTN_Custom)
        {
            BaiTapTracNghiem btTN = new BaiTapTracNghiem()
            {
                CauHoi = btTN_Custom.CauHoi,
                CauTraLoi1 = btTN_Custom.CauTraLoi1,
                CauTraLoi2 = btTN_Custom.CauTraLoi2,
                CauTraLoi3 = btTN_Custom.CauTraLoi3,
                CauTraLoi4 = btTN_Custom.CauTraLoi4,
                DapAn = btTN_Custom.DapAn,
                UIdNguoiTao = btTN_Custom.UIdNguoiTao
            };

            try
            {
                _codeSampleContext.BaiTapTracNghiems.Add(btTN);
                _codeSampleContext.SaveChanges();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public List<BaiTapTracNghiem> getAll()
        {
            return _codeSampleContext.BaiTapTracNghiems.ToList();
        }
        public bool deleteBaiTapTN(int id)
        {
            BaiTapTracNghiem btTN = _codeSampleContext.BaiTapTracNghiems.FirstOrDefault(p => p.Id == id);
            if (btTN == null)
                return false;
            try
            {
                _codeSampleContext.BaiTapTracNghiems.Remove(btTN);
                _codeSampleContext.SaveChanges();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
    }
}
