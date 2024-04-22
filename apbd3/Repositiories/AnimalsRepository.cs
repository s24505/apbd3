using System.Data.SqlClient;
using apbd3.Models;

namespace apbd3.Repositiories;

public class AnimalsRepository : IAnimalsRepository
{
    public IEnumerable<Animal> FetchAnimals()
    {
        using SqlConnection con = new("Server=db-mssql;Database=2019SBD;User=DESKTOP-SEIPVV6\\Patryk");
        con.Open();

        using var cmd = new SqlCommand(); //jak uzywamy using to zawsze zamknie polaczenie przy returnie
        cmd.Connection = con;
        cmd.CommandText = "SELECT IdAnimal, Name, Description, Category, Area FROM Animals ORDER BY Name";

        var dr = cmd.ExecuteReader();
        var animals = new List<Animal>();
        while (dr.Read())
        {
            var grade = new Animal()
            {
                IdAnimal = (int)dr["IdAnimal"],
                Name = dr["Name"].ToString(),
                Descripiton = dr["Descripiton"].ToString(),
                Category = dr["Category"].ToString(),
                Area = dr["Area"].ToString()
            };
            animals.Add(grade);
        }
        
        return animals;
    }
}