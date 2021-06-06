using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClosedXML.Excel;

namespace library_winform
{
    public class ExportToExcelClass
    {
        public static void PrintToXLSX (DataGridView dataGrid)
        {
            var workbook = new XLWorkbook();
            var worksheet = workbook.Worksheets.Add("Лист1");
            
            worksheet.Cell("A" + 1).Value = "Книга";
            worksheet.Cell("B" + 1).Value = "Автор";
            worksheet.Cell("C" + 1).Value = "Всего экземпляров";
            worksheet.Cell("D" + 1).Value = "Выдано за период";
            worksheet.Cell("E" + 1).Value = "Доступно экземпляров";

            worksheet.Cell("A" + 1).Style.Font.Bold = true;
            worksheet.Cell("B" + 1).Style.Font.Bold = true;
            worksheet.Cell("C" + 1).Style.Font.Bold = true;
            worksheet.Cell("D" + 1).Style.Font.Bold = true;
            worksheet.Cell("E" + 1).Style.Font.Bold = true;

            worksheet.Cell("A" + 1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            worksheet.Cell("B" + 1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            worksheet.Cell("C" + 1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            worksheet.Cell("D" + 1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            worksheet.Cell("E" + 1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

            for (int i = 0; i <= dataGrid.RowCount - 1; i++)
            {
                for (int j = 0; j <= dataGrid.ColumnCount - 1; j++)
                {
                    DataGridViewCell cell = dataGrid[j, i];
                    worksheet.Cell(i + 2, j + 1).Value = cell.Value;
                }
            }

            var rngTable = worksheet.Range("A1:E" + dataGrid.RowCount);
            rngTable.Style.Border.LeftBorder = XLBorderStyleValues.Thin;
            rngTable.Style.Border.RightBorder = XLBorderStyleValues.Thin;
            rngTable.Style.Border.BottomBorder = XLBorderStyleValues.Thin;
            rngTable.Style.Border.TopBorder = XLBorderStyleValues.Thin;

            worksheet.Columns().AdjustToContents();

            workbook.SaveAs(@"..\..\reports\report_" + DateTime.Now.Ticks.ToString() + @".xlsx");
            workbook.Dispose();
        }

        public static async void ExportToXLSX (DataGridView dataGrid)
        {
            await Task.Run(()=>PrintToXLSX(dataGrid));
        }
    }
}
