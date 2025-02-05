using System.Collections.Generic;
using System.Threading.Tasks;

namespace University.BL.Repositories
{
    public interface IGenericRepository<TEntity> where TEntity : class //"IGenericRepository" es el nombre de la interfaz------ <TEntity> es un objeto que puede tomar cualquier identidad, es decir puese ser un curso, estudiante o cualquiera de las tablas o clases.
    {
        //estos son metodos implementados como son "Task" quiere decir que son metodos asincronos
        Task<IEnumerable<TEntity>> GetAll();//Esta linea es una tarea asincrona que devuelve una lista <IEnumerable de un objeto que se quiere consultar <TEntity y se va a llamar GetAll()
        Task<TEntity> GetById(int id);// Metodo que se llama GetByI que recibe un entreo y devuelve la entidad (int id)
        Task<TEntity> Insert(TEntity entity); // Estos dos metodos reciben un objeto que es el que quieren percistir en la base de datos y devuelve el mismo objeto 
        Task<TEntity> Update(TEntity entity);
        Task Delete(int id);//El delete no devuelva nada y recibe un parametro
    }
}
// Esta interfaz  lo que hace es decir que quien implemente esa intefaz tiene que almenos tener los metodos anterioes, con los mismos nombres, parametros y demas.