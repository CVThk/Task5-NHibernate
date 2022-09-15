using System;
using System.Collections.Generic;
using System.Text;

namespace StudentManagerment.Core.Interfaces.IServices
{
    public interface IBasicService<T>
    {
        List<T> getAll();
        T create();
        void update(List<T> list, string objUpdate, T infoUpdate);
        void detete(List<T> list, string code);
        T search(List<T> list, string code);
    }
}
