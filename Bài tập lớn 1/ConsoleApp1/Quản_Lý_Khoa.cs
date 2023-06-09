using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static Bài_tập_lớn_1.Quản_Lý_Khoa;
using static Bài_tập_lớn_1.Quản_Lý_Lớp;

namespace Bài_tập_lớn_1
{
    internal class Quản_Lý_Khoa : Quản_Lý_Lớp
    {
        public struct Khoa
        {
            public string Makhoa;
            public string Tenkhoa;
            public List<Lop> DSlop;
        }
        // khởi tạo sanh sách lưu thông tin các khoa
        public static List<Khoa> DSkhoa = new List<Khoa>();
        public static Khoa Taokhoa(string Makhoa, string Tenkhoa)//hàm tạo khoa
        {
            Khoa khoa = new Khoa();
            khoa.Makhoa = Makhoa;
            khoa.Tenkhoa = Tenkhoa;
            khoa.DSlop = new List<Lop>();
            return khoa;
        }
        public static int luachon()
        {
            int i;
            while (true)
            {
                Console.Write("Mời nhập lựa chọn của bạn: ");

                if (int.TryParse(Console.ReadLine(), out i))
                {//kiểm tra lựa chọn nhập vào có đúng định dạng không, nếu đúng thì thoát khỏi vòng lặp
                    break;
                }
                else Console.WriteLine("Nhập lựa chọn chưa đúng định dạng");
            }
            return i;
        }
        public static void QLDScackhoa()
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine("\t\t\t\t\t╔════════════════════════════════════════════╗");
            Console.WriteLine("\t\t\t\t\t║      QUẢN LÝ THÔNG TIN KHOA ĐÀO TẠO        ║");
            Console.WriteLine("\t\t\t\t\t╠════════════════════════════════════════════╣");
            Console.WriteLine("\t\t\t\t\t║  1. THÊM KHOA ĐÀO TẠO                      ║");
            Console.WriteLine("\t\t\t\t\t║         └────────────┘                     ║");
            Console.WriteLine("\t\t\t\t\t║  2. HIỂN THỊ CÁC KHOA ĐÀO TẠO ĐÃ CÓ TRONG  ║");
            Console.WriteLine("\t\t\t\t\t║     DANH SÁCH                              ║");
            Console.WriteLine("\t\t\t\t\t║         └────────────┘                     ║");
            Console.WriteLine("\t\t\t\t\t║  3. XEM THÔNG TIN DANH SÁCH LỚP CỦA KHOA   ║");
            Console.WriteLine("\t\t\t\t\t║     ĐANG ĐÀO TẠO                           ║");
            Console.WriteLine("\t\t\t\t\t║         └────────────┘                     ║");
            Console.WriteLine("\t\t\t\t\t║  4. XOÁ KHOA ĐÀO TẠO                       ║");
            Console.WriteLine("\t\t\t\t\t║         └────────────┘                     ║");
            Console.WriteLine("\t\t\t\t\t║  5. TÌM KIẾM KHOA                          ║");
            Console.WriteLine("\t\t\t\t\t║         └────────────┘                     ║");
            Console.WriteLine("\t\t\t\t\t║  6. THOÁT KHỎI CHƯƠNG TRÌNH                ║");
            Console.WriteLine("\t\t\t\t\t║         └────────────┘                     ║");
            Console.WriteLine("\t\t\t\t\t╠════════════════════════════════════════════╣");
            Console.WriteLine("\t\t\t\t\t║  Hãy chọn một trong các chức năng trên:    ║");
            Console.WriteLine("\t\t\t\t\t╚════════════════════════════════════════════╝");

            int lc = luachon();
            switch (lc)
            {
                case 1:
                    themkhoadaotao();
                    Console.WriteLine("╔═══════════════════════════════════════════════════════════════════╗");
                    Console.WriteLine("║                     Bạn có làm thêm nữa không                     ║");
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
                        QLDScackhoa();
                    }
                    else if (nhap1.Equals("2")) { break; }                  
                    break;
                case 2://hiển thị khoa đào tạo đã có
                    DSkhoa.Clear();
                    docdanhsachkhoa();
                    Hienthikhoadaco();
                    Console.WriteLine("╔═══════════════════════════════════════════════════════════════════╗");
                    Console.WriteLine("║                     Bạn có làm thêm nữa không                     ║");
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
                    string nhap = Console.ReadLine();
                    if (nhap.Equals("1"))
                    {
                        QLDScackhoa();
                    }
                    else if (nhap.Equals("2")) { break; }
                    break;
                case 3:
                    //xem danh sách lớp của khoa đang đào tạo;
                    Console.Clear();
                    Console.WriteLine("\t\t\t\t\t╔═════════════════════════════════════════════════════╗");
                    Console.WriteLine("\t\t\t\t\t║           Nhập vào mã khoa bạn muốn hiển thị        ║");
                    Console.WriteLine("\t\t\t\t\t║═════════════════════════════════════════════════════║");
                    Console.WriteLine("\t\t\t\t\t║                                                     ║");
                    Console.WriteLine("\t\t\t\t\t║               ╭───────────────────────╮             ║");
                    Console.WriteLine("\t\t\t\t\t║               │ Mã khoa :             │             ║");
                    Console.WriteLine("\t\t\t\t\t║               ╰───────────────────────╯             ║");
                    Console.WriteLine("\t\t\t\t\t╚═════════════════════════════════════════════════════╝");
                    Console.SetCursorPosition(68, 5);
                    string Makhoa = Console.ReadLine();
                    HienthiDSlopkhoadangdaotao(Makhoa);
                    Console.WriteLine("╔═══════════════════════════════════════════════════════════════════╗");
                    Console.WriteLine("║                     Bạn có làm thêm nữa không                     ║");
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
                    if (nhap2.Equals("1"))
                    {
                        QLDScackhoa();
                    }
                    else if (nhap2.Equals("2")) { break; }
                    break;
                case 4://xóa khoa đào tạo
                    do
                    {
                        Console.Write("Nhập vào mã khoa bạn muốn xóa: "); Makhoa = Console.ReadLine();
                        DSkhoa.Clear();
                        docdanhsachkhoa();
                        if (Ktttrung(Makhoa) == false) { break; }//kiểm tra mã khoa phải trùng,false là trùng
                        else
                        {
                            Console.WriteLine("Mã khoa này chưa có bạn phải thêm khoa đã ");
                            goto Thoat;
                        }
                    } while (true);
                    Xoakhoa(Makhoa);
                    Console.WriteLine("╔═══════════════════════════════════════════════════════════════════╗");
                    Console.WriteLine("║                     Bạn có làm thêm nữa không                     ║");
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
                    string nhap3 = Console.ReadLine();
                    if (nhap3.Equals("1"))
                    {
                        QLDScackhoa();
                    }
                    else if (nhap3.Equals("2")) { break; }
                Thoat: QLDScackhoa();
                    break;
                case 5:
                    Console.Clear();
                    Console.WriteLine("\t\t\t\t\t╔═════════════════════════════════════════════════════╗");
                    Console.WriteLine("\t\t\t\t\t║            Nhập vào mã khoa muốn tìm kiếm           ║");
                    Console.WriteLine("\t\t\t\t\t║═════════════════════════════════════════════════════║");
                    Console.WriteLine("\t\t\t\t\t║                                                     ║");
                    Console.WriteLine("\t\t\t\t\t║            ╭─────────────────────────────╮          ║");
                    Console.WriteLine("\t\t\t\t\t║            │ Mã khoa :                   │          ║");
                    Console.WriteLine("\t\t\t\t\t║            ╰─────────────────────────────╯          ║");
                    Console.WriteLine("\t\t\t\t\t╚═════════════════════════════════════════════════════╝");
                    Console.SetCursorPosition(65, 5);
                    Makhoa = Console.ReadLine();
                    Timkiemkhoa(Makhoa);
                    break;
                case 6: break;
                default:
                    Console.Clear();
                    Console.WriteLine("\t\t\t\t\t╔════════════════════════════════════════════════════════════════╗");
                    Console.WriteLine("\t\t\t\t\t║           KHÔNG CÓ CHỨC NĂNG NÀY. VUI LÒNG NHẬP LẠI            ║");
                    Console.WriteLine("\t\t\t\t\t╚════════════════════════════════════════════════════════════════╝");
                    QLDScackhoa();
                    break;
            }

        }
        public static bool Ktttrung(string Makhoa)//hàm kiểm tra Mã khoa có trùng không
        {
            foreach (Khoa K in DSkhoa)//duyệt trong list DSkhoa
            {
                if (K.Makhoa == Makhoa) { return false; }//nếu trùng thì trả về false
            }
            return true;//không trùng thì trả về true
        }
        public static void themkhoadaotao()
        {
            string Makhoa;
            string Tenkhoa;
            bool kt = true;
            do
            {
                do
                {
                    Console.Write("Nhập vào mã khoa: "); Makhoa = Console.ReadLine();
                    if(!Regex.IsMatch(Makhoa, @"^[0-9]+$")) { Console.WriteLine("Mã khoa không đúng định dạng vui lòng nhập lại"); }
                    else { }
                } while (!Regex.IsMatch(Makhoa, @"^[0-9]+$"));//kiểm tra điều kiện sai (nếu Makhoa nhập vào khác 0-9 thì nhập lại)
                kt = Ktttrung(Makhoa);//kiểm tra Makhoa có trùng ko: nếu trùng thì kt=false, ko trùng thì kt=true
                if (kt == false) Console.WriteLine("Mã khoa này đã có nhập lại thông tin");
            }
            while (kt == false);//kt phải = true(ko trùng) thì mới thoát khỏi vòng lặp 

            do
            {
                Console.Write("Nhập vào tên khoa: ");Tenkhoa = Console.ReadLine();
                Tenkhoa = Regex.Replace(Tenkhoa, @"\s+", " ");//thay thế các khoảng trắng liên tiếp bằng một khoảng trắng duy nhất
                if (!Regex.IsMatch(Tenkhoa, @"^[a-zA-Z0-9 ]+$")|| Tenkhoa.Length > 30 || Tenkhoa.Length == 0) { Console.WriteLine("Tên khoa không đúng định dạng vui lòng nhập lại"); }
            } while (!Regex.IsMatch(Tenkhoa, @"^[a-zA-Z0-9 ]+$")|| Tenkhoa.Length > 30 || Tenkhoa.Length == 0);//kiểm tra điều kiện sai (nếu Tenkhoa nhập vào khác a-zA-Z0-9 thì nhập lại) 

            Khoa Km = Taokhoa(Makhoa, Tenkhoa);//Km = hàm Taokhoa 
            DSkhoa.Add(Km);// thêm khoa đã nhập vào danh sách khoa
            /*foreach(Khoa khoa in DSkhoa)
            {
                Console.WriteLine(khoa.Makhoa);
            }*/
            ghidanhsachkhoa();//ghi vào file khoa.txt
            Console.WriteLine("Đã thêm khoa thành công");

        }
        public static void Timkiemkhoa(string Makhoa)
        {
            Console.Clear();
            DSkhoa.Clear();
            docdanhsachkhoa();
            foreach (Khoa kh in DSkhoa)
            {
                if (kh.Makhoa == Makhoa)
                {
                    Console.WriteLine("╔═════════════════════════════════════════════════════╗");
                    Console.WriteLine("║          Danh sách các khoa đang đào tạo            ║");
                    Console.WriteLine("╚═════════════════════════════════════════════════════╝");
                    Console.WriteLine("║ Mã khoa ║\t║ Tên khoa ║");
                    Console.WriteLine($"║ {kh.Makhoa} ║\t\t║ {kh.Tenkhoa} ║");
                    Console.WriteLine("╚═════════════════════════════════════════════════════╝");
                }
                else
                {
                    //Console.WriteLine($"check");
                }
                
            }

        }
        public static void Hienthikhoadaco()
        {
            if (DSkhoa.Count > 0)//kiểm tra list DSkhoa có dữ liệu không 
            {
                Console.WriteLine("╔═════════════════════════════════════════════════════╗");
                Console.WriteLine("║          Danh sách các khoa đang đào tạo            ║");
                Console.WriteLine("╚═════════════════════════════════════════════════════╝");
                Console.WriteLine("║ Mã khoa ║\t║ Tên khoa ║");
                foreach (Khoa K in DSkhoa)// Cho K chạy trong list DSkhoa
                {
                    Console.WriteLine($"║ {K.Makhoa} ║\t\t║ {K.Tenkhoa} ║");
                }
            }
            else
            {
                Console.WriteLine("Chưa có khoa nào");
                Console.WriteLine("╔═══════════════════════════════════════════════════════════════════╗");
                Console.WriteLine("║                     Bạn có muốn thêm khoa không                   ║");
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
                string nhap = Console.ReadLine();
                if (nhap.Equals("1"))
                {
                    themkhoadaotao();
                    Console.WriteLine("╔═══════════════════════════════════════════════════════════════════╗");
                    Console.WriteLine("║                Bạn có muốn hiển thị khoa nữa không                ║");
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
                        Hienthikhoadaco();
                    }
                    else { }

                }
                else if (nhap.Equals("2")) {  }

            }
            
        }
        public static Khoa Laykhoa(string Makhoa)
        {
            foreach (Khoa K in DSkhoa)
            {
                if (K.Makhoa == Makhoa) { return K; }
            }//kiểm tra mã khoa nếu trùng thì trả ra K(biến truy xuất đến DSkhoa) còn ko trùng thi trả ra 1 biến rỗng
            Khoa Ktrong = new Khoa();
            return Ktrong;
        }
        public static void HienthiDSlopkhoadangdaotao(string Makhoa)
        {
            Console.Clear();
            DSkhoa.Clear();//xóa hết dữ liệu trong list DSkhoa
            docdanhsachkhoa();//đọc file ra DSkhoa để lấy Mã khoa trong DSkhoa
            if (Ktttrung(Makhoa) == false)//kiểm tra mã khoa phải trùng,false là trùng
            {         
                //Console.WriteLine("check");
                Khoa kq = Laykhoa(Makhoa);//cho kq = (Makhoa trùng với Makhoa(đã nhập)) để cho ra 1 biến truy xuất đến struct
                docdanhsachlop();//đọc file ra DSlop để lấy Mã khoa trong DSlop
                Console.WriteLine("╔═══════════════════════════════════════════════════════════════════╗");
                Console.WriteLine("║           Thông tin danh sách các lớp trong khoa này là           ║");
                Console.WriteLine("╚═══════════════════════════════════════════════════════════════════╝");
                Console.WriteLine("║ Mã lớp ║\t║ Tên lớp ║\t\t║ GVCN ║\t║ Mã khoa ║\t║ Mã niên khóa ║");
                if (DSlop.Count > 0)//kiểm tra DSlop có dữ liệu không
                {
                    foreach (Lop L in DSlop)//cho L chạy trong list DSlop 
                    {
                        if (kq.Makhoa == L.Makhoa)//kiểm tra Mã khoa trong DSkhoa có trùng với Mã khoa trong Dslop không
                        {
                            //nếu trùng thì hiển thị ra màn hình                          
                            //Console.WriteLine("check");
                            Console.WriteLine("║ " + L.Malop + " ║" + "\t" + "║ " + L.Tenlop + " ║" + "\t" + "║ " + L.Giaovienchunhiem + " ║" + "\t" + "║ " + L.Makhoa + " ║" + "\t\t" + "║ " + L.Manienkhoa + " ║");
                            //Console.WriteLine(L.Makhoa);
                            //break;
                        }
                        //else { Console.Clear(); Console.WriteLine("Mã khoa không trùng với mã khoa trong lớp");break;  }
                    }
                }
                else { Console.WriteLine("Khoa này không có lớp nào. Bạn phải thêm lớp vào khoa đã"); Chạy_Chương_Trình.inchinh(); }
            }
            else Console.WriteLine("Khoa này chưa có. Bạn phải thêm khoa vào đã ");

        }
        public static void Xoakhoa(string Makhoa)
        {
            foreach(Khoa k in DSkhoa)//Cho k chạy trong list DSkhoa
            {
                if(k.Makhoa == Makhoa)//nếu Mã khoa trong list Dskhoa = Mã khoa nhập vào
                {
                    //thì xóa trong DSkhoa
                    DSkhoa.Remove(k);
                    //ghidanhsachkhoa();//xong lại ghi vào file
                    Console.WriteLine("Bạn đã xóa khoa thành công");
                    break;
                }
            }
            string filePath = "khoa.txt";
            File.WriteAllText(filePath, string.Empty);//xóa dữ liệu trong file khoa.txt
            ghidanhsachkhoa();//xóa xong thì ghi những dữ liệu cũ vô file (còn dữ liệu vừa bị xóa thì đã mất)
            DSkhoa.Clear();//xong lại cho list DSkhoa trống để trách bị lặp dữ liệu sang những phần khác

        }
        public static void ghidanhsachkhoa()
        {
            try
            {
                for (int j = 0; j < DSkhoa.Count; j++)// duyệt dữ liệu trong DSkhoa
                {
                    //xong ghi dữ liệu vào file
                    File.AppendAllText("C:\\Users\\NGUYEN VAN HIEU\\Source\\Repos\\Bài tập lớn 1\\ConsoleApp1\\bin\\Debug\\khoa.txt", $"{DSkhoa[j].Makhoa}@{DSkhoa[j].Tenkhoa}" +"\n");

                }
            }
            catch (Exception ex) { Console.WriteLine("Lỗi: " + ex.Message); }//try-catch để kiểm tra ngoại lệ, soát lỗi,...
            
        }
        public static void docdanhsachkhoa()
        {
            try
            {
                //đọc file khoa.txt ra 1 mảng
                string[] tach = File.ReadAllLines("C:\\Users\\NGUYEN VAN HIEU\\Source\\Repos\\Bài tập lớn 1\\ConsoleApp1\\bin\\Debug\\khoa.txt");
                // 1 mảng = đọc file 1 dòng trong file là 1 dòng trong mảng
                foreach (string s in tach)
                {//duyệt trong mảng
                    Khoa khoa = new Khoa();
                    string[] tach1 = s.Split('@');//tách mảng bởi dấu @            
                    khoa.Makhoa = tach1[0];//trở thành dòng đầu 
                    khoa.Tenkhoa = tach1[1];//dòng 2
                    //Console.WriteLine(tach1[0]);
                    //Console.WriteLine(khoa.Makhoa);
                    DSkhoa.Add(khoa);
                    /*foreach (Khoa khoa1 in DSkhoa)
                    {
                        Console.WriteLine("check trong DSkhoa");
                        Console.WriteLine(khoa1.Makhoa);
                        Console.WriteLine(khoa.Tenkhoa);
                    }
                    Console.WriteLine("Đã đọc hết dữ liệu trong DSkhoa");*/
                }
                Console.WriteLine("Đã đọc hết dữ liệu trong file khoa.txt");
            }
            catch (Exception ex) { Console.WriteLine("Lỗi: " + ex.Message); }//try-catch để kiểm tra ngoại lệ, soát lỗi,...
            
        }
    }
}
