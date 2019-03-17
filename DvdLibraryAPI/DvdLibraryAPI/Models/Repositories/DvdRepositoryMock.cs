using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DvdLibraryAPI.Models.Repositories
{
    public class DvdRepositoryMock : IDvdRepository
    {
        private static List<Dvd> _repo;
        static DvdRepositoryMock()
        {
            _repo = new List<Dvd>
            {
                new Dvd
                {
                    dvdId = 0,
                    title = "Jurassic Park",
                    realeaseYear = "1993",
                    director = "Spielberg",
                    rating ="PG-13",
                    notes = null
                },
                new Dvd
                {
                    dvdId = 1,
                    title = "O Brother, Where Art Thou?",
                    realeaseYear = "2000",
                    director = "Coen",
                    rating ="PG-13",
                    notes = "Directed by the Coen Brothers."
                },
                new Dvd
                {
                    dvdId = 2,
                    title = "Inside Out",
                    realeaseYear = "2015",
                    director = "Docter",
                    rating ="PG",
                    notes = "Yes, that IS how you spell his last name."
                },
                new Dvd
                {
                    dvdId = 3,
                    title = "Jaws",
                    realeaseYear = "1975",
                    director = "Spielberg",
                    rating ="PG",
                    notes = null
                }
            };
        }

        public Dvd Create(Dvd dvd)
        {
            dvd.dvdId = _repo.Max(d => d.dvdId) + 1;
            _repo.Add(dvd);
            return dvd;
        }

        public void Delete(int id)
        {
            _repo.RemoveAll(d => d.dvdId == id);
        }

        public Dvd Read(int id)
        {
            return _repo.FirstOrDefault(d => d.dvdId == id);
        }

        public IEnumerable<Dvd> ReadAll()
        {
            return _repo;
        }

        public IEnumerable<Dvd> ReadByDirector(string director)
        {
            return _repo.Where(d => d.director.ToLower().Contains(director.ToLower()));
        }

        public IEnumerable<Dvd> ReadByRating(string rating)
        {
            return _repo.Where(d => string.Equals(d.rating, rating, StringComparison.CurrentCultureIgnoreCase));
        }

        public IEnumerable<Dvd> ReadByTitle(string title)
        {
            return _repo.Where(d => d.title.ToLower().Contains(title.ToLower()));
        }

        public IEnumerable<Dvd> ReadByYear(string year)
        {
            return _repo.Where(d => d.realeaseYear.Contains(year));
        }

        public void Update(Dvd dvd)
        {
            int targetIndex = _repo.FindIndex(d => d.dvdId == dvd.dvdId);
            _repo[targetIndex] = dvd;
        }
    }
}