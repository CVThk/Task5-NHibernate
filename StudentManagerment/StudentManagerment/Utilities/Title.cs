using System;
using System.Collections.Generic;
using System.Text;

namespace StudentManagerment.Utilities
{
    public class Title
    {
        public void showTitleStudent()
        {
            Console.WriteLine("\t\t\t\t\tDANH SÁCH SINH VIÊN");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("\t{0,-15}{1,-30}{2,-15}{3,-15}{4,-10}", "Mã sinh viên", "Họ và tên", "Lớp", "Giới tính", "Ngày sinh");
            Console.ResetColor();

            Console.Write('\t');
            for (int i = 0; i < 15 + 30 + 15 + 15 + 10; i++)
            {
                Console.Write('-');
            }
            Console.WriteLine();
        }

        public void showTitleSubject()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("\t{0,-15}{1,-50}{2,-10}", "Mã môn", "Tên môn", "Số tiết");
            Console.ResetColor();

            Console.Write('\t');
            for (int i = 0; i < 15 + 50 + 10; i++)
            {
                Console.Write('-');
            }
            Console.WriteLine();
        }

        public void showTitleTranscript()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("\t{0,-15}{1,-50}{2,-10}{3,-20}{4,-20}{5,-10}", "Mã môn học", "Tên môn học", "Số tiết", "Điểm quá trình", "Điểm thành phần", "Kết quả");
            Console.ResetColor();

            Console.Write('\t');
            for (int i = 0; i < 15 + 50 + 20 + 20 + 10 + 10; i++)
            {
                Console.Write('-');
            }
            Console.WriteLine();
        }
    }
}
