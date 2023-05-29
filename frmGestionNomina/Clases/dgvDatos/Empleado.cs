namespace frmGestionNomina.Clases.dgvDatos
{
    internal class Empleado
    {
        private string identificacion;
        private string nombres;
        private string apellidos;
        private string tipoDocumento;
        private string numeroDocumento;

        public Empleado(string identificacion,string nombres,string apellidos,string tipoDocumento,string numeroDocumento) {
            this.identificacion = identificacion;
            this.nombres = nombres;
            this.apellidos = apellidos;
            this.tipoDocumento = tipoDocumento;
            this.numeroDocumento = numeroDocumento;
        }

        public string Identificacion { get => identificacion; set => identificacion = value; }
        public string Nombres { get => nombres; set => nombres = value; }
        public string Apellidos { get => apellidos; set => apellidos = value; }
        public string TipoDocumento { get => tipoDocumento; set => tipoDocumento = value; }
        public string NumeroDocumento { get => numeroDocumento; set => numeroDocumento = value; }
    }
}
