/*Crear un struct que implemente una interfaz para calcular el área de un círculo, un
triángulo y un cuadrado. El usuario debe ingresar los datos correspondientes para
realizar los cálculos.*/

interface ICalcularArea
{
    double CalcularArea();
}

struct Circulo : ICalcularArea
{
    public double Radio { get; set; }

    public double CalcularArea()
    {
        return Math.PI * Math.Pow(Radio, 2);
    }
}

struct Triangulo : ICalcularArea
{
    public double Base { get; set; }
    public double Altura { get; set; }

    public double CalcularArea()
    {
        return (Base * Altura) / 2;
    }
}

struct Cuadrado : ICalcularArea
{
    public double Lado { get; set; }

    public double CalcularArea()
    {
        return Math.Pow(Lado, 2);
    }
}

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Ingrese los datos de la forma geometrica: ");

        //Circulo
        Console.WriteLine("Radio del circulo");
        double radioCirculo = Convert.ToDouble(Console.ReadLine());

        //Triangulo
        Console.WriteLine("Ingrese la base del triangulo: ");
        double baseTriangulo = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine("Ingrese la altura del triangulo: ");
        double alturaTriangulo = Convert.ToDouble(Console.ReadLine());

        //Cuadrado
        Console.WriteLine("Lado del cuadrado: ");
        double lado = Convert.ToDouble(Console.ReadLine());

        Circulo circulo = new Circulo { Radio = radioCirculo };
        Triangulo triangulo = new Triangulo { Base = baseTriangulo, Altura = alturaTriangulo };
        Cuadrado cuadrado = new Cuadrado { Lado = lado };

        Console.WriteLine("Areas calculadas: ");
        Console.WriteLine($"Area del circulo: {circulo.CalcularArea():F2}");
        Console.WriteLine($"Area del triangulo: {triangulo.CalcularArea()}");
        Console.WriteLine($"Area del cuadrado: {cuadrado.CalcularArea()}");
    }
}