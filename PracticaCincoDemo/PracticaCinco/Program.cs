public class PersonaClase
{
    public string Nombre { get; set; }
    public int Edad { get; set; }

}

public struct PersonaStruct
{
    public string Nombre { get; set; }
    public int Edad { get; set; }
}

internal class Program
{
    private static void Main(string[] args)
    {
        PersonaClase persona1 = new PersonaClase();
        persona1.Nombre = "Juan";
        persona1.Edad = 5;

        PersonaClase persona2 = new PersonaClase();
        persona2 = persona1; //Se hace una referencia

        persona2.Nombre = "Pedro";

        Console.WriteLine($"Persona 1: Nombre = {persona1.Nombre}, Edad = {persona1.Edad}");
        Console.WriteLine($"Persona 2: Nombre = {persona2.Nombre}, Edad = {persona2.Edad}");


        //
        PersonaStruct personaStruct1 = new PersonaStruct();
        personaStruct1.Nombre = "Juan";
        personaStruct1.Edad = 5;

        PersonaStruct PersonaStruct2 = personaStruct1; //Se hace una copia
        PersonaStruct2.Nombre = "Maria"; 


        Console.WriteLine($"Persona 1: Nombre = {personaStruct1.Nombre}, Edad = {personaStruct1.Edad}");
        Console.WriteLine($"Persona 2: Nombre = {PersonaStruct2.Nombre}, Edad = {PersonaStruct2.Edad}");
    }
}