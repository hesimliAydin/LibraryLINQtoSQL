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
        private readonly IRepository<Book> bookRepo;

        private ObservableCollection<Book> allBooks;

        public ObservableCollection<Book> AllBooks
        {
            get { return allBooks; }
            set { allBooks = value; OnPropertyChanged();  }
        }

        public RelayCommand ShowAllCommand { get; set; }

        public StudentWindowViewModel(IRepository<Book> repository)
        {
            bookRepo= repository;

            ShowAllCommand = new RelayCommand(s =>
            {
                repository= bookRepo.GetAllData();
                var show = new ShowAllBooksWindow();
                show.Show();
            });
        }



    }
}
