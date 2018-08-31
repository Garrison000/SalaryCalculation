using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;
using Model;

namespace Helper
{
    public class ExcelOutHelper
    {
        private Application app { get; set; }
        private Workbooks wbs { get; set; }
        private Workbook wb { get; set; }
        private Worksheet ws { get; set; }
        private DatabaseContext db { get; set; }

        public string ExcelOut()
        {
            ExcelInit();
            //Save();
            if(SaveAs("工资表"))
            {
                return "文件导出成功！";
            }
            else
            {
                return "文件导出失败！";
            }
        }

        private void ExcelInit()
        {
            db = DatabaseContext.GetInstance();

            app = new Application();
            wbs = app.Workbooks;
            wb = wbs.Add(true);
            ws = wb.Sheets[1] as Worksheet;
            ws.Name = "工资表";
            ws.Cells[1, 1] = "姓名";
            ws.Cells[1, 2] = "工资";
            int i = 2;
            foreach (var teacher in db.Teachers)
            {
                ws.Cells[i, 1] = teacher.Name;
                ws.Cells[i, 2] = teacher.Salary;
                i++;
            }
        }
        //public bool Save()
        //{
        //    try
        //    {
        //        wb.Save();
        //        return true;
        //    }
        //    catch(Exception e)
        //    {
        //        return false;
        //    }
        //}
        private bool SaveAs(object Filename)
        {
            try
            {
                wb.SaveAs(Filename, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                return true;
            }
            catch(Exception e)
            {
                return false;
            }
        }
    }
}
