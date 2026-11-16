namespace HabitTracker.utils;

public class Utils
{
    public void Pausar()
    {
        Console.WriteLine("\nPresione cualquier tecla para continuar...");
        Console.ReadKey();
    }

    public int LeerPositivo(string mensaje)
    {
        string? entrada;
        int valor;

        while (true)
        {
            Console.Write($"{mensaje} > ");
            entrada = Console.ReadLine();

            if (int.TryParse(entrada, out valor) && valor > 0)
            {
                return valor;
            }
            else
            {
                Console.WriteLine("Por favor, ingrese un número entero positivo.");
            }
        }
    }

    public string LeerCadena(string mensaje)
    {
        string? entrada;

        while (true)
        {
            Console.Write($"{mensaje} > ");
            entrada = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(entrada))
            {
                return entrada;
            }
            else
            {
                Console.WriteLine("Por favor, ingrese un valor no vacío.");
            }
        }
    }

    public DateTime LeerFecha(string mensaje)
    {
        string? entrada;
        DateTime fecha;

        while (true)
        {
            Console.Write($"{mensaje} > ");
            entrada = Console.ReadLine();

            if (DateTime.TryParseExact(entrada, "yyyy-MM-dd", null, System.Globalization.DateTimeStyles.None, out fecha))
            {
                return fecha;
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Por favor, ingrese una fecha válida en el formato YYYY-MM-DD.");
            }
        }
    }
}