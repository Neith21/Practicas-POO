namespace Test
{
	[TestClass]
	public class cuentaBancariaTests
	{
		[TestMethod]
		public void Depositar_AumentoElSaldo()
		{
			double saldoInicial = 100;
			double montoDeposito = 50;
			CuentaBancaria cuentaBancaria = new CuentaBancaria(saldoInicial);

			cuentaBancaria.Depositar(montoDeposito);

			Assert.AreEqual(150, cuentaBancaria.saldo);
		}

		[TestMethod]
		public void Retirar_DisminuyeElSaldo()
		{
			double saldoInicial = 100;
			double montoRetiro = 50;
			CuentaBancaria cuentaBancaria = new CuentaBancaria(saldoInicial);

			cuentaBancaria.Retirar(montoRetiro);

			Assert.AreEqual(saldoInicial - montoRetiro, cuentaBancaria.saldo);
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentException))]
		public void Depositar_ConMontoNegativo_LanzaArgumentException()
		{
			double saldoInicial = 100;
			double montoDeposito = -50;
			CuentaBancaria cuentaBancaria = new CuentaBancaria(saldoInicial);

			cuentaBancaria.Depositar(montoDeposito);
		}

		[TestMethod]
		[ExpectedException(typeof(SaldoNegativoException))]
		public void Constuctor_ConSaldoNegativo_LanzaSaldoNegativoException()
		{
			double saldoInicial = -100;
			CuentaBancaria cuenta = new CuentaBancaria(saldoInicial);
		}
	}
}