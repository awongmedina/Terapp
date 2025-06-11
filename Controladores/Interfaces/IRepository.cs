using System;
using System.Collections.Generic;
using System.Linq.Expressions;


namespace Terapp.UI.Controladores
{
    public interface IRepository<T> where T : class
    {
        /// <summary>
        /// Este metodo AGREGA a la base de datos la entidad que recibe
        /// </summary>
        /// <param name="T">La entidad que recibe</param>
        void Agregar(T entity);

        /// <summary>
        /// Este metodo ACTUALIZA en la base de datos la informacion en la entidad proporcionada
        /// </summary>
        /// <param name="T">La entidad que recibe</param>
        void Actualizar(T entity);

        /// <summary>
        /// Este metodo ELIMINA de la base de datos la entidad proporcionada
        /// </summary>
        /// <param name="T">El nombre del paciente</param>
        void Eliminar(T entity);

        /// <summary>
        /// Este metodo obtiene una lista de las entidades
        /// </summary>
        /// <param name="T">El nombre del paciente</param>
        /// <returns>Todas las entidades de la base de datos</returns>
        IEnumerable<T> ObtenerTodos();

        /// <summary>
        /// Este metodo obtiene una entidad basado en el ID
        /// </summary>
        /// <param name="T">El ID de la entidad</param>
        /// <returns>La entidad encontrada</returns>
        T ObtenerPorID(int id);

        /// <summary>
        /// Este metodo obtiene la entidad basado en el nombre proporcionado
        /// </summary>
        /// <param name="nombre">El nombre registrado en la entidad</param>
        /// <returns>El entidad encontrada</returns>
        T ObtenerPorNombre(string nombre);

        T ObtenerPorCondicion(Expression<Func<T, bool>> filtro);

        IEnumerable<T> ObtenerTodosPorCondicion(Expression<Func<T, bool>> filtro);

        

    }
}
