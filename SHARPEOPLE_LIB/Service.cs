//Service.cs  
using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace SHARPEOPLE_LIB
{  
    public class PeopleService : ICalculator  
    {
        public List<Dictionary<string, string>> GetPeople()
        {
            try
            {
                using (var sqlConnexion = new MySqlConnection("Server=localhost; database=hoomans; UID=root; SslMode=none"))
                {
                    var sqlCommand = new MySqlCommand("Select * From people", sqlConnexion);
                    
                    sqlConnexion.Open();
                    var sqlReader = sqlCommand.ExecuteReader();
                    
                    var result = new List<Dictionary<string, string>>();
                    
                    while (sqlReader.Read())
                    {
                        result.Add(new Dictionary<string, string>
                        {
                            {"id", sqlReader["id"].ToString()},
                            {"name", sqlReader["name"].ToString()},
                            {"height", sqlReader["height"].ToString()},
                            {"weight", sqlReader["weight"].ToString()},
                        });
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
        public People(int id, int name, int height, int weight)
        {
            Id = id;
            Name = name;
            Height = height;
            Weight = weight;
        }

        public int Id;
        public int Name;
        public int Height;
        public int Weight;
    }
}  