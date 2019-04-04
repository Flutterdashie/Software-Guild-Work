using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DvdLibraryAPI.Models
{
    public static class DVDMapper
    {
        public static Dvd ToDVD(JObject input)
        {
            int parsedId;
            if (input["dvdId"] == null)
            {
                parsedId = 0;
            }
            else
            {
                parsedId = (int)input["dvdId"];
            }
            return new Dvd
            {
                //dvdId = (int?)input["dvdId"] ?? 0,
                dvdId = parsedId,
                title = input["title"].ToString(),
                rating = input["rating"].ToString(),
                realeaseYear = input["realeaseYear"].ToString(),
                director = input["director"].ToString(),
                notes = input["notes"]?.ToString()
            };
        }

        public static JObject ToJSON(Dvd input)
        {
            JObject result = new JObject();
            result.Add("dvdId", input.dvdId);
            result.Add("title", input.title);
            result.Add("rating", input.rating);
            result.Add("realeaseYear", input.realeaseYear);
            result.Add("director", input.director);
            result.Add("notes", input.notes);
            return result;
        }
    }
}