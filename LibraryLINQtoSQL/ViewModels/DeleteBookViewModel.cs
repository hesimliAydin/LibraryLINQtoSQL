using LibraryLINQtoSQL.Commands;
using LibraryLINQtoSQL.DataAccess;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace LibraryLINQtoSQL.ViewModels
{
    public class DeleteBookViewModel:BaseViewModel
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
            var result = MessageBox.Show($"Are you sure you want to delete the book - {SelectedBook.Name}?", "Delete Book", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                var book = new BookRepository();
                book.DeleteBookById(SelectedBook.Id);
                Books.Remove(SelectedBook);
                MessageBox.Show("Book was deleted successfully");
            }
        }

        public DeleteBookViewModel()
        {
            var book = new BookRepository();
            Books = new ObservableCollection<Book>(book.GetAllData());

            BackCommand = new RelayCommand((b) =>
            {
                App.ExecuteBackCommand();
            });
        }
    }
}
