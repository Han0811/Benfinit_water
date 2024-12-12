using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Benfinit_water.Model
{
    internal class usermodel
    {
        public int Id { get; set; }  // Định nghĩa ID, kiểu int, tự động tăng nếu là khóa chính trong cơ sở dữ liệu.
        public bool IsAdmin { get; set; }// Default là false.
        public string UserName { get; set; }  // Tên người dùng.
        public bool IsActive { get; set; }// Default là false.
        public int DonViCongTac { get; set; }  // Đơn vị công tác, mặc định là 0.
        public string Address { get; set; }  // Địa chỉ.
        public string Email { get; set; }  // Email.
        public string Phone { get; set; }  // Số điện thoại.
        public string Password { get; set; }  // Mật khẩu (mã hóa mật khẩu khi lưu trữ).
        public DateTime DateJoined { get; set; }  // Ngày tham gia, mặc định là thời gian hiện tại.
        public string FirstName { get; set; }  // Tên.
        public string LastName { get; set; }  // Họ.
    }

}
