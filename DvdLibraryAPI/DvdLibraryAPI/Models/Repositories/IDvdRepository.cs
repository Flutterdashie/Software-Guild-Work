using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DvdLibraryAPI.Models.Repositories
{
    public interface IDvdRepository
    {
        Dvd Create(Dvd dvd);
        Dvd Read(int id);
        IEnumerable<Dvd> ReadAll();
        IEnumerable<Dvd> ReadByTitle(string title);
        IEnumerable<Dvd> ReadByRating(string rating);
        IEnumerable<Dvd> ReadByDirector(string director);
        IEnumerable<Dvd> ReadByYear(string year);
        void Update(Dvd dvd);
        void Delete(int id);
    }
}
