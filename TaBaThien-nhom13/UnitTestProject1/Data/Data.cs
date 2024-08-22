using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace UnitTestProject1.Data
{
    public static class Data
    {
        public static string name = "Nguyen Van A";
        public static string phoneNumber = "0975621962";
        public static string invalidPhone = "SPRING2024";
        public static string email = "testmail@gmail.com";
        public static string invalidEmail = "invalidmail.....";
        public static string address = "so 7 163/36";
        public static string notiName = "Mục Họ và tên: là mục bắt buộc.";
        public static string notiNumber = "Mục Số điện thoại: là mục bắt buộc.";
        public static string notiInvalidNumber = "Mục Số điện thoại: không phải là số điện thoại hợp lệ.";
        public static string notiEmail = "Mục Địa chỉ email: là mục bắt buộc.";
        public static string notiInvalidEmail = "Địa chỉ email thanh toán không hợp lệ";
        public static string notiProvince = "Mục Tỉnh/Thành phố: là mục bắt buộc.";
        public static string notiDistrict = "Mục Quận/Huyện: là mục bắt buộc.";
        public static string notiWard = "Mục Xã/Phường/Thị trấn: là mục bắt buộc.";
        public static string notiAddress = "Mục Địa chỉ: là mục bắt buộc.";
        public static string receiverName = "Nguyen Van B";
        public static string receiverNumber = "0875621962";
        public static string receiverAddress = "so 7 duong Chua Lang";
        public static string notiReceiverName = "Shipping Tên đầy đủ của người nhận là mục bắt buộc.";
        public static string notiReceiverNumber = "";
        public static string notiReceiverProvince = "Shipping Tỉnh/Thành phố là mục bắt buộc.";
        public static string notiReceiverDistrict = "Shipping Quận/Huyện là mục bắt buộc.";
        public static string notiReceiverWard = "Shipping Xã/Phường/Thị trấn là mục bắt buộc.";
        public static string notiReceiverAddress = "Shipping Địa chỉ là mục bắt buộc.";
        public static string couponCode = "AUTUMN2024";
        public static string notiCouponCode = "Mã giảm giá \"autumn2024\" không tồn tại!";
    }
}
