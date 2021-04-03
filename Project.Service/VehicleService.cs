using Project.Service.DAL;
using Project.Service.DAL.Interface;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Project.Service
{
      public class VehicleService<TModel> : IGenericRepository<TModel> where TModel : class
      {
            private VehicleContext _context;
            private DbSet<TModel> _table;


            #region Constructor

            public VehicleService(VehicleContext context)
            {
                  this._context = context;
                  this._table = _context.Set<TModel>();
            }

            public VehicleService()
            {
                  this._context = new VehicleContext();
                  this._table = _context.Set<TModel>();
            }

            #endregion


            #region CRUD

            // List
            public IEnumerable<TModel> GetAll()
            {
                  return _table.ToList();
            }

            // Detail
            public TModel GetById(int idToFind)
            {
                  return _table.Find(idToFind);
            }

            // Create
            public void Insert(TModel objToInsert)
            {
                  _table.Add(objToInsert);
            }

            // Edit
            public void Update(TModel objToEdit)
            {
                  _table.Attach(objToEdit);
                  _context.Entry(objToEdit).State = EntityState.Modified;
            }

            // Delete
            public void Delete(int idToDelete)
            {
                  TModel objToDelete = _table.Find(idToDelete);
                  _table.Remove(objToDelete);
            }

            #endregion

            
            #region Disp...

            // Disp...
            private bool disposed = false;

            protected virtual void Dispose(bool disposing)
            {
                  if (!this.disposed)
                        if (disposing)
                              _context.Dispose();

                  this.disposed = true;
            }

            public void Dispose()
            {
                  Dispose(true);
                  GC.SuppressFinalize(this);
            }

            #endregion

      }
}