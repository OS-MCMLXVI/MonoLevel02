using System.Collections.Generic;

namespace Project.Service.DAL.Interface
{
      public interface IGenericRepository<TModel> where TModel : class
      {
            IEnumerable<TModel> GetAll();             // List (Index)
            TModel GetById(int id);                           // Detail
            void Insert(TModel obj);                          // Create
            void Update(TModel obj);                       // Edit
            void Delete(int id);                                  // Delete
      }
}