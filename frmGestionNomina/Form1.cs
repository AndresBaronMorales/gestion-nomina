using frmGestionNomina.Clases;
using frmGestionNomina.Clases.dgvDatos;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace frmGestionNomina
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            horasExtrasPanelesVisible(false);
            cbxHorasExtrasCargarDatos();
            LecturaDatos datos = new LecturaDatos();
            dgvCargarDatosRegistros(datos);
            dgvCargarDatosRegistrosEmpleados(datos);
            dgvCargarDatosRegistrosHorasExtras(datos);
            dgvCargarDatosRegistrosSalarios(datos);
            dgvCargarDatosRegistrosTotalPagado(datos);
        }

        //Funciones
        private void ActivarTxtNumeroDocumento() => txtDatosNumeroDocumento.ReadOnly = false;

        private void horasExtrasPanelesVisible(bool valor)
        {
            pContenedorHoraExtraDiv06.Visible = valor;
            pContenedorHoraExtraDiv05.Visible = valor;
            pContenedorHoraExtraDiv04.Visible = valor;
            pContenedorHoraExtraDiv03.Visible = valor;
            pContenedorHoraExtraDiv02.Visible = valor;
        }

        //Cargando datos cbx horas extras
        public void cbxHorasExtrasCargarDatos() {
            HorasTarifas horasTarifas = new HorasTarifas();
            cbxSalarioHorasExtras.Items.AddRange(horasTarifas.HorasTarifasNombres().ToArray());            
        }

        //Valor de radioButton
        private string valorRadioButton()
        {
            string valor = "";
            RadioButton[] radioBotonoes = new RadioButton[] { rbDatosTipoDocumentoCC, rbDatosTipoDocumentoCCDIG, rbDatosTipoDocumentoNIP, rbDatosTipoDocumentoTI, rbDatosTipoDocumentoPA };

            foreach (var radio in radioBotonoes)
            {
                if (radio.Checked)
                {
                    valor = $"{radio.Text}";
                    break;
                }
            }
            return valor;
        }

        //Horas registradas en el cbx
        private List<HoraExtra> horasAgregadas()
        {
            List<HoraExtra> horasRegistradas = new List<HoraExtra>();

            for (var i = 0; i < cbxSalarioHorasExtrasAgregadas.Items.Count; i++)
            {
                char[] separadores = { ':', ',' };
                string horaCbx = cbxSalarioHorasExtrasAgregadas.Items[i].ToString();

                HoraExtra horas = new HoraExtra();
                horas.Nombre = horaCbx.Split(separadores)[0];
                horas.Valor = Convert.ToDouble(horaCbx.Split(separadores)[2].Trim());

                if (horasRegistradas.Count != 0)
                {
                    bool existe = false;
                    foreach (var hora in horasRegistradas)
                    {
                        if (hora.Nombre == horas.Nombre)
                        {
                            hora.Valor = hora.Valor + horas.Valor;
                            existe = true;
                            break;
                        }
                    }
                    if (!existe) horasRegistradas.Add(horas);
                }
                else
                {
                    horasRegistradas.Add(horas);
                }
            }
            return horasRegistradas;
        }

        //Registrando las horas 
        private void registroHoras(Registro registroDatos)
        {
            List<HoraExtra> horasRegistradas = horasAgregadas();

            foreach (var horaExtra in horasRegistradas)
            {
                if (horaExtra.Nombre == "Recargo nocturno") registroDatos.RecargoNocturnoHoras = Convert.ToInt16(horaExtra.Valor);
                if (horaExtra.Nombre == "Extra diurna") registroDatos.ExtraDiurnaHoras = Convert.ToInt16(horaExtra.Valor);
                if (horaExtra.Nombre == "Extra nocturna") registroDatos.ExtraNocturnaHoras = Convert.ToInt16(horaExtra.Valor);
                if (horaExtra.Nombre == "Ordinaria dominical o festivo") registroDatos.OrdinariaDominicalFestivoHoras = Convert.ToInt16(horaExtra.Valor);
                if (horaExtra.Nombre == "Diurna dominical o festivo") registroDatos.DiurnaDominicalFestivoHoras = Convert.ToInt16(horaExtra.Valor);
                if (horaExtra.Nombre == "Nocturna dominical o festivo") registroDatos.NocturnaDominicalFestivoHoras = Convert.ToInt16(horaExtra.Valor);
            }
        }

        //Cargar datos dgv
        private void dgvCargarDatosRegistros(LecturaDatos datos)
        {
            if (datos.Datos != null)
            {
                var datosTabla = new BindingSource();
                datosTabla.DataSource = datos.Datos;
                dgvRegistros.DataSource = datosTabla;
                cabecerasDgvRegistros(dgvRegistros);
            }
        }

        //Cargar datos dgv empleados
        private void dgvCargarDatosRegistrosEmpleados(LecturaDatos datos)
        {
            if (datos.Datos != null)
            {
                List<Empleado> empleados = new List<Empleado>();
                datos.Datos.ForEach(registro => empleados.Add(registro.GetEmpleado()));

                var datosTabla = new BindingSource();
                datosTabla.DataSource = empleados;
                dgvEmpleados.DataSource = datosTabla;
                cabecerasDgvEmpleados(dgvEmpleados);
            }
        }

        //Cargar datos dgv horas extra
        private void dgvCargarDatosRegistrosHorasExtras(LecturaDatos datos)
        {
            if (datos.Datos != null)
            {
                List<HorasExtraDgv> empleados = new List<HorasExtraDgv>();
                datos.Datos.ForEach(registro => empleados.Add(registro.GetHorasExtras()));

                var datosTabla = new BindingSource();
                datosTabla.DataSource = empleados;
                dgvHorasExtras.DataSource = datosTabla;
                cabecerasDgvRegistrosHorasExtras(dgvHorasExtras);
            }
        }

        //Cargar datos dgv salarios
        private void dgvCargarDatosRegistrosSalarios(LecturaDatos datos)
        {
            if (datos.Datos != null)
            {
                List<Salarios> salarios = new List<Salarios>();
                datos.Datos.ForEach(registro => salarios.Add(registro.GetSalarios()));

                var datosTabla = new BindingSource();
                datosTabla.DataSource = salarios;
                dgvSalarios.DataSource = datosTabla;
                cabecerasDgvRegistrosSalarios(dgvSalarios);
            }
        }

        //Cargar datos dgv totalPagado
        private void dgvCargarDatosRegistrosTotalPagado(LecturaDatos datos)
        {
            if (datos.Datos != null)
            {
                TotalPagado totalPago = new TotalPagado();
                totalPago.NumeroEmpleados = datos.Datos.Count;

                foreach (var registro in datos.Datos) {
                    totalPago.SalariosBasicos += registro.SalarioBasico;
                    totalPago.SalariosDevengados += registro.SalarioDevengado;
                    totalPago.TotalDevengados += registro.TotalDevengado;
                    totalPago.NetoPagados += registro.NetoPagado;
                }

                var datosTabla = new BindingSource();
                datosTabla.DataSource = totalPago;
                dgvTotalPagado.DataSource = datosTabla;
                cabecerasDgvRegistrosTotalPagados(dgvTotalPagado);
            }
        }

        //Titulos dgv
        private void cabecerasDgvRegistros(DataGridView tabla)
        {
            string[] titulos = new string[] { "Identificación", "Nombres", "Apellidos", "Tipo de documento", "Numero de documento", "Salario básico", "$ Hora ordinaria", "Días liquidados", "Salario devengado", "# Horas recargo nocturno", "$ Horas recargo nocturno", "# Horas extra diurnas", "$ Horas extra diurnas", "# Horas extra nocturna", "$ Horas extra nocturna", "# Horas ordinaria dominical festivo", "$ Horas ordinaria dominical festivo", "# Horas diurna dominical festivo", "$ Horas diurna dominical festivo", "# Horas nocturna dominical festivo", "$ Horas nocturna dominical festivo", "Auxilio de transporte", "Total, devengado", "Salud", "Pensión", "% Deducciones", "$ Deducciones", "Neto pagado" };

            for (var i = 0; i < titulos.Length; i++)
            {
                tabla.Columns[i].HeaderText = titulos[i];
            }
        }

        //Titulos dgv empleados
        private void cabecerasDgvEmpleados(DataGridView tabla)
        {
            string[] titulos = new string[] { "Identificación", "Nombres", "Apellidos", "Tipo de documento", "Numero de documento"};

            for (var i = 0; i < titulos.Length; i++)
            {
                tabla.Columns[i].HeaderText = titulos[i];
            }
        }

        //Titulos dgv horas extra
        private void cabecerasDgvRegistrosHorasExtras(DataGridView tabla)
        {
            string[] titulos = new string[] { "Identificación", "Nombres", "Apellidos", "# Horas recargo nocturno", "$ Horas recargo nocturno", "# Horas extra diurnas", "$ Horas extra diurnas", "# Horas extra nocturna", "$ Horas extra nocturna", "# Horas ordinaria dominical festivo", "$ Horas ordinaria dominical festivo", "# Horas diurna dominical festivo", "$ Horas diurna dominical festivo", "# Horas nocturna dominical festivo", "$ Horas nocturna dominical festivo" };

            for (var i = 0; i < titulos.Length; i++)
            {
                tabla.Columns[i].HeaderText = titulos[i];
            }
        }

        //Titulos dgv salarios
        private void cabecerasDgvRegistrosSalarios(DataGridView tabla)
        {
            string[] titulos = new string[] { "Identificación", "Nombres", "Apellidos","Salario básico","Salario devengado","Total, devengado","Neto pagado" };

            for (var i = 0; i < titulos.Length; i++)
            {
                tabla.Columns[i].HeaderText = titulos[i];
            }
        }

        //Titulos dgv salarios total pagados
        private void cabecerasDgvRegistrosTotalPagados(DataGridView tabla)
        {
            string[] titulos = new string[] { "# Empleados", "Salario básicos", "Salarios devengados", "Total, devengados", "Neto pagados" };

            for (var i = 0; i < titulos.Length; i++)
            {
                tabla.Columns[i].HeaderText = titulos[i];
            }
        }

        private void Clear()
        {
            txtDatosIdentificacion.Text = "";
            txtDatosNombres.Text = "";
            txtDatosApellidos.Text = "";
            rbDatosTipoDocumentoCC.Checked = false;
            rbDatosTipoDocumentoCCDIG.Checked = false;
            rbDatosTipoDocumentoNIP.Checked = false;
            rbDatosTipoDocumentoTI.Checked = false;
            rbDatosTipoDocumentoPA.Checked = false;
            txtDatosNumeroDocumento.Text = "";
            txtDatosNumeroDocumento.ReadOnly = true;
            txtSalarioSlarioBasico.Text = "";
            txtSalarioDiasLiquidados.Text = "";
            txtSalarioSlarioDeducciones.Text = "";
            cbSalarioHorasExtras.Checked = false;
            txtSalarioHorasExtrasNumero.Text = "";
            cbxSalarioHorasExtrasAgregadas.Items.Clear();
        }


        //Eventos
        private void rbDatosTipoDocumentoCC_CheckedChanged(object sender, EventArgs e)
        {
            ActivarTxtNumeroDocumento();   
        }

        private void rbDatosTipoDocumentoCCDIG_CheckedChanged(object sender, EventArgs e)
        {
            ActivarTxtNumeroDocumento();
        }

        private void rbDatosTipoDocumentoNIP_CheckedChanged(object sender, EventArgs e)
        {
            ActivarTxtNumeroDocumento();
        }

        private void rbDatosTipoDocumentoTI_CheckedChanged(object sender, EventArgs e)
        {
            ActivarTxtNumeroDocumento();
        }

        private void rbDatosTipoDocumentoPA_CheckedChanged(object sender, EventArgs e)
        {
            ActivarTxtNumeroDocumento();
        }

        private void cbSalarioHorasExtras_CheckedChanged(object sender, EventArgs e)
        {
            if (cbSalarioHorasExtras.Checked)
            {
                horasExtrasPanelesVisible(true);
            }
            else {
                horasExtrasPanelesVisible(false);
            }   
        }

        private void btnHorasExtrasAgregar_Click(object sender, EventArgs e)
        {
            cbxSalarioHorasExtrasAgregadas.Items.Add($"{cbxSalarioHorasExtras.Text}, Numero de horas: {txtSalarioHorasExtrasNumero.Text}");

            cbxSalarioHorasExtras.SelectedIndex = 0;
            txtSalarioHorasExtrasNumero.Text = "";
        }

        private void btnHorasExtrasEliminar_Click(object sender, EventArgs e)
        {
            cbxSalarioHorasExtrasAgregadas.Items.RemoveAt(cbxSalarioHorasExtrasAgregadas.SelectedIndex);
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            Registro registroDatos = new Registro(txtDatosIdentificacion.Text,txtDatosNombres.Text,txtDatosApellidos.Text,valorRadioButton(),txtDatosNumeroDocumento.Text,Convert.ToDouble(txtSalarioSlarioBasico.Text),Convert.ToInt16(txtSalarioDiasLiquidados.Text),Convert.ToDouble(txtSalarioSlarioDeducciones.Text));
            registroHoras(registroDatos);
            registroDatos.HorasExtrasValor();

            RegistroDatos registroJson = new RegistroDatos(registroDatos);

            LecturaDatos datos = new LecturaDatos();
            dgvCargarDatosRegistros(datos);
            dgvCargarDatosRegistrosEmpleados(datos);
            dgvCargarDatosRegistrosHorasExtras(datos);
            dgvCargarDatosRegistrosSalarios(datos);
            dgvCargarDatosRegistrosTotalPagado(datos);

            Clear();
        }
    }
}
