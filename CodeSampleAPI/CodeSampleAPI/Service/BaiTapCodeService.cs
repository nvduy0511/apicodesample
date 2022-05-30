﻿using CodeSampleAPI.Data;
using CodeSampleAPI.Model;
using CodeSampleAPI.Model.searchResult;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CodeSampleAPI.Service
{
    public interface IBaiTapCodeService
    {
        BaiTapCode GetById(int id);

        List<BaiTapCode> getAllBaiTapCode();
        bool addBaiTapCodeAndTestCases(BaiTapCode_Custom baiTapCode_Custom);
        List<BaiTapCode> getListBaiTapCodeByUId(string uID);
        List<CauHoi_SearchResult> searchByIdOrMoTa(string searchValue);
        bool deleteBaiTapCode(int id);
    }

    public class BaiTapCodeService : IBaiTapCodeService
    {
        private readonly CodeSampleContext _codeSampleContext;
        public BaiTapCodeService(CodeSampleContext codeSampleContext)
        {
            this._codeSampleContext = codeSampleContext;
        }

  
        public BaiTapCode GetById(int id)
        {
            return _codeSampleContext.BaiTapCodes.FirstOrDefault(p => p.Id == id);
        }
        public List<BaiTapCode> getAllBaiTapCode()
        {
            return _codeSampleContext.BaiTapCodes.ToList();
        }

        public bool addBaiTapCodeAndTestCases(BaiTapCode_Custom btCode_Custom)
        {
            BaiTapCode baiTapCode = new BaiTapCode() { 
                DeBai = btCode_Custom.DeBai, 
                TieuDe = btCode_Custom.TieuDe, 
                UIdNguoiTao = btCode_Custom.UIdNguoiTao, 
                RangBuoc = btCode_Custom.RangBuoc, 
                DinhDangDauRa = btCode_Custom.DinhDangDauRa, 
                DinhDangDauVao = btCode_Custom.DinhDangDauVao, 
                MauDauRa = btCode_Custom.MauDauRa,
                MauDauVao = btCode_Custom.MauDauVao, 
                NgonNgu = btCode_Custom.NgonNgu
            };

            List<TestCase_Custom> testCases = btCode_Custom.testCases;
            try
            {
                _codeSampleContext.BaiTapCodes.Add(baiTapCode);
                _codeSampleContext.SaveChanges();
                foreach (var testCase in testCases)
                {
                    TestCaseBtcode t = new TestCaseBtcode() { IdBaiTap = baiTapCode.Id, Input = testCase.Input, Output = testCase.Output };
                    _codeSampleContext.TestCaseBtcodes.Add(t);
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error: ", ex);
                return false;
            }
            return true;

        }

        public bool deleteBaiTapCode(int id)
        {
            BaiTapCode btCode = _codeSampleContext.BaiTapCodes.FirstOrDefault(p => p.Id == id);
            if (btCode == null)
                return false;

            try
            {
                _codeSampleContext.BaiTapCodes.Remove(btCode);
                _codeSampleContext.SaveChanges();
            }
            catch (System.Exception)
            {
                return false;
            }
            return true;
        }

        public List<CauHoi_SearchResult> searchByIdOrMoTa(string searchValue)
        {
            searchValue = RemoveVietnameseTone(searchValue.Trim());
            List<CauHoi_SearchResult> lsByID = new List<CauHoi_SearchResult>();
            List<CauHoi_SearchResult> lsByMoTa = new List<CauHoi_SearchResult>();

            int id;
            if(int.TryParse(searchValue,out id))
            {
                // filter theo id
                lsByID = (from bt in _codeSampleContext.BaiTapCodes
                          where bt.Id == id
                          select new CauHoi_SearchResult()
                          {
                              id = bt.Id,
                              moTa = bt.TieuDe
                          }).ToList();
            }    
            //fliter theo moTa
            lsByMoTa = (from bt in _codeSampleContext.BaiTapCodes
                        where bt.TieuDe.ToLower().Contains(searchValue)
                        select new CauHoi_SearchResult()
                        {
                            id = bt.Id,
                            moTa = bt.TieuDe
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

        public List<BaiTapCode> getListBaiTapCodeByUId(string uID)
        {
            return _codeSampleContext.BaiTapCodes.Where(bt => bt.UIdNguoiTao == uID).ToList();
        }
    }
}
