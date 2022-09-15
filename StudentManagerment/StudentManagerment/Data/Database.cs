using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using StudentManagerment.Data;
using StudentManagerment.Models;
using StudentManagerment.Core.Interfaces.IData;

namespace StudentManagerment.Data
{
    public class Database : IStudentData, ISubjectData, ITranscriptData
    {
        public DataTable fillData(string stringSqlConnection, string stringCommand)
        {
            DataTable data = new DataTable();
            using (SqlConnection sqlConnection = new SqlConnection(stringSqlConnection))
            {
                sqlConnection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(stringCommand, sqlConnection);
                adapter.Fill(data);
                sqlConnection.Close();
            }
            return data;
        }


        public string getStringConnection(string serverName, string databaseName, string id, string pass)
        {
            return @"Data Source=" + serverName + ";Initial Catalog=" + databaseName + ";User ID=" + id + ";Password=" + pass;
        }

        public string getStringConnection(string serverName, string databaseName)
        {
            return "Data Source=" + serverName + ";Initial Catalog=" + databaseName + ";Integrated Security=True";
        }
        // xóa sinh viên trên Database
        public void deleteStudent(string code)
        {
            using (SqlConnection sqlConnection = new SqlConnection(getStringConnection(@"CVTHINH\SQLEXPRESS", "StudentManagerment")))
            {
                sqlConnection.Open();
                SqlCommand commandTranscript = new SqlCommand(@"DELETE DIEM WHERE MASINHVIEN = @mssv", sqlConnection);
                commandTranscript.Parameters.Add("@mssv", SqlDbType.Char).Value = code;
                commandTranscript.ExecuteNonQuery();
                SqlCommand command = new SqlCommand(@"DELETE SINHVIEN WHERE MASINHVIEN = @mssv", sqlConnection);
                command.Parameters.Add("@mssv", SqlDbType.Char).Value = code;
                // Thực thi Command (Dùng cho delete, insert, update).
                int rowCount = command.ExecuteNonQuery();
                Console.WriteLine("\t{0} row(s) affected", rowCount);
            }
        }
        // xóa môn học trên Database
        public void deleteSubject(string code)
        {
            using (SqlConnection sqlConnection = new SqlConnection(getStringConnection(@"CVTHINH\SQLEXPRESS", "StudentManagerment")))
            {
                sqlConnection.Open();
                SqlCommand commandTranscript = new SqlCommand(@"DELETE DIEM WHERE MAMONHOC = @mamh", sqlConnection);
                commandTranscript.Parameters.Add("@mamh", SqlDbType.Char).Value = code;
                commandTranscript.ExecuteNonQuery();
                SqlCommand command = new SqlCommand(@"DELETE MONHOC WHERE MAMONHOC = @mamh", sqlConnection);
                command.Parameters.Add("@mamh", SqlDbType.Char).Value = code;
                // Thực thi Command (Dùng cho delete, insert, update).
                int rowCount = command.ExecuteNonQuery();
                Console.WriteLine("\t{0} row(s) affected", rowCount);
            }
        }
        // xóa điểm của môn học trên Database
        public void deleteScoresOfSubject(string code)
        {
            using (SqlConnection sqlConnection = new SqlConnection(getStringConnection(@"CVTHINH\SQLEXPRESS", "StudentManagerment")))
            {
                sqlConnection.Open();
                SqlCommand commandTranscript = new SqlCommand(@"UPDATE DIEM SET DIEMQUATRINH = null, DIEMTHANHPHAN = null WHERE MaMonHoc = @mamh", sqlConnection);
                commandTranscript.Parameters.Add("@mamh", SqlDbType.Char).Value = code;
                // Thực thi Command (Dùng cho delete, insert, update).
                int rowCount = commandTranscript.ExecuteNonQuery();
                Console.WriteLine("\t{0} row(s) affected", rowCount);
            }
        }
        // cập nhật lại điểm trên Database
        public void updateTranscript(Result result, string maSV)
        {
            using (SqlConnection sqlConnection = new SqlConnection(getStringConnection(@"CVTHINH\SQLEXPRESS", "StudentManagerment")))
            {
                sqlConnection.Open();
                SqlCommand command = new SqlCommand(@"UPDATE DIEM SET DIEMQUATRINH = @diemQuaTrinh, DIEMTHANHPHAN = @diemThanhPhan WHERE MaSinhVien = @mssv AND MaMonHoc = @mamh", sqlConnection);
                command.Parameters.Add("@diemQuaTrinh", SqlDbType.Float).Value = result.DiemMonHoc.DiemQuaTrinh;
                command.Parameters.Add("@diemThanhPhan", SqlDbType.Float).Value = result.DiemMonHoc.DiemThanhPhan;
                command.Parameters.Add("@mssv", SqlDbType.Char).Value = maSV;
                command.Parameters.Add("@mamh", SqlDbType.Char).Value = result.MonHoc.MaMonHoc;
                // Thực thi Command (Dùng cho delete, insert, update).
                int rowCount = command.ExecuteNonQuery();
                Console.WriteLine("\t{0} row(s) affected", rowCount);
            }
        }
        public void updateStudent(Student studentUpdate)
        {
            using (SqlConnection sqlConnection = new SqlConnection(getStringConnection(@"CVTHINH\SQLEXPRESS", "StudentManagerment")))
            {
                sqlConnection.Open();
                SqlCommand command = new SqlCommand(@"UPDATE SINHVIEN
                        SET TENSINHVIEN = @tensv,GIOITINH = @gtinh, NGAYSINH = @ngsinh, NGAYVAOTRUONG = @ngayvt, LOP = @lop, KHOA = @khoa, TRANGTHAI = @trangthai,
                        BACDAOTAO = @bacdt, SDT = @sdt, CMND = @cmnd, DIACHITT = @diachi, DANTOC = @dantoc, TONGIAO = @tongiao
                        WHERE MASINHVIEN = @masv", sqlConnection);
                command.Parameters.Add("@tensv", SqlDbType.Char).Value = studentUpdate.TenSinhVien;
                command.Parameters.Add("@gtinh", SqlDbType.Char).Value = studentUpdate.GioiTinh;
                command.Parameters.Add("@ngsinh", SqlDbType.DateTime).Value = studentUpdate.NgaySinh;
                command.Parameters.Add("@ngayvt", SqlDbType.DateTime).Value = studentUpdate.NgayVaoTruong;
                command.Parameters.Add("@lop", SqlDbType.Char).Value = studentUpdate.Lop;
                command.Parameters.Add("@khoa", SqlDbType.Char).Value = studentUpdate.Khoa;
                command.Parameters.Add("@trangthai", SqlDbType.Char).Value = studentUpdate.TrangThai;
                command.Parameters.Add("@bacdt", SqlDbType.Char).Value = studentUpdate.BacDaoTao;
                command.Parameters.Add("@sdt", SqlDbType.Char).Value = studentUpdate.SDT;
                command.Parameters.Add("@cmnd", SqlDbType.Char).Value = studentUpdate.CMND;
                command.Parameters.Add("@diachi", SqlDbType.Char).Value = studentUpdate.DiaChiTT;
                command.Parameters.Add("@dantoc", SqlDbType.Char).Value = studentUpdate.DanToc;
                command.Parameters.Add("@tongiao", SqlDbType.Char).Value = studentUpdate.TonGiao;
                command.Parameters.Add("@masv", SqlDbType.Char).Value = studentUpdate.MaSinhVien;
                // Thực thi Command (Dùng cho delete, insert, update).
                int rowCount = command.ExecuteNonQuery();
                Console.WriteLine("\t{0} row(s) affected", rowCount);
            }
        }
        public void updateSubject(Subject subjectUpdate)
        {
            using (SqlConnection sqlConnection = new SqlConnection(getStringConnection(@"CVTHINH\SQLEXPRESS", "StudentManagerment")))
            {
                sqlConnection.Open();
                SqlCommand command = new SqlCommand(@"UPDATE MONHOC
                        SET TENMONHOC = @tenmh, SOTIET = @sotiet, TYLEQUATRINH = @tlqt, TYLETHANHPHAN = @tltp
                        WHERE MAMONHOC = @mamh", sqlConnection);
                command.Parameters.Add("@tenmh", SqlDbType.Char).Value = subjectUpdate.TenMonHoc;
                command.Parameters.Add("@sotiet", SqlDbType.Int).Value = subjectUpdate.SoTiet;
                command.Parameters.Add("@tlqt", SqlDbType.Float).Value = subjectUpdate.TyLeQuaTrinh;
                command.Parameters.Add("@tltp", SqlDbType.Float).Value = subjectUpdate.TyLeThanhPhan;
                command.Parameters.Add("@mamh", SqlDbType.Char).Value = subjectUpdate.MaMonHoc;
                // Thực thi Command (Dùng cho delete, insert, update).
                int rowCount = command.ExecuteNonQuery();
                Console.WriteLine("\t{0} row(s) affected", rowCount);
            }
        }

        public List<Student> GetStudents()
        {
            List<Student> ds = new List<Student>();
            DataTable data = fillData(getStringConnection(@"CVTHINH\SQLEXPRESS", "StudentManagerment"), @"SELECT * FROM SINHVIEN");
            foreach (DataRow row in data.Rows)
            {
                string mssv = row["MaSinhVien"].ToString().Trim();
                string ten = row["TenSinhVien"].ToString().Trim();
                string gt = row["gioitinh"].ToString().Trim();
                DateTime ns = DateTime.ParseExact(((DateTime)row["NgaySinh"]).ToShortDateString(), "dd/MM/yyyy", null);
                DateTime nvt = DateTime.ParseExact(((DateTime)row["NgayVaoTruong"]).ToShortDateString(), "dd/MM/yyyy", null);
                string lop = row["Lop"].ToString().Trim();
                string khoa = row["Khoa"].ToString().Trim();
                string trangthai = row["TrangThai"].ToString().Trim();
                string bacdaotao = row["BacDaoTao"].ToString().Trim();
                string sdt = row["SDT"].ToString().Trim();
                string cmnd = row["CMND"].ToString().Trim();
                string diachithuongtru = row["DiaChiTT"].ToString().Trim();
                string dantoc = row["DanToc"].ToString().Trim();
                string tongiao = row["TONGIAO"].ToString().Trim();
                ds.Add(new Student(mssv, ten, gt, lop, ns, nvt, khoa, trangthai, bacdaotao, sdt, cmnd, diachithuongtru, dantoc, tongiao));
            }
            return ds;
        }

        public List<Subject> GetSubjects()
        {
            List<Subject> ds = new List<Subject>();
            DataTable data = fillData(getStringConnection(@"CVTHINH\SQLEXPRESS", "StudentManagerment"), @"SELECT * FROM MONHOC");
            foreach (DataRow row in data.Rows)
            {
                string maMH = row["MAMONHOC"].ToString().Trim();
                string tenMH = row["TENMONHOC"].ToString().Trim();
                int soTiet = int.Parse(row["SoTiet"].ToString());
                double tlQT = double.Parse(row["TyLeQuaTrinh"].ToString());
                double tlTP = double.Parse(row["TyLeThanhPhan"].ToString());
                ds.Add(new Subject(maMH, tenMH, soTiet, tlQT, tlTP));
            }
            return ds;
        }

        public List<Transcript> GetTranscripts()
        {
            List<Transcript> ds = new List<Transcript>();
            DataTable data = fillData(getStringConnection(@"CVTHINH\SQLEXPRESS", "StudentManagerment"), @"SELECT * FROM bangDiem");
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
