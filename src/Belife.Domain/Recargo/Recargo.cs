namespace Belife.Domain.Recargo
{
    using System;

    public abstract class Recargo : IRecargo
    {
        protected Double recargo;

        public Double RecargoAplicado
        {
            get { return this.recargo; }
        }

        protected Recargo()
        {
            this.recargo = 0;
        }
    }
}
