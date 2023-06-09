using Bài_tập_lớn_1;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static Bài_tập_lớn_1.Quản_Lý_Khoa;
using static Bài_tập_lớn_1.Quản_Lý_Lớp;
using static Bài_tập_lớn_1.Quản_Lý_Niên_Khóa;
using static Bài_tập_lớn_1.Quản_Lý_Sinh_Viên;
using static ConsoleApp1.Quản_Lý_Đăng_Nhập;

namespace Bài_tập_lớn_1
{
    internal class Quản_Lý_Lớp : Quản_Lý_Sinh_Viên
    {
        public struct Lop
        {
            public string Malop;
            public string Tenlop;
            public string Giaovienchunhiem;
            public string Makhoa;
            public string Manienkhoa;
            public List<Sinhvien> DS1lop;
        }
        public static Lop Taolopmoi(string Malop, string Tenlop,string Giaovienchunhiem, string Makhoa, string Manienkhoa)
        {//hàm tạo lớp mới 
            Lop lop = new Lop();
            lop.Malop = Malop;
            lop.Tenlop = Tenlop;
            lop.Giaovienchunhiem = Giaovienchunhiem;
            lop.Makhoa = Makhoa;
            lop.Manienkhoa = Manienkhoa;
            lop.DS1lop = new List<Sinhvien>();
            return lop;
        }
        //Thực hiện quản lý thông tin các lớp
        public static List<Lop> DSlop = new List<Lop>();
        //Thực hiện quản lý thông tin các sinh viên trong lớp
        public static List<Sinhvien> DSSV = new List<Sinhvien>();

        public static void themlopmoivaods()
        {
            bool kt = false;
            string Malop;
            string Tenlop;
            string Giaovienchunhiem;
            string Makhoa;
            string Manienkhoa;
            do
            {
                do
                {
                    Console.Write("Mời nhập vào mã lớp (gồm 6 số): ");
                    Malop = Console.ReadLine();
                    if (!Regex.IsMatch(Malop, @"^[0-9]+$") || Malop.Length!=6){ Console.WriteLine("Mã lớp không đúng định dạng vui lòng nhập lại"); }
                } while (!Regex.IsMatch(Malop, @"^[0-9]+$") || Malop.Length != 6);//kiểm tra điều kiện sai (nếu Malop nhập vào khác 0-9 và phải 6 số) thì nhập lại
                DSlop.Clear();
                docdanhsachlop();
                kt = kttrunglop(Malop);//kiểm tra lớp có trùng ko đã,xem xem kt là true hay false
                if (kt == false)
                {
                    Console.WriteLine("Mã lớp đã có mời nhập lại thông tin");
                }
                DSlop.Clear();
            } while (kt == false);//kt phải là true thì mới thoát khỏi vòng lặp

            do
            {               
                Console.Write("Mời nhập tên lớp: ");
                Tenlop = Console.ReadLine().Trim();//Trim là bỏ khoảng trắng ở đầu với cuối
                Tenlop= Regex.Replace(Tenlop, @"\s+", " ");//thay thế các khoảng trắng liên tiếp bằng một khoảng trắng duy nhất                
                if (!Regex.IsMatch(Tenlop, @"^[a-zA-Z0-9 ]+$")|| Tenlop.Length > 30 || Tenlop.Length == 0)
                {
                    Console.WriteLine("Tên lớp không đúng định dạng vui lòng nhập lại");
                }
                //kiểm tra điều kiện sai (nếu Tenlop nhập vào (khác a-zA-Z0-9 )và (trên 30 kí tự) và (= rỗng) thì nhập lại)
            } while (!Regex.IsMatch(Tenlop, @"^[a-zA-Z0-9 ]+$")||Tenlop.Length > 30 || Tenlop.Length == 0);//khác kí tự đặc biệt và không quá 30 kí rự và khác rỗng 
            //Console.WriteLine(Tenlop);

            do
            {
                Console.Write("Mời nhập tên giáo viên chủ nhiệm: ");
                Giaovienchunhiem = Console.ReadLine().Trim();
                Giaovienchunhiem = Regex.Replace(Giaovienchunhiem, @"\s+", " ");//thay thế các khoảng trắng liên tiếp bằng một khoảng trắng duy nhất
                if (!Regex.IsMatch(Giaovienchunhiem, @"^[a-zA-Z0-9 ]+$") || Giaovienchunhiem.Length > 30 || Giaovienchunhiem.Length == 0)
                {
                    Console.WriteLine("Tên giáo viên chủ nhiệm không đúng định dạng vui lòng nhập lại");
                }
                //kiểm tra điều kiện sai (nếu Giaovienchunhiem nhập vào (khác a-zA-Z0-9 )và (trên 30 kí tự) và (= rỗng) thì nhập lại)
            } while (!Regex.IsMatch(Giaovienchunhiem, @"^[a-zA-Z0-9 ]+$") || Giaovienchunhiem.Length > 30 || Giaovienchunhiem.Length == 0);
            //Console.WriteLine(Giaovienchunhiem);

            do
            {
                do
                {
                    Console.Write("Mời nhập mã khoa: "); Makhoa = Console.ReadLine();
                    if (!Regex.IsMatch(Makhoa, @"^[0-9]+$")){ Console.WriteLine("Mã khoa không đúng định dạng vui lòng nhập lại"); }
                } while (!Regex.IsMatch(Makhoa, @"^[0-9]+$"));
                kt =Quản_Lý_Khoa.Ktttrung(Makhoa);                    
                if (kt == false)
                {
                    Console.WriteLine("Mã khoa đã có mời nhập lại thông tin ");
                }
                else break;
            } while (kt == true);

            do
            {
                do
                {
                    Console.Write("Mời nhập mã niên khóa: "); Manienkhoa = Console.ReadLine();
                    if(!Regex.IsMatch(Manienkhoa, @"^[0-9]+$")) { Console.WriteLine("Mã niên khóa không đúng định dạng vui lòng nhập lại"); }
                } while (!Regex.IsMatch(Manienkhoa, @"^[0-9]+$"));
                kt =Quản_Lý_Niên_Khóa.Ktttrung(Manienkhoa);
                if (kt == false)
                {
                    Console.WriteLine("Mã niên khóa đã có mời nhập lại thông tin");
                }
                else break;
            } while (kt == true);

            Lop lp = Taolopmoi(Malop, Tenlop,Giaovienchunhiem, Makhoa, Manienkhoa);
            DSlop.Add(lp);
            Console.Clear();
            Console.WriteLine("Bạn đã thêm lớp vào DSlop rồi");

            //Console.WriteLine("Thêm lớp vào danh sách khoa quản lý");
            Console.WriteLine("╔═════════════════════════════════════════════════════════════╗");
            Console.WriteLine("║  Bạn có muốn thêm lớp này vào danh sách khoa quản lý không  ║");
            Console.WriteLine("║═════════════════════════════════════════════════════════════║");
            Console.WriteLine("║                                                             ║");
            Console.WriteLine("║                 ╭───────────────────────╮                   ║");
            Console.WriteLine("║                 │      1.Có             │                   ║");
            Console.WriteLine("║                 ╰───────────────────────╯                   ║");
            Console.WriteLine("║                 ╭───────────────────────╮                   ║");
            Console.WriteLine("║                 │      2.Không          │                   ║");
            Console.WriteLine("║                 ╰───────────────────────╯                   ║");
            Console.WriteLine("╠═════════════════════════════════════════════════════════════╣");
            Console.WriteLine("║           Hãy chọn một trong các chức năng trên:            ║");
            Console.WriteLine("╚═════════════════════════════════════════════════════════════╝");
            Console.Write("Mời nhập lựa chọn của bạn: ");
            string nhap = Console.ReadLine();
            if (nhap.Equals("1"))
            {
                kt = Quản_Lý_Khoa.Ktttrung(Makhoa);
                if (kt == false)
                {
                    Quản_Lý_Khoa.Laykhoa(Makhoa).DSlop.Add(lp);//thêm vào danh sách khoa quản lý
                    //Quản_Lý_Khoa.Laykhoa(Makhoa).DSlop.Add(lp);//thêm vào danh sách khoa quản lý
                    Console.WriteLine("Thêm lớp thành công vào DSlop trong DSkhoa");
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Mã khoa chưa có trong DSkhoa nên không thể ghi thông tin vào DSlop");
                    Console.WriteLine("Khoa này chưa tồn tại.Bạn phải thêm khoa này đã.");
                }
            }
            else Console.Clear();

            //Console.WriteLine("Thêm lớp vào danh sách niên khóa quản lý");
            Console.WriteLine("╔═════════════════════════════════════════════════════════════╗");
            Console.WriteLine("║    Bạn có muốn thêm lớp này vào danh sách niên khóa không   ║");
            Console.WriteLine("║═════════════════════════════════════════════════════════════║");
            Console.WriteLine("║                                                             ║");
            Console.WriteLine("║                 ╭───────────────────────╮                   ║");
            Console.WriteLine("║                 │      1.Có             │                   ║");
            Console.WriteLine("║                 ╰───────────────────────╯                   ║");
            Console.WriteLine("║                 ╭───────────────────────╮                   ║");
            Console.WriteLine("║                 │      2.Không          │                   ║");
            Console.WriteLine("║                 ╰───────────────────────╯                   ║");
            Console.WriteLine("╠═════════════════════════════════════════════════════════════╣");
            Console.WriteLine("║           Hãy chọn một trong các chức năng trên:            ║");
            Console.WriteLine("╚═════════════════════════════════════════════════════════════╝");
            Console.Write("Mời nhập lựa chọn của bạn: ");
            string nhap1 = Console.ReadLine();
            if (nhap1.Equals("1"))
            {
                kt = Quản_Lý_Niên_Khóa.Ktttrung(Manienkhoa);
                if (kt == false)
                {
                    Quản_Lý_Niên_Khóa.Laynienkhoa(Manienkhoa).DSlop.Add(lp);//thêm vào dah sach niên khoá
                    //Quản_Lý_Niên_Khóa.Laynienkhoa(Manienkhoa).DSlop.Add(lp);//thêm vào dah sach niên khoá
                    Console.WriteLine("Thêm lớp thành công vào DSlop trong DSnienkhoa");

                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Mã niên khóa chưa có trong DSnienkhoa nên không thể ghi thông tin vào DSlop");
                    Console.WriteLine("Niên khóa này chưa tồn tại.Bạn phải thêm niên khóa này đã.");
                }
            }
            else Console.Clear();
            ghidanhsachlop();
        }
        static Lop LayLop(string Malop)
        {//kiểm tra mã lớp nếu tồn tại thì trả ra lop còn ko tồn tại thi trả ra rỗng
            foreach (Lop lop in DSlop)
            {
                if (lop.Malop == Malop)
                {
                    return lop;
                }
            }
            Lop LopTrong = new Lop(); return LopTrong;
        }
        public static bool kttrunglop(string Malop)
        {
            bool kt = true;
            foreach (Lop lop in DSlop)
            {
                if (lop.Malop == Malop)
                {
                    kt = false; break;//nếu mã lớp trùng thì false
                }
            }
            return kt;
        }
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
        public static void QLDSlop()
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine("\t\t\t\t\t╔══════════════════════════════════════════════╗");
            Console.WriteLine("\t\t\t\t\t║           QUẢN LÝ THÔNG TIN LỚP              ║");
            Console.WriteLine("\t\t\t\t\t╠══════════════════════════════════════════════╣");
            Console.WriteLine("\t\t\t\t\t║     1. Thêm sinh viên vào lớp                ║");
            Console.WriteLine("\t\t\t\t\t║         └─────────────────┘                  ║");
            Console.WriteLine("\t\t\t\t\t║     2. Xoá sinh viên trong lớp               ║");
            Console.WriteLine("\t\t\t\t\t║         └──────────────────┘                 ║");
            Console.WriteLine("\t\t\t\t\t║     3. Hiển thị thông tin sinh viên          ║");
            Console.WriteLine("\t\t\t\t\t║         trong lớp                            ║");
            Console.WriteLine("\t\t\t\t\t║         └─────────────────┘                  ║");
            Console.WriteLine("\t\t\t\t\t║     4. Tìm kiếm sinh viên                    ║");
            Console.WriteLine("\t\t\t\t\t║         └─────────────────┘                  ║");
            Console.WriteLine("\t\t\t\t\t║     5. Sửa thông tin sinh viên               ║");
            Console.WriteLine("\t\t\t\t\t║         └──────────────────┘                 ║");
            Console.WriteLine("\t\t\t\t\t║     6. Thống kê điểm của sinh viên           ║");
            Console.WriteLine("\t\t\t\t\t║         └──────────────────┘                 ║");
            Console.WriteLine("\t\t\t\t\t║     7. Thoát khỏi chương trình               ║");
            Console.WriteLine("\t\t\t\t\t║         └──────────────────┘                 ║");
            Console.WriteLine("\t\t\t\t\t╠══════════════════════════════════════════════╣");
            Console.WriteLine("\t\t\t\t\t║     Hãy chọn một trong các chức năng trên:   ║");
            Console.WriteLine("\t\t\t\t\t╚══════════════════════════════════════════════╝");
            int lc = luachon();
            string Tenlop;
            string Malop;
            string Masv;
            switch (lc)
            {
                case 1:

                    do
                    {
                        DSlop.Clear();
                        docdanhsachlop();                       
                        Console.Clear();
                        Console.WriteLine("\t\t\t\t\t╔═════════════════════════════════════════════════════╗");
                        Console.WriteLine("\t\t\t\t\t║         Nhập vào mã lớp muốn thêm sinh viên vào     ║");
                        Console.WriteLine("\t\t\t\t\t║═════════════════════════════════════════════════════║");
                        Console.WriteLine("\t\t\t\t\t║                                                     ║");
                        Console.WriteLine("\t\t\t\t\t║               ╭───────────────────────╮             ║");
                        Console.WriteLine("\t\t\t\t\t║               │ Mã lớp :              │             ║");
                        Console.WriteLine("\t\t\t\t\t║               ╰───────────────────────╯             ║");                        
                        Console.WriteLine("\t\t\t\t\t╚═════════════════════════════════════════════════════╝");
                        Console.SetCursorPosition(67, 5);
                        Malop = Console.ReadLine();
                        //docdanhsachlop();
                        if (kttrunglop(Malop) == false) { break; }//mã lớp phải trùng thì mới thêm được
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Mã lớp này chưa có trong Dslop");
                            Console.WriteLine("╔═════════════════════════════════════════════════════╗");
                            Console.WriteLine("║            Bạn có muốn thêm lớp này không           ║");
                            Console.WriteLine("║═════════════════════════════════════════════════════║");
                            Console.WriteLine("║                                                     ║");
                            Console.WriteLine("║               ╭───────────────────────╮             ║");
                            Console.WriteLine("║               │      1.Có             │             ║");
                            Console.WriteLine("║               ╰───────────────────────╯             ║");
                            Console.WriteLine("║               ╭───────────────────────╮             ║");
                            Console.WriteLine("║               │      2.Không          │             ║");
                            Console.WriteLine("║               ╰───────────────────────╯             ║");                          
                            Console.WriteLine("╠═════════════════════════════════════════════════════╣");
                            Console.WriteLine("║         Hãy chọn một trong các chức năng trên:      ║");
                            Console.WriteLine("╚═════════════════════════════════════════════════════╝");
                            Console.Write("Mời nhập lựa chọn của bạn: ");
                            string nhap = Console.ReadLine();
                            if (nhap.Equals("1"))
                            {
                                themlopmoivaods();
                                Console.WriteLine("Bạn đã thêm lớp thành công");
                            }
                            else Console.WriteLine();
                        }
                        Console.WriteLine("╔═══════════════════════════════════════════════════════════════════╗");
                        Console.WriteLine("║            Bạn có muốn thêm sinh viên vào lớp nữa không           ║");
                        Console.WriteLine("║═══════════════════════════════════════════════════════════════════║");
                        Console.WriteLine("║                                                                   ║");
                        Console.WriteLine("║                      ╭───────────────────────╮                    ║");
                        Console.WriteLine("║                      │      1.Có             │                    ║");
                        Console.WriteLine("║                      ╰───────────────────────╯                    ║");
                        Console.WriteLine("║                      ╭───────────────────────╮                    ║");
                        Console.WriteLine("║                      │      2.Không          │                    ║");
                        Console.WriteLine("║                      ╰───────────────────────╯                    ║");
                        Console.WriteLine("╠═══════════════════════════════════════════════════════════════════╣");
                        Console.WriteLine("║               Hãy chọn một trong các chức năng trên:              ║");
                        Console.WriteLine("╚═══════════════════════════════════════════════════════════════════╝");
                        Console.Write("Mời nhập lựa chọn của bạn: ");
                        string nhap1 = Console.ReadLine();
                        if (nhap1.Equals("2"))
                        {
                            goto Thoat;//nhảy đến Thoát
                        }
                        else if(nhap1.Equals("1")) { }
                        
                    } while (true);
                    //khi đã nhập đúng mã thì là lớp đấy đã tồn tại thì có thể thêm sinh viên vào lớp
                    Console.Clear();
                    Themsinhvienvaolop(Malop);
                    Console.WriteLine("Bạn đã thêm sinh viên thành công");
                Thoat: QLDSlop();
                    break;
                case 2:
                    do
                    {
                        DSlop.Clear();
                        docdanhsachlop();
                        Console.Clear();
                        Console.WriteLine("\t\t\t\t\t╔═════════════════════════════════════════════════════╗");
                        Console.WriteLine("\t\t\t\t\t║            Nhập vào mã lớp muốn xóa sinh viên       ║");
                        Console.WriteLine("\t\t\t\t\t║═════════════════════════════════════════════════════║");
                        Console.WriteLine("\t\t\t\t\t║                                                     ║");
                        Console.WriteLine("\t\t\t\t\t║               ╭───────────────────────╮             ║");
                        Console.WriteLine("\t\t\t\t\t║               │ Mã lớp :              │             ║");
                        Console.WriteLine("\t\t\t\t\t║               ╰───────────────────────╯             ║");
                        Console.WriteLine("\t\t\t\t\t╚═════════════════════════════════════════════════════╝");
                        Console.SetCursorPosition(67, 5);
                        Malop = Console.ReadLine();
                        
                        if (kttrunglop(Malop) == false) { break; }//mã lớp phải trùng thì mới thêm được
                        else
                        {
                            Console.Clear() ;
                            Console.WriteLine("Mã lớp này chưa có");
                            Console.WriteLine("╔═════════════════════════════════════════════════════╗");
                            Console.WriteLine("║            Bạn có muốn thêm lớp này không           ║");
                            Console.WriteLine("║═════════════════════════════════════════════════════║");
                            Console.WriteLine("║                                                     ║");
                            Console.WriteLine("║               ╭───────────────────────╮             ║");
                            Console.WriteLine("║               │      1.Có             │             ║");
                            Console.WriteLine("║               ╰───────────────────────╯             ║");
                            Console.WriteLine("║               ╭───────────────────────╮             ║");
                            Console.WriteLine("║               │      2.Không          │             ║");
                            Console.WriteLine("║               ╰───────────────────────╯             ║");
                            Console.WriteLine("╠═════════════════════════════════════════════════════╣");
                            Console.WriteLine("║         Hãy chọn một trong các chức năng trên:      ║");
                            Console.WriteLine("╚═════════════════════════════════════════════════════╝");
                            Console.Write("Mời nhập lựa chọn của bạn: ");
                            string nhap = Console.ReadLine();
                            if (nhap.Equals("1"))
                            {
                                themlopmoivaods();
                                Console.WriteLine("Bạn đã thêm lớp thành công");
                            }
                            else Console.WriteLine();
                        }
                        Console.Clear();
                        Console.WriteLine("╔═══════════════════════════════════════════════════════════════════╗");
                        Console.WriteLine("║           Bạn có muốn xóa sinh viên trong lớp nữa không           ║");
                        Console.WriteLine("║═══════════════════════════════════════════════════════════════════║");
                        Console.WriteLine("║                                                                   ║");
                        Console.WriteLine("║                      ╭───────────────────────╮                    ║");
                        Console.WriteLine("║                      │      1.Có             │                    ║");
                        Console.WriteLine("║                      ╰───────────────────────╯                    ║");
                        Console.WriteLine("║                      ╭───────────────────────╮                    ║");
                        Console.WriteLine("║                      │      2.Không          │                    ║");
                        Console.WriteLine("║                      ╰───────────────────────╯                    ║");
                        Console.WriteLine("╠═══════════════════════════════════════════════════════════════════╣");
                        Console.WriteLine("║               Hãy chọn một trong các chức năng trên:              ║");
                        Console.WriteLine("╚═══════════════════════════════════════════════════════════════════╝");
                        Console.Write("Mời nhập lựa chọn của bạn: ");
                        string nhap1 = Console.ReadLine();
                        if (nhap1.Equals("2"))
                        {
                            goto Thoat1;// goto là nhảy
                        }
                        else if (nhap1.Equals("1")) { }
                    } while (true);
                    //khi đã nhập đúng mã thì là lớp đấy đã tồn tại thì có thể xóa sinh viên 
                    Xoasv(Malop);
                    Thoat1: QLDSlop();
                    break;
                case 3:
                    do
                    {
                        DSlop.Clear();
                        docdanhsachlop();
                        Console.Clear();
                        Console.WriteLine("\t\t\t\t\t╔═════════════════════════════════════════════════════╗");
                        Console.WriteLine("\t\t\t\t\t║             Nhập vào mã lớp muốn hiển thị           ║");
                        Console.WriteLine("\t\t\t\t\t║═════════════════════════════════════════════════════║");
                        Console.WriteLine("\t\t\t\t\t║                                                     ║");
                        Console.WriteLine("\t\t\t\t\t║               ╭───────────────────────╮             ║");
                        Console.WriteLine("\t\t\t\t\t║               │ Mã lớp :              │             ║");
                        Console.WriteLine("\t\t\t\t\t║               ╰───────────────────────╯             ║");
                        Console.WriteLine("\t\t\t\t\t╚═════════════════════════════════════════════════════╝");
                        Console.SetCursorPosition(67, 5);
                        Malop = Console.ReadLine();                       
                        if (kttrunglop(Malop) == false) { break; }//mã lớp phải trùng thì mới hiển thị được
                        else
                        {
                            Console.WriteLine("Mã lớp này chưa có");
                            Console.WriteLine("╔═════════════════════════════════════════════════════╗");
                            Console.WriteLine("║            Bạn có muốn thêm lớp này không           ║");
                            Console.WriteLine("║═════════════════════════════════════════════════════║");
                            Console.WriteLine("║                                                     ║");
                            Console.WriteLine("║               ╭───────────────────────╮             ║");
                            Console.WriteLine("║               │      1.Có             │             ║");
                            Console.WriteLine("║               ╰───────────────────────╯             ║");
                            Console.WriteLine("║               ╭───────────────────────╮             ║");
                            Console.WriteLine("║               │      2.Không          │             ║");
                            Console.WriteLine("║               ╰───────────────────────╯             ║");
                            Console.WriteLine("╠═════════════════════════════════════════════════════╣");
                            Console.WriteLine("║         Hãy chọn một trong các chức năng trên:      ║");
                            Console.WriteLine("╚═════════════════════════════════════════════════════╝");
                            Console.Write("Mời nhập lựa chọn của bạn: ");
                            string nhap = Console.ReadLine();
                            if (nhap.Equals("1"))
                            {
                                themlopmoivaods();
                                Console.WriteLine("Bạn đã thêm lớp thành công");
                            }
                            else Console.WriteLine();
                        }
                        Console.WriteLine("╔═══════════════════════════════════════════════════════════════════╗");
                        Console.WriteLine("║        Bạn có muốn hiển thị thông tin sinh viên nữa không         ║");
                        Console.WriteLine("║═══════════════════════════════════════════════════════════════════║");
                        Console.WriteLine("║                                                                   ║");
                        Console.WriteLine("║                      ╭───────────────────────╮                    ║");
                        Console.WriteLine("║                      │      1.Có             │                    ║");
                        Console.WriteLine("║                      ╰───────────────────────╯                    ║");
                        Console.WriteLine("║                      ╭───────────────────────╮                    ║");
                        Console.WriteLine("║                      │      2.Không          │                    ║");
                        Console.WriteLine("║                      ╰───────────────────────╯                    ║");
                        Console.WriteLine("╠═══════════════════════════════════════════════════════════════════╣");
                        Console.WriteLine("║               Hãy chọn một trong các chức năng trên:              ║");
                        Console.WriteLine("╚═══════════════════════════════════════════════════════════════════╝");
                        Console.Write("Mời nhập lựa chọn của bạn: ");
                        string nhap1 = Console.ReadLine();
                        if (nhap1.Equals("2"))
                        {
                            goto Thoat2;// goto là nhảy
                        }
                        else if (nhap1.Equals("1")) { }
                    } while (true);
                    //khi đã nhập đúng mã thì là lớp đấy đã tồn tại thì có thể hiển thị danh sách sinh viên của lớp
                    Console.WriteLine("Đã vào lớp "+Malop);
                    Hienthisinhvientronglop(Malop);
                    /*
                    Lop l = LayLop(Malop);//l này tồn tại hay rỗng
                    DSlop.Clear();
                    if (l.DS1lop.Count > 0)//kiểm tra trong DS1lop có thông tin gì ko
                    {
                        Console.WriteLine("╔═══════════════════════════════════════════════════════════════════════════════════╗");
                        Console.WriteLine("║                  Danh sách thông tin sinh viên trong lớp là                       ║");
                        Console.WriteLine("║═══════════════════════════════════════════════════════════════════════════════════║");
                        Console.WriteLine("║  Mã SV ║   Tên  ║ Mã lớp ║ Ngày sinh ║ Giới tính ║ Địa chỉ ║ Số điện thoại ║ Điểm ║");
                        for (int i = 0; i < l.DS1lop.Count; i++)
                        {
                            Console.WriteLine("║ " + l.DS1lop[i].Masv + " ║" + "\t" + "║ " + l.DS1lop[i].Tensv + " ║" + "\t" + "║ " + l.DS1lop[i].Malop + " ║" + "\t" + "║ " + l.DS1lop[i].Ngaysinh + " ║" + "\t" + "║ " + l.DS1lop[i].Gioitinh + " ║" + "\t" + "║ " + l.DS1lop[i].Diachi + " ║" + "\t" + "║ " + l.DS1lop[i].Sodienthoai + " ║" + "\t" + "║ " + l.DS1lop[i].Diem + "║" + "\t");
                        }
                    }   
                   */
                    Thoat2: QLDSlop();
                    break;
                case 4:
                    Console.Clear();
                    Console.WriteLine("\t\t\t\t\t╔═════════════════════════════════════════════════════╗");
                    Console.WriteLine("\t\t\t\t\t║         Nhập vào mã sinh viên muốn tìm kiếm         ║");
                    Console.WriteLine("\t\t\t\t\t║═════════════════════════════════════════════════════║");
                    Console.WriteLine("\t\t\t\t\t║                                                     ║");
                    Console.WriteLine("\t\t\t\t\t║            ╭─────────────────────────────╮          ║");
                    Console.WriteLine("\t\t\t\t\t║            │ Mã sinh viên :              │          ║");
                    Console.WriteLine("\t\t\t\t\t║            ╰─────────────────────────────╯          ║");
                    Console.WriteLine("\t\t\t\t\t╚═════════════════════════════════════════════════════╝");
                    Console.SetCursorPosition(70, 5);
                    Masv = Console.ReadLine();
                    Timkiemsinhvien(Masv);
                    break;
                case 5:
                    do {
                        DSlop.Clear();
                        docdanhsachlop();
                        Console.Clear();
                        Console.WriteLine("\t\t\t\t\t╔═════════════════════════════════════════════════════╗");
                        Console.WriteLine("\t\t\t\t\t║      Nhập vào mã lớp muốn sửa thông tin sinh viên   ║");
                        Console.WriteLine("\t\t\t\t\t║═════════════════════════════════════════════════════║");
                        Console.WriteLine("\t\t\t\t\t║                                                     ║");
                        Console.WriteLine("\t\t\t\t\t║               ╭───────────────────────╮             ║");
                        Console.WriteLine("\t\t\t\t\t║               │ Mã lớp :              │             ║");
                        Console.WriteLine("\t\t\t\t\t║               ╰───────────────────────╯             ║");
                        Console.WriteLine("\t\t\t\t\t╚═════════════════════════════════════════════════════╝");
                        Console.SetCursorPosition(67, 5);
                        Malop = Console.ReadLine();
                        if (kttrunglop(Malop) == false) { break; }//mã lớp phải trùng thì mới thoát được
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Mã lớp này chưa có");
                            Console.WriteLine("╔═════════════════════════════════════════════════════╗");
                            Console.WriteLine("║            Bạn có muốn thêm lớp này không           ║");
                            Console.WriteLine("║═════════════════════════════════════════════════════║");
                            Console.WriteLine("║                                                     ║");
                            Console.WriteLine("║               ╭───────────────────────╮             ║");
                            Console.WriteLine("║               │      1.Có             │             ║");
                            Console.WriteLine("║               ╰───────────────────────╯             ║");
                            Console.WriteLine("║               ╭───────────────────────╮             ║");
                            Console.WriteLine("║               │      2.Không          │             ║");
                            Console.WriteLine("║               ╰───────────────────────╯             ║");
                            Console.WriteLine("╠═════════════════════════════════════════════════════╣");
                            Console.WriteLine("║         Hãy chọn một trong các chức năng trên:      ║");
                            Console.WriteLine("╚═════════════════════════════════════════════════════╝");
                            Console.Write("Mời nhập lựa chọn của bạn: ");
                            string nhap = Console.ReadLine();
                            if (nhap.Equals("1"))
                            {
                                themlopmoivaods();
                                Console.WriteLine("Bạn đã thêm lớp thành công");
                            }
                            else Console.WriteLine();
                        }
                    } while (true);
                    //khi đã nhập đúng mã thì là lớp đấy đã tồn tại thì có thể sửa thông tin sinh viên 
                    Suathongtinsinhvien(Malop);
                    break;
                case 6:
                    Thongkesv();
                    break;
                case 7:break;
                default:
                    Console.Clear();
                    Console.WriteLine("\t\t\t\t\t╔════════════════════════════════════════════════════════════════╗");
                    Console.WriteLine("\t\t\t\t\t║           KHÔNG CÓ CHỨC NĂNG NÀY. VUI LÒNG NHẬP LẠI            ║");
                    Console.WriteLine("\t\t\t\t\t╚════════════════════════════════════════════════════════════════╝");
                    QLDSlop();
                    break;
            }
        }
        public static void Themsinhvienvaolop(string Malop)
        {
            string Masv, Tensv, Ngaysinh, Gioitinh, Diachi, Sodienthoai, Diem;
            bool kt = true;
            //Lop tmplop = LayLop(Malop);//tmplop này tồn tại hay rỗng           
            do
            {
                do
                {
                    Console.Write("Mời nhập vào mã sinh viên (gồm 8 số): ");
                    Masv = Console.ReadLine();
                    if (Masv.Length != 8 || !Regex.IsMatch(Masv, @"^[0-9]+$"))
                    {
                        Console.WriteLine("Mã sinh viên không đúng định dạng vui lòng nhập lại");
                    }
                    else { break; }
                } while (Masv.Length != 8 || !Regex.IsMatch(Masv, @"^[0-9]+$"));
                DSSV.Clear();
                docdanhsachsv();
                if (DSSV.Count > 0)
                {
                    foreach (Sinhvien sv1 in DSSV)
                    {
                        if (sv1.Masv == Masv) { kt = false; break; }//kiểm tra trong DSSV
                        else { kt = true;break; }
                    }
                }
                else { Console.WriteLine("DSSV trống"); }
                //DSSV.Clear();
                if (kt == true) { DSSV.Clear(); break; }
                else Console.WriteLine("Mã sinh viên bị trùng rồi mời nhập lại");
                /*
                //Console.WriteLine(tmplop.DS1lop.Count);
                if (tmplop.DS1lop.Count > 0)
                {
                    foreach (Sinhvien sv1 in tmplop.DS1lop)
                    {
                        if (sv1.Masv == Masv) { kt = false; break; }//Kiểm tra trong DS1lop
                        else { }
                    }                 //Console.WriteLine("Chưa có mã sinh viên này trong DS1lop"); 

                }
                */

            } while (kt == false) ;

            do
            {
                Console.Write("Mời nhập tên sinh viên: ");
                Tensv = Console.ReadLine().Trim();
                Tensv = Regex.Replace(Tensv, @"\s+", " ");//thay thế các khoảng trắng liên tiếp bằng một khoảng trắng duy nhất                
                if (!Regex.IsMatch(Tensv, @"^[a-zA-Z0-9 ]+$") || Tensv.Length > 30 || Tensv.Length == 0)
                {
                    Console.WriteLine("Tên sinh viên không đúng định dạng vui lòng nhập lại");
                }
            } while (!Regex.IsMatch(Tensv, @"^[a-zA-Z0-9 ]+$") || Tensv.Length > 30 || Tensv.Length == 0);//khác kí tự đặc biệt và không quá 30 kí rự và khác rỗng

            do
            {
                Console.Write("Mời nhập ngày sinh của sinh viên: ");
                Ngaysinh = Console.ReadLine().Trim();
                Ngaysinh = Regex.Replace(Ngaysinh, @"\s+", " ");//thay thế các khoảng trắng liên tiếp bằng một khoảng trắng duy nhất                
                if (!Regex.IsMatch(Ngaysinh, @"^[0-9 ]+$") || Ngaysinh.Length == 0)
                {
                    Console.WriteLine("Ngày sinh của sinh viên không đúng định dạng vui lòng nhập lại");
                }
            } while (!Regex.IsMatch(Ngaysinh, @"^[0-9 ]+$") || Ngaysinh.Length == 0);

            do
            {
                Console.Write("Mời nhập giới tính của sinh viên: ");
                Gioitinh = Console.ReadLine();
                if (!Regex.IsMatch(Gioitinh, @"^[a-zA-Z]+$") || Gioitinh.Length <1 || Gioitinh.Length>4)
                {
                    Console.WriteLine("Giới tính của sinh viên không đúng định dạng vui lòng nhập lại");
                }
            } while (!Regex.IsMatch(Gioitinh, @"^[a-zA-Z]+$") || Gioitinh.Length >4 || Gioitinh.Length <1);

            do
            {
                Console.Write("Mời nhập điạ chỉ của sinh viên: ");
                Diachi = Console.ReadLine().Trim();
                if (!Regex.IsMatch(Diachi, @"^[a-zA-Z ]+$") || Diachi.Length == 0)
                {
                    Console.WriteLine("Địa chỉ của sinh viên không đúng định dạng vui lòng nhập lại");
                }
            } while (!Regex.IsMatch(Diachi, @"^[a-zA-Z ]+$") || Diachi.Length == 0);

            do
            {
                Console.Write("Mời nhập số điện thoại của sinh viên: ");
                Sodienthoai = Console.ReadLine();
                if (!Regex.IsMatch(Sodienthoai, @"^[0-9]+$") || Sodienthoai.Length != 10)
                {
                    Console.WriteLine("Số điện thoại của sinh viên không đúng định dạng vui lòng nhập lại");
                }
            } while (!Regex.IsMatch(Sodienthoai, @"^[0-9]+$") || Sodienthoai.Length != 10);

            do
            {             
                Console.Write("Mời nhập điểm của sinh viên: ");
                Diem = Console.ReadLine();
                if(float.Parse(Diem) < 0 || float.Parse(Diem) >10)
                {
                    Console.WriteLine("Điểm không đúng định dạng vui lòng nhập lại");
                }
            }while(float.Parse(Diem) < 0 || float.Parse(Diem) > 10);
            
            Sinhvien sv = Quản_Lý_Sinh_Viên.Taosv(Masv,Tensv, Malop,Ngaysinh,Gioitinh,Diachi,Sodienthoai, Diem);
            //tmplop.DS1lop.Add(sv);
            DSSV.Add(sv);
            Console.Clear();
            Console.WriteLine("Bạn đã thêm sinh viên vào DSSV");
            Ghidanhsachsv();
            DSSV.Clear();
        }
        public static void Hiethicaclopdaco()
        {
            DSlop.Clear();
            docdanhsachlop();//đọc từ file ra để lấy dữ liệu vào list DSlop
            if (DSlop.Count > 0)
            {
                Console.WriteLine("╔════════════════════════════════════════════════════════════════╗");
                Console.WriteLine("║                  Danh sách các lớp đã có                       ║");
                Console.WriteLine("╚════════════════════════════════════════════════════════════════╝");
                Console.WriteLine("║ Mã lớp ║ ║ Tên lớp ║\t\t\t║ Giáo viên chủ nhiệm ║ ║ Mã khoa ║\t║ Mã niên khóa ║");
                foreach (Lop L in DSlop)
                {
                    Console.WriteLine("║ " + L.Malop + " ║" + " ║ " + L.Tenlop + " ║" + "\t"+ "║ " + L.Giaovienchunhiem + " ║" + "\t\t" + "║ " + L.Makhoa + " ║" + "\t\t"+ "║ " + L.Manienkhoa+ " ║");
                }
                Console.WriteLine("╚══════════════════════════════════════════════════════════════════════════════════════╝");
            }
            else
            {
                Console.WriteLine("Không có lớp nào");
                Console.WriteLine("╔═════════════════════════════════════════════════════╗");
                Console.WriteLine("║              Bạn có muốn thêm lớp không             ║");
                Console.WriteLine("║═════════════════════════════════════════════════════║");
                Console.WriteLine("║                                                     ║");
                Console.WriteLine("║               ╭───────────────────────╮             ║");
                Console.WriteLine("║               │      1.Có             │             ║");
                Console.WriteLine("║               ╰───────────────────────╯             ║");
                Console.WriteLine("║               ╭───────────────────────╮             ║");
                Console.WriteLine("║               │      2.Không          │             ║");
                Console.WriteLine("║               ╰───────────────────────╯             ║");
                Console.WriteLine("╠═════════════════════════════════════════════════════╣");
                Console.WriteLine("║         Hãy chọn một trong các chức năng trên:      ║");
                Console.WriteLine("╚═════════════════════════════════════════════════════╝");
                Console.Write("Mời nhập lựa chọn của bạn: ");
                string nhap = Console.ReadLine();
                if (nhap.Equals("1"))
                {
                    themlopmoivaods();
                    Console.WriteLine("Bạn đã thêm lớp thành công");
                    Console.WriteLine("╔═════════════════════════════════════════════════════╗");
                    Console.WriteLine("║    Bạn có muốn hiển thị các lớp đang có nữa không   ║");
                    Console.WriteLine("║═════════════════════════════════════════════════════║");
                    Console.WriteLine("║                                                     ║");
                    Console.WriteLine("║               ╭───────────────────────╮             ║");
                    Console.WriteLine("║               │      1.Có             │             ║");
                    Console.WriteLine("║               ╰───────────────────────╯             ║");
                    Console.WriteLine("║               ╭───────────────────────╮             ║");
                    Console.WriteLine("║               │      2.Không          │             ║");
                    Console.WriteLine("║               ╰───────────────────────╯             ║");
                    Console.WriteLine("╠═════════════════════════════════════════════════════╣");
                    Console.WriteLine("║         Hãy chọn một trong các chức năng trên:      ║");
                    Console.WriteLine("╚═════════════════════════════════════════════════════╝");
                    Console.Write("Mời nhập lựa chọn của bạn: ");
                    string nhap1 = Console.ReadLine();
                    if (nhap.Equals("1"))
                    {
                        Hiethicaclopdaco();
                    }
                    else { }
                }
                else { }
            }
            
        }
        public static void Hienthisinhvientronglop(string Malop)
        {
            DSSV.Clear();
            docdanhsachsv();
            Console.Clear();
            if (DSSV.Count > 0)
            {
                Console.WriteLine("╔═══════════════════════════════════════════════════════════════════════════════════╗");
                Console.WriteLine("║                  Danh sách thông tin sinh viên trong lớp là                       ║");
                Console.WriteLine("║═══════════════════════════════════════════════════════════════════════════════════║");
                Console.WriteLine("║  Mã SV ║\t║  Tên ║\t\t║ Mã lớp ║ ║ Ngày sinh ║ ║ Giới tính ║ ║ Địa chỉ ║ ║ Số điện thoại ║ ║ Điểm ║");
                foreach (Sinhvien sv in DSSV)
                {
                    if (sv.Malop == Malop)
                    {
                        Console.WriteLine("║ " + sv.Masv + " ║" + "\t" + "║ " + sv.Tensv + " ║" + "\t" + "║ " + sv.Malop + " ║" + "║ " + sv.Ngaysinh + " ║" + "║ " + sv.Gioitinh + " ║" + "\t\t" + "║ " + sv.Diachi + " ║" + "\t" + "║ " + sv.Sodienthoai + " ║" + "\t" + "║ " + sv.Diem + "║" + "\t");
                        DSSV.Clear();
                    }
                    //else { Console.WriteLine("Mã lớp không trùng nhau"); }

                }
                Console.WriteLine("╚═══════════════════════════════════════════════════════════════════════════════════╝");
            }
            else
            {
                Console.WriteLine("Chưa có thông tin của sinh viên trong lớp");
                Console.WriteLine("╔═══════════════════════════════════════════════════════════════════╗");
                Console.WriteLine("║            Bạn có muốn thêm sinh viên này vào lớp không           ║");
                Console.WriteLine("║═══════════════════════════════════════════════════════════════════║");
                Console.WriteLine("║                                                                   ║");
                Console.WriteLine("║                      ╭───────────────────────╮                    ║");
                Console.WriteLine("║                      │      1.Có             │                    ║");
                Console.WriteLine("║                      ╰───────────────────────╯                    ║");
                Console.WriteLine("║                      ╭───────────────────────╮                    ║");
                Console.WriteLine("║                      │      2.Không          │                    ║");
                Console.WriteLine("║                      ╰───────────────────────╯                    ║");
                Console.WriteLine("╠═══════════════════════════════════════════════════════════════════╣");
                Console.WriteLine("║               Hãy chọn một trong các chức năng trên:              ║");
                Console.WriteLine("╚═══════════════════════════════════════════════════════════════════╝");
                Console.Write("Mời nhập lựa chọn của bạn: ");
                string nhap1 = Console.ReadLine();
                if (nhap1.Equals("1"))
                {
                    Themsinhvienvaolop(Malop);
                    Console.WriteLine("╔═══════════════════════════════════════════════════════════════════╗");
                    Console.WriteLine("║         Bạn có muốn hiển thị thông tin sinh viên nữa không        ║");
                    Console.WriteLine("║═══════════════════════════════════════════════════════════════════║");
                    Console.WriteLine("║                                                                   ║");
                    Console.WriteLine("║                      ╭───────────────────────╮                    ║");
                    Console.WriteLine("║                      │      1.Có             │                    ║");
                    Console.WriteLine("║                      ╰───────────────────────╯                    ║");
                    Console.WriteLine("║                      ╭───────────────────────╮                    ║");
                    Console.WriteLine("║                      │      2.Không          │                    ║");
                    Console.WriteLine("║                      ╰───────────────────────╯                    ║");
                    Console.WriteLine("╠═══════════════════════════════════════════════════════════════════╣");
                    Console.WriteLine("║               Hãy chọn một trong các chức năng trên:              ║");
                    Console.WriteLine("╚═══════════════════════════════════════════════════════════════════╝");
                    Console.Write("Mời nhập lựa chọn của bạn: ");
                    string nhap2 = Console.ReadLine();
                    if (nhap2.Equals("1")) { Hienthisinhvientronglop(Malop); }
                    else { }
                }
                else if (nhap1.Equals("2")) { }
            }

        }
        public static void Thongkesv()
        {
            DSSV.Clear();
            docdanhsachsv();
            Sinhvien sinhVienMaxDiem = new Sinhvien();
            double maxDiem = double.MinValue;//là giá trị nhỏ nhất có thể được biểu diễn bằng kiểu dữ liệu double
            foreach (Sinhvien sv in DSSV)
            {//so sánh từng điểm trong DSSV với maxDiem
                if (double.Parse(sv.Diem) > maxDiem)
                {
                    maxDiem =double.Parse(sv.Diem);//nếu điểm nào trong DSSV lớn hơn thì ta gắn maxDiem = điểm đấy
                    sinhVienMaxDiem = sv;//tìm được sv có điểm cao thì gán nó vào sinhVienMaxDiem

                }//sau khi duyệt hết for thi sẽ ra điểm lớn nhất
            }
            Console.WriteLine("Điểm lớn nhất trong số các sinh viên là: " + maxDiem);
            Console.WriteLine("Sinh viên đó có tên là: "+sinhVienMaxDiem.Tensv);
            
            Sinhvien sinhVienMinDiem = new Sinhvien();
            double minDiem = double.MaxValue;//là giá trị lớn nhất có thể được biểu diễn bằng kiểu dữ liệu double
            foreach (Sinhvien sv in DSSV)
            {//so sánh từng điểm trong DSSV với minDiem
                if (double.Parse(sv.Diem) < minDiem)
                {
                    minDiem =double.Parse(sv.Diem);//nếu điểm nào trong DSSV nhỏ hơn thì ta gắn minDiem = điểm đấy
                    sinhVienMinDiem=sv;//tìm được sv có điểm thấp thì gán nó vào sinhVienMinDiem

                }//sau khi duyệt hết for thi sẽ ra điểm nhỏ nhất
            }
            Console.WriteLine("Điểm nhỏ nhất trong số các sinh viên là: " + minDiem);
            Console.WriteLine("Sinh viên đó có tên là: " + sinhVienMinDiem.Tensv);
            DSSV.Clear();

            /*
            docdanhsachsv();
            foreach(Sinhvien sv in DSSV)
            {
                if(double.Parse( sv.Diem) >8)
                {
                    Console.WriteLine(sv.Masv+ sv.Diem+sv.Tensv);
                }
            }
            */
        }
        public static void Suathongtinsinhvien(string Malop)
        {
            string Masv;
            bool kt = false;

            for (int i = 0; i < DSlop.Count; i++)//duyệt trong Dslop
            {
                if (DSlop[i].Malop == Malop)//Kiểm tra mã lớp(phải trùng thì mới làm được)
                {
                    Console.WriteLine("Đã vào lớp " + DSlop[i].Malop);
                    do
                    {
                        Console.Clear();
                        Console.WriteLine("\t\t\t\t\t╔═════════════════════════════════════════════════════╗");
                        Console.WriteLine("\t\t\t\t\t║            Nhập vào mã sinh viên muốn sửa           ║");
                        Console.WriteLine("\t\t\t\t\t║═════════════════════════════════════════════════════║");
                        Console.WriteLine("\t\t\t\t\t║                                                     ║");
                        Console.WriteLine("\t\t\t\t\t║            ╭─────────────────────────────╮          ║");
                        Console.WriteLine("\t\t\t\t\t║            │ Mã sinh viên :              │          ║");
                        Console.WriteLine("\t\t\t\t\t║            ╰─────────────────────────────╯          ║");
                        Console.WriteLine("\t\t\t\t\t╚═════════════════════════════════════════════════════╝");
                        Console.SetCursorPosition(70, 5);
                        Masv = Console.ReadLine();
                        DSSV.Clear();//cho list DSSV trống đã
                        docdanhsachsv();//xong đọc file ra để lấy dữ liệu vào list DSSV
                        foreach (Sinhvien timsv in DSSV)
                        {//danh sách lớp thứ(1,...) liên kết tới danh sách thông tin sinh viên 1 lớp
                            if (timsv.Masv == Masv)//mã sv phải trùng 
                            {
                                Console.WriteLine("Đã tìm thấy sinh viên có mã " + timsv.Masv);
                                //DSlop[i].DS1lop.Remove(xoasv);//xóa sinh viên trong danh sách lớp
                                DSSV.Remove(timsv);//xóa sinh viên có mã được nhập trong list DSSV
                                /*
                                foreach(Sinhvien sinhvien in DSSV)
                                {
                                    Console.WriteLine(sinhvien.Masv);
                                    //Console.WriteLine(sinhvien.Tensv);
                                }
                                */
                                //Console.WriteLine("Bạn đã xóa sinh viên thành công");
                                kt = true; break;
                            }
                            else
                            {
                                //Console.WriteLine("Mã sinh viên không trùng nên không thể xóa"); 
                            }                            
                        }
                        string filePath = "sinhvien.txt";
                        File.WriteAllText(filePath, string.Empty);//xóa dữ liệu trong file sinhvien.txt
                        Themsinhvienvaolop(Malop);//nhập lại thông tin mới của sinh viên xong ghi cả dữ liệu mới với dữ liệu cũ vào file sinhvien.txt
                        Console.WriteLine("Bạn đã sửa thành công");
                        //những dữ liệu cũ vô file (còn dữ liệu vừa bị xóa thì đã mất)
                        DSSV.Clear();//xong lại cho list DSSV trống để trách bị lặp dữ liệu sang những phần khác
                        if (kt == true) break;//khi xóa thành công thì thoát khỏi do while
                        else
                        {
                            Console.WriteLine("Mã sinh viên này không tồn tại.");
                        }
                    } while (kt == false);
                    break;
                }
            }           

        }
        static void Xoasv(string Malop)
        {
            string Masv;
            bool kt = false;
                       
            for (int i = 0; i < DSlop.Count; i++)//duyệt trong Dslop 
            {
                if (DSlop[i].Malop == Malop)//Kiểm tra mã lớp(phải trùng thì mới làm được)
                {
                    //Console.Clear();
                    Console.WriteLine("Đã vào lớp "+DSlop[i].Malop);
                    do
                    {
                        Console.Clear();
                        Console.WriteLine("\t\t\t\t\t╔═════════════════════════════════════════════════════╗");
                        Console.WriteLine("\t\t\t\t\t║            Nhập vào mã sinh viên muốn xóa           ║");
                        Console.WriteLine("\t\t\t\t\t║═════════════════════════════════════════════════════║");
                        Console.WriteLine("\t\t\t\t\t║                                                     ║");
                        Console.WriteLine("\t\t\t\t\t║            ╭─────────────────────────────╮          ║");
                        Console.WriteLine("\t\t\t\t\t║            │ Mã sinh viên :              │          ║");
                        Console.WriteLine("\t\t\t\t\t║            ╰─────────────────────────────╯          ║");
                        Console.WriteLine("\t\t\t\t\t╚═════════════════════════════════════════════════════╝");
                        Console.SetCursorPosition(70, 5);
                        Masv = Console.ReadLine();
                        DSSV.Clear();//cho list DSSV trống đã
                        docdanhsachsv();//xong đọc file ra để lấy dữ liệu vào list DSSV
                        foreach (Sinhvien xoasv in DSSV)
                        {//danh sách lớp thứ(1,...) liên kết tới danh sách thông tin sinh viên 1 lớp
                            if (xoasv.Masv == Masv)//mã sv phải trùng 
                            {
                                Console.WriteLine("Đã tìm thấy sinh viên có mã "+xoasv.Masv);
                                //DSlop[i].DS1lop.Remove(xoasv);//xóa sinh viên trong danh sách lớp
                                DSSV.Remove(xoasv);//xóa sinh viên có mã được nhập trong list DSSV
                                /*
                                foreach(Sinhvien sinhvien in DSSV)
                                {
                                    Console.WriteLine(sinhvien.Masv);
                                    //Console.WriteLine(sinhvien.Tensv);
                                }
                                */                               
                                Console.WriteLine("Bạn đã xóa sinh viên thành công");
                                kt = true; break;
                            }
                            else
                            {
                                //Console.WriteLine("Mã sinh viên không trùng nên không thể xóa"); 
                            } 
                        }
                        string filePath = "sinhvien.txt";
                        File.WriteAllText(filePath,string.Empty);//xóa dữ liệu trong file sinhvien.txt
                        Ghidanhsachsv();//xóa xong thì ghi những dữ liệu cũ vô file (còn dữ liệu vừa bị xóa thì đã mất)
                        DSSV.Clear();//xong lại cho list DSSV trống để trách bị lặp dữ liệu sang những phần khác
                        
                        if (kt == true) break;//khi xóa thành công thì thoát khỏi do while
                        else
                        {
                            Console.Clear() ;
                            Console.WriteLine("Mã sinh viên này không tồn tại.");
                            Console.WriteLine("╔═══════════════════════════════════════════════════════════════════╗");
                            Console.WriteLine("║            Bạn có muốn thêm sinh viên này vào lớp không           ║");
                            Console.WriteLine("║═══════════════════════════════════════════════════════════════════║");
                            Console.WriteLine("║                                                                   ║");
                            Console.WriteLine("║                      ╭───────────────────────╮                    ║");
                            Console.WriteLine("║                      │      1.Có             │                    ║");
                            Console.WriteLine("║                      ╰───────────────────────╯                    ║");
                            Console.WriteLine("║                      ╭───────────────────────╮                    ║");
                            Console.WriteLine("║                      │      2.Không          │                    ║");
                            Console.WriteLine("║                      ╰───────────────────────╯                    ║");
                            Console.WriteLine("╠═══════════════════════════════════════════════════════════════════╣");
                            Console.WriteLine("║               Hãy chọn một trong các chức năng trên:              ║");
                            Console.WriteLine("╚═══════════════════════════════════════════════════════════════════╝");
                            Console.Write("Mời nhập lựa chọn của bạn: ");
                            string nhap1 = Console.ReadLine();
                            if (nhap1.Equals("1"))
                            {
                                Themsinhvienvaolop(Malop);
                                Console.WriteLine("╔═══════════════════════════════════════════════════════════════════╗");
                                Console.WriteLine("║           Bạn có muốn xóa sinh viên trong lớp nữa không           ║");
                                Console.WriteLine("║═══════════════════════════════════════════════════════════════════║");
                                Console.WriteLine("║                                                                   ║");
                                Console.WriteLine("║                      ╭───────────────────────╮                    ║");
                                Console.WriteLine("║                      │      1.Có             │                    ║");
                                Console.WriteLine("║                      ╰───────────────────────╯                    ║");
                                Console.WriteLine("║                      ╭───────────────────────╮                    ║");
                                Console.WriteLine("║                      │      2.Không          │                    ║");
                                Console.WriteLine("║                      ╰───────────────────────╯                    ║");
                                Console.WriteLine("╠═══════════════════════════════════════════════════════════════════╣");
                                Console.WriteLine("║               Hãy chọn một trong các chức năng trên:              ║");
                                Console.WriteLine("╚═══════════════════════════════════════════════════════════════════╝");
                                Console.Write("Mời nhập lựa chọn của bạn: ");
                                string nhap2 = Console.ReadLine();
                                if (nhap2.Equals("1")) { }                     
                                else if (nhap2.Equals("2")) { break; }
                            }
                            else if (nhap1.Equals("2")) { break; }
                        }
                    } while (kt == false);
                    break;//thoát khỏi for ngài
                }
            }
            

        }
        public static void Timkiemsinhvien(string Masv)
        {
            Console.Clear();
            DSSV.Clear();
            docdanhsachsv();
            foreach (Sinhvien sv in DSSV)
            {
                if (sv.Masv == Masv)
                {
                    Console.WriteLine("╔════════════════════════════════════════════════════════════════╗");
                    Console.WriteLine("║                  Thông tin sinh viên là                        ║");
                    Console.WriteLine("╚════════════════════════════════════════════════════════════════╝");
                    Console.WriteLine("║ Mã sinh viên ║ ║ Tên sinh viên ║\t║ Mã lớp ║ ║ Ngày sinh ║ ║ Giới tính ║ ║ Địa chỉ ║ ║ Số điện thoại ║ ║ Điểm ║");
                    Console.WriteLine($"║ {sv.Masv} ║\t ║ {sv.Tensv} ║\t║ {sv.Malop} ║ ║ {sv.Ngaysinh} ║ ║ {sv.Gioitinh} ║\t║ {sv.Diachi} ║\t║ {sv.Sodienthoai} ║ ║ {sv.Diem} ║");
                }
                else
                {
                    //Console.WriteLine("Không có sinh viên này");
                } 
                
            }
        }
        public static void Ghidanhsachsv()
        {
            try
            {
                // ghi thông tin các sinh viên vào file
                for (int j = 0; j < DSSV.Count; j++)
                {
                    File.AppendAllText("C:\\Users\\NGUYEN VAN HIEU\\Source\\Repos\\Bài tập lớn 1\\ConsoleApp1\\bin\\Debug\\sinhvien.txt", $"{DSSV[j].Masv}@{DSSV[j].Tensv}@{DSSV[j].Malop}@{DSSV[j].Ngaysinh}@{DSSV[j].Gioitinh}@{DSSV[j].Diachi}@{DSSV[j].Sodienthoai}@{DSSV[j].Diem}" + "\n");

                }
            }
            catch (Exception ex) { Console.WriteLine("Lỗi: " + ex.Message); }//try-catch để kiểm tra ngoại lệ, soát lỗi,...
        }
        public static void ghidanhsachlop()
        {
            try
            {
                // ghi thông tin các sinh viên vào file
                for (int j = 0; j < DSlop.Count; j++)
                {
                    File.AppendAllText("C:\\Users\\NGUYEN VAN HIEU\\Source\\Repos\\Bài tập lớn 1\\ConsoleApp1\\bin\\Debug\\lop.txt", $"{DSlop[j].Malop}@{DSlop[j].Tenlop}@{DSlop[j].Giaovienchunhiem}@{DSlop[j].Makhoa}@{DSlop[j].Manienkhoa}" + "\n");

                }
            }
            catch (Exception ex) { Console.WriteLine("Lỗi: " + ex.Message); }//try-catch để kiểm tra ngoại lệ, soát lỗi,...
        }
        public static void docdanhsachsv()
        {
            try
            {
                string[] tach = File.ReadAllLines("C:\\Users\\NGUYEN VAN HIEU\\Source\\Repos\\Bài tập lớn 1\\ConsoleApp1\\bin\\Debug\\sinhvien.txt");
                // 1 mảng = đọc file 1 dòng trong file là 1 dòng trong mảng
                foreach (string s in tach)
                {//duyệt trong mảng
                    Sinhvien sinhvien = new Sinhvien();
                    string[] tach1 = s.Split('@');//tách mảng bởi dấu @            
                    sinhvien.Masv = tach1[0];//trở thành dòng đầu 
                    sinhvien.Tensv = tach1[1];//dòng 2
                    sinhvien.Malop = tach1[2];
                    sinhvien.Ngaysinh = tach1[3];
                    sinhvien.Gioitinh = tach1[4];
                    sinhvien.Diachi = tach1[5];
                    sinhvien.Sodienthoai = tach1[6];
                    sinhvien.Diem = tach1[7];
                    DSSV.Add(sinhvien);
                    /*
                    foreach (Sinhvien sinhvien1 in DSSV)
                    {
                        Console.WriteLine("check trong DSSV");
                        Console.WriteLine(sinhvien1.Masv);
                        Console.WriteLine(sinhvien.Malop);
                    }
                    Console.WriteLine("Đã hết dữ liệu trong list DSSV");
                    */
                    //Quản_Lý_Lớp.LayLop(sinhvien.Malop).DS1lop.Add(sinhvien);
                    
                }
                Console.WriteLine("Đã hết dữ liệu trong file sinhvien.txt");
            }
            catch (Exception ex) { Console.WriteLine("Lỗi: " + ex.Message); }//try-catch để kiểm tra ngoại lệ, soát lỗi,...
                       
        }
        public static void docdanhsachlop()
        {
            try
            {
                string[] tach = File.ReadAllLines("C:\\Users\\NGUYEN VAN HIEU\\Source\\Repos\\Bài tập lớn 1\\ConsoleApp1\\bin\\Debug\\lop.txt");
                // 1 mảng = đọc file 1 dòng trong file là 1 dòng trong mảng
                foreach (string s in tach)
                {//duyệt trong mảng
                    Lop lop = new Lop();
                    string[] tach1 = s.Split('@');//tách mảng bởi dấu @            
                    lop.Malop = tach1[0];//trở thành dòng đầu 
                    lop.Tenlop = tach1[1];//dòng 2
                    lop.Giaovienchunhiem = tach1[2];
                    lop.Makhoa= tach1[3];
                    lop.Manienkhoa= tach1[4];
                    DSlop.Add(lop);

                    /*foreach (Lop l in DSlop)
                    {
                        Console.WriteLine("check trong DSlop");
                        Console.WriteLine(l.Malop);
                        Console.WriteLine(l.Makhoa);
                    }
                    Console.WriteLine("Đã hết dữ liệu trong list DSlop");*/

                    //Quản_Lý_Niên_Khóa.Laynienkhoa(Lop.Manienkhoa).DSlop.Add(Lop);
                    //Quản_Lý_Khoa.Laykhoa(Lop.Makhoa).DSlop.Add(Lop);
                }
                Console.WriteLine("Đã đọc hết dữ liệu trong file lop.txt");
            }
            catch (Exception ex) { Console.WriteLine("Lỗi: " + ex.Message); }//try-catch để kiểm tra ngoại lệ, soát lỗi,...

        }
    }

}
