using System.Data;
using System.Windows.Forms;

namespace GestionArchivoRegistroPropiedad
{
    /// <summary>
    /// Clase auxiliar para convertir un DataGridView a DataTable
    /// y evitar problemas con dynamic en QuestPDF.
    /// </summary>
    public static class ReporteHelper
    {
        public static DataTable ConvertirDataGridViewADataTable(DataGridView dgv)
        {
            var dt = new DataTable();

            // Crear columnas (excluyendo las invisibles)
            foreach (DataGridViewColumn col in dgv.Columns)
            {
                if (col.Visible)
                {
                    dt.Columns.Add(col.Name, typeof(string));
                }
            }

            // Agregar filas
            foreach (DataGridViewRow row in dgv.Rows)
            {
                if (row.IsNewRow) continue;

                var fila = dt.NewRow();
                foreach (DataGridViewColumn col in dgv.Columns)
                {
                    if (!col.Visible) continue;

                    var valor = row.Cells[col.Index].Value;
                    fila[col.Name] = valor?.ToString() ?? "";
                }
                dt.Rows.Add(fila);
            }

            return dt;
        }
    }
}