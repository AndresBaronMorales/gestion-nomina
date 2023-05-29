using System.Collections.Generic;

namespace frmGestionNomina.Clases
{
    internal class HorasTarifas
    {
        private List<HoraExtra> tarifas;

        public HorasTarifas() {
            this.tarifas = HorasExtras();
        }

        public List<HoraExtra> Tarifas { get => tarifas;}

        private List<HoraExtra> HorasExtras()
        {
            List<HoraExtra> horasExtrasDatos = new List<HoraExtra>()
            {
                new HoraExtra("Recargo nocturno",0.35),
                new HoraExtra("Extra diurna",0.25),
                new HoraExtra("Extra nocturna",0.75),
                new HoraExtra("Ordinaria dominical o festivo",0.75),
                new HoraExtra("Diurna dominical o festivo",1),
                new HoraExtra("Nocturna dominical o festivo",1.5)
            };
            return horasExtrasDatos;
        }

        //Nombres horas
        public List<string> HorasTarifasNombres() {
            List<string> nombresHoras = new List<string>();
            this.Tarifas.ForEach(nombre => nombresHoras.Add(nombre.Nombre));
            return nombresHoras;
        }
    }
}
