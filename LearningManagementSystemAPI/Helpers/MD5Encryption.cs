using System.Security.Cryptography;
using System.Text;

namespace LearningManagementSystemAPI.Helpers
{
    public class MD5Encryption
    {
        public static string CalculateMD5(string input)
        {
            // Chuyển đổi chuỗi vào mảng bytes
            byte[] inputBytes = Encoding.UTF8.GetBytes(input);

            // Khởi tạo MD5
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                // Mã hoá mảng bytes
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                // Chuyển đổi mảng bytes thành chuỗi hex
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("x2"));
                }

                // Trả về chuỗi đã mã hoá
                return sb.ToString();
            }
        }
    }
}
