using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DegerliMadenSatis.Data.Abstract
{
    public interface IGenericRepository<TEntity> //Veri tabanı işlemlerini bu kısımda barındırılır. (CRUD)
    {
        List<TEntity> GetAll();//Dışarıdan category produck gelecek, burada crud işlemleri gerçekleşecek.
        TEntity GetById(int id);
        void Create(TEntity entity); 
        void Update(TEntity entity);
        void HardDelete(TEntity entity);
        void SoftDelete(TEntity entity);

    }
}
