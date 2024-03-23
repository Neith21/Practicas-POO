using Spectre.Console;

public enum Departemento
{
    IT,
    HR,
    Sales,
    Merketing
}

public class Employee
{
    public string Name { get; set; }
    public Departemento Department { get; set; }
}

internal class Program
{
    private static void Main(string[] args)
    {
        var employees = new Dictionary<int, Employee>();

        while (true)
        {
            AnsiConsole.WriteLine();
            AnsiConsole.WriteLine("1. Agregar empleado.");
            AnsiConsole.WriteLine("2. Mostrar todos los empleados.");

            AnsiConsole.WriteLine("3. Salir.");
            AnsiConsole.WriteLine();

            var choice = AnsiConsole.Ask<int>("Seleccione un opción: ");

            switch (choice)
            {
                case 1:
                    AddEmployee(employees);
                    break;
                case 2:
                    ShowEmployees(employees);
                    break;
                case 3:
                    AnsiConsole.WriteLine("¡Hasta luego!");
                    return;
                default:
                    AnsiConsole.WriteLine("Opción no válida. Por favor, intente de nuevo.");
                    break;
            }
        }
    }

    static void AddEmployee(Dictionary<int, Employee> employees)
    {
        var id = AnsiConsole.Ask<int>("Ingresa el ID del empleado: ");
        var name = AnsiConsole.Ask<string>("Ingresa el nombre del empleado: ");
        var department = AnsiConsole.Prompt(
                new SelectionPrompt<Departemento>()
                .Title("Selecciona el departamento del empleado:")
                .AddChoices(Departemento.IT, Departemento.HR, Departemento.Sales, Departemento.Merketing)
                .PageSize(4)
            );

        employees[id] = new Employee { Name = name, Department = department };

        AnsiConsole.WriteLine("Empleado agregado con éxito.");
    }

    static void ShowEmployees(Dictionary<int, Employee> employees)
    {
        if (employees.Count == 0)
        {
            AnsiConsole.WriteLine("No hay empleados para mostrar.");
            return;
        }

        var table = new Table().Border(TableBorder.DoubleEdge);
        table.AddColumn("ID").Centered();
        table.AddColumn("Nombre");
        table.AddColumn("Departamento");

        foreach (var employee in employees)
        {
            table.AddRow(employee.Key.ToString(), employee.Value.Name, employee.Value.Department.ToString());
        }

        AnsiConsole.Render(table);
    }
}