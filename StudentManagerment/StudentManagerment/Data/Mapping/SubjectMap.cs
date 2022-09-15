using FluentNHibernate.Mapping;
using StudentManagerment.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentManagerment.Data.Mapping
{
    public class SubjectMap : ClassMap<Subject>
    {
        public SubjectMap()
        {
            Id(x => x.MaMonHoc);
            Map(x => x.TenMonHoc);
            Map(x => x.SoTiet);
            Map(x => x.TyLeQuaTrinh);
            Map(x => x.TyLeThanhPhan);
            Table("MONHOC");
        }
    }
}
