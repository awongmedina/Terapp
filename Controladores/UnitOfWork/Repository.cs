using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Terapp.UI.Controladores
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly TerapiModel _context;
        private readonly DbSet<T> _dbSet;

        public Repository(TerapiModel context) 
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public void Agregar(T entity ) => _dbSet.Add(entity);

        public void Eliminar(T entity) => _dbSet.Remove(entity);

        public void Actualizar(T entity) => _dbSet.AddOrUpdate(entity);

        public IEnumerable<T> ObtenerTodos() => _dbSet.ToList();

        public T ObtenerPorID(int id) => _dbSet.Find(id);

        public T ObtenerPorNombre(string nombre) => _dbSet.Find(nombre);

        public T ObtenerPorCondicion(Expression<Func<T, bool>> filtro)
        {
            return _dbSet.Where(filtro).FirstOrDefault();
        }

        public IEnumerable<T> ObtenerTodosPorCondicion(Expression<Func<T, bool>> filtro)
        {
            return _dbSet.Where(filtro);
        }
    }
}
