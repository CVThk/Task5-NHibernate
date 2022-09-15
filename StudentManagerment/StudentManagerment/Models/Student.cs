using System;
using System.Collections.Generic;
using System.Text;

namespace StudentManagerment.Models
{
    public class Student
    {
        public virtual string MaSinhVien { get; set; }
        public virtual string TenSinhVien { get; set; }
        public virtual string GioiTinh { get; set; }
        public virtual DateTime NgaySinh { get; set; }
        public virtual string Lop { get; set; }
        public virtual int KhoaHoc // Khóa học
        {
            get { return NgayVaoTruong.Year; }
        }
        public virtual DateTime NgayVaoTruong { get; set; } // Ngày vào trường
        public virtual string Khoa { get; set; } // Khoa: Công nghệ Thông tin, Quản Trị Kinh Doanh, ...
        public virtual string TrangThai { get; set; } // Trạng thái: Đang học, ra trường, ...
        public virtual string BacDaoTao { get; set; } // Bậc đào tạo: Đại học, cao đẳng, ...
        public virtual string SDT { get; set; } // Số điện thoại
        public virtual string CMND { get; set; }
        public virtual string DiaChiTT { get; set; } // Địa chỉ thường trú
        public virtual string DanToc { get; set; }
        public virtual string TonGiao { get; set; }

        public Student() { }
        public Student(string masv, string ten, string gioiTinh, string lop, DateTime ngaySinh, DateTime ngayVaoTruong, string khoa, string trangThai, string bacDaoTao, string sdt, string cmnd, string diaChiThuongTru, string danToc, string tonGiao)
        {
            this.MaSinhVien = masv;
            this.TenSinhVien = ten;
            this.GioiTinh = gioiTinh;
            this.Lop = lop;
            this.NgaySinh = ngaySinh;
            this.NgayVaoTruong = ngayVaoTruong;
            this.Khoa = khoa;
            this.TrangThai = trangThai;
            this.BacDaoTao = bacDaoTao;
            this.SDT = sdt;
            this.CMND = cmnd;
            this.DiaChiTT = diaChiThuongTru;
            this.DanToc = danToc;
            this.TonGiao = tonGiao;
        }
    }
}
