using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using CodeSampleAPI.Data;
using CodeSampleAPI.Model;
using CodeSampleAPI.Model.searchResult;

namespace CodeSampleAPI.Service
{
    public interface IBaiTapTracNghiemService
    {
        bool addBaiTapTracNghiem(BaiTapTracNghiem_Custom btTN_Custom);
        List<BaiTapTracNghiem> getAll();
        BaiTapTracNghiem getOne(int id);
        IList<BaiTapTracNghiem> getListByUId(string uID);
        List<CauHoi_SearchResult> searchBaiTapTN(string searchValue);
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
            catch (Exception )
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
            catch (Exception e)
            {
                string error = e.Message;
                return false;
            }
            return true;
        }

        public List<CauHoi_SearchResult> searchBaiTapTN(string searchValue)
        {
            searchValue = RemoveVietnameseTone(searchValue.Trim());
            List<CauHoi_SearchResult> lsByID = new List<CauHoi_SearchResult>();
            List<CauHoi_SearchResult> lsByMoTa = new List<CauHoi_SearchResult>();

            int id;
            if (int.TryParse(searchValue, out id))
            {
                // filter theo id
                lsByID = (from bt in _codeSampleContext.BaiTapTracNghiems
                          where bt.Id == id
                          select new CauHoi_SearchResult()
                          {
                              id = bt.Id,
                              moTa = bt.CauHoi
                          }).ToList();
            }
            //fliter theo moTa
            lsByMoTa = (from bt in _codeSampleContext.BaiTapTracNghiems
                        where bt.CauHoi.ToLower().Contains(searchValue.ToLower())
                        select new CauHoi_SearchResult()
                        {
                            id = bt.Id,
                            moTa = bt.CauHoi
                        }).ToList();
           
            return lsByID.Union(lsByMoTa, new CauHoi_SearchResult_Compare()).ToList();
        }

        public string RemoveVietnameseTone(string text)
        {
            string result = text.ToLower();
            result = Regex.Replace(result, "à|á|ạ|ả|ã|â|ầ|ấ|ậ|ẩ|ẫ|ă|ằ|ắ|ặ|ẳ|ẵ|/g", "a");
            result = Regex.Replace(result, "è|é|ẹ|ẻ|ẽ|ê|ề|ế|ệ|ể|ễ|/g", "e");
            result = Regex.Replace(result, "ì|í|ị|ỉ|ĩ|/g", "i");
            result = Regex.Replace(result, "ò|ó|ọ|ỏ|õ|ô|ồ|ố|ộ|ổ|ỗ|ơ|ờ|ớ|ợ|ở|ỡ|/g", "o");
            result = Regex.Replace(result, "ù|ú|ụ|ủ|ũ|ư|ừ|ứ|ự|ử|ữ|/g", "u");
            result = Regex.Replace(result, "ỳ|ý|ỵ|ỷ|ỹ|/g", "y");
            result = Regex.Replace(result, "đ", "d");
            return result;
        }

        public BaiTapTracNghiem getOne(int id)
        {
            return _codeSampleContext.BaiTapTracNghiems.FirstOrDefault(p => p.Id == id);
        }

        public IList<BaiTapTracNghiem> getListByUId(string uID)
        {
            return _codeSampleContext.BaiTapTracNghiems.Where(tn => tn.UIdNguoiTao == uID).ToList();
        }
    }
}
