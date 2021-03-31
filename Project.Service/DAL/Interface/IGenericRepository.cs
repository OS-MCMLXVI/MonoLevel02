using System.Collections.Generic;

namespace Project.Service.DAL.Interface
{
      public interface IGenericRepository<TModel> where TModel : class
      {
            IEnumerable<TModel> GetAll();             // List (Index)
            TModel GetById(int idToFind);                // Detail
            void Insert(TModel objToInsert);             // Create
            void Update(TModel objToUpdate);       // Edit
            void Delete(int idToDelete);                    // Delete
      }
}