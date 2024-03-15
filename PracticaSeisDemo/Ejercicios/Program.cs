/*Crear un programa que ayude a gestionar un sistema de archivos, debe crear las
interfaces necesarias para lograrlo, el programa podrá gestionar diferentes tipos de
archivos como PDFs, Microsoft Word, Excel, PowerPoint, etc. Debe asegurarse que
cada archivo de contener la fecha de creación, el autor del archivo y la última fecha de
modificación. El programa podrá agregar los archivos, mostrar el listado de todos los
archivos, mostrar los archivos por categoría (PDF, Word, etc.). Algunos archivos como
Word, Excel o PowerPoint van a tener un método para poder editarse mientras que los
archivos en PDF no. El programa debe simular que se realizó un cambio en el archivo
seleccionado para editar siempre y cuando no sea un PDF.*/

interface IEditable
{
    void Editar();
}

abstract class Archivo
{
    public string Nombre { get; set; }
    public DateTime FechaCreacion { get; set; }
    public string Autor { get; set; }
    public DateTime UltimaModificacion { get; set; }

    public Archivo(string nombre, string autor)
    {
        Nombre = nombre;
        FechaCreacion = DateTime.Now;
        Autor = autor;
        UltimaModificacion = FechaCreacion;
    }

    public abstract void MostrarInformacion();
}

class PDF : Archivo
{
    public PDF(string nombre, string autor) : base(nombre, autor) { }

    public override void MostrarInformacion()
    {
        Console.WriteLine($"Nombre: {Nombre}");
        Console.WriteLine($"Fecha de creación: {FechaCreacion}");
        Console.WriteLine($"Autor: {Autor}");
        Console.WriteLine($"Última modificación: {UltimaModificacion}");
        Console.WriteLine($"Este archivo no puede ser editado.");
    }
}

class Editable : Archivo, IEditable
{
    public Editable(string nombre, string autor) : base(nombre, autor) { }

    public override void MostrarInformacion()
    {
        Console.WriteLine($"Nombre: {Nombre}");
        Console.WriteLine($"Fecha de creación: {FechaCreacion}");
        Console.WriteLine($"Autor: {Autor}");
        Console.WriteLine($"Última modificación: {UltimaModificacion}");
    }

    public void Editar()
    {
        Console.WriteLine($"Editando {Nombre}...");
        UltimaModificacion = DateTime.Now;
        Console.WriteLine($"Edición completada. Última fecha de modificación: {UltimaModificacion}");
    }
}

internal class Program
{
    private static void Main(string[] args)
    {
        List<Archivo> archivos = new List<Archivo>();

        bool salir = false;
        while (!salir)
        {
            Console.WriteLine("1. Agregar archivo.");
            Console.WriteLine("2. Listar archivos.");
            Console.WriteLine("3. Editar archivos.");
            Console.WriteLine("4. Salir.");
            Console.Write("Ingrese una opción: ");
            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    Console.WriteLine("1. PDF.");
                    Console.WriteLine("2. WORD.");
                    Console.Write("Seleccione el tipo de archivo: ");
                    string seleccion = Console.ReadLine();

                    Console.WriteLine("Nombre del archivo");
                    string nombre = Console.ReadLine();
                    Console.WriteLine("Autor: ");
                    string autor = Console.ReadLine();

                    Archivo nuevoArchivo;
                    if (seleccion == "1")
                    {
                        nuevoArchivo = new PDF(nombre + ".pdf", autor);
                    }
                    else if (seleccion == "2")
                    {
                        nuevoArchivo = new Editable(nombre + ".pdf", autor);
                    }
                    else
                    {
                        Console.WriteLine("Opción inválida.");
                        break;
                    }
                    archivos.Add(nuevoArchivo);
                    Console.WriteLine("Archivo agregado con exito.");
                    break;

                case "2":
                    Console.WriteLine("Listado de archivos:");
                    foreach (var archivo in archivos)
                    {
                        archivo.MostrarInformacion();
                        Console.WriteLine();
                    }
                    break;
                case "3":
                    Console.WriteLine("Ingrese el indice del archivo que desea editar: ");
                    for (int i = 0; i < archivos.Count; i++)
                    {
                        Console.WriteLine($"{i}. {archivos[i].Nombre}");
                    }
                    Console.Write("Indice: ");
                    int indice;

                    if (int.TryParse(Console.ReadLine(), out indice) && indice >= 0 && indice < archivos.Count)
                    {
                        if (archivos[indice] is IEditable editable)
                        {
                            editable.Editar();
                        }
                        else
                        {
                            Console.WriteLine("El archivo seleccionado no puede ser editado.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Ingrese una opción valida.");
                    }
                    break;

                case "4":
                    salir = true;
                    break;
                default:
                    Console.WriteLine("Opción inválida.");
                    break;
            }
        }
    }
}