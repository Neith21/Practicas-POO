using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticaCatorce.Login
{
    public static class LoginView
    {
        public static void Menu()
        {
            UserManager userManager = new UserManager();

            while (true)
            {
                Console.Clear();
                var choice = AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                        .Title("[yellow]¿Qué te gustaría hacer?[/]")
                        .AddChoices("Registrarse", "Iniciar Sesión", "Salir"));

                switch (choice)
                {
                    case "Registrarse":
                        Register(userManager);
                        break;
                    case "Iniciar Sesión":
                        Login(userManager);
                        break;
                    case "Salir":
                        return;
                }
            }
        }

        public static void Register(UserManager userManager)
        {
            Console.Clear();
            AnsiConsole.MarkupLine("[underline green]Registro de Usuario[/]");

            var username = AnsiConsole.Ask<string>("Ingrese su [yellow]nombre de usuario[/]:");
            var password = AnsiConsole.Prompt(
                new TextPrompt<string>("Ingrese su [yellow]contraseña[/]:")
                    .PromptStyle("red")
                    .Secret());

            if (userManager.Register(username, password))
            {
                AnsiConsole.MarkupLine("[green]Registro exitoso![/]");
            }
            else
            {
                AnsiConsole.MarkupLine("[red]El usuario ya existe[/]");
            }

            AnsiConsole.MarkupLine("Presione cualquier tecla para continuar");
            Console.ReadKey();
        }

        public static void Login(UserManager userManager)
        {
            Console.Clear();
            AnsiConsole.MarkupLine("[underline green]Inicio de Sesión[/]");

            var username = AnsiConsole.Ask<string>("Ingrese su [yellow]nombre de usuario[/]:");
            var password = AnsiConsole.Prompt(
                new TextPrompt<string>("Ingrese su [yellow]contraseña[/]:")
                    .PromptStyle("red")
                    .Secret());

            if (userManager.Login(username, password))
            {
                AnsiConsole.MarkupLine("[green]Inicio de sesión exitoso![/]");
            }
            else
            {
                AnsiConsole.MarkupLine("[red]Usuario o contraseña son incorrectos![/]");
            }

            AnsiConsole.MarkupLine("Presione cualquier tecla para continuar");
            Console.ReadKey();
        }
    }
}
