using StudentManagerment.Core.Interfaces.IData;
using StudentManagerment.Core.Interfaces.IServices;
using StudentManagerment.Data;
using StudentManagerment.Models;
using StudentManagerment.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentManagerment.Core.Services
{
    public class TranscriptService : ITranscriptService
    {
        ITranscriptData _data;
        public TranscriptService(ITranscriptData data)
        {
            this._data = data;
        }

        public Transcript create()
        {
            return new Transcript();
        }

        public void detete(List<Transcript> list, string code) // xóa điểm của môn học
        {
            foreach (Transcript transcript in list)
            {
               foreach(Result result in transcript.bangDiem)
                {
                    if(result.MonHoc.MaMonHoc == code)
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
                        result.DiemMonHoc.DiemQuaTrinh = null;
                        result.DiemMonHoc.DiemThanhPhan = null;
                        new Database().deleteScoresOfSubject(result.MonHoc.MaMonHoc);
                        return;
                    }    
                }    
            }
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\tKhông tìm thấy bảng điểm trong danh sách hiện tại!");
            Console.ResetColor();
        }

        public List<Transcript> getAll() => _data.GetTranscripts();

        public Transcript search(List<Transcript> list, string code)
        {
            return list.Find(x => x.MaSinhVien == code);
        }

        public void showInfo(Student student, Transcript transcript, IStudentService studentService)
        {
            studentService.showInfo(student);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n\t[>]BẢNG ĐIỂM");
            Console.ResetColor();
            Title title = new Title();
            title.showTitleTranscript();

            foreach (Result result in transcript.bangDiem)
            {
                string diemQuaTrinh = (result.DiemMonHoc.DiemQuaTrinh == null) ? "" : result.DiemMonHoc.DiemQuaTrinh.ToString();
                string diemThanhPhan = (result.DiemMonHoc.DiemThanhPhan == null) ? "" : result.DiemMonHoc.DiemThanhPhan.ToString();
                Console.WriteLine("\t{0,-15}{1,-50}{2,-10}{3,-20}{4,-20}", result.MonHoc.MaMonHoc, result.MonHoc.TenMonHoc, result.MonHoc.SoTiet, diemQuaTrinh, diemThanhPhan);
            }
        }
        public void showResult(Transcript transcript)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n\t[>]BẢNG ĐIỂM");
            Console.ResetColor();
            new Title().showTitleTranscript();
            foreach (Result result in transcript.bangDiem)
            {
                string kq = result.DiemMonHoc.DiemQuaTrinh * result.MonHoc.TyLeQuaTrinh + result.DiemMonHoc.DiemThanhPhan * result.MonHoc.TyLeThanhPhan >= 4 ? "Đỗ" : "Trượt";
                string diemQuaTrinh = (result.DiemMonHoc.DiemQuaTrinh == null) ? "" : result.DiemMonHoc.DiemQuaTrinh.ToString();
                string diemThanhPhan = (result.DiemMonHoc.DiemThanhPhan == null) ? "" : result.DiemMonHoc.DiemThanhPhan.ToString();
                Console.WriteLine("\t{0,-15}{1,-50}{2,-10}{3,-20}{4,-20}{5,-10}", result.MonHoc.MaMonHoc, result.MonHoc.TenMonHoc, result.MonHoc.SoTiet, diemQuaTrinh, diemThanhPhan, kq);
            }
        }

        public void update(List<Transcript> list, string objUpdate, Transcript infoUpdate)
        {
            throw new NotImplementedException();
        }

        public void upScores(string maMonHoc, Transcript transcript)
        {
            foreach (Result result in transcript.bangDiem)
            {
                if (result.MonHoc.MaMonHoc == maMonHoc.ToUpper())
                {
                    double diemQuaTrinh, diemThanhPhan;
                    bool kt;
                    do
                    {
                        Console.Write("\tNhập điểm quá trình: ");
                        kt = double.TryParse(Console.ReadLine(), out diemQuaTrinh);
                    } while (kt == false || diemQuaTrinh < 0 || diemQuaTrinh > 10);
                    do
                    {
                        Console.Write("\tNhập điểm thành phần: ");
                        kt = double.TryParse(Console.ReadLine(), out diemThanhPhan);
                    } while (kt == false || diemThanhPhan < 0 || diemThanhPhan > 10);
                    result.DiemMonHoc.DiemQuaTrinh = diemQuaTrinh;
                    result.DiemMonHoc.DiemThanhPhan = diemThanhPhan;
                    // update database
                    new Database().updateTranscript(result, transcript.MaSinhVien);
                    return;
                }
            }
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\tKhông tìm thấy môn học trong danh sách hiện tại!");
            Console.ResetColor();
        }
    }
}
