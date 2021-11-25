using System.Collections.Generic;

namespace Series_registration.Interfaces
{
    public interface IRepository<T>
    {
        List<T> list();
        T getBy(string input, int by);
        void add(T entity);
        void delete(int id);
        void update(int id, T entity);
        int nextId();
    }
}