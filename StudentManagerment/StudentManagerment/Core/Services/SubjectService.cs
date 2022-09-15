using StudentManagerment.Core.Interfaces.IData;
using StudentManagerment.Core.Interfaces.IServices;
using StudentManagerment.Data;
using StudentManagerment.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentManagerment.Core.Services
{
    public class SubjectService : ISubjectService
    {
        ISubjectData _data;
        public SubjectService(ISubjectData data)
        {
            this._data = data;
        }

        public Subject create()
        {
            return new Subject();
        }
        public void detete(List<Subject> list, string code)
        {
            foreach(Subject subject in list)
            {
                if(subject.MaMonHoc == code)
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
                    list.Remove(subject);
                    new Database().deleteSubject(code);
                    return;
                }    
            }
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\tKhông tìm thấy môn học trong danh sách hiện tại!");
            Console.ResetColor();
        }

        public List<Subject> getAll() => _data.GetSubjects();

        public Subject search(List<Subject> list, string code)
        {
            return list.Find(x => x.MaMonHoc == code);
        }

        public void showInfo(Subject subject)
        {
            Console.WriteLine("\t{0,-15}{1,-50}{2,-10}", subject.MaMonHoc, subject.TenMonHoc, subject.SoTiet.ToString());
        }

        public void update(List<Subject> list, string objUpdate, Subject infoUpdate)
        {
            foreach (Subject subject in list)
            {
                if (subject.MaMonHoc == objUpdate)
                {
                    subject.TenMonHoc = infoUpdate.TenMonHoc;
                    subject.SoTiet = infoUpdate.SoTiet;
                    subject.TyLeQuaTrinh = infoUpdate.TyLeQuaTrinh;
                    subject.TyLeThanhPhan = infoUpdate.TyLeThanhPhan;
                    new Database().updateSubject(subject);
                    return;
                }
            }
        }
    }
}
