using DAL;
using DTO;
using System.Collections.Generic;

namespace BUS
{
    public class HangSanXuatBUS
    {
        private HangSanXuatDAL _dal = new HangSanXuatDAL();

        public List<HangSanXuat> GetAll()
        {
            return _dal.GetAll();
        }

        public bool Them(HangSanXuat h)
        {
            return _dal.Them(h);
        }

        public bool Sua(HangSanXuat h)
        {
            return _dal.Sua(h);
        }

        public bool Xoa(string maHang)
        {
            string thongBao;
            return _dal.Xoa(maHang, out thongBao);
        }

        public bool Xoa(string maHang, out string thongBao)
        {
            return _dal.Xoa(maHang, out thongBao);
        }
    }
}