using System.Collections.Generic;


namespace Webshop.Api.Service
{
    public interface IEntityService<T1, T2> where T1 : class
    {
        IEnumerable<T1> GetAll();

        T1 GetById(T2 id);

        T1 Save(T1 entity);

        void DeleteById(T2 id);

        T1 Edit(T1 entity);
    }
}
