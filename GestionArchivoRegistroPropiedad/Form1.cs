using GestionArchivoRegistroPropiedad.Models;

namespace GestionArchivoRegistroPropiedad
{
    public partial class Form1 : Form
    {
        private readonly GestionArchivoRegistroPropiedadContext _context;

        // El constructor recibe el contexto automáticamente
        public Form1(GestionArchivoRegistroPropiedadContext context)
        {
            InitializeComponent();
            _context = context;
        }

      

        private void Form1_Load_1(object sender, EventArgs e)
        {
            string hash = BCrypt.Net.BCrypt.HashPassword("Admin123");
            MessageBox.Show(hash, "Hash generado");

        }
    }
}