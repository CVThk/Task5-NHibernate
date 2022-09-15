using StudentManagerment.Core.Interfaces.IData;
using StudentManagerment.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace StudentManagerment.Data
{
    public class NHibernateData : IStudentData, ISubjectData, ITranscriptData
    {
        public List<Student> GetStudents()
        {
            List<Student> students;
            using (var session = NHibernateHelper.OpenSession())
            {
                students = session.Query<Student>().ToList();
            }
            return students;
        }

        public List<Subject> GetSubjects()
        {
            List<Subject> subjects;
            using (var session = NHibernateHelper.OpenSession())
            {
                subjects = session.Query<Subject>().ToList();
            }
            return subjects;
        }


        public List<Transcript> GetTranscripts()
        {
            List<Transcript> ds = new List<Transcript>();
            Database database = new Database();
            DataTable data = database.fillData(database.getStringConnection(@"CVTHINH\SQLEXPRESS", "StudentManagerment"), @"SELECT * FROM bangDiem");
            foreach (DataRow row in data.Rows)
            {
                string mssv = row["MaSinhVien"].ToString().Trim();
                string maMH = row["MAMONHOC"].ToString().Trim();
                string tenMH = row["TENMONHOC"].ToString().Trim();
                int soTiet = int.Parse(row["SoTiet"].ToString());
                bool kt;
                double _diemQT, _diemTP;
                double? diemQuaTrinh, diemThanhPhan;
                kt = double.TryParse(row["DiemQuaTrinh"].ToString(), out _diemQT);
                if (kt)
                    diemQuaTrinh = _diemQT;
                else diemQuaTrinh = null;
                kt = double.TryParse(row["DiemThanhPhan"].ToString(), out _diemTP);
                if (kt)
                    diemThanhPhan = _diemTP;
                else diemThanhPhan = null;
                double tyLeQuaTrinh = double.Parse(row["TYLEQUATRINH"].ToString());
                double tyLeThanhPhan = double.Parse(row["TYLETHANHPHAN"].ToString());
                Transcript tam = ds.Find(t => t.MaSinhVien == mssv);
                if (tam != null) // nếu bảng điểm đã tồn tại thì chỉ cần add Result của môn học vào bảng điểm
                {
                    tam.bangDiem.Add(new Result(new Subject(maMH, tenMH, soTiet, tyLeQuaTrinh, tyLeThanhPhan), new Scores(diemQuaTrinh, diemThanhPhan)));
                }
                else
                {
                    List<Result> ketQuaMonHoc = new List<Result>();
                    ketQuaMonHoc.Add(new Result(new Subject(maMH, tenMH, soTiet, tyLeQuaTrinh, tyLeThanhPhan), new Scores(diemQuaTrinh, diemThanhPhan)));
                    ds.Add(new Transcript(mssv, ketQuaMonHoc));
                }
            }
            return ds;
        }
    }
}
