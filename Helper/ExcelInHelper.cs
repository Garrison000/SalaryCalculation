using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;
using Model;

namespace Helper
{
    class ExcelInHelper
    {
        private string FileName { get; set; }
        private Application app { get; set; }
        private Workbooks wbs { get; set; }
        private Workbook wb { get; set; }
        private Worksheet ws { get; set; }
        private DatabaseContext db { get; set; }

        public string[] ExcelIn(string FileName)
        {
            string[] fs = new string[1000];
            Open(FileName);
            fs = GetAllContent();
            return fs;
        }

        private void Open(string filename)
        {
            FileName = filename;
            db = DatabaseContext.GetInstance();
            app = new Application();
            wbs = app.Workbooks;
            wb = wbs.Add(filename);
            ws = wb.Sheets[1] as Worksheet;
        }

        private string GetCell(object ob)
        {
            string s = ((Range)ob).Text;
            return s;
        }
        private string GetString(object ob,int row,int column)
        {
            string s = GetCell(ob);
            if(s=="")
            {
                return s;
            }
            if(GetCell(ws.Cells[row+1,column])!="")
            {
                s = s + "+" + ws.Cells[row + 1, column];
            }
            if(GetCell(ws.Cells[row,column+1])!="")
            {
                s = s + "-" + ws.Cells[row, column + 1];
            }
            return s;
        }

        private string GetRowContent(int row)
        {
            string s;
            s = GetString(ws.Cells[row,2],row,2);
            if(GetString(ws.Cells[row,4],row,4)=="")
            {
                return s;
            }
            else
            {
                for(int i=4;i<=12 ;i+=2)
                {
                    s = s + "|" + GetString(ws.Cells[row, i],row,i);
                }
                return s;
            }
        }

        private string[] GetAllContent()
        {
            string[] fs = new string[1000];
            int strIndex = 0;
            for(int row=3; ;row+=34)
            {
                for(int i=0;i<=30 ;i+=2 )
                {
                    if(i==2||i==6||i==18||i==26)
                    {
                        continue;
                    }
                    fs[strIndex] = GetRowContent(row + i);
                    strIndex++;
                }
                if (GetString(ws.Cells[row,2],row,2)=="")
                {
                    break;
                }
            }
            return fs;
        }
    }
}
