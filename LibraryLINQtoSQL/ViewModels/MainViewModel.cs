using LibraryLINQtoSQL.Commands;
using LibraryLINQtoSQL.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryLINQtoSQL.ViewModels
{
    public class MainViewModel:BaseViewModel
    {
        public RelayCommand LibrarianCommand { get; set; }
        public RelayCommand StudentCommand { get; set; }


        public MainViewModel()
        {
            LibrarianCommand = new RelayCommand(l =>
            {
                var lib_window = new LibrarianWindow();
                lib_window.ShowDialog();
            });


            StudentCommand = new RelayCommand(s =>
            {
                var student_window = new StudentWindow();
                student_window.ShowDialog();
            });

        }
    }
}
