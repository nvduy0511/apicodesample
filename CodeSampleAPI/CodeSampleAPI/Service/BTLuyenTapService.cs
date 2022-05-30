using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodeSampleAPI.Data;
using CodeSampleAPI.Model;

namespace CodeSampleAPI.Service
{
    public interface IBTLuyenTapService
    {
        List<BTLuyenTap_getAll> getAll();
        List<BtLuyenTap> getBTLuyenTapByuID(string uID);
        BtLuyenTap getOne(int id);

        bool add(BaiTapLuyenTap_Custom btLuyenTap_Cus);
    }
    public class BTLuyenTapService:IBTLuyenTapService
    {
        private readonly CodeSampleContext _codeSampleContext;
        public BTLuyenTapService(CodeSampleContext codeSampleContext)
        {
            this._codeSampleContext = codeSampleContext;
        }

        public bool add(BaiTapLuyenTap_Custom btLuyenTap_Cus)
        {
            BtLuyenTap baiLuyenTap = new BtLuyenTap()
            {
                DeBai = btLuyenTap_Cus.DeBai,
                TieuDe = btLuyenTap_Cus.TieuDe,
                UIdNguoiTao = btLuyenTap_Cus.UIdNguoiTao,
                RangBuoc = btLuyenTap_Cus.RangBuoc,
                DinhDangDauRa = btLuyenTap_Cus.DinhDangDauRa,
                DinhDangDauVao = btLuyenTap_Cus.DinhDangDauVao,
                MauDauRa = btLuyenTap_Cus.MauDauRa,
                MauDauVao = btLuyenTap_Cus.MauDauVao,
                Tag = btLuyenTap_Cus.Tag,
                DoKho = btLuyenTap_Cus.DoKho,
                SoNguoiLam = 0,
                SoNguoiThanhCong = 0
            };

            List<TestCase_Custom> testCases = btLuyenTap_Cus.testCases;
            try
            {
                _codeSampleContext.BtLuyenTaps.Add(baiLuyenTap);
                _codeSampleContext.SaveChanges();
                foreach (var testCase in testCases)
                {
                    TestCaseLuyenTap t = new TestCaseLuyenTap() { IdBtluyenTap = baiLuyenTap.Id, Input = testCase.Input, Output = testCase.Output };
                    _codeSampleContext.TestCaseLuyenTaps.Add(t);
                }
                _codeSampleContext.SaveChanges();
            }
            catch (System.Exception)
            {
                return false;
            }
            return true;
        }

        public List<BTLuyenTap_getAll> getAll()
        {
            var res = (from bt in _codeSampleContext.BtLuyenTaps
                       select new BTLuyenTap_getAll()
                       {
                           Id = bt.Id,
                           DoKho = bt.DoKho,
                           LinkAvatar = bt.UIdNguoiTaoNavigation.LinkAvatar,
                           SoNguoiLam = bt.SoNguoiLam,
                           SoNguoiThanhCong = bt.SoNguoiThanhCong,
                           Tag = bt.Tag,
                           TenHienThi = bt.UIdNguoiTaoNavigation.TenHienThi,
                           TieuDe = bt.TieuDe
                       }).ToList();
            return res;
        }

        public BtLuyenTap getOne(int id)
        {
            return _codeSampleContext.BtLuyenTaps.FirstOrDefault(p => p.Id == id);
        }

        public List<BtLuyenTap> getBTLuyenTapByuID(string uID)
        {
            return _codeSampleContext.BtLuyenTaps.Where(bt => bt.UIdNguoiTao == uID).ToList();
        }
    }
}
