using System.Collections.Generic;

namespace MailSender.lib.Services
{
    public interface IDataService<T>
    {
        /// <summary>Извлечь все</summary>
        IEnumerable<T> GetAll();

        /// <summary>Извлечь по Id</summary>
        T GetById(int id);

        /// <summary>Обновить</summary>
        void Update(T item);

        /// <summary>Создать</summary>
        void Create(T item);

        /// <summary>Удалить</summary>
        void Delete(T item);
    }
}
