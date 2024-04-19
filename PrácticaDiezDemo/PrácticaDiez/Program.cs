using Spectre.Console;

record Person(string Name, int Age);

internal class Program
{
    private static void Main(string[] args)
    {
        string csvFilePath = PromptFilePath();

        DataRetriver dataRetriver = new DataRetriver(csvFilePath);

        List<Person> people = dataRetriver.LoadPeople();

        var adults = people.Where(p => p.Age >= 18);

        RenderResults(adults);
    }

    static string PromptFilePath()
    {
        AnsiConsole.MarkupLine("[yellow]Ingrese la ruta del archivo CVS:[/]");
        return AnsiConsole.Ask<string>("Ruta del archivo:");
    }

    static void RenderResults(IEnumerable<Person> people)
    {
        var table = new Table();

        table.AddColumn("Nombre");
        table.AddColumn("Edad");

        foreach (var person in people)
        {
            table.AddRow(person.Name, person.Age.ToString());
        }

        AnsiConsole.Render(table);
    }
}

class DataRetriver
{
    private string _csvFilePath;

    public DataRetriver(string csvFilePath)
    {
        _csvFilePath = csvFilePath;
    }

    public List<Person> LoadPeople()
    {
        List<Person> people = new List<Person>();

        string[] lines = File.ReadAllLines(_csvFilePath);

        foreach (var line in lines)
        {
            string[] parts = line.Split(',');

            Person person = new Person(parts[0], Convert.ToInt32(parts[1]));
            people.Add(person);
        }

        return people;
    }
}