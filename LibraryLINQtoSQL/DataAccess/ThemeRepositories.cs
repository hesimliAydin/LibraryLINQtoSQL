using LibraryLINQtoSQL.Abstractions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryLINQtoSQL.DataAccess
{
    public class ThemeRepositories : IRepository<Theme>
    {

        private readonly LibraryDbDataContext _dbDataContext;

        public ThemeRepositories()
        {
            _dbDataContext= new LibraryDbDataContext();
        }
        public void AddData(Theme data)
        {
            _dbDataContext.Themes.InsertOnSubmit(data);
            _dbDataContext.SubmitChanges();
        }

        public void DeleteData(Theme data)
        {
            _dbDataContext.Themes.DeleteOnSubmit(data);
            _dbDataContext.SubmitChanges();
        }

        public ObservableCollection<Theme> GetAllData()
        {
            var themes=from t in _dbDataContext.Themes
                     select t;

            return new ObservableCollection<Theme>(themes);
        }

        public Theme GetData(int id)
        {
            return _dbDataContext.Themes.SingleOrDefault(t => t.Id == id);
        }

        public void UpdateData(Theme data)
        {
            var item=_dbDataContext.Themes.SingleOrDefault(t => t.Id == data.Id);

            item = new Theme
            {
                Name = data.Name
            };
            _dbDataContext.SubmitChanges();
        }
    }
}
