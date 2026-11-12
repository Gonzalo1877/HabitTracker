namespace HabitTracker.databaseOperations;
using Microsoft.Data.Sqlite;

    public class DatabaseOperations
    {
        string cs = "Data Source=habittracker.db; Foreign Keys=True";

        public void RegistrarHabito(string nombre, string unidad)
        {

        var con = new SqliteConnection(cs);
        con.Open();

        using var command = con.CreateCommand();
        command.CommandText = "INSERT INTO habits (name, unit) VALUES ($nombre, $unidad)";

        command.Parameters.AddWithValue("$nombre", nombre);
        command.Parameters.AddWithValue("$unidad", unidad);

        command.ExecuteNonQuery();
        }

        public void AgregarHabito(DateTime fecha, int cantidad, int habitId)
        {
            var con = new SqliteConnection(cs);
            con.Open();

            using var command = con.CreateCommand();
            command.CommandText = "INSERT INTO habit_logs (habitId, date, quantity) VALUES ($habitId, $fecha, $cantidad)";

            command.Parameters.AddWithValue("$habitId", habitId);
            command.Parameters.AddWithValue("$fecha", fecha.ToString("yyyy-MM-dd"));
            command.Parameters.AddWithValue("$cantidad", cantidad);

            command.ExecuteNonQuery();
        }
    
        public void MostrarHabitosDisponibles()
        {
            var con = new SqliteConnection(cs);
            con.Open();

            using var command = con.CreateCommand();
            command.CommandText = "SELECT id, name, unit FROM habits";

            using SqliteDataReader rdr = command.ExecuteReader();

            Console.Clear();
            while (rdr.Read())
            {
            Console.WriteLine("* * *");
            Console.WriteLine($"Nombre: {rdr.GetString(1)}");
            Console.WriteLine($"ID: {rdr.GetInt32(0)}");
            }
        }

        public void EliminarHabito(int habitId)
        {
            var con = new SqliteConnection(cs);
            con.Open();

            try
                {
                    using var command = con.CreateCommand();
                    command.CommandText = "DELETE FROM habits WHERE id = $habitId";

                    command.Parameters.AddWithValue("$habitId", habitId);

                    command.ExecuteNonQuery();
                }
            catch (SqliteException ex)
                {
                    Console.WriteLine($"Error al eliminar el hábito: {ex.Message}.");
                    Console.Write("Presione una tecla para continuar. > ");
                    Console.ReadKey();
                }
        }
    }
