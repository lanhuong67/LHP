using System;

namespace DTO
{
    // Class static này sẽ tồn tại xuyên suốt quá trình chạy phần mềm.
    // Khi một nhân viên đăng nhập thành công, hệ thống sẽ gán thông tin của họ vào đây.
    public static class UserSession
    {
        // Mình gán sẵn giá trị mặc định để bạn test giao diện khi chưa code xong Form Login.
        // Khi làm Form Login, bạn sẽ cập nhật lại các biến này bằng dữ liệu thực từ SQL.
        public static string MaNV { get; set; } = "NV001";
        public static string HoTen { get; set; } = "Lê Hữu Phúc";
        public static string ChucVu { get; set; } = "Admin";
    }
}