using DM.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DM.Service.IServices
{
    public interface IDMService
    {
        string HellWord();

        void InsertClass(Class classObject);

        List<Class> getAllClass();

        Class getClassById(int IdClass);

        void EditClass(Class classObject);

        void DeleteClass(int IdClass);

    }
}
