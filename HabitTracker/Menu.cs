namespace HabitTracker.menu;
using HabitTracker.databaseOperations;
public class Menu
{
    public void MostrarMenu()
    {
       bool menuActivo = true;
       int cantidad;
       int id;
       var dbOp = new DatabaseOperations();
       do
        {
        Console.Clear();
        Console.WriteLine("* * * HabitTracker * * * ");
        Console.WriteLine("1. Agregar ocurrencia de hábito");
        Console.WriteLine("2. Registrar hábito nuevo");
        Console.WriteLine("3. Ver hábitos");
        Console.WriteLine("4. Eliminar hábito");
        Console.WriteLine("0. Salir\n");
        Console.Write("> ");

        int opt = int.TryParse(Console.ReadLine(), out  opt) ? opt : 0;

        switch (opt)
        {
            case 1:

                DateTime fecha; 
                
                dbOp.MostrarHabitosDisponibles();
                Console.WriteLine("Ingrese el ID del hábito que desea registrar: ");
                id = int.TryParse(Console.ReadLine(), out id) ? id : -1;

                try
                    {
                        Console.WriteLine("Ingrese fecha ");
                        Console.Write("> ");
                        fecha = DateTime.Parse(Console.ReadLine());
                    }
                catch (FormatException)
                    {
                        Console.WriteLine("Formato de fecha inválido. Se usará la fecha actual.");
                        Console.Write("> ");
                        fecha = DateTime.Now;
                    }
                
                Console.WriteLine("Ingrese cantidad ");
                cantidad = int.TryParse(Console.ReadLine(), out cantidad) ? cantidad : 0;
            
                dbOp.AgregarHabito(fecha,cantidad,id);
                break;
            case 2:
                string nombre, unidad;

                Console.Write("Ingrese el nombre del hábito: ");
                nombre = Console.ReadLine();

                Console.Write("Ingrese el tipo de habito del hábito (medido por unidad, ej: vasos de agua, veces que sali a caminar, etc): ");
                unidad = Console.ReadLine();

                dbOp.RegistrarHabito(nombre, unidad);
                break;
            case 3:
                dbOp.MostrarHabitosDisponibles();
                Console.WriteLine("Presione cualquier tecla para continuar...");
                Console.ReadKey();
                break;
            case 4:
                dbOp.MostrarHabitosDisponibles();
                Console.WriteLine("Ingrese el ID del hábito que desea eliminar: ");
                id = int.TryParse(Console.ReadLine(), out id) ? id : -1;

                if (id != -1)
                    {
                        dbOp.EliminarHabito(id);
                    } 
                    else
                    {
                        Console.WriteLine("ID inválido. No se eliminará ningún hábito.");
                        Console.Write("Presione cualquier tecla para continuar... > ");
                        Console.ReadKey();
                    }
                break;
            case 0:
                menuActivo = false; 
                Console.WriteLine("Saliendo...");
                Thread.Sleep(1000);
                break;
            default:
                Console.WriteLine("Opción inválida. Intente de nuevo.");
                break;
        }
       } while (menuActivo); 
    }
}