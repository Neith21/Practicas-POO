public interface IGestorLibros
{
    void MostrarLibro();
}

public struct Libro : IGestorLibros
{
    public string Titulo;
    public string Autor;
    public int AnioPublicacion;

    public Libro(string titulo, string autor, int anioPublicacion)
    {
        Titulo = titulo;
        Autor = autor;
        AnioPublicacion = anioPublicacion;
    }

    public void MostrarLibro()
    {
        Console.WriteLine($"Titulo {Titulo}, Autor {Autor}, Año de publicación: {AnioPublicacion}");
    }
}

internal class Program
{
    private static void Main(string[] args)
    {
        List<Libro> libro = new List<Libro>();

        while (true)
        {
            Console.WriteLine("1. Agregar libro.");
            Console.WriteLine("2. Mostrar libro");
            Console.WriteLine("3. Salir");
            Console.Write("Ingrese una opción: ");
            string opcion = Console.ReadLine();

            switch ( opcion )
            {
                case "1":
                    Console.Write("Ingrese el titulo del libro: ");
                    string titulo = Console.ReadLine();
                    Console.Write("Ingrese el autor del libro: ");
                    string autor = Console.ReadLine();
                    Console.Write("Ingrese el año de publicación del libro: ");
                    int anioPublicacion;

                    while(!int.TryParse(Console.ReadLine(), out anioPublicacion))
                    {
                        Console.Write("Año invalido, intente de nuevo: ");
                    }
                    libro.Add(new Libro(titulo, autor, anioPublicacion));
                    break;
                case "2":
                    Console.WriteLine("Lista de libros");
                    foreach (var li in libro)
                    {
                        li.MostrarLibro();
                    }
                    break;
                case "3":
                    Console.WriteLine("Saliendo del programa...");
                    return;
                default:
                    Console.WriteLine("Opción inválida. Intente de nuevo.");
                    break;
            }
        }
    }
}