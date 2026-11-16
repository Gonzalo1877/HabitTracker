namespace HabitTracker.menu;
using HabitTracker.databaseOperations;
using HabitTracker.utils;
public class Menu
{
    public void MostrarMenu()
    {
       bool menuActivo = true;
       int cantidad;
       int habitId, ocurrenciaId;
       var dbOp = new DatabaseOperations();
       var utils = new Utils();
       DateTime fecha; 

       
       do
        {
        Console.Clear();
        Console.WriteLine("* * * HabitTracker * * * ");
        Console.WriteLine("1. Agregar ocurrencia de hábito");
        Console.WriteLine("2. Registrar hábito nuevo");
        Console.WriteLine("3. Ver hábitos");
        Console.WriteLine("4. Ver ocurrencias de un hábito");
        Console.WriteLine("5. Eliminar hábito");
        Console.WriteLine("6. Eliminar ocurrencias de habito");
        Console.WriteLine("7. Editar ocurrencias de hábito");
        Console.WriteLine("0. Salir\n");
        Console.Write("> ");

        int opt = int.TryParse(Console.ReadLine(), out  opt) ? opt : 0;

        switch (opt)
        {
            case 1:
                dbOp.MostrarHabitosDisponibles();

                habitId = utils.LeerPositivo("Ingrese el ID del hábito que desea registrar");
                if (!dbOp.ValidarId(habitId)) break;

                fecha = utils.LeerFecha("Ingrese fecha (YYYY-MM-DD): ");
                cantidad = utils.LeerPositivo("Ingrese la cantidad: ");

                dbOp.AgregarHabito(fecha,cantidad,habitId);
                break;
            case 2:
                string nombre, unidad;

                nombre = utils.LeerCadena("Ingrese el nombre del hábito");
                unidad = utils.LeerCadena("Ingrese el tipo de hábito (medido por unidad, ej: vasos de agua, veces que sali a caminar, etc): ");

                dbOp.RegistrarHabito(nombre, unidad);
                break;
            case 3:
                dbOp.MostrarHabitosDisponibles();
                utils.Pausar();
                break;
            case 4: 
                dbOp.MostrarHabitosDisponibles();

                habitId = utils.LeerPositivo("Ingrese el ID del hábito del que desea ver las ocurrencias");
                if (!dbOp.ValidarId(habitId)) break;    
                    
                dbOp.MostrarOcurrenciasHabito(habitId);

                utils.Pausar();
                break;
            case 5:
                dbOp.MostrarHabitosDisponibles();

                habitId = utils.LeerPositivo("Ingrese el ID del hábito que desea eliminar: ");
                if (!dbOp.ValidarId(habitId)) break;

                dbOp.EliminarHabito(habitId);
            
                break;
            case 6: 
                dbOp.MostrarHabitosDisponibles();
 
                habitId = utils.LeerPositivo("Ingrese el ID del hábito cuyas ocurrencias desea eliminar: ");
                if (!dbOp.ValidarId(habitId)) break;

                dbOp.EliminarOcurrencias(habitId);
             
                break;
            case 7:
                dbOp.MostrarHabitosDisponibles();
                habitId = utils.LeerPositivo("Ingrese el ID del hábito cuyas ocurrencias desea editar: ");
                if (!dbOp.ValidarId(habitId)) break;

                dbOp.MostrarOcurrenciasHabito(habitId);
                ocurrenciaId = utils.LeerPositivo("Ingrese el ID de la ocurrencia que desea editar: ");
                if (!dbOp.ValidarOcurrencia(ocurrenciaId, habitId)) break;

                fecha = utils.LeerFecha("Ingrese la nueva fecha (YYYY-MM-DD): ");

                cantidad = utils.LeerPositivo("Ingrese la nueva cantidad: ");

                dbOp.ActualizarOcurrencia(ocurrenciaId,habitId, fecha, cantidad);
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