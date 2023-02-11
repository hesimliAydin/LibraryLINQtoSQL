using LibraryLINQtoSQL.Abstractions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryLINQtoSQL.DataAccess
{
    public class AuthorRepositories : IRepository<Author>
    {
        private readonly  LibraryDbDataContext _dbDataContext;

        public AuthorRepositories()
        {
            _dbDataContext= new LibraryDbDataContext();
        }

        public void AddData(Author data)
        {
            _dbDataContext.Authors.InsertOnSubmit(data);
            _dbDataContext.SubmitChanges();
        }

        public void DeleteData(Author data)
        {
            _dbDataContext.Authors.DeleteOnSubmit(data);
            _dbDataContext.SubmitChanges();
        }

        public ObservableCollection<Author> GetAllData()
        {
            var authors = from a in _dbDataContext.Authors
                          select a;

            return new ObservableCollection<Author>(authors);
        }

        public Author GetData(int id)
        {
            return _dbDataContext.Authors.SingleOrDefault(a => a.Id == id);
        }

        public void UpdateData(Author data)
        {
            var item=_dbDataContext.Authors.SingleOrDefault(a=>a.Id== data.Id);
            item = new Author
            {
                FirstName= data.FirstName,
                LastName= data.LastName
            };

            _dbDataContext.SubmitChanges();
        }
    }
}
