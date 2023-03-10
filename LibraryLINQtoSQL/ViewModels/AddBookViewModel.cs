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
using System.Windows;
using System.Windows.Controls;

namespace LibraryLINQtoSQL.ViewModels
{
    public class AddBookViewModel : BaseViewModel
    {
        public RelayCommand BackCommand { get; set; }
        public RelayCommand AddBookCommand { get; set; }

        private ObservableCollection<Author> authors;

        public ObservableCollection<Author> Authors
        {
            get { return authors; }
            set { authors = value; OnPropertyChanged(); }
        }

        private ObservableCollection<Theme> themes;

        public ObservableCollection<Theme> Themes
        {
            get { return themes; }
            set { themes = value; OnPropertyChanged(); }
        }

        private ObservableCollection<Category> categories;

        public ObservableCollection<Category> Categories
        {
            get { return categories; }
            set { categories = value; OnPropertyChanged(); }
        }

        private ObservableCollection<Press> presses;

        public ObservableCollection<Press> Presses
        {
            get { return presses; }
            set { presses = value; OnPropertyChanged(); }
        }

        public string BookName { get; set; }
        public string Pages { get; set; }
        public string YearPress { get; set; }
        public string Comment { get; set; }
        public string Quantity { get; set; }
        public int AuthorIndex { get; set; }
        public int ThemeIndex { get; set; }
        public int CategoryIndex { get; set; }
        public int PressIndex { get; set; }

        public AddBookViewModel()
        {
            var author=new AuthorRepositories();
            Authors = author.GetAllData();
            var theme=new ThemeRepositories();
            Themes = theme.GetAllData();
            var categorie=new CategoriesRepositories();
            Categories = categorie.GetAllData();
            var press=new PressRepositories();
            Presses = press.GetAllData();

            BackCommand = new RelayCommand((b) =>
            {
                App.ExecuteBackCommand();
            });



            AddBookCommand = new RelayCommand((b) =>
            {
                if (AuthorIndex == -1 || ThemeIndex == -1 || CategoryIndex == -1 || PressIndex == -1
                 || BookName.Trim() == String.Empty || Pages.Trim() == string.Empty || YearPress.Trim() == string.Empty
                 || Comment.Trim() == String.Empty | Quantity.Trim() == string.Empty)
                {
                    MessageBox.Show("Please, fill form completely!");
                    return;
                }
                Book newBook = new Book()
                {
                    Id = theme.GetAllData().Max(x => x.Id) + 1,
                    Name = BookName,
                    Pages = int.Parse(this.Pages.Trim()),
                    YearPress = int.Parse(this.YearPress.Trim()),
                    Quantity = int.Parse(this.Quantity.Trim()),
                    Id_Author = Authors[AuthorIndex].Id,
                    Id_Themes = Themes[ThemeIndex].Id,
                    Id_Category = Categories[CategoryIndex].Id,
                    Id_Press = Presses[PressIndex].Id
                };
                var book = new BookRepository();
                book.AddData(newBook);
                App.ExecuteBackCommand();
                MessageBox.Show("New book was added successfully");
            });
        }
    }
}
