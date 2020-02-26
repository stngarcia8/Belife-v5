namespace Belife.Domain.Recargo.Vehiculo
{
    using System;

    public sealed class RecargoPorAntiguedadDelVehiculo : Recargo
    {
        private readonly DateTime fecha;

        private readonly int antiguedad;

        private RecargoPorAntiguedadDelVehiculo(Nullable<DateTime> fecha)
            : base()
        {
            if (fecha == null)
            {
                throw new DateNullException("La fecha del vehiculo no puede ser un valor nulo.");
            }
            this.fecha = Convert.ToDateTime(fecha);
            this.antiguedad = this.ObtenerAntiguedad();
            this.recargo = this.CalcularRecargo();
        }

        public static IRecargo CrearRegargo(Nullable<DateTime> fecha)
        {
            return new RecargoPorAntiguedadDelVehiculo(fecha);
        }

        private int ObtenerAntiguedad()
        {
            if (this.fecha.Year > DateTime.Now.Year)
            {
                throw new InvalidDateException("El año de antiguedad del vehiculo no puede exceder el valor del año en curso.");
            }
            return DateTime.Now.Year - this.fecha.Year;
        }

        private double CalcularRecargo()
        {
            if (this.antiguedad == 0) return 1.2;
            if (this.antiguedad > 0 && this.antiguedad <= 5) return 0.8;
            return 0.4;
        }
    }
}
