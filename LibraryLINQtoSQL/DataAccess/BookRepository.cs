using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryLINQtoSQL.DataAccess
{
    public class BookRepository
    {
        private LibraryDbDataContext _dbDataContext;

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

        public ObservableCollection<Book> GetAllData()
        {
            var books = from b in _dbDataContext.Books
                        select b;
            return new ObservableCollection<Book>(books);
        }

        public void UpdateData(Book data)
        {
            var item = _dbDataContext.Books.SingleOrDefault(b => b.Id == data.Id);

            item = new Book
            {
                Id= data.Id,
                Name= data.Name,
                Pages= data.Pages,
                Quantity= data.Quantity,
                Id_Themes= data.Id_Themes,
                Id_Category= data.Id_Category,
                Id_Author= data.Id_Author,
                YearPress= data.YearPress,
                Comment= data.Comment,
                Id_Press= data.Id_Press,
            };

            data = item;

            _dbDataContext.SubmitChanges();
        }

    }
}
