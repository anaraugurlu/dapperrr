using dapperrr.Mapping;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dapperrr.Domain.Abstractions
{
    public interface IRepository<T>
    {
        T GetData(int book);
        void CallSp();
        List<Book> GetAllData();
        void AddData(Book book);
        void UpdateData(T data);
        void DeleteData(int id);

    }
}
