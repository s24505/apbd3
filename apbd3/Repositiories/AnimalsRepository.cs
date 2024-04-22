using System.Data.SqlClient;
using apbd3.Models;

namespace apbd3.Repositiories;

public class AnimalsRepository : IAnimalsRepository
{
    private String dbConnection = "Server=db-mssql;Database=2019SBD;User=DESKTOP-SEIPVV6\\Patryk";
    public IEnumerable<Animal> FetchAnimals()
    {
        using SqlConnection con = new(dbConnection);
        con.Open();

        using var cmd = new SqlCommand(); //jak uzywamy using to zawsze zamknie polaczenie przy returnie
        cmd.Connection = con;
        cmd.CommandText = "SELECT IdAnimal, Name, Description, Category, Area FROM Animals ORDER BY Name";

        var dr = cmd.ExecuteReader();
        var animals = new List<Animal>();
        while (dr.Read())
        {
            var animal = new Animal()
            {
                IdAnimal = (int)dr["IdAnimal"],
                Name = dr["Name"].ToString(),
                Description = dr["Description"].ToString(),
                Category = dr["Category"].ToString(),
                Area = dr["Area"].ToString()
            };
            animals.Add(animal);
        }
        
        return animals;
    }

    public Animal GetAnimal(int idAnimal)
    {
        using SqlConnection con = new(dbConnection);
        con.Open();

        using var cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = "SELECT IdAnimal, Name, Description, Category, Area FROM Animals WHERE IdAnimal = @IdAnimal";
        cmd.Parameters.AddWithValue("@IdAnimal", idAnimal);

        var dr = cmd.ExecuteReader();

        if (!dr.Read()) return null;
        
        var animal = new Animal()
        {
            IdAnimal = (int)dr["IdAnimal"],
            Name = dr["Name"].ToString(),
            Description = dr["Description"].ToString(),
            Category = dr["Category"].ToString(),
            Area = dr["Area"].ToString()
        };
        
        return animal;
    }

    public int UpdateAnimal(Animal animal)
    {
        using var con = new SqlConnection(dbConnection);
        con.Open();

        using var cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText =
            "UPDATE Animals SET Name=@Name, Description=@Description, Category=@Category, Area=@Area WHERE IdAnimal=@IdAnimal";
        cmd.Parameters.AddWithValue("IdAnimal", animal.IdAnimal);
        cmd.Parameters.AddWithValue("Name", animal.Name);
        cmd.Parameters.AddWithValue("Description", animal.Description);
        cmd.Parameters.AddWithValue("Category", animal.Category);
        cmd.Parameters.AddWithValue("Area", animal.Area);

        var affectedCount = cmd.ExecuteNonQuery();
        return affectedCount;
    }
}