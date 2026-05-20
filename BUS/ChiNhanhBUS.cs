using System;
using System.Collections.Generic;
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

        public bool Them(ChiNhanh cn)
        {
            // Ở BUS bạn có thể bổ sung các luật (Business Rules) trước khi đẩy xuống DAL
            // Ví dụ: Kiểm tra số điện thoại có hợp lệ không, email đúng định dạng không...
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