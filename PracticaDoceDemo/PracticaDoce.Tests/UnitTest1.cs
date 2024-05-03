using Moq;

namespace PracticaDoce.Tests
{
    public class BibliotecaTests
    {
        [TestCase("1984")]
        [TestCase("El Hobbit")]
        public void PrestarLibro_LibroExiste_NoDebeLanzarExcepcion(string titulo)
        {
            var biblioteca = new Biblioteca();
            biblioteca.AgregarLibro("1984", "Juan");
            biblioteca.AgregarLibro("El Hobbit", "Juana");

            Assert.DoesNotThrow(() => biblioteca.PrestarLibro(titulo));
        }

        [Test]
        public void PrestarLibro_LibroNoExistente_DebeLanzarExcepcion()
        {
            var biblioteca = new Biblioteca();
            biblioteca.AgregarLibro("1984", "Juan");

            Assert.Throws<Exception>(() => biblioteca.PrestarLibro("El Hobbit"));
        }

        [Test]
        public void PruebaConcurrente_PrestarYDevolverLibro_SinExcepciones()
        {
            var biblioteca = new Biblioteca();
            biblioteca.AgregarLibro("1984", "Juan");

            Parallel.For(0, 100, _ =>
            {
                biblioteca.PrestarLibro("1984");
                biblioteca.DevolverLibro("1984");
            });
        }

        [Test]
        public void PruebaRendimiento_AgregarMilLibros_EnMenosDeUnSegundo()
        {
            var biblioteca = new Biblioteca();
            var tiempoInicial = DateTime.Now;

            for (int i = 0; i < 1000; i++)
            {
                biblioteca.AgregarLibro($"Libro{i}", $"Autor{i}");
            }

            var tiempoFinal = DateTime.Now;
            var tiempoTotal = tiempoFinal - tiempoInicial;

            Assert.Less(tiempoTotal.TotalSeconds, 1);
        }
    }
}