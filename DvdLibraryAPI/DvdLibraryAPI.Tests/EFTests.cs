using DvdLibraryAPI.Models;
using DvdLibraryAPI.Models.Repositories;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DvdLibraryAPI.Tests
{
    [TestFixture]
    class EFTests
    {
        //private static IDvdRepository _repo;
        //[OneTimeSetUp]
        //public void PrepRepo()
        //{
        //    _repo = new DvdRepositoryEF();
        //}


        //[Test]
        //public void FullCRRRRRRUDTest()
        //{
        //    Dvd testDvd = new Dvd
        //    {
        //        title = "Test DVD",
        //        director = "Testing",
        //        rating = "R",
        //        realeaseYear = "2019",
        //        notes = "If you can see this, the test didn't edit itself properly."
        //    };
        //    testDvd = _repo.Create(testDvd);
        //    Assert.AreEqual(testDvd.notes, _repo.Read(testDvd.dvdId).notes);
        //    testDvd.notes = "If you can see this, the test didn't clean itself up properly.";
        //    _repo.Update(testDvd);
        //    Assert.AreEqual(testDvd.notes, _repo.Read(testDvd.dvdId).notes);
        //    Assert.IsNotEmpty(_repo.ReadAll(), "Could not read all");
        //    Assert.IsNotEmpty(_repo.ReadByDirector("Testing"), "Could not read by director");
        //    Assert.IsNotEmpty(_repo.ReadByRating("R"), "Could not read by rating");
        //    Assert.IsNotEmpty(_repo.ReadByTitle("Test DVD"), "Could not read by title");
        //    Assert.IsNotEmpty(_repo.ReadByYear("2019"), "Could not read by year");
        //    _repo.Delete(testDvd.dvdId);
        //    Assert.IsNull(_repo.Read(testDvd.dvdId).rating);
        //}
    }
}
