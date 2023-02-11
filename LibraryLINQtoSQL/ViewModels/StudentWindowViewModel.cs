using LibraryLINQtoSQL.Abstractions;
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
    public class StudentWindowViewModel:BaseViewModel
    {
        

        public RelayCommand ShowAllCommand { get; set; }

        public StudentWindowViewModel()
        {
            

            ShowAllCommand = new RelayCommand(s =>
            {
                var allBooks = new ShowAllBooksWindow();
                var allBooksViewModel = new ShowAllBooksViewModel();
                allBooks.DataContext= allBooksViewModel;
                App.ChangePage(allBooks);
            });
        }



    }
}
