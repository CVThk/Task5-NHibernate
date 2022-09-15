using StudentManagerment.Data;
using StudentManagerment.Models;
using StudentManagerment.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StudentManagerment
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;
            new Execute().runMain();
            //List<Student> dssv = (new NHibernateData()).GetStudents();
            //dssv.ForEach(x => Console.WriteLine("\n\tTHÔNG TIN SINH VIÊN\n\tMã sinh viên: {0}\n\tHọ tên: {1}\n\tGiới tính: {2}\n\tNgày sinh: {3,-30}Dân tộc: {4,-20}Tôn giáo: {5}\n\tSố CMND: {6}\n\tĐiện thoại: {7}\n\tĐịa chỉ thường trú: {8}\n\tTHÔNG TIN HỌC VẤN\n\tTrạng thái: {9,-50}Ngày vào trường: {10}\n\tLớp: {11,-50}Bậc đào tạo: {12}\n\tKhoa: {13,-50}Khóa học: {14}",
            //x.MaSinhVien, x.TenSinhVien, x.GioiTinh, x.NgaySinh.ToShortDateString(), x.DanToc, x.TonGiao, x.CMND, x.SDT, x.DiaChiTT, x.TrangThai, x.NgayVaoTruong.ToShortDateString(), x.Lop, x.BacDaoTao, x.Khoa, x.KhoaHoc));

            //using (var session = NHibernateHelper.OpenSession())
            //{
            //    dssv = session.Query<Student>().ToList();
            //    dssv.ForEach(x => Console.WriteLine("\n\tTHÔNG TIN SINH VIÊN\n\tMã sinh viên: {0}\n\tHọ tên: {1}\n\tGiới tính: {2}\n\tNgày sinh: {3,-30}Dân tộc: {4,-20}Tôn giáo: {5}\n\tSố CMND: {6}\n\tĐiện thoại: {7}\n\tĐịa chỉ thường trú: {8}\n\tTHÔNG TIN HỌC VẤN\n\tTrạng thái: {9,-50}Ngày vào trường: {10}\n\tLớp: {11,-50}Bậc đào tạo: {12}\n\tKhoa: {13,-50}Khóa học: {14}",
            //        x.MaSinhVien, x.TenSinhVien, x.GioiTinh, x.NgaySinh.ToShortDateString(), x.DanToc, x.TonGiao, x.CMND, x.SDT, x.DiaChiTT, x.TrangThai, x.NgayVaoTruong.ToShortDateString(), x.Lop, x.BacDaoTao, x.Khoa, x.KhoaHoc));
            //}

            //List<Subject> dsmh = (new NHibernateData()).GetSubjects();
            //dsmh.ForEach(x => Console.WriteLine("\t{0,-15}{1,-50}{2,-10}", x.MaMonHoc, x.TenMonHoc, x.SoTiet.ToString()));
        }
    }
}
