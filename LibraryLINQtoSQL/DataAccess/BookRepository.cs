using LibraryLINQtoSQL.Abstractions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryLINQtoSQL.DataAccess
{
    public class BookRepository : IRepository<Book>
    {
        private readonly LibraryDbDataContext _dbDataContext;

        public BookRepository()
        {
            _dbDataContext= new LibraryDbDataContext();
        }
        public void AddData(Book data)
        {
            _dbDataContext.Books.InsertOnSubmit(data);
            _dbDataContext.SubmitChanges();
        }

        public void DeleteData(Book data)
        {
            _dbDataContext.Books.DeleteOnSubmit(data);
            _dbDataContext.SubmitChanges();
        }

        public void DeleteBookById(int bookId)
        {
            _dbDataContext.Books.DeleteOnSubmit(_dbDataContext.Books.FirstOrDefault(b => b.Id == bookId));
            var scards = from s in _dbDataContext.S_Cards
                         where s.Id_Book == bookId
                         select s;
            _dbDataContext.S_Cards.DeleteAllOnSubmit<S_Card>(scards);

            var tcards = from t in _dbDataContext.T_Cards
                         where t.Id_Book == bookId
                         select t;
            _dbDataContext.T_Cards.DeleteAllOnSubmit<T_Card>(tcards);

            _dbDataContext.SubmitChanges();
        }

        public ObservableCollection<Book> GetAllData()
        {
            var books=from b in _dbDataContext.Books
                      select b;

            return new ObservableCollection<Book>(books);
        }

        public Book GetData(int id)
        {
           return _dbDataContext.Books.SingleOrDefault(b => b.Id == id);
        }



        public void UpdateData(Book data)
        {
            var item=_dbDataContext.Books.SingleOrDefault(b=>b.Id == data.Id);

            item = new Book
            {
                Author= data.Author,
                Category=data.Category,
                Comment=data.Comment,
                Id_Press=data.Id_Press,
                Id_Author=data.Id_Author,
                Id_Category=data.Id_Category,
                Name=data.Name,
                Pages=data.Pages,
                Press=data.Press,
                Id_Themes=data.Id_Themes,
                Quantity=data.Quantity,
                S_Cards=data.S_Cards,
                T_Cards=data.T_Cards,
                Theme=data.Theme,
                YearPress=data.YearPress,
            };
            _dbDataContext.SubmitChanges();

        }
    }
}
