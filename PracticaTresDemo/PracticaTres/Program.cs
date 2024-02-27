namespace PracticaTres
{
	public interface IComportanmientoAnimal
	{
		void EmitirSonido();
		void Mover(int distancia);
	}

	public abstract class Animal
	{
		public abstract string Nombre { get; }

		public void MostrarNombre()
		{
			Console.WriteLine($"El nombre del animal es: {Nombre}");
		}

		public int CalcularEdadEnMeses(int edadEnAnyos)
		{
			return edadEnAnyos * 12;
		}

		public abstract void Dormir();

		public abstract void Comer(string comida);

		public void Desplazarse(int distancia)
		{
			Console.WriteLine($"{Nombre} se está desplanzado {distancia} metros.");
		}
	}

	class Gato : Animal, IComportanmientoAnimal
	{
		public override string Nombre => "Gato";

		public override void Comer(string comida)
		{
			Console.WriteLine($"El gato está comiendo {comida}");
		}

		public override void Dormir()
		{
			Console.WriteLine("El gato está durmiendo.");
		}

		public void EmitirSonido()
		{
			Console.WriteLine("¡Miau!");
		}

		public void Mover(int distancia)
		{
			Console.WriteLine("El gato se está moviedo");
		}
	}

	internal class Program
	{
		static void Main(string[] args)
		{
			Gato gato = new Gato();

			gato.MostrarNombre();
			gato.Dormir();
			gato.Comer("Pescado");
			gato.Desplazarse(10);
			gato.EmitirSonido();
			gato.Mover(5);

			int edadEnMeses = gato.CalcularEdadEnMeses(2);
			Console.WriteLine($"La edad del gato en meses es: {edadEnMeses}");
		}
	}
}
