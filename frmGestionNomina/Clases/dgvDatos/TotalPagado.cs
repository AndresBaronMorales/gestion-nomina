namespace frmGestionNomina.Clases.dgvDatos
{
    internal class TotalPagado
    {
        private int numeroEmpleados;
        private double salariosBasicos;
        private double salariosDevengados;
        private double totalDevengados;
        private double netoPagados;

        public TotalPagado(int numeroEmpleados, double salariosBasicos, double salariosDevengados, double totalDevengados, double netoPagados)
        {
            this.numeroEmpleados = numeroEmpleados;
            this.salariosBasicos = salariosBasicos;
            this.salariosDevengados = salariosDevengados;
            this.totalDevengados = totalDevengados;
            this.netoPagados = netoPagados;
        }

        public TotalPagado() { }

        public int NumeroEmpleados { get => numeroEmpleados; set => numeroEmpleados = value; }
        public double SalariosBasicos { get => salariosBasicos; set => salariosBasicos = value; }
        public double SalariosDevengados { get => salariosDevengados; set => salariosDevengados = value; }
        public double TotalDevengados { get => totalDevengados; set => totalDevengados = value; }
        public double NetoPagados { get => netoPagados; set => netoPagados = value; }
    }
}
