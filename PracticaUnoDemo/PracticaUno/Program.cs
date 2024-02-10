public class Empleado
{
	public string Nombre { get; set; }
	public string Departamento { get; set; }
	public double Salario { get; set;}

    public Empleado(string Nombre, string departamento, double salario)
    {
		this.Nombre = Nombre;
		Departamento = departamento;
		Salario = salario;
    }

	public virtual double CalcularBono()
	{
		return Salario * 0.1;
	}
}

public class Gerente : Empleado
{
	public string AreaResponsabilidad { get; set; }

    public Gerente(string x, string departamento, double salario, string areaResponsabilidad)
		: base(x, departamento, salario)
	{
		AreaResponsabilidad = areaResponsabilidad;
    }

	public override double CalcularBono() 
	{ 
		return Salario * 0.15;
	}
}

internal class Program
{
	private static void Main(string[] args)
	{
		List<Empleado> empleados = new List<Empleado>();

		empleados.Add(new Empleado("Juan", "Ventas", 2000));
		empleados.Add(new Gerente("Maria", "Marketing", 3000, "Campañas"));

		foreach (var empleado in empleados)
		{
			Console.WriteLine($"Nombre: {empleado.Nombre}, Departamento: {empleado.Departamento}, Salario: {empleado.Salario}, Bono: {empleado.CalcularBono()}");
		}
	}
}
