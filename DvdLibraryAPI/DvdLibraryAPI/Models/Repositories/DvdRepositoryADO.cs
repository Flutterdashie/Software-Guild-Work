using System;
using System.Collections.Generic;
using System.Data;
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
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = _connStr;
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "CreateDvd";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = conn;
                cmd.Parameters.AddWithValue("@title", dvd.title);
                cmd.Parameters.AddWithValue("@realeaseYear", dvd.realeaseYear);
                cmd.Parameters.AddWithValue("@director", dvd.director);
                cmd.Parameters.AddWithValue("@rating", dvd.rating);
                if (dvd.notes != null)
                {
                    cmd.Parameters.AddWithValue("@notes", dvd.notes);
                }

                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string parsedNotes = (reader["notes"] != DBNull.Value) ? reader["notes"].ToString() : null;
                        return new Dvd
                        {
                            dvdId = (int)reader["dvdId"],
                            title = reader["title"].ToString(),
                            rating = reader["rating"].ToString(),
                            realeaseYear = reader["realeaseYear"].ToString(),
                            director = reader["director"].ToString(),
                            notes = parsedNotes
                        };
                    }
                }

                return new Dvd();
            }
        }

        public void Delete(int id)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = _connStr;
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "DeleteByID";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = conn;
                cmd.Parameters.AddWithValue("@Id", id);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public Dvd Read(int id)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = _connStr;
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "GetByID";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = conn;
                cmd.Parameters.AddWithValue("@Id", id);
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string parsedNotes = (reader["notes"] != DBNull.Value) ? reader["notes"].ToString() : null;
                        return new Dvd
                        {
                            dvdId = (int)reader["dvdId"],
                            title = reader["title"].ToString(),
                            rating = reader["rating"].ToString(),
                            realeaseYear = reader["realeaseYear"].ToString(),
                            director = reader["director"].ToString(),
                            notes = parsedNotes
                        };
                    }
                }

                return new Dvd();
            }
        }

        public IEnumerable<Dvd> ReadAll()
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = _connStr;
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "GetAll";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = conn;
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
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
                }

                yield break;
            }
        }

        public IEnumerable<Dvd> ReadByDirector(string director)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = _connStr;
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "GetByDirector";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Search", director);
                cmd.Connection = conn;
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
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
                }

                yield break;
            }
        }

        public IEnumerable<Dvd> ReadByRating(string rating)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = _connStr;
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "GetByRating";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Search", rating);
                cmd.Connection = conn;
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
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
                }

                yield break;
            }
        }

        public IEnumerable<Dvd> ReadByTitle(string title)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = _connStr;
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "GetByTitle";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Search", title);
                cmd.Connection = conn;
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
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
                }

                yield break;
            }
        }

        public IEnumerable<Dvd> ReadByYear(string year)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = _connStr;
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "GetByYear";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Search", year);
                cmd.Connection = conn;
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
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
                }

                yield break;
            }
        }

        public void Update(Dvd dvd)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = _connStr;
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "UpdateByID";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = conn;
                cmd.Parameters.AddWithValue("@dvdId", dvd.dvdId);
                cmd.Parameters.AddWithValue("@title", dvd.title);
                cmd.Parameters.AddWithValue("@realeaseYear", dvd.realeaseYear);
                cmd.Parameters.AddWithValue("@director", dvd.director);
                cmd.Parameters.AddWithValue("@rating", dvd.rating);
                if (dvd.notes != null)
                {
                    cmd.Parameters.AddWithValue("@notes", dvd.notes);
                }

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        //private static IEnumerable<Dvd> InterpretReader(SqlCommand cmd)
        //{
        //    using (SqlDataReader reader = cmd.ExecuteReader())
        //    {
        //        while (reader.Read())
        //        {
        //            string parsedNotes = (reader["notes"] != DBNull.Value) ? reader["notes"].ToString() : null;
        //            yield return new Dvd
        //            {
        //                dvdId = (int)reader["dvdId"],
        //                title = reader["title"].ToString(),
        //                rating = reader["rating"].ToString(),
        //                realeaseYear = reader["realeaseYear"].ToString(),
        //                director = reader["director"].ToString(),
        //                notes = parsedNotes
        //            };
        //        }
        //    }

        //    yield break;
        //}
    }
}