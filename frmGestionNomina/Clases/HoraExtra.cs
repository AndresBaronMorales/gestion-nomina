namespace frmGestionNomina.Clases
{
    internal class HoraExtra
    {
        private string nombre;
        private double valor;

        public HoraExtra(string nombre,double valor) {
            this.nombre = nombre;
            this.valor = valor;
        }

        public HoraExtra() { }

        public string Nombre { get => nombre; set => nombre = value; }
        public double Valor { get => valor; set => valor = value; }
    }
}
