using System;
using System.Collections.Generic;
using System.Text;

namespace StudentManagerment.Models
{
    public class Transcript
    {
        public virtual IList<Result> bangDiem { get; set; }
        public virtual string MaSinhVien { get; set; }

        public Transcript(string mssv, List<Result> bangDiem)
        {
            MaSinhVien = mssv;
            this.bangDiem = bangDiem;
        }

        public Transcript() { }
    }
}
