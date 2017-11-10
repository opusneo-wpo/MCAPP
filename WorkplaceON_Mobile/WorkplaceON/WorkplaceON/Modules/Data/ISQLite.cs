using SQLite;

namespace WorkplaceON.Data
{
    public interface ISQLite
    {
        SQLiteConnection GetConnection();
    }
}
