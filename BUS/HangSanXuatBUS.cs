using DAL;
using DTO;
using System.Collections.Generic;

namespace BUS
{
    public class HangSanXuatBUS
    {
        private HangSanXuatDAL _dal = new HangSanXuatDAL();

        public List<HangSanXuat> GetAll() => _dal.GetAll();
        public bool Them(HangSanXuat hsx) => _dal.Them(hsx);
        public bool Sua(HangSanXuat hsx) => _dal.Sua(hsx);
        public bool Xoa(string maHang) => _dal.Xoa(maHang);
    }
}