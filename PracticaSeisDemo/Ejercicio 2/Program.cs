/*Crear un programa que ayude a gestionar empleados, debe controlar los gerentes y
los desarrolladores, los desarrolladores pueden obtener un bono y completan 4
proyectos en el año, debe crear los métodos necesarios para calcular el salario y el
bono en caso aplique, el programa debe mostrar el listado de empleados, el listado
por categoría (gerente o desarrollador) y mostrar los salarios. Debe usar clases
abstractas para este ejercicio.*/

abstract class Empleado
{

    public string Nombre { get; set; }
    public double SalarioBase { get; set; }

    public Empleado(string nombre, double salarioBase)
    {
        Nombre = nombre;
        SalarioBase = salarioBase;
    }

    public abstract double CalcularSalario();

    public virtual void MostrarInformacion()
    {
        Console.WriteLine($"Nombre: {Nombre}");
        Console.WriteLine($"Salario base: {SalarioBase}");
    }
}

class Gerente : Empleado
{
    public Gerente(string nombre, double salarioBase) : base( nombre, salarioBase) { }

    public override double CalcularSalario()
    {
        return SalarioBase;
    }

    public override void MostrarInformacion()
    {
        base.MostrarInformacion();
        Console.WriteLine("Cargo: Gerente");
    }
}

class Desarrollador : Empleado
{
    private int proyectosCompletados;

    public Desarrollador(string nombre, double salarioBase) : base ( nombre, salarioBase)
    {
        proyectosCompletados = 0;
    }

    public void CompletarProyecto()
    {
        proyectosCompletados++;
    }

    public override double CalcularSalario()
    {
        double salarioTotal = SalarioBase;
        if (proyectosCompletados >= 4)
        {
            salarioTotal += 1000;
        }
        return salarioTotal;
    }

    public override void MostrarInformacion()
    {
        base.MostrarInformacion();
        Console.WriteLine("Cargo: Desarrollador");
        Console.WriteLine($"Proyectos completados: {proyectosCompletados}");
    }
}

internal class Program
{
    private static void Main(string[] args)
    {
        List<Empleado> empleados = new List<Empleado>();

        empleados.Add(new Gerente("Gerente 1", 5000));
        empleados.Add(new Desarrollador("Desarrollado 1", 6000));
        empleados.Add(new Desarrollador("Desarrollado 2", 6000));

        foreach (var empleado in empleados)
        {
            if (empleado is Desarrollador desarrollador && desarrollador.Nombre == "Desarrollado 1")
            {
                for (int i = 0; i < 4; i++)
                {
                    desarrollador.CompletarProyecto();
                }
            }
        }
        Console.WriteLine("Lista de empleados: ");
        foreach (var empleado in empleados)
        {
            empleado.MostrarInformacion();
            Console.WriteLine($"Salario total: {empleado.CalcularSalario()}");
        }

    }
}