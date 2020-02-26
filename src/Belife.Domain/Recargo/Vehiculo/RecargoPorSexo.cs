namespace Belife.Domain.Recargo.Vehiculo
{
    using System;

    public sealed class RecargoPorSexo : Recargo
    {
        private String sexo;

        private RecargoPorSexo(String sexo)
            : base()
        {
            if (string.IsNullOrEmpty(sexo))
            {
                throw new SexNullException("El sexo de la persona dueña del vehiculo no puede tener un valor nulo.");
            }
            this.sexo = sexo.ToLower();
            this.ValidaSexo();
            this.recargo = this.CalculaRecargo();
        }

        public static IRecargo CrearRecargo(String sexo)
        {
            return new RecargoPorSexo(sexo);
        }

        private void ValidaSexo()
        {
            if (!this.sexo.Equals("masculino") && !this.sexo.Equals("femenino"))
            {
                throw new InvalidSexException("El valor para el campo sexo debe comprender entre 'Masculino' y 'Femenino'.");
            }
        }

        private Double CalculaRecargo()
        {
            return (this.sexo.Equals("masculino") ? 0.8 : 0.4);
        }
    }
}
