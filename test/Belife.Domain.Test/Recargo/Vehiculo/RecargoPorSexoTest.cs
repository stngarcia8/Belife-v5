namespace Belife.Domain.Test.Recargo.Vehiculo
{

    using Belife.Domain.Recargo;
    using Belife.Domain.Recargo.Vehiculo;
    using System;
    using Xunit;


    public class RecargoPorSexoTest
    {

        Double valorEsperado;
        IRecargo recargo;


        private Double ObtenerRecargo(String sexo)
        {
            recargo = RecargoPorSexo.CrearRecargo(sexo);
            return recargo.RecargoAplicado;
        }


        [Fact]
        public void ErrorAlEnviarElSexoConValorNulo()
        {
            Assert.Throws<SexNullException>(() => RecargoPorSexo.CrearRecargo(null));
        }


        [Fact]
        public void ErrorAlEnviarUnSexoNoEspecificadoComoMasculinoOFemenino()
        {
            Assert.Throws<InvalidSexException>(() => RecargoPorSexo.CrearRecargo("otro"));
        }


        [Fact]
        public void ErrorAlEspecificarElSexoVacio()
        {
            Assert.Throws<SexNullException>(() => RecargoPorSexo.CrearRecargo(String.Empty));
        }


        [Fact]
        public void ObtenerRecargoDeCeroPuntoCuatroPorcientoSiElDueñoDelVehiculoEsDeSexoFemenino()
        {
            valorEsperado = 0.4;
            Assert.Equal(valorEsperado, ObtenerRecargo("femenino"));
        }


        [Fact]
        public void ObtenerRecargoDeCeroPuntoOchoPorcientoSiElDueñoDelVehiculoEsDeSexoMasculino()
        {
            valorEsperado = 0.8;
            Assert.Equal(valorEsperado, ObtenerRecargo("masculino"));
        }


    }
}
