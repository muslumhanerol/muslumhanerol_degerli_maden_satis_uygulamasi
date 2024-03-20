using DegerliMadenSatis.Data.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DegerliMadenSatis.Data.Concrete
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> //Igeneric a ait özellikleri implament ederek alta yazdırdık.
        where TEntity : class
    {
        private readonly DbContext _dbContext;
        public GenericRepository(DbContext dbContext) //Dışarıdan buraya DbContext tipinde bilgi geldi. Dışarıdan gelen dbContexti _dbContextin içine koyuyoruz.
        {
            _dbContext = dbContext;
        }
        public void Create(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public List<TEntity> GetAll()
        {
            throw new NotImplementedException();
        }

        public TEntity GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void HardDelete(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public void SoftDelete(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public void Update(TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
