//Service.cs  
using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace SHARPEOPLE_LIB
{  
    public class PeopleService : IPeople  
    {
        public List<People> GetPeople()
        {
            try
            {
                using (var sqlConnexion = new MySqlConnection("Server=localhost; database=hoomans; UID=root; SslMode=none"))
                {
                    var sqlCommand = new MySqlCommand("Select * From people", sqlConnexion);
                    
                    sqlConnexion.Open();
                    var sqlReader = sqlCommand.ExecuteReader();
                    
                    var result = new List<People>();
                    
                    while (sqlReader.Read())
                    {
                        int.TryParse(sqlReader["id"].ToString(), out var idInt);
                        float.TryParse(sqlReader["height"].ToString(), out var heightFloat);
                        float.TryParse(sqlReader["weight"].ToString(), out var weightFloat);
                        result.Add(new People(idInt, sqlReader["name"].ToString(), heightFloat, weightFloat));
                    }

                    return result;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
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