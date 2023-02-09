using LibraryLINQtoSQL.Commands;
using LibraryLINQtoSQL.DataAccess;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryLINQtoSQL.ViewModels
{
    public class ShowAllBooksViewModel:BaseViewModel
    {
        public RelayCommand BackCommand { get; set; }

        private ObservableCollection<Book> books;

        public ObservableCollection<Book> Books
        {
            get { return books; }
            set { books = value; OnPropertyChanged(); }
        }

        public ShowAllBooksViewModel()
        {
            
        }
    }
}
