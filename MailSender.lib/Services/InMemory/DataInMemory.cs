using MailSender.lib.Data.BaseEntityes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MailSender.lib.Services.InMemory
{
    public abstract class DataInMemory<T> : IDataService<T> where T : Entity
    {
        protected readonly List<T> _Items = new List<T>();


        public void Create(T item)
        {
            if (_Items.Any(i => i.Id == item.Id)) return;
            item.Id = _Items.Count == 0 ? 1 : _Items.Max(i => i.Id) + 1;
            _Items.Add(item);
        }

        public void Delete(T item)
        {
            _Items.Remove(item);
        }

        public IEnumerable<T> GetAll() => _Items;

        public T GetById(int id)
        {
            if (id <= 0) throw new ArgumentOutOfRangeException(nameof(id), id, "Значение id должно быть больше нуля");
            return _Items.FirstOrDefault(item => item.Id == id);
        }

        public abstract void Update(T item);
    }
}
