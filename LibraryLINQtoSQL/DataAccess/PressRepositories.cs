using LibraryLINQtoSQL.Abstractions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryLINQtoSQL.DataAccess
{
    public class PressRepositories : IRepository<Press>
    {

        private readonly LibraryDbDataContext _dbDataContext;

        public PressRepositories()
        {
            _dbDataContext= new LibraryDbDataContext();
        }
        public void AddData(Press data)
        {
            _dbDataContext.Presses.InsertOnSubmit(data);
            _dbDataContext.SubmitChanges();
        }

        public void DeleteData(Press data)
        {
            _dbDataContext.Presses.DeleteOnSubmit(data);
            _dbDataContext.SubmitChanges();
        }

        public ObservableCollection<Press> GetAllData()
        {
            var press = from p in _dbDataContext.Presses
                        select p;

            return new ObservableCollection<Press>(press);
        }

        public Press GetData(int id)
        {
            return _dbDataContext.Presses.SingleOrDefault(p => p.Id == id);
        }

        public void UpdateData(Press data)
        {
            var item=_dbDataContext.Presses.SingleOrDefault(p=>p.Id == data.Id);

            item = new Press
            {
                Name= data.Name
            };

            _dbDataContext.SubmitChanges();

        }
    }
}
