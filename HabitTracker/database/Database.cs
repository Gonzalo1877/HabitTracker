namespace HabitTracker.database;
using Microsoft.Data.Sqlite;

public class DatabaseSQLite
{   
    public void IniciarDb() 
    {       
    // Inicializacion de ruta y apertura de la conexion.
    string cs = "Data Source=habittracker.db; Foreign Keys=True";

    using var connection = new SqliteConnection(cs);
    
    // Intenta ejecutar el comando y captura cualquier excepción que pueda ocurrir.
    try {
        connection.Open();

        using var command = connection.CreateCommand();

        // Crear tabla Habits, si no existe
        command.CommandText = @"
            CREATE TABLE IF NOT EXISTS habits (
                id INTEGER PRIMARY KEY AUTOINCREMENT,
                name TEXT NOT NULL,
                unit TEXT NOT NULL
            );
        ";

        // Crear tabla HabitLogs, si no existe.
        command.CommandText += @"
            CREATE TABLE IF NOT EXISTS habit_logs (
                id INTEGER PRIMARY KEY AUTOINCREMENT,
                habitId INTEGER NOT NULL,
                date TEXT NOT NULL,
                quantity INTEGER NOT NULL,
                FOREIGN KEY (habitId) REFERENCES habits(id)
            );
            ";
            
        command.ExecuteNonQuery();     
    }     
    catch (SqliteException ex) 
        {
            Console.WriteLine($"Error al crear las tablas: {ex.Message}");
        } 
    }
}
