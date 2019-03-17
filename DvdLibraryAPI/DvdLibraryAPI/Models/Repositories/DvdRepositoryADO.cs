using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace DvdLibraryAPI.Models.Repositories
{
    public class DvdRepositoryADO : IDvdRepository
    {
        private readonly string _connStr;
        public DvdRepositoryADO(string connStr)
        {
            _connStr = connStr;
        }
        public Dvd Create(Dvd dvd)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = _connStr;
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "DeleteByID";
                cmd.Connection = conn;
                throw new NotImplementedException();
            }
        }

        public Dvd Read(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Dvd> ReadAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Dvd> ReadByDirector(string director)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Dvd> ReadByRating(string rating)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Dvd> ReadByTitle(string title)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Dvd> ReadByYear(string year)
        {
            throw new NotImplementedException();
        }

        public void Update(Dvd dvd)
        {
            throw new NotImplementedException();
        }

        private static IEnumerable<Dvd> InterpretReader(SqlDataReader reader)
        {
            while(reader.Read())
            {
                string parsedNotes = (reader["notes"] != DBNull.Value) ? reader["notes"].ToString() : null;
                yield return new Dvd
                {
                    dvdId = (int)reader["dvdId"],
                    title = reader["title"].ToString(),
                    rating = reader["rating"].ToString(),
                    realeaseYear = reader["realeaseYear"].ToString(),
                    director = reader["director"].ToString(),
                    notes = parsedNotes
                };
            }
            yield break;
        }
    }
}