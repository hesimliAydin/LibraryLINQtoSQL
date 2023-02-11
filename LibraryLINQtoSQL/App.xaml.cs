using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace LibraryLINQtoSQL
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static List<UIElement> Pages { get; set; } = new List<UIElement>();

        public static void ChangePage(UIElement newPage, bool addNewPage = true)
        {
            if (addNewPage)
                Pages.Add(newPage);
        }

        public static void ExecuteBackCommand()
        {
            Pages.Remove(Pages.Last());
            App.ChangePage(Pages.Last(), false);
        }
    }
}
