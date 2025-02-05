using System.Collections.Generic;
using System.Threading.Tasks;
using University.BL.Repositories;

namespace University.BL.Services.Implements
{
    public class GenericService<TEntity> : IGenericService<TEntity> where TEntity : class
    {
        private IGenericRepository<TEntity> genericRepository;//Lo que hace la capa de servicios es solamente acceder al repositorio.

        public GenericService(IGenericRepository<TEntity> genericRepository) //llama a los diferentes metodos del repositorio por medio de controlador
                    {
            this.genericRepository = genericRepository;
        }

        public async Task Delete(int id)
        {
            await genericRepository.Delete(id);
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await genericRepository.GetAll();
        }

        public async Task<TEntity> GetById(int id)
        {
            return await genericRepository.GetById(id);
        }

        public async Task<TEntity> Insert(TEntity entity)
        {
            return await genericRepository.Insert(entity);
        }

        public async Task<TEntity> Update(TEntity entity)
        {
            return await genericRepository.Update(entity);
        }
    }
}
