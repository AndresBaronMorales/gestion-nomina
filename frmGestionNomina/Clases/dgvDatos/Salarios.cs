namespace frmGestionNomina.Clases.dgvDatos
{
    internal class Salarios
    {
        private string identificacion;
        private string nombres;
        private string apellidos;
        private double salarioBasico;
        private double salarioDevengado;
        private double totalDevengado;
        private double netoPagado;

        public Salarios(string identificacion, string nombres, string apellidos, double salarioBasico, double salarioDevengado, double totalDevengado, double netoPagado)
        {
            this.identificacion = identificacion;
            this.nombres = nombres;
            this.apellidos = apellidos;
            this.salarioBasico = salarioBasico;
            this.salarioDevengado = salarioDevengado;
            this.totalDevengado = totalDevengado;
            this.netoPagado = netoPagado;
        }

        public string Identificacion { get => identificacion; set => identificacion = value; }
        public string Nombres { get => nombres; set => nombres = value; }
        public string Apellidos { get => apellidos; set => apellidos = value; }
        public double SalarioBasico { get => salarioBasico; set => salarioBasico = value; }
        public double SalarioDevengado { get => salarioDevengado; set => salarioDevengado = value; }
        public double TotalDevengado { get => totalDevengado; set => totalDevengado = value; }
        public double NetoPagado { get => netoPagado; set => netoPagado = value; }
    }
}
