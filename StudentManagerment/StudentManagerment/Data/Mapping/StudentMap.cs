using FluentNHibernate.Mapping;
using StudentManagerment.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentManagerment.Data.Mapping
{
    public class StudentMap : ClassMap<Student>
    {
        public StudentMap()
        {
            Id(x => x.MaSinhVien);
            Map(x => x.TenSinhVien);
            Map(x => x.GioiTinh);
            Map(x => x.NgaySinh);
            Map(x => x.Lop);
            Map(x => x.NgayVaoTruong);
            Map(x => x.Khoa);
            Map(x => x.TrangThai);
            Map(x => x.BacDaoTao);
            Map(x => x.SDT);
            Map(x => x.CMND);
            Map(x => x.DiaChiTT);
            Map(x => x.DanToc);
            Map(x => x.TonGiao);
            Table("SINHVIEN");
        }
    }
}
