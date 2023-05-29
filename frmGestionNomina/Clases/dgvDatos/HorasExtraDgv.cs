namespace frmGestionNomina.Clases.dgvDatos
{
    internal class HorasExtraDgv
    {
        private string identificacion;
        private string nombres;
        private string apellidos;
        private int recargoNocturnoHoras;
        private double recargoNocturnoValor;
        private int extraDiurnaHoras;
        private double extraDiurnaValor;
        private int extraNocturnaHoras;
        private double extraNocturnaValor;
        private int ordinariaDominicalFestivoHoras;
        private double ordinariaDominicalFestivoValor;
        private int diurnaDominicalFestivoHoras;
        private double diurnaDominicalFestivoValor;
        private int nocturnaDominicalFestivoHoras;
        private double nocturnaDominicalFestivoValor;

        public HorasExtraDgv(string identificacion, string nombres, string apellidos, int recargoNocturnoHoras, double recargoNocturnoValor, int extraDiurnaHoras, double extraDiurnaValor, int extraNocturnaHoras, double extraNocturnaValor, int ordinariaDominicalFestivoHoras, double ordinariaDominicalFestivoValor, int diurnaDominicalFestivoHoras, double diurnaDominicalFestivoValor, int nocturnaDominicalFestivoHoras, double nocturnaDominicalFestivoValor)
        {
            this.Identificacion = identificacion;
            this.Nombres = nombres;
            this.Apellidos = apellidos;
            this.RecargoNocturnoHoras = recargoNocturnoHoras;
            this.RecargoNocturnoValor = recargoNocturnoValor;
            this.ExtraDiurnaHoras = extraDiurnaHoras;
            this.ExtraDiurnaValor = extraDiurnaValor;
            this.ExtraNocturnaHoras = extraNocturnaHoras;
            this.ExtraNocturnaValor = extraNocturnaValor;
            this.OrdinariaDominicalFestivoHoras = ordinariaDominicalFestivoHoras;
            this.OrdinariaDominicalFestivoValor = ordinariaDominicalFestivoValor;
            this.DiurnaDominicalFestivoHoras = diurnaDominicalFestivoHoras;
            this.DiurnaDominicalFestivoValor = diurnaDominicalFestivoValor;
            this.NocturnaDominicalFestivoHoras = nocturnaDominicalFestivoHoras;
            this.NocturnaDominicalFestivoValor = nocturnaDominicalFestivoValor;
        }

        public string Identificacion { get => identificacion; set => identificacion = value; }
        public string Nombres { get => nombres; set => nombres = value; }
        public string Apellidos { get => apellidos; set => apellidos = value; }
        public int RecargoNocturnoHoras { get => recargoNocturnoHoras; set => recargoNocturnoHoras = value; }
        public double RecargoNocturnoValor { get => recargoNocturnoValor; set => recargoNocturnoValor = value; }
        public int ExtraDiurnaHoras { get => extraDiurnaHoras; set => extraDiurnaHoras = value; }
        public double ExtraDiurnaValor { get => extraDiurnaValor; set => extraDiurnaValor = value; }
        public int ExtraNocturnaHoras { get => extraNocturnaHoras; set => extraNocturnaHoras = value; }
        public double ExtraNocturnaValor { get => extraNocturnaValor; set => extraNocturnaValor = value; }
        public int OrdinariaDominicalFestivoHoras { get => ordinariaDominicalFestivoHoras; set => ordinariaDominicalFestivoHoras = value; }
        public double OrdinariaDominicalFestivoValor { get => ordinariaDominicalFestivoValor; set => ordinariaDominicalFestivoValor = value; }
        public int DiurnaDominicalFestivoHoras { get => diurnaDominicalFestivoHoras; set => diurnaDominicalFestivoHoras = value; }
        public double DiurnaDominicalFestivoValor { get => diurnaDominicalFestivoValor; set => diurnaDominicalFestivoValor = value; }
        public int NocturnaDominicalFestivoHoras { get => nocturnaDominicalFestivoHoras; set => nocturnaDominicalFestivoHoras = value; }
        public double NocturnaDominicalFestivoValor { get => nocturnaDominicalFestivoValor; set => nocturnaDominicalFestivoValor = value; }
    }
}
