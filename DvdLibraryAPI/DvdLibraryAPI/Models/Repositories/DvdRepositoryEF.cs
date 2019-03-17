using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DvdLibraryAPI.Models.Repositories
{
    public class DvdRepositoryEF : IDvdRepository
    {
        private static DvdLibraryEntities _database;
        static DvdRepositoryEF()
        {
            _database = new DvdLibraryEntities();
        }

        public Dvd Create(Dvd dvd)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            //Unintentionally let EF map the stored procs. I'll save using those for ADO.
            var target = _database.Dvds.FirstOrDefault(d => d.dvdId == id);
            if (target != null)
            {
                _database.Dvds.Remove(target);
                _database.SaveChanges();
            }

        }

        public Dvd Read(int id)
        {
            return _database.Dvds.FirstOrDefault(d => d.dvdId == id);
        }

        public IEnumerable<Dvd> ReadAll()
        {
            return _database.Dvds;
        }

        public IEnumerable<Dvd> ReadByDirector(string director)
        {
            return _database.Dvds.Where(d => d.director.ToLower().Contains(director.ToLower()));
        }

        public IEnumerable<Dvd> ReadByRating(string rating)
        {
            return _database.Dvds.Where(d => string.Equals(d.rating,rating,StringComparison.CurrentCultureIgnoreCase));
        }

        public IEnumerable<Dvd> ReadByTitle(string title)
        {
            return _database.Dvds.Where(d => d.title.ToLower().Contains(title.ToLower()));
        }

        public IEnumerable<Dvd> ReadByYear(string year)
        {
            return _database.Dvds.Where(d => d.realeaseYear.Contains(year));
        }

        public void Update(Dvd dvd)
        {
            _database.Entry
        }
    }
}