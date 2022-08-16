namespace ControlDeEstacionamiento
{
    public partial class FrmControlDeEstacionamiento : Form
    {
        string dia;
        public FrmControlDeEstacionamiento()
        {
            InitializeComponent();
        }

        private void FrmControlDeEstacionamiento_Load(object sender, EventArgs e)
        {
            //Mostrando la fecha actual
            lblFecha.Text = DateTime.Now.ToShortDateString();

            //Determinar el dia
            DateTime fecha = DateTime.Parse(lblFecha.Text);
            dia = fecha.ToString("dddd");

            double Costo = 0;
            switch(dia)
            {
                case "domingo": Costo = 2; break;
                case "lunes": 
                case "martes": 
                case "miercoles": 
                case "jueves": 
                    Costo = 4; break;
                case "viernes": 
                case "sabado": 
                    Costo = 7; break;
            }
            lblCosto.Text = Costo.ToString("0.00");
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            //Capturando los datos del fromulario
            string Placa = txtPlaca.Text;
            double costo = double.Parse(lblCosto.Text);
            DateTime fecha = DateTime.Parse(lblFecha.Text);
            DateTime horaInicio = DateTime.Parse(txtHoraInicio.Text);
            DateTime horaFin = DateTime.Parse(txtHoraFin.Text);

            //Calcular la hora
            TimeSpan hora = horaFin - horaInicio;

            //Calcular el importe
            double importe = costo * (hora.TotalHours);

            ListViewItem fila = new ListViewItem(Placa);
            fila.SubItems.Add(fecha.ToString("d"));
            fila.SubItems.Add(horaInicio.ToString("t"));
            fila.SubItems.Add(horaFin.ToString("t"));
            fila.SubItems.Add(hora.TotalHours.ToString());
            fila.SubItems.Add(costo.ToString("c"));
            fila.SubItems.Add(importe.ToString("c"));
            lvRegistro.Items.Add(fila);
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtPlaca.Clear();
            txtHoraInicio.Clear();
            txtHoraFin.Clear();
            txtPlaca.Focus();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("¿Estas seguro que desea salir?", "Estacionamiento", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

            if (r == DialogResult.Yes)
                this.Close();
        }
    }
}