using Spectre.Console;
 public class CuentaBancaria
{
    public double saldo;

    public CuentaBancaria(double saldoInicial)
    {
        if (saldoInicial < 0)
        {
            throw new SaldoNegativoException("El saldo inicial no puede ser negativo.");
        }
        this.saldo = saldoInicial;
    }

    public void Depositar(double monto)
    {
        if (monto <= 0)
        {
            throw new ArgumentException("El monto del deposito debe ser positivo.");
        }
        saldo += monto;
        AnsiConsole.MarkupLine($"[bold green]Deposito de {monto} realizado[/] Nuevo saldo: {saldo}");
    }

    public void Retirar(double monto)
    {
        if (monto <= 0)
        {
            throw new ArgumentException("El monto del retiro debe ser positivo.");
        }
        if (saldo < monto)
        {
            throw new SaldoInsuficienteException("Saldo insufuciente para realizar el retiro.");
        }
        saldo -= monto;
        AnsiConsole.MarkupLine($"[bold green]Retiro de {monto} realizado.[/] Nuevo saldo: {saldo}");
    }

    public void Transferir(CuentaBancaria destino, double monto)
    {
        Retirar(monto);
        destino.Depositar(monto);
        AnsiConsole.MarkupLine($"[bold green]Transferencia de {monto} realizada.[/] De esta cuenta a la cuenta destino.");
    }
}

public class SaldoNegativoException : Exception
{
    public SaldoNegativoException(string message) : base(message)
    { }
}

public class SaldoInsuficienteException : Exception
{
    public SaldoInsuficienteException(string message) : base(message)
    { }
}

public class Program
{
    private static void Main(string[] args)
    {
        AnsiConsole.MarkupLine($"[bold yellow]Bienvenido a la aplicación de transferencia bancaria[/]");
        AnsiConsole.WriteLine();

        try
        {
            Console.WriteLine("Ingrese el saldo inicial para la cuenta uno.");
            double saldoInicial1 = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Ingrese el saldo inicial para la cuenta dos.");
            double saldoInicial2 = Convert.ToDouble(Console.ReadLine());

            CuentaBancaria cuenta1 = new CuentaBancaria(saldoInicial1);
            CuentaBancaria cuenta2 = new CuentaBancaria(saldoInicial2);

            Console.WriteLine("Ingrese el monto a transferir de la cuenta 1 a la cuenta 2:");
            double montoTransferencia = Convert.ToDouble(Console.ReadLine());

            cuenta1.Transferir(cuenta2, montoTransferencia);
        }
        catch (SaldoInsuficienteException ex)
        {
            AnsiConsole.MarkupLine($"[bold red]Error:[/] {ex.Message}");
        }
        catch (SaldoNegativoException ex)
        {
            AnsiConsole.MarkupLine($"[bold red]Error:[/] {ex.Message}");
        }
        catch (ArgumentException ex)
        {
            AnsiConsole.MarkupLine($"[bold red]Error:[/] {ex.Message}");
        }
        catch (Exception ex)
        {
            AnsiConsole.MarkupLine($"[bold red]Error:[/] {ex.Message}");
        }
    }
}