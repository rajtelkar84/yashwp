using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace West.EnterpriseUX.Automation.MobileNew
{
    public class ExcelUtils
    {
        public static IEnumerable<object[]> GetSheetData(string path, string sheetname)
        {
            XLWorkbook book = new XLWorkbook(path);

            var sheet = book.Worksheet(sheetname);
            var range = sheet.RangeUsed();

            int rowCount = range.RowCount();
            int columnCount = range.ColumnCount();

            for (int r = 2; r <= rowCount; r++)
            {
                object[] dataRow = new object[columnCount];

                for (int c = 1; c <= columnCount; c++)
                {
                    string cellValue = range.Cell(r, c).GetString();
                    Console.WriteLine(cellValue);
                    dataRow[c - 1] = cellValue;
                }
                yield return dataRow;
            }

            book.Dispose();
        }
    }
}