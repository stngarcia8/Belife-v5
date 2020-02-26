namespace Belife.Domain.Recargo.Vehiculo
{
    using System;
    using Belife.Domain.Recargo;

    public sealed class RecargoPorEdadDuenoVehiculo : Recargo
    {
        private DateTime fecha;

        private int edad;

        private RecargoPorEdadDuenoVehiculo(Nullable<DateTime> fecha)
            : base()
        {
            if (fecha == null)
            {
                throw new DateNullException("La fecha de nacimiento del dueño del vehiculo no puede tener un valor nulo.");
            }
            this.fecha = Convert.ToDateTime(fecha);
            this.edad = this.ObtenerEdad();
            this.recargo = this.CalcularRecargo();
        }

        public static IRecargo CrearRecargo(Nullable<DateTime> fecha)
        {
            return new RecargoPorEdadDuenoVehiculo(fecha);
        }

        private int ObtenerEdad()
        {
            int myEdad = DateTime.Now.Year - this.fecha.Year;
            if (myEdad < 18)
            {
                throw new InvalidDateException("Solo se permiten clientes que tengan la mayoria de edad.");
            }
            return myEdad;
        }

        private double CalcularRecargo()
        {
            if (this.edad >= 18 && this.edad <= 25) return 1.2;
            if (this.edad >= 26 && this.edad <= 45) return 2.4;
            return 3.2;
        }
    }
}
