using LibraryLINQtoSQL.Commands;
using LibraryLINQtoSQL.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryLINQtoSQL.ViewModels
{
    public class LibrarianWindowViewModel
    {
        public RelayCommand AddNewBookCommand { get; set; }
        public RelayCommand DeleteBookCommand { get; set; }
        public RelayCommand ShowAllBooksCommand { get; set; }
        public RelayCommand UpdateBookCommand { get; set; }

        public LibrarianWindowViewModel() 
        {
            AddNewBookCommand = new RelayCommand((s) =>
            {
                var addBook = new AddBookWindow();
                var addBookViewModel=new AddBookViewModel();
                addBook.DataContext= addBookViewModel;
                App.ChangePage(addBook);
                
            });

            DeleteBookCommand = new RelayCommand((s) =>
            {
                var deleteBook = new DeleteBook();
                var deleteBookViewModel=new DeleteBookViewModel();
                deleteBook.DataContext= deleteBookViewModel;
                App.ChangePage(deleteBook);
            });

            ShowAllBooksCommand = new RelayCommand((s) =>
            {
                var allBooks=new ShowAllBooksWindow();
                var allBooksViewModel=new ShowAllBooksViewModel();
                allBooks.DataContext= allBooksViewModel;
                App.ChangePage(allBooks);
            });

            UpdateBookCommand = new RelayCommand((s) =>
            {
                var updateBook = new UpdateBook();
                var updateBookViewModel=new UpdateBookViewModel();
                updateBook.DataContext= updateBookViewModel;
                App.ChangePage(updateBook);
            });


        }
    }
}
