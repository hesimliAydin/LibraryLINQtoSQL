using LibraryLINQtoSQL.Commands;
using LibraryLINQtoSQL.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace LibraryLINQtoSQL.ViewModels
{
    public class EditBookViewModel:BaseViewModel
    {
        public RelayCommand BackCommand { get; set; }
        public RelayCommand SaveChangesCommand { get; set; }

        private List<Author> authors;

        public List<Author> Authors
        {
            get { return authors; }
            set { authors = value; OnPropertyChanged(); }
        }

        private List<Theme> themes;

        public List<Theme> Themes
        {
            get { return themes; }
            set { themes = value; OnPropertyChanged(); }
        }

        private List<Category> categories;

        public List<Category> Categories
        {
            get { return categories; }
            set { categories = value; OnPropertyChanged(); }
        }

        private List<Press> presses;

        public List<Press> Presses
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

        public EditBookViewModel(Book book)
        {
            var author = new AuthorRepositories();
            Authors = author.GetAllData();
            var theme = new ThemeRepositories();
            Themes = theme.GetAllData();
            var categorie = new CategoriesRepositories();
            Categories = categorie.GetAllData();
            var press = new PressRepositories();
            Presses = press.GetAllData();

            BookName = book.Name;
            Pages = book.Pages.ToString();
            YearPress = book.YearPress.ToString();
            Comment = book.Comment;
            Quantity = book.Quantity.ToString();
            AuthorIndex = Authors.IndexOf(book.Author);
            ThemeIndex = Themes.IndexOf(book.Theme);
            CategoryIndex = Categories.IndexOf(book.Category);
            PressIndex = Presses.IndexOf(book.Press);

            BackCommand = new RelayCommand((b) =>
            {
                App.ExecuteBackCommand();
            });

            SaveChangesCommand = new RelayCommand((b) =>
            {
                if (AuthorIndex == -1 || ThemeIndex == -1 || CategoryIndex == -1 || PressIndex == -1
                 || string.IsNullOrEmpty(BookName) || string.IsNullOrEmpty(Pages) || string.IsNullOrEmpty(YearPress)
                 || string.IsNullOrEmpty(Comment) || string.IsNullOrEmpty(Quantity))
                {
                    MessageBox.Show("Please, fill form completely!");
                    return;
                }

                Book newBook = new Book()
                {
                    Id = book.Id,
                    Name = BookName,
                    Pages = int.Parse(this.Pages.Trim()),
                    YearPress = int.Parse(this.YearPress.Trim()),
                    Quantity = int.Parse(this.Quantity.Trim()),
                    Comment = this.Comment,
                    Id_Author = Authors[AuthorIndex].Id,
                    Id_Themes = Themes[ThemeIndex].Id,
                    Id_Category = Categories[CategoryIndex].Id,
                    Id_Press = Presses[PressIndex].Id
                };

                var books = new BookRepository();
                books.UpdateData(newBook);
                MessageBox.Show("Book was updated successfully");
                App.ExecuteBackCommand();
            });
        }
    }
}
