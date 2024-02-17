public interface IPrestable
{
	void Pestar();
	void Devolver();

}

public class Persona
{
	public string Nombre { get; set; }
	public int Edad { get; set; }
}

public class Autor : Persona
{
	List<Libro> libros { get; set; }
}

public class Libro : IPrestable
{
	public string Titulo { get; set; }
	public Autor Autor { get; set; }

	public void Devolver()
	{
		Console.WriteLine("El libro ha sido devuelto.");
	}

	public void Pestar()
	{
		Console.WriteLine("El libro ha sido prestado.");
	}
}

public class Bibliotecario : Persona
{
	public void RegistrarPrestamo(Libro libro, Persona persona)
	{
		Console.WriteLine($"El libro {libro.Titulo}, del autor {libro.Autor.Nombre} ha sido prestado a {persona.Nombre}");
	}
}

public class Usuario : Persona
{
	public List<Libro> librosPrestados { get; set; }
}

internal class Program
{
	private static void Main(string[] args)
	{
		Autor autor = new Autor { Nombre = "Gabriel García Márquez", Edad = 91};
		Libro libro = new Libro { Titulo = "Cien años de soledad", Autor = autor };

		Bibliotecario bibliotecario = new Bibliotecario { Nombre = "Luisa", Edad = 35};
		Usuario usuario = new Usuario { Nombre = "Juan", Edad = 25 };

		bibliotecario.RegistrarPrestamo(libro, usuario);
		libro.Pestar();
		libro.Devolver();
	}
}