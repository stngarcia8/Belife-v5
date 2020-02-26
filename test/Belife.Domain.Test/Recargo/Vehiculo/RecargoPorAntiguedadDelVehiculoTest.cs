namespace Belife.Domain.Test.Recargo.Vehiculo
{
    using System;
    using Belife.Domain.Recargo;
    using Belife.Domain.Recargo.Vehiculo;
    using Xunit;

    public class RecargoPorAntiguedadDelVehiculoTest
    {

        private DateTime fecha;
        Double valorEsperado;
        IRecargo recargo;


        private Double ObtenerRecargo(DateTime fecha)
        {
            recargo = RecargoPorAntiguedadDelVehiculo.CrearRegargo(fecha);
            return recargo.RecargoAplicado;
        }


        [Fact]
        public void ErrorAlEnviarUnaFechaNulaParaLaAntiguedadDelVehiculo()
        {
            Assert.Throws<DateNullException>(() => RecargoPorAntiguedadDelVehiculo.CrearRegargo(null));
        }


        [Fact]
        public void ErrorAlEnviarUnaFechaSuperiorALaFechaActualParaLaAntiguedadDelVehiculo()
        {
            fecha = new DateTime(DateTime.Now.Year + 1, 1, 1);
            Assert.Throws<InvalidDateException>(() => RecargoPorAntiguedadDelVehiculo.CrearRegargo(fecha));
        }


        [Fact]
        public void ObtenerRecargoDeUnoPuntoDosPorcientoSiElVehiculoEsDelAñoEnCurso()
        {
            valorEsperado = 1.2;
            Assert.Equal(valorEsperado, ObtenerRecargo(DateTime.Now));
        }


        [Fact]
        public void ObtenerRecargoDeCeroPuntoOchoPorcientoSiElVehiculoTieneEntreUnoYCincoAños()
        {
            valorEsperado = 0.8;
            fecha = new DateTime(DateTime.Now.Year - 1, 1, 1);
            Assert.Equal(valorEsperado, ObtenerRecargo(fecha));

            fecha = new DateTime(DateTime.Now.Year - 5, 1, 1);
            Assert.Equal(valorEsperado, ObtenerRecargo(fecha));
        }


        [Fact]
        public void ObtenerRecargoDeCeroPuntoCuatroPorcientoSiElVehiculoTieneMasDeCincoAños()
        {
            valorEsperado = 0.4;
            fecha = new DateTime(DateTime.Now.Year - 6, 1, 1);
            Assert.Equal(valorEsperado, ObtenerRecargo(fecha));
        }


    }
}
