using Newtonsoft.Json;
using System.IO;

namespace frmGestionNomina.Clases
{
    internal class RegistroDatos
    {
        private string ruta = @"C:\Datos\registrosNomina.json";
        private Registro datos;

        public RegistroDatos(Registro datos) {
            this.datos = datos;
            registrarDatos();
        }

        public Registro Datos { get => datos; set => datos = value; }

        private void registrarDatos()
        {
            string registroJson = JsonConvert.SerializeObject(this.datos);
            string datosRegistrados = File.ReadAllText(this.ruta);

            if (datosRegistrados == "") datosRegistrados = "[]";
            if (datosRegistrados == "[]")
            {
                datosRegistrados = datosRegistrados.Insert(datosRegistrados.Length - 1, registroJson);
            }
            else
            {
                datosRegistrados = datosRegistrados.Insert(datosRegistrados.Length - 1, $",{registroJson}");
            }
            File.WriteAllText(this.ruta, datosRegistrados);
        }
    }
}
