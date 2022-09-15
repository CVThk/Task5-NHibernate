using System;
using System.Collections.Generic;
using System.Text;

namespace StudentManagerment.Models
{
    public class Subject
    {
        public virtual string MaMonHoc { get; set; }
        public virtual string TenMonHoc { get; set; }
        public virtual int SoTiet { get; set; }
        public virtual double TyLeQuaTrinh { get; set; }
        public virtual double TyLeThanhPhan { get; set; }

        public Subject() { }
        public Subject(string maMonHoc, string tenMonHoc, int soTiet, double tyLeQuaTrinh, double tyLeThanhPhan)
        {
            this.MaMonHoc = maMonHoc;
            this.TenMonHoc = tenMonHoc;
            this.SoTiet = soTiet;
            this.TyLeQuaTrinh = tyLeQuaTrinh;
            this.TyLeThanhPhan = tyLeThanhPhan;
        }
    }
}
