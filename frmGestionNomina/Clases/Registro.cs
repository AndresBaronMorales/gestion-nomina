using frmGestionNomina.Clases.dgvDatos;
using System;

namespace frmGestionNomina.Clases
{
    internal class Registro
    {
        private string identificacion;
        private string nombres;
        private string apellidos;
        private string tipoDocumento;
        private string numeroDocumento;
        private double salarioBasico;
        private double valorHoraOrdinaria;
        private int diasLiquidados;
        private double salarioDevengado;
        private int recargoNocturnoHoras = 0;
        private double recargoNocturnoValor = 0;
        private int extraDiurnaHoras = 0;
        private double extraDiurnaValor = 0;
        private int extraNocturnaHoras = 0;
        private double extraNocturnaValor = 0;
        private int ordinariaDominicalFestivoHoras = 0;
        private double ordinariaDominicalFestivoValor = 0;
        private int diurnaDominicalFestivoHoras = 0;
        private double diurnaDominicalFestivoValor = 0;
        private int nocturnaDominicalFestivoHoras = 0;
        private double nocturnaDominicalFestivoValor = 0;
        private double auxilioTransporte;
        private double totalDevengado;
        private double salud;
        private double pension;
        private double deducciones;
        private double deduccionesValor;
        private double netoPagado;

        public Registro(string identificacion,string nombres,string apellidos,string tipoDocumento,string numeroDocumento,double salarioBasico,int diasLiquidados,double deducciones) {
            this.identificacion = identificacion;
            this.nombres = nombres;
            this.apellidos = apellidos;
            this.tipoDocumento = tipoDocumento;
            this.numeroDocumento = numeroDocumento;
            this.salarioBasico = salarioBasico;
            this.valorHoraOrdinaria = CalcularHoraOrdinaria();
            this.diasLiquidados = diasLiquidados;
            this.salarioDevengado = CalcularSalarioDevengado();
            this.auxilioTransporte = CalcularAuxilioTransporte();
            this.totalDevengado = CalcularTotalDevengado();
            this.salud = CalcularSaludPension();
            this.pension = CalcularSaludPension();
            this.deducciones = deducciones;
            CalcularNetoPagado();
        }

        public string Identificacion { get => identificacion; set => identificacion = value; }
        public string Nombres { get => nombres; set => nombres = value; }
        public string Apellidos { get => apellidos; set => apellidos = value; }
        public string TipoDocumento { get => tipoDocumento; set => tipoDocumento = value; }
        public string NumeroDocumento { get => numeroDocumento; set => numeroDocumento = value; }
        public double SalarioBasico { get => salarioBasico; set => salarioBasico = value; }
        public double ValorHoraOrdinaria { get => valorHoraOrdinaria; set => valorHoraOrdinaria = value; }
        public int DiasLiquidados { get => diasLiquidados; set => diasLiquidados = value; }
        public double SalarioDevengado { get => salarioDevengado; set => salarioDevengado = value; }
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
        public double AuxilioTransporte { get => auxilioTransporte; set => auxilioTransporte = value; }
        public double TotalDevengado { get => totalDevengado; set => totalDevengado = value; }
        public double Salud { get => salud; set => salud = value; }
        public double Pension { get => pension; set => pension = value; }
        public double Deducciones { get => deducciones; set => deducciones = value; }
        public double DeduccionesValor { get => deduccionesValor; set => deduccionesValor = value; }
        public double NetoPagado { get => netoPagado; set => netoPagado = value; }
        

        //Metodos
        private double CalcularHoraOrdinaria() => Math.Truncate(this.salarioBasico / 240);

        private double CalcularSalarioDevengado() => Math.Truncate((this.salarioBasico / 30) * this.diasLiquidados);

        private double CalcularValorHoraRecargo(double recargo) => Math.Truncate((this.valorHoraOrdinaria * recargo) + this.valorHoraOrdinaria);

        public void HorasExtrasValor() {
            this.recargoNocturnoValor = CalcularValorHoraRecargo(0.35) * this.recargoNocturnoHoras;
            this.extraDiurnaValor = CalcularValorHoraRecargo(0.25) * this.extraDiurnaHoras;
            this.extraNocturnaValor = CalcularValorHoraRecargo(0.75) * this.extraNocturnaHoras;
            this.ordinariaDominicalFestivoValor = CalcularValorHoraRecargo(0.75) * this.ordinariaDominicalFestivoHoras;
            this.diurnaDominicalFestivoValor = CalcularValorHoraRecargo(1) * this.diurnaDominicalFestivoHoras;
            this.nocturnaDominicalFestivoValor = CalcularValorHoraRecargo(1.5) * this.nocturnaDominicalFestivoHoras;
        }

        private double CalcularAuxilioTransporte() {
            double auxilio = 0;
            if (this.salarioDevengado <= (1160000 * 2)) {
                auxilio = Math.Truncate(Convert.ToDouble((140606 / 30) * this.diasLiquidados));
            }
            return auxilio;
        }

        private double HorasExtrasValorTotal() => this.recargoNocturnoValor + this.extraDiurnaValor + this.extraNocturnaValor + this.ordinariaDominicalFestivoValor + this.diurnaDominicalFestivoValor + this.nocturnaDominicalFestivoValor;         

        private double CalcularTotalDevengado() => this.salarioDevengado + HorasExtrasValorTotal() + this.auxilioTransporte;

        private double CalcularSaludPension() => Math.Truncate((this.totalDevengado - this.auxilioTransporte) * 0.04);

        private void CalcularNetoPagado() {
            double netoPagado = this.totalDevengado - (this.salud + this.pension);
            double deduccionesValor = (this.deducciones * netoPagado) / 100;
            this.netoPagado = netoPagado - deduccionesValor;
            this.deduccionesValor = deduccionesValor;
        }

        public Empleado GetEmpleado() => new Empleado(this.identificacion, this.nombres, this.apellidos, this.tipoDocumento, this.numeroDocumento);

        public HorasExtraDgv GetHorasExtras() => new HorasExtraDgv(this.identificacion,this.nombres,this.apellidos,this.recargoNocturnoHoras,this.recargoNocturnoValor,this.extraDiurnaHoras,this.extraDiurnaValor,this.extraNocturnaHoras,this.extraNocturnaValor,this.ordinariaDominicalFestivoHoras,this.ordinariaDominicalFestivoValor,this.diurnaDominicalFestivoHoras,this.diurnaDominicalFestivoValor,this.nocturnaDominicalFestivoHoras,this.nocturnaDominicalFestivoValor);

        public Salarios GetSalarios() => new Salarios(this.identificacion,this.nombres,this.apellidos,this.salarioBasico,this.salarioDevengado,this.totalDevengado,this.netoPagado);
    }
}
