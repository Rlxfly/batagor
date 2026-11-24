using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace FinalPrjk
{
    /// <summary>Fungsi bersama untuk form list: pencarian, id baris terpilih, memilih baris.</summary>
    internal static class ListHelper
    {
        public static void Filter(DataTable table, string text)
        {
            string t = (text ?? "").Trim().Replace("'", "''")
                .Replace("[", "").Replace("]", "").Replace("%", "").Replace("*", "");

            if (t.Length == 0)
            {
                table.DefaultView.RowFilter = "";
                return;
            }
            var bagian = new List<string>();
            foreach (DataColumn col in table.Columns)
            {
                if (col.DataType == typeof(string))
                    bagian.Add("[" + col.ColumnName + "] LIKE '%" + t + "%'");
            }
            table.DefaultView.RowFilter = string.Join(" OR ", bagian.ToArray());
        }

        /// <summary>Id baris terpilih (kolom tersembunyi bernama colId), 0 bila tidak ada.</summary>
        public static int SelectedId(DataGridView grid)
        {
            if (grid.CurrentRow == null || !grid.Columns.Contains("colId")) return 0;
            object v = grid.CurrentRow.Cells["colId"].Value;
            return (v == null || v == DBNull.Value) ? 0 : Convert.ToInt32(v);
        }

        public static void SelectRow(DataGridView grid, int id)
        {
            if (id == 0) return;
            DataGridViewColumn first = grid.Columns.GetFirstColumn(DataGridViewElementStates.Visible);
            if (first == null) return;
            foreach (DataGridViewRow r in grid.Rows)
            {
                if (Convert.ToInt32(r.Cells["colId"].Value) == id)
                {
                    grid.CurrentCell = r.Cells[first.Index];
                    break;
                }
            }
        }
    }
}
