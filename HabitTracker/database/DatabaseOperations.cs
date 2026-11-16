namespace HabitTracker.databaseOperations;
using Microsoft.Data.Sqlite;
using HabitTracker.utils;

    public class DatabaseOperations
    {
        string cs = "Data Source=habittracker.db; Foreign Keys=True";
        public void RegistrarHabito(string nombre, string unidad)
        {

        using var con = new SqliteConnection(cs);
        con.Open();

        using var command = con.CreateCommand();
        command.CommandText = "INSERT INTO habits (name, unit) VALUES ($nombre, $unidad)";

        command.Parameters.AddWithValue("$nombre", nombre);
        command.Parameters.AddWithValue("$unidad", unidad);

        command.ExecuteNonQuery();
        }

        public void AgregarHabito(DateTime fecha, int cantidad, int habitId)
        {
            using var con = new SqliteConnection(cs);
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
            using var con = new SqliteConnection(cs);
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

        public void MostrarOcurrenciasHabito(int habitId)
        {
            using var con = new SqliteConnection(cs);
            con.Open();

           try 
           { 
            using var command = con.CreateCommand();
            command.CommandText = "SELECT id, date, quantity FROM habit_logs WHERE habitId = $habitId";

            command.Parameters.AddWithValue("$habitId", habitId);

            using SqliteDataReader rdr = command.ExecuteReader();
            Console.Clear();
        
            while (rdr.Read())
            {
            Console.WriteLine("* * *");
            Console.WriteLine($"ID: {rdr.GetInt32(0)} || Fecha: {rdr.GetString(1)} || Cantidad: {rdr.GetInt32(2)}");
            }
            } 
            catch (SqliteException ex)
            {
                Console.WriteLine($"Error al mostrar las ocurrencias: {ex.Message}.");
                Console.Write("Presione una tecla para continuar. > ");
                Console.ReadKey();
            }
       }
        public void EliminarHabito(int habitId)
        {
            using var con = new SqliteConnection(cs);
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

        public void EliminarOcurrencias(int habitId)
        {
            using var con = new SqliteConnection(cs);
            con.Open();

            try
            {
            using var command = con.CreateCommand();
            command.CommandText = "DELETE FROM habit_logs WHERE habitId = $habitId";

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

        public void ActualizarOcurrencia(int ocurrenciaId,  int habitId, DateTime fecha, int cantidad)
        {
            using var con = new SqliteConnection(cs);
            con.Open();

            try
            {
                using var command = con.CreateCommand();
                command.CommandText = "UPDATE habit_logs SET date = $date, quantity = $quantity WHERE id = $id AND habitId = $habitId";

                command.Parameters.AddWithValue("$date", fecha.ToString("yyyy-MM-dd"));
                command.Parameters.AddWithValue("$quantity", cantidad);
                command.Parameters.AddWithValue("$id", ocurrenciaId);
                command.Parameters.AddWithValue("$habitId", habitId);

                command.ExecuteNonQuery();
            }
            catch (SqliteException ex)
            {
                Console.WriteLine($"Error al actualizar las ocurrencias: {ex.Message}.");
                Console.Write("Presione una tecla para continuar. > ");
                Console.ReadKey();
            }
        }

        public bool ValidarId(int id)
        {
            var utils = new Utils();
            using var con = new SqliteConnection(cs);
            con.Open();

            using var command = con.CreateCommand();
            command.CommandText = "SELECT EXISTS(SELECT 1 FROM habits WHERE id = $habitId)";

            command.Parameters.AddWithValue("$habitId", id);

            bool existe = Convert.ToInt64(command.ExecuteScalar()) == 1;

            if (!existe) 
            {
                Console.WriteLine("El ID ingresado no existe en la base de datos.");
                utils.Pausar();
            }      
            return existe;
        }

        public bool ValidarOcurrencia(int ocurrenciaId, int habitId)
        {
            var utils = new Utils();
            using var con = new SqliteConnection(cs);
            con.Open();

            using var command = con.CreateCommand();
            command.CommandText = "SELECT EXISTS(SELECT 1 FROM habit_logs WHERE id = $ocurrenciaId AND habitId = $habitId)";

            command.Parameters.AddWithValue("$ocurrenciaId", ocurrenciaId);
            command.Parameters.AddWithValue("$habitId", habitId);

            bool existe = Convert.ToInt64(command.ExecuteScalar()) == 1;

            if (!existe) 
            {
                Console.WriteLine("La ocurrencia no existe o no pertenece al hábito especificado.");
                utils.Pausar();
            }

            return existe;
        }
    }