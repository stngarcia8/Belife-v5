namespace Belife.Domain.Test.Recargo.Vehiculo
{
    using Belife.Domain.Recargo;
    using Belife.Domain;
    using Belife.Domain.Recargo.Vehiculo;
    using System;
    using Xunit;

    public class RecargoPorEdadDuenoVehiculoTest
    {

        private DateTime fecha;
        Double valorEsperado;
        IRecargo recargo;


        private Double ObtenerRecargo(DateTime fecha)
        {
            recargo = RecargoPorEdadDuenoVehiculo.CrearRecargo(fecha);
            return recargo.RecargoAplicado;
        }


        [Fact]
        public void ErrorAlEnviarUnaFechaDeNacimientoNula()
        {
            Assert.Throws<DateNullException>(() => RecargoPorEdadDuenoVehiculo.CrearRecargo(null));
        }


        [Fact]
        public void ErrorAlSerDueñoMenorDeEdad()
        {
            fecha = new DateTime(DateTime.Now.Year - 17, 1, 1);
            Assert.Throws<InvalidDateException>(() => RecargoPorEdadDuenoVehiculo.CrearRecargo(fecha));
        }


        [Fact]
        public void ObtenerRecargoDeUnoPuntoDosPorcientoSiElDueñoTieneEntreDieciochoYVeinticincoAños()
        {
            valorEsperado = 1.2;
            fecha = new DateTime(DateTime.Now.Year - 18, 1, 1);
            Assert.Equal(valorEsperado, ObtenerRecargo(fecha));

            fecha = new DateTime(DateTime.Now.Year - 25, 1, 1);
            Assert.Equal(valorEsperado, ObtenerRecargo(fecha));
        }


        [Fact]
        public void ObtenerRecargoDeDosPuntoCuatroPorcientoSiElDueñoTieneEntreVeintiseisYCuarentaYCincoAños()
        {
            valorEsperado = 2.4;
            fecha = new DateTime(DateTime.Now.Year - 26, 1, 1);
            Assert.Equal(valorEsperado, ObtenerRecargo(fecha));

            fecha = new DateTime(DateTime.Now.Year - 45, 1, 1);
            Assert.Equal(valorEsperado, ObtenerRecargo(fecha));
        }


        [Fact]
        public void ObtenerRecargoDeTresPuntoDosPorcientoSiElDueñoTieneMasDeCuarentaYCincoAños()
        {
            valorEsperado = 3.2;
            fecha = new DateTime(DateTime.Now.Year - 46, 1, 1);
            Assert.Equal(valorEsperado, ObtenerRecargo(fecha));
        }


    }
}
