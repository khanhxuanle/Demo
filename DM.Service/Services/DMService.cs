using DM.Data;
using DM.Service.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DM.Service.Services
{
    public class DMService : IDMService
    {
        private readonly DMContext _dmContext;

        public DMService(DMContext dmContext)
        {
            this._dmContext = dmContext;
        }
        public string HellWord()
        {
            return "Hello Word";
        }

        public void InsertClass(Class classObject)
        {
            _dmContext.Classes.Add(classObject);
            _dmContext.SaveChanges();
        }

        public List<Class> getAllClass()
        {
            var listClass = _dmContext.Classes.ToList();
            return listClass;
        }

        public Class getClassById(int IdClass)
        {
            var classObjectById = _dmContext.Classes.FirstOrDefault(m => m.Id == IdClass);
            return classObjectById;
        }

        public void EditClass(Class classObject)
        {
            var classEditObject = _dmContext.Classes.FirstOrDefault(m => m.Id == classObject.Id);

            if(classEditObject != null)
            {
                classEditObject.ClassName = classObject.ClassName;
                classEditObject.ClassDescription = classObject.ClassDescription;
            }

            _dmContext.Entry(classEditObject).State = System.Data.Entity.EntityState.Modified;

            _dmContext.SaveChanges();
        }

        public void DeleteClass(int IdClass)
        {
            var classDeleteObject = _dmContext.Classes.FirstOrDefault(m => m.Id == IdClass);

            _dmContext.Entry(classDeleteObject).State = System.Data.Entity.EntityState.Deleted;

            _dmContext.SaveChanges();
            
        }
    }
}
