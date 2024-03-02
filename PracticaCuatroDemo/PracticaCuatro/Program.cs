public abstract class Vehiculo
{
    public abstract string Nombre { get; }
    public abstract void Encender();
    public abstract void Apagar();
}

public abstract class VehiculoMotorizado : Vehiculo
{
    public abstract override string Nombre { get; }

    public abstract int NumeroRuedas { get; }

    public sealed override void Encender()
    {
        Console.WriteLine("Encendiendo el motor...");
    }

    public abstract override void Apagar();
}

public sealed class Automovil : VehiculoMotorizado
{
    public override string Nombre => "Automovil";

    public override int NumeroRuedas => 4;

    public string Color { get; set; }

    public Automovil(string color)
    {
        Color = color;
    }

    public double VelocidadMaxima()
    {
        return 200;
    }

    public sealed override void Apagar()
    {
        Console.WriteLine("Apagando el automovil...");
    }
}

internal class Program
{
    private static void Main(string[] args)
    {
        Automovil automovil = new Automovil("Rojo");
        Console.WriteLine($"Nombre: {automovil.Nombre}");
        Console.WriteLine($"Numero de ruedas: {automovil.NumeroRuedas}");
        Console.WriteLine($"Color: {automovil.Color}");
        automovil.Encender();
        automovil.Apagar();
        Console.WriteLine($"Velocidad máxima: {automovil.VelocidadMaxima()} km/h");

        Automovil automovil1 = new Automovil("Verde");
        Console.WriteLine($"Color: {automovil1.Color}");

    }
}