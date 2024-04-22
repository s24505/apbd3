using System.Data.SqlClient;
using apbd3.Models;

namespace apbd3.Repositiories;

public class AnimalsRepository : IAnimalsRepository
{
    private String dbConnection = "Data Source=db-mssql;Initial Catalog=2019SBD;Integrated Security=True";
    public IEnumerable<Animal> GetAnimals(String orderBy)
    {
        Dictionary<string, string> allowedColumns = new Dictionary<string, string>
        {
            { "idanimals", "IdAnimals" },
            { "name", "Name" },
            { "description", "Description" },
            { "category", "Category" },
            { "area", "Area" }
        };
        
        if (!allowedColumns.ContainsKey(orderBy.ToLower()))
        {
            return null;
        }

        using SqlConnection con = new(dbConnection);
        con.Open();

        using var cmd = new SqlCommand(); //jak uzywamy using to zawsze zamknie polaczenie przy returnie
        cmd.Connection = con;
        string query =
            $"SELECT IdAnimal, Name, Description, Category, Area FROM Animals ORDER BY {allowedColumns[orderBy.ToLower()]}";
        cmd.CommandText = query;

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

    public int CreateAnimal(Animal animal)
    {
        using var con = new SqlConnection(dbConnection);
        con.Open();

        using var cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText =
            "INSERT INTO Animals(IdAnimal, Name, Description, Category, Area) VALUES (@IdAnimal, @Name, @Description, @Category, @Area)";
        cmd.Parameters.AddWithValue("@IdAnimal", animal.IdAnimal);
        cmd.Parameters.AddWithValue("@Name", animal.Name);
        cmd.Parameters.AddWithValue("@Description", animal.Description);
        cmd.Parameters.AddWithValue("@Category", animal.Category);
        cmd.Parameters.AddWithValue("@Area", animal.Area);

        var affectedCount = cmd.ExecuteNonQuery();
        return affectedCount;
    }

    public int UpdateAnimal(Animal animal)
    {
        using var con = new SqlConnection(dbConnection);
        con.Open();

        using var cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText =
            "UPDATE Animals SET Name=@Name, Description=@Description, Category=@Category, Area=@Area WHERE IdAnimal=@IdAnimal";
        cmd.Parameters.AddWithValue("@IdAnimal", animal.IdAnimal);
        cmd.Parameters.AddWithValue("@Name", animal.Name);
        cmd.Parameters.AddWithValue("@Description", animal.Description);
        cmd.Parameters.AddWithValue("@Category", animal.Category);
        cmd.Parameters.AddWithValue("@Area", animal.Area);

        var affectedCount = cmd.ExecuteNonQuery();
        return affectedCount;
    }

    public int DeleteAnimal(int idAnimal)
    {
        using var con = new SqlConnection(dbConnection);
        con.Open();

        using var cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = "DELETE FROM Animals WHERE IdAnimal=@IdAnimal";
        cmd.Parameters.AddWithValue("@IdAnimal", idAnimal);

        var affectedCount = cmd.ExecuteNonQuery();
        return affectedCount;
    }
}