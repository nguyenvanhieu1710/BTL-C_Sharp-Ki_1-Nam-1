using Bài_tập_lớn_1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.IO;
using static Bài_tập_lớn_1.Quản_Lý_Lớp;

namespace ConsoleApp1
{
    internal class Quản_Lý_Đăng_Nhập:Chạy_Chương_Trình
    {
        public struct dangnhap
        {
            public string user;
            public string pass;
        }
        //static List<dangnhap> listtoancuc = new List<dangnhap>();
        static List<dangnhap> dsdangnhap = new List<dangnhap>();
        public static void Congviec()
        {
            Menu();
        }
        public static void Menu()
        {
            Console.WriteLine("\t\t\t\t\t╔═════════════════════════════════════════════════════╗");
            Console.WriteLine("\t\t\t\t\t║            ĐĂNG NHẬP VÀO HỆ THỐNG QUẢN LÝ           ║");
            Console.WriteLine("\t\t\t\t\t║═════════════════════════════════════════════════════║");
            Console.WriteLine("\t\t\t\t\t║                                                     ║");
            Console.WriteLine("\t\t\t\t\t║               ╭───────────────────────╮             ║");
            Console.WriteLine("\t\t\t\t\t║               │      1.Đăng nhập      │             ║");
            Console.WriteLine("\t\t\t\t\t║               ╰───────────────────────╯             ║");
            Console.WriteLine("\t\t\t\t\t║               ╭───────────────────────╮             ║");
            Console.WriteLine("\t\t\t\t\t║               │      2.Đăng ký        │             ║");
            Console.WriteLine("\t\t\t\t\t║               ╰───────────────────────╯             ║");
            Console.WriteLine("\t\t\t\t\t║               ╭───────────────────────╮             ║");
            Console.WriteLine("\t\t\t\t\t║               │      3.Thoát          │             ║");
            Console.WriteLine("\t\t\t\t\t║               ╰───────────────────────╯             ║");
            Console.WriteLine("\t\t\t\t\t╠═════════════════════════════════════════════════════╣");
            Console.WriteLine("\t\t\t\t\t║         Hãy chọn một trong các chức năng trên:      ║");
            Console.WriteLine("\t\t\t\t\t╚═════════════════════════════════════════════════════╝");
            Console.Write("Mời nhập lựa chọn của bạn: ");
            string chon = Console.ReadLine();
            if (chon.Equals("1"))
            {
                Dangnhap();
            }
            else if(chon.Equals("2"))
            {
                Dangky();
            }
            else { Console.WriteLine("Chào tạm biệt"); }
        }
        public static void Dangnhap()
        {
            Console.Clear();
            bool kt = false;
            int solansai = 0;
            dangnhap dangNhap = new dangnhap();
            string user;
            string pass;
            dsdangnhap.Clear();//làm cho list dsdangnhap
            docfiledangnhap();//doc file ra list dsdangnhap
            do
            {
                Console.Clear() ;
                Console.WriteLine("\t\t\t\t\t╔═════════════════════════════════════════════════════╗");
                Console.WriteLine("\t\t\t\t\t║            ĐĂNG NHẬP VÀO HỆ THỐNG QUẢN LÝ           ║");
                Console.WriteLine("\t\t\t\t\t║═════════════════════════════════════════════════════║");
                Console.WriteLine("\t\t\t\t\t║                                                     ║");
                Console.WriteLine("\t\t\t\t\t║               ╭───────────────────────╮             ║");
                Console.WriteLine("\t\t\t\t\t║               │ Tài khoản:            │             ║");
                Console.WriteLine("\t\t\t\t\t║               ╰───────────────────────╯             ║");
                Console.WriteLine("\t\t\t\t\t║               ╭───────────────────────╮             ║");
                Console.WriteLine("\t\t\t\t\t║               │ Mật khẩu:             │             ║");
                Console.WriteLine("\t\t\t\t\t║               ╰───────────────────────╯             ║");
                Console.WriteLine("\t\t\t\t\t╚═════════════════════════════════════════════════════╝");
                do
                {
                    Console.SetCursorPosition(68, 5);
                    dangNhap.user = Console.ReadLine().Replace("@","_");//đổi kí tự @ thành _                    
                } while (dangNhap.user.Length >10);
                
                do
                {
                    Console.SetCursorPosition(67, 8);
                    dangNhap.pass = Console.ReadLine().Replace("@","_");//đổi kí tự @ thành _
                } while (dangNhap.pass.Length >10);

                bool kt1 = Kttrungtk(dangNhap.user) ;//kiểm tra user nhập vào có trùng với user trong list dsdangnhap không
                bool kt2 = Kttrungmk(dangNhap.pass);//kiểm tra pass nhập vào có trùng với pass trong list dsdangnhap không
                if (kt1==true && kt2 == true)//=true là trùng 
                {
                    Console.WriteLine("Tài khoản mật khẩu đã trùng khớp");
                    kt = true;//để kiểm tra điều kiện bên dưới
                    break;//để thoát ra khỏi do while ngoài
                }
                else
                {
                    solansai++;//tăng số lần sai lên
                    if (solansai < 3)//kiểm tra số lần sai
                    {
                        Console.Clear();
                        Console.WriteLine("Tài khoản hoặc mật khẩu không đúng. Vui lòng nhập lại");
                        Console.WriteLine("\t\t\t\t\t╔═════════════════════════════════════════════════════╗");
                        Console.WriteLine("\t\t\t\t\t║             Bạn có muốn đăng ký không               ║");
                        Console.WriteLine("\t\t\t\t\t║═════════════════════════════════════════════════════║");
                        Console.WriteLine("\t\t\t\t\t║                                                     ║");
                        Console.WriteLine("\t\t\t\t\t║               ╭───────────────────────╮             ║");
                        Console.WriteLine("\t\t\t\t\t║               │ 1.Có                  │             ║");
                        Console.WriteLine("\t\t\t\t\t║               ╰───────────────────────╯             ║");
                        Console.WriteLine("\t\t\t\t\t║               ╭───────────────────────╮             ║");
                        Console.WriteLine("\t\t\t\t\t║               │ 2.Không               │             ║");
                        Console.WriteLine("\t\t\t\t\t║               ╰───────────────────────╯             ║");
                        Console.WriteLine("\t\t\t\t\t╚═════════════════════════════════════════════════════╝");
                        Console.Write("Mời nhập lựa chọn của bạn: ");
                        string chon = Console.ReadLine();
                        if (chon.Equals("1"))
                        {
                            Dangky();
                        }
                        else if (chon.Equals("2")) { }                       
                    }
                }               
            } while (solansai < 3);//lặp nếu số lần sai vẫn nhỏ hơn 3
            if (kt == true)//kiểm tra điều điện đúng thì mới cho đăng nhập
            {
                Console.Clear ();
                Console.WriteLine("Đăng nhập thành công");
                Chạy_Chương_Trình.inchinh();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Bạn đã nhập sai quá nhiều lần. Hãy thử lại sau.");
            }
        }
        public static void Dangky()
        {
            Console.Clear ();
            dangnhap dangNhap = new dangnhap();

            Console.WriteLine("\t\t\t\t\t╔═════════════════════════════════════════════════════╗");
            Console.WriteLine("\t\t\t\t\t║            ĐĂNG KÝ VÀO HỆ THỐNG QUẢN LÝ             ║");
            Console.WriteLine("\t\t\t\t\t║═════════════════════════════════════════════════════║");
            Console.WriteLine("\t\t\t\t\t║                                                     ║");
            Console.WriteLine("\t\t\t\t\t║               ╭───────────────────────╮             ║");
            Console.WriteLine("\t\t\t\t\t║               │ Tài khoản:            │             ║");
            Console.WriteLine("\t\t\t\t\t║               ╰───────────────────────╯             ║");
            Console.WriteLine("\t\t\t\t\t║               ╭───────────────────────╮             ║");
            Console.WriteLine("\t\t\t\t\t║               │ Mật khẩu:             │             ║");
            Console.WriteLine("\t\t\t\t\t║               ╰───────────────────────╯             ║");
            Console.WriteLine("\t\t\t\t\t╚═════════════════════════════════════════════════════╝");

            do
            {
                Console.SetCursorPosition(68, 5);
                dangNhap.user = Console.ReadLine().Replace("@", "_");//đổi kí tự @ thành _
            } while (dangNhap.user.Length >10);//điều kiện phải ít hơn 10 kí tự thì mới thoát lặp
            //kiểm tra điều kiện sai
            do
            {
                Console.SetCursorPosition(67, 8);
                dangNhap.pass = Console.ReadLine().Replace("@", "_");//đổi kí tự @ thành _
            } while (dangNhap.pass.Length >10);//điều kiện phải ít hơn 10 kí tự thì mới thoát lặp

            dsdangnhap.Add(dangNhap);//thêm vào list dsdangnhap
            foreach (dangnhap dn1 in dsdangnhap)
            {
                //Console.WriteLine("check");
                //Console.WriteLine(dn1.user);
                //Console.WriteLine(dn1.pass);
            }           
            ghifiledangnhap();//ghi vào file dangnhap.txt
            Console.Clear();
            Console.WriteLine("Bạn đã đăng ký thành công");
            Console.WriteLine("\t\t\t\t\t╔═════════════════════════════════════════════════════╗");
            Console.WriteLine("\t\t\t\t\t║            Bạn có muốn đăng nhập không              ║");
            Console.WriteLine("\t\t\t\t\t║═════════════════════════════════════════════════════║");
            Console.WriteLine("\t\t\t\t\t║                                                     ║");
            Console.WriteLine("\t\t\t\t\t║               ╭───────────────────────╮             ║");
            Console.WriteLine("\t\t\t\t\t║               │ 1.Có                  │             ║");
            Console.WriteLine("\t\t\t\t\t║               ╰───────────────────────╯             ║");
            Console.WriteLine("\t\t\t\t\t║               ╭───────────────────────╮             ║");
            Console.WriteLine("\t\t\t\t\t║               │ 2.Không               │             ║");
            Console.WriteLine("\t\t\t\t\t║               ╰───────────────────────╯             ║");
            Console.WriteLine("\t\t\t\t\t╚═════════════════════════════════════════════════════╝");
            Console.Write("Mời nhập lựa chọn của bạn: ");
            string chon = Console.ReadLine();
            if (chon.Equals("1"))
            {
                Dangnhap();
            }
            else if (chon.Equals("2"))
            {
                Menu();
            }      
        }
        public static bool Kttrungtk(string user)//hàm kiểm tra trùng tài khoản hay không
        {
            bool kt1 = false;
            foreach (dangnhap dn1 in dsdangnhap)//cho dn1 chạy trong list dsdangnhap
            {
                if (dn1.user == user) { kt1 = true; break; }//nếu user ở trong list trùng với user nhập vào thì ->true 
            }
            return kt1;//ko trùng ->false
        }
        public static bool Kttrungmk(string pass)//hàm kiểm tra trùng mật khẩu hay không
        {
            bool kt1 = false;
            foreach (dangnhap dn1 in dsdangnhap)//cho dn1 chạy trong list dsdangnhap
            {
                if (dn1.user == pass) { kt1 = true; break; }//nếu pass ở trong list trùng với pass nhập vào thì ->true 
            }
            return kt1;//ko trùng ->false
        }
        static void ghifiledangnhap()//hàm ghi dữ liệu vào file dangnhap.txt
        {
            try
            {
                // ghi thông tin các sinh viên vào file
                for (int j = 0; j < dsdangnhap.Count; j++)//duyệt trong list dsdangnhap
                {
                    File.AppendAllText("C:\\Users\\NGUYEN VAN HIEU\\Source\\Repos\\Bài tập lớn 1\\ConsoleApp1\\bin\\Debug\\dangnhap.txt", $"{dsdangnhap[j].user}@{dsdangnhap[j].pass}" + "\n");
                    //ghi vào trong file dangnhap.txt cách nhau bởi dấu @
                }
            }
            catch (Exception ex) { Console.WriteLine("Lỗi: " + ex.Message); }//try-catch để kiểm tra ngoại lệ, soát lỗi,...
        }
        static void docfiledangnhap()
        {
            try
            {   //đọc file dangnhap.txt ra mảng
                string[] tach = File.ReadAllLines("C:\\Users\\NGUYEN VAN HIEU\\Source\\Repos\\Bài tập lớn 1\\ConsoleApp1\\bin\\Debug\\dangnhap.txt");
                // 1 mảng = đọc file 1 dòng trong file là 1 dòng trong mảng
                foreach (string s in tach)
                {//duyệt trong mảng
                    dangnhap dangnhap1 = new dangnhap();
                    string[] tach1 = s.Split('@');//tách mảng bởi dấu @            
                    dangnhap1.user = tach1[0];//trở thành dòng đầu
                    dangnhap1.pass = tach1[1];//dòng 2
                    //Console.WriteLine("check1");
                    //Console.WriteLine(dangnhap1.user);
                    //Console.WriteLine(dangnhap1.pass);
                    dsdangnhap.Add(dangnhap1);
                    /*
                    foreach (dangnhap dn in dsdangnhap)
                    {
                        Console.WriteLine("check2");
                        Console.WriteLine(dn.user);
                        Console.WriteLine(dn.pass);
                    } 
                    */
                }
                Console.WriteLine("Đã hết dữ liệu trong file");
            }
            catch (Exception ex) { Console.WriteLine("Lỗi: " + ex.Message); }//try-catch để kiểm tra ngoại lệ, soát lỗi,...
        }
    }
}
