//Service.cs  

using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;

namespace SHARPEOPLE_LIB
{
    public class PeopleService : IPeople
    {
        private readonly string _connexionString;

        public PeopleService()
        {
            _connexionString = "Server=localhost; database=hoomans; UID=root; SslMode=none";
        }

        public List<People> GetPeople()
        {
            return GetFormattedResult("Select * From people");
        }

        public People GetPeople(int id)
        {
            return GetFormattedResult("Select * From people WHERE id=" + id)[0];
        }

        public void DelPeople(int id)
        {
            var result = GetFormattedResult("DELETE From people WHERE id=" + id)[0];
        }

        public void AddPeople(string name, float height, float weight)
        {
            var result = GetFormattedResult($"INSERT INTO people (id, name, height, weight) VALUES ({name}, {height}, {weight})");
        }

        public void SetPeople(int id, string name, float height, float weight)
        {
            var result = GetFormattedResult($"UPDATE people SET name={name}, height={height}, weight={weight} WHERE id={id}");
        }

        private List<People> GetFormattedResult(string request)
        {
            using (var sqlConnexion = new MySqlConnection(_connexionString))
            {
                var sqlCommand = new MySqlCommand(request, sqlConnexion);

                sqlConnexion.Open();
                var sqlReader = sqlCommand.ExecuteReader();

                return FormatResult(sqlReader);
            }
        }

        private static List<People> FormatResult(IDataReader sqlReader)
        {
            var result = new List<People>();

            while (sqlReader.Read())
            {
                result.Add(new People(
                    Convert.ToInt32(sqlReader["id"].ToString()), 
                    sqlReader["name"].ToString(), 
                    Convert.ToSingle(sqlReader["height"].ToString()), 
                    Convert.ToSingle(sqlReader["weight"].ToString())
                    ));
            }

            return result;
        }
    }

    public class People
    {
        public People(int id, string name, float height, float weight)
        {
            Id = id;
            Name = name;
            Height = height;
            Weight = weight;
        }

        public int Id;
        public string Name;
        public float Height;
        public float Weight;
    }
}