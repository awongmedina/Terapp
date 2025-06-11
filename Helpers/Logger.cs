using System;
using System.IO;
using System.Reflection;

public static class Logger
{
    private static readonly string logFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "logs.txt");

    public static void RegistrarError(Exception ex, string metodo)
    {
        try
        {
            using (StreamWriter sw = new StreamWriter(logFilePath, true))
            {
                sw.WriteLine($"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] Método: {metodo}");
                sw.WriteLine($"Mensaje: {ex.Message}");
                sw.WriteLine($"StackTrace: {ex.StackTrace}");
                sw.WriteLine(new string('-', 50)); // Separador visual
            }
        }
        catch (Exception logEx)
        {
            Console.WriteLine($"Error al registrar el log: {logEx.Message}");
        }
    }
}