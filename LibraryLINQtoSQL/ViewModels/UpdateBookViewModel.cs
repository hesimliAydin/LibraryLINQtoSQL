using LibraryLINQtoSQL.Commands;
using LibraryLINQtoSQL.DataAccess;
using LibraryLINQtoSQL.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryLINQtoSQL.ViewModels
{
    public class UpdateBookViewModel:BaseViewModel
    {
        
        public RelayCommand BackCommand { get; set; }

        private Book selectedBook;

        public Book SelectedBook
        {
            get { return selectedBook; }
            set
            {
                selectedBook = value;
                OnPropertyChanged();
                SelectionChanged();
            }
        }

        private ObservableCollection<Book> books;

        public ObservableCollection<Book> Books
        {
            get { return books; }
            set { books = value; OnPropertyChanged(); }
        }

        public void SelectionChanged()
        {

            var editBook = new EditBook();
            var editBookViewModel = new EditBookViewModel(SelectedBook);
            editBook.DataContext = editBookViewModel;
            App.ChangePage(editBook);
        }

        
        public UpdateBookViewModel()
        {
            var book = new BookRepository();
            Books = new ObservableCollection<Book>(book.GetAllData());

            BackCommand = new RelayCommand((a) =>
            {
                App.ExecuteBackCommand();
            });
        }
    }
}
