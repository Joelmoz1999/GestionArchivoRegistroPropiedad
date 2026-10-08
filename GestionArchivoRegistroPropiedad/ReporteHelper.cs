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

            // Crear columnas usando el HeaderText (texto visible)
            foreach (DataGridViewColumn col in dgv.Columns)
            {
                if (col.Visible)
                {
                    // 🔑 Usa HeaderText si existe, si no, usa Name
                    string nombreColumna = string.IsNullOrWhiteSpace(col.HeaderText)
                        ? col.Name
                        : col.HeaderText;

                    // Evitar duplicados
                    while (dt.Columns.Contains(nombreColumna))
                        nombreColumna += "_";

                    dt.Columns.Add(nombreColumna, typeof(string));
                }
            }

            // Agregar filas
            foreach (DataGridViewRow row in dgv.Rows)
            {
                if (row.IsNewRow) continue;

                var fila = dt.NewRow();
                int indice = 0;
                foreach (DataGridViewColumn col in dgv.Columns)
                {
                    if (!col.Visible) continue;

                    var valor = row.Cells[col.Index].Value;
                    fila[indice] = valor?.ToString() ?? "";
                    indice++;
                }
                dt.Rows.Add(fila);
            }

            return dt;
        }
    }
}