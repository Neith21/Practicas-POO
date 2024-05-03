using Spectre.Console;

namespace PracticaDoce
{
    public class Libro
    {
        public string Titulo { get; private set; }
        public string Autor { get; private set; }
        public bool EstaPrestado { get; private set; }

        public Libro(string titulo, string autor)
        {
            Titulo = titulo;
            Autor = autor;
            EstaPrestado = false;
        }

        public virtual void Prestar()
        {
            if (EstaPrestado)
                throw new LibroNoDisponibleException("El libro ya está prestado.");
            EstaPrestado = true;
        }


        public void Devolver()
        {
            EstaPrestado = false;
        }
    }

    public class LibroNoDisponibleException : Exception
    {
        public LibroNoDisponibleException(string message) : base(message) { }
    }

    public class Biblioteca
    {
        private List<Libro> libros = new List<Libro>();

        public void AgregarLibro(string titulo, string autor)
        {
            libros.Add(new Libro(titulo, autor));
            AnsiConsole.MarkupLine("[green]Libro agregado exitosamente![/]");
        }

        public void AgregarLibro(Libro libro)
        {
            libros.Add(libro);
            AnsiConsole.MarkupLine("[green]Libro agregado exitosamente![/]");
        }

        public void PrestarLibro(string titulo)
        {
            var libro = libros.Find(l => l.Titulo == titulo);
            if (libro == null)
                throw new Exception("El libro no existe.");
            libro.Prestar();
            AnsiConsole.MarkupLine("[blue]Libro prestado exitosamente![/]");
        }

        public void DevolverLibro(string titulo)
        {
            var libro = libros.Find(l => l.Titulo == titulo);
            if (libro == null)
                throw new Exception("El libro no existe.");
            libro.Devolver();
            AnsiConsole.MarkupLine("[yellow]Libro devuelto exitosamente![/]");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            var biblioteca = new Biblioteca();
            biblioteca.AgregarLibro("1984", "George Orwell");
            biblioteca.AgregarLibro("El Hobbit", "J.R.R. Tolkien");

            try
            {
                biblioteca.PrestarLibro("1984");
                biblioteca.PrestarLibro("1984");
                biblioteca.DevolverLibro("1984");
            }
            catch (Exception ex)
            {
                AnsiConsole.MarkupLine($"[red]{ex.Message}[/]");
            }
        }
    }
}
