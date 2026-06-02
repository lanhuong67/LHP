using System;
using System.Collections.Generic;
using System.Linq;
using DAL;
using DTO;

namespace BUS
{
    public class ChiNhanhBUS
    {
        private ChiNhanhDAL _dal = new ChiNhanhDAL();

        public List<ChiNhanh> GetAll()
        {
            return _dal.GetAll();
        }

        public List<ChiNhanh> GetChiNhanhDangHoatDong()
        {
            return _dal.GetAll()
                .Where(cn => LaTrangThaiDangHoatDong(cn.TrangThai))
                .ToList();
        }

        public bool ChiNhanhDangHoatDong(string maCN)
        {
            if (string.IsNullOrWhiteSpace(maCN))
                return false;

            var cn = _dal.GetAll()
                .FirstOrDefault(x => x.MaChiNhanh == maCN);

            if (cn == null)
                return false;

            return LaTrangThaiDangHoatDong(cn.TrangThai);
        }

        public bool LaTrangThaiDangHoatDong(string trangThai)
        {
            if (string.IsNullOrWhiteSpace(trangThai))
                return false;

            string value = trangThai.Trim().ToLower();

            return value == "đang hoạt động"
                || value == "dang hoat dong"
                || value == "hoạt động"
                || value == "hoat dong"
                || value == "đang kinh doanh"
                || value == "dang kinh doanh"
                || value == "active"
                || value == "true"
                || value == "1";
        }

        public bool LaTrangThaiNgungHoatDong(string trangThai)
        {
            if (string.IsNullOrWhiteSpace(trangThai))
                return false;

            string value = trangThai.Trim().ToLower();

            return value == "ngừng hoạt động"
                || value == "ngung hoat dong"
                || value == "ngưng hoạt động"
                || value == "ngung hoạt động"
                || value == "tạm ngưng"
                || value == "tam ngung"
                || value == "inactive"
                || value == "false"
                || value == "0";
        }

        public bool Them(ChiNhanh cn)
        {
            return _dal.Them(cn);
        }

        public bool Sua(ChiNhanh cn)
        {
            return _dal.Sua(cn);
        }

        public bool Xoa(string maCN)
        {
            return _dal.Xoa(maCN);
        }
    }
}
