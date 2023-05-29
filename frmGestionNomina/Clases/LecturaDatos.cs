using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace frmGestionNomina.Clases
{
    internal class LecturaDatos
    {
        private string ruta = @"C:\Datos\registrosNomina.json";
        private List<Registro> datos;

        public LecturaDatos() {
            DeserializeDatos();
        }

        public List<Registro> Datos { get => datos; set => datos = value; }

        private void DeserializeDatos() {
            string datosJson = File.ReadAllText(this.ruta);
            if (datosJson != null) this.datos = JsonConvert.DeserializeObject<List<Registro>>(datosJson);
        }
    }
}
