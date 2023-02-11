using LibraryLINQtoSQL.Abstractions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryLINQtoSQL.DataAccess
{
    public class CategoriesRepositories : IRepository<Category>
    {
        private readonly LibraryDbDataContext _dbDataContext;

        public CategoriesRepositories()
        {
            _dbDataContext= new LibraryDbDataContext();
        }
        public void AddData(Category data)
        {
           _dbDataContext.Categories.InsertOnSubmit(data);
            _dbDataContext.SubmitChanges();
        }

        public void DeleteData(Category data)
        {
            _dbDataContext.Categories.DeleteOnSubmit(data);
            _dbDataContext.SubmitChanges();
        }

        public ObservableCollection<Category> GetAllData()
        {
            var category = from c in _dbDataContext.Categories
                           select c;

            return new ObservableCollection<Category>(category);
        }

        public Category GetData(int id)
        {
           return _dbDataContext.Categories.SingleOrDefault(c => c.Id == id);
        }

        public void UpdateData(Category data)
        {
            var item=_dbDataContext.Categories.SingleOrDefault(c => c.Id == data.Id);

            item = new Category
            {
                Name = data.Name
            };
            _dbDataContext.SubmitChanges();
        }
    }
}
