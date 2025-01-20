using ExamenP3OntanedaTomas.Models;
using SQLite;
using System.Threading.Tasks;

public class PaisSQLite
{
    readonly SQLiteAsyncConnection _database;

    public PaisSQLite(string dbPath)
    {
        _database = new SQLiteAsyncConnection(dbPath);
        _database.CreateTableAsync<PaisDB>().Wait();
    }

    public Task<List<PaisDB>> GetPaisesAsync()
    {
        return _database.Table<PaisDB>().ToListAsync();
    }

    public Task<int> GuardarPaisAsync(PaisDB pais)
    {
        return _database.InsertAsync(pais);
    }

    public Task<int> DeletePaisAsync(PaisDB pais)
    {
        return _database.DeleteAsync(pais);
    }
}
