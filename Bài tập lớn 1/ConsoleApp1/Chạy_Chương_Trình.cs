using ConsoleApp1;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static Bài_tập_lớn_1.Chạy_Chương_Trình;
using static Bài_tập_lớn_1.Quản_Lý_Khoa;
using static Bài_tập_lớn_1.Quản_Lý_Lớp;
using static Bài_tập_lớn_1.Quản_Lý_Niên_Khóa;

namespace Bài_tập_lớn_1
{
    internal class Chạy_Chương_Trình
    {
        public static int luachon()
        {
            int i;
            while (true)
            {
                Console.Write("Mời nhập lựa chọn của bạn: ");

                if (int.TryParse(Console.ReadLine(), out i))
                {
                    break;
                }
                else Console.WriteLine("Nhập lựa chọn chưa đúng định dạng");
            }
            return i;
        }
        public static void inchinh()
        {
            //Console.Clear ();
            Console.WriteLine("\t\t\t\t\t╔═════════════════════════════════════════════════╗");
            Console.WriteLine("\t\t\t\t\t║                QUẢN LÝ SINH VIÊN                ║");
            Console.WriteLine("\t\t\t\t\t╠═════════════════════════════════════════════════╣");
            Console.WriteLine("\t\t\t\t\t║             1. QUẢN LÝ NIÊN KHOÁ                ║");
            Console.WriteLine("\t\t\t\t\t║         └───────────────────────┘               ║");
            Console.WriteLine("\t\t\t\t\t║           2. QUẢN LÝ KHOA ĐÀO TẠO               ║");
            Console.WriteLine("\t\t\t\t\t║         └───────────────────────┘               ║");
            Console.WriteLine("\t\t\t\t\t║             3. QUẢN LÝ THÔNG TIN LỚP            ║");
            Console.WriteLine("\t\t\t\t\t║         └───────────────────────┘               ║");
            Console.WriteLine("\t\t\t\t\t║                4. THÊM LỚP                      ║");
            Console.WriteLine("\t\t\t\t\t║         └───────────────────────┘               ║");
            Console.WriteLine("\t\t\t\t\t║           5. HIỂN THỊ CÁC LỚP ĐANG CÓ           ║");
            Console.WriteLine("\t\t\t\t\t║         └───────────────────────┘               ║");
            Console.WriteLine("\t\t\t\t\t║           6. THÔNG TIN NGƯỜI QUẢN LÝ            ║");
            Console.WriteLine("\t\t\t\t\t║         └───────────────────────┘               ║");
            Console.WriteLine("\t\t\t\t\t║            7. THOÁT KHỎI CHƯƠNG TRÌNH           ║");
            Console.WriteLine("\t\t\t\t\t║         └───────────────────────┘               ║");
            Console.WriteLine("\t\t\t\t\t╠═════════════════════════════════════════════════╣");
            Console.WriteLine("\t\t\t\t\t║         Hãy chọn một trong các chức năng trên:  ║");
            Console.WriteLine("\t\t\t\t\t╚═════════════════════════════════════════════════╝");

            int lc = luachon();
            switch (lc)
            {
                case 1:
                    Console.Clear();
                    Quản_Lý_Niên_Khóa.Quanlycacnienkhoa();
                    inchinh();
                    break;

                case 2:
                    Console.Clear();
                    Quản_Lý_Khoa.QLDScackhoa();              
                    inchinh();
                    break;
                case 3:
                    Console.Clear();
                    Quản_Lý_Lớp.QLDSlop();                   
                    inchinh();
                    break;
                case 4:
                    Console.Clear();
                    Quản_Lý_Lớp.themlopmoivaods();                   
                    inchinh();
                    break;
                case 5:
                    Console.Clear();
                    Quản_Lý_Lớp.Hiethicaclopdaco();                    
                    break;
                case 6:
                    Console.Clear();
                    Console.WriteLine($"Được biết đến là một người quản lý rất tài năng và có tinh thần trách nhiệm cao, Hiếu luôn đảm bảo rằng công việc được hoàn thành với chất lượng và hiệu quả tốt nhất. Với tính cẩn trọng và tỉ mỉ trong từng chi tiết, anh ta luôn luôn dành thời gian và nỗ lực để đảm bảo rằng mọi thứ được hoàn thành đúng theo kế hoạch và tiêu chuẩn cao nhất.\r\n\r\nBên cạnh đó, Hiếu cũng là một người đầy tình cảm và tận tâm. Anh ta luôn quan tâm đến sự phát triển của các nhân viên trong tổ chức và luôn sẵn lòng giúp đỡ họ trong công việc để đạt được mục tiêu chung của tổ chức. Sự giúp đỡ và hỗ trợ của anh ta đã giúp cho nhiều nhân viên trong tổ chức cảm thấy tự tin và khích lệ trong công việc của mình.\r\n\r\nVì vậy, không chỉ được biết đến với vẻ đẹp trai, Hiếu còn là một người quản lý rất nghiêm túc và tận tâm, luôn sẵn sàng giúp đỡ và hỗ trợ mọi người trong công việc để đạt được kết quả tốt nhất cho tổ chức.");
                    break;
                case 7:
                    Console.Clear();
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("\t\t\t\t\t╔════════════════════════════════════════════════════════════════╗");
                    Console.WriteLine("\t\t\t\t\t║           KHÔNG CÓ CHỨC NĂNG NÀY. VUI LÒNG NHẬP LẠI            ║");
                    Console.WriteLine("\t\t\t\t\t╚════════════════════════════════════════════════════════════════╝");
                    inchinh();
                    break;
            }

        }
        static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;
            //Quản_Lý_Niên_Khóa.docdanhsachnienkhoa();
            //Quản_Lý_Khoa.docdanhsachkhoa();
            //Quản_Lý_Lớp.docdanhsachlop();
            //Quản_Lý_Lớp.docdanhsachsv();
            //Quản_Lý_Đăng_Nhập.Congviec();
            inchinh() ;
        }
    }

}
