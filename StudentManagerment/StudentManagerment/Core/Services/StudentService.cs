using StudentManagerment.Core.Interfaces.IData;
using StudentManagerment.Core.Interfaces.IServices;
using StudentManagerment.Data;
using StudentManagerment.Models;
using System;
using System.Collections.Generic;
using System.Text;


namespace StudentManagerment.Core.Services
{
    public class StudentService : IStudentService
    {
        private IStudentData _data;
        public StudentService(IStudentData data)
        {
            this._data = data;
        }

        public void showInfoDetail(Student student)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n\tTHÔNG TIN SINH VIÊN");
            Console.ResetColor();
            Console.WriteLine("\tMã sinh viên: " + student.MaSinhVien);
            Console.WriteLine("\tHọ tên: " + student.TenSinhVien);
            Console.WriteLine("\tGiới tính: " + student.GioiTinh);
            Console.WriteLine(("\tNgày sinh: " + student.NgaySinh.ToShortDateString()).PadRight(30) + ("Dân tộc: " + student.DanToc).PadRight(20) + "Tôn giáo: " + student.TonGiao);
            Console.WriteLine("\tSố CMND: " + student.CMND);
            Console.WriteLine("\tĐiện thoại: " + student.SDT);
            Console.WriteLine("\tĐịa chỉ thường trú: " + student.DiaChiTT);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n\tTHÔNG TIN HỌC VẤN");
            Console.ResetColor();
            Console.WriteLine(("\tTrạng thái: " + student.TrangThai).PadRight(50) + "Ngày vào trường: " + student.NgayVaoTruong.ToShortDateString());
            Console.WriteLine(("\tLớp: " + student.Lop).PadRight(50) + "Bậc đào tạo: " + student.BacDaoTao);
            Console.WriteLine(("\tKhoa: " + student.Khoa).PadRight(50) + "Khóa học: " + student.KhoaHoc);
        }
        public void showInfo(Student student)
        {
            Console.WriteLine("\t{0,-15}{1,-30}{2,-15}{3,-15}{4,-10}", student.MaSinhVien, student.TenSinhVien, student.Lop, student.GioiTinh, student.NgaySinh.ToShortDateString());
        }
        public List<Student> getAll() => _data.GetStudents();

        public Student create()
        {
            return new Student();
        }
        public Student search(List<Student> list, string code)
        {
            return list.Find(x => x.MaSinhVien == code);
        }

        public void detete(List<Student> list, string code)
        {
            foreach(Student student in list)
            {
                if(student.MaSinhVien == code)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("\t[>] Chú ý: bạn có chắc muốn xóa không? Thông tin điểm số liên quan sẽ bị xóa tất cả! (Y/N): ");
                    string kt = Console.ReadLine();
                    Console.ResetColor();
                    if (kt.ToUpper() == "N")
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("\t[>] Đã hủy bỏ!");
                        Console.ResetColor();
                        return;
                    }    
                    list.Remove(student);
                    new Database().deleteStudent(code);
                    return;
                }    
            }
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\tKhông tìm thấy sinh viên trong danh sách hiện tại!");
            Console.ResetColor();
        }

        public void update(List<Student> list, string objUpdate, Student infoUpdate)
        {
            foreach(Student student in list)
            {
                if(student.MaSinhVien == objUpdate)
                {
                    student.TenSinhVien = infoUpdate.TenSinhVien;
                    student.NgaySinh = infoUpdate.NgaySinh;
                    student.GioiTinh = infoUpdate.GioiTinh;
                    student.Lop = infoUpdate.Lop;
                    student.NgayVaoTruong = infoUpdate.NgayVaoTruong;
                    student.Khoa = infoUpdate.Khoa;
                    student.TrangThai = infoUpdate.TrangThai;
                    student.BacDaoTao = infoUpdate.BacDaoTao;
                    student.SDT = infoUpdate.SDT;
                    student.DiaChiTT = infoUpdate.DiaChiTT;
                    student.DanToc = infoUpdate.DanToc;
                    student.TonGiao = infoUpdate.TonGiao;
                    new Database().updateStudent(student);
                    return;
                }    
            }    
        }
    }
}
