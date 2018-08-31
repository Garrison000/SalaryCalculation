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
        //private DatabaseContext db { get; set; }
        const int StrNum  = 5000;

        public void ExcelIn(string FileName)
        {
            //db = DatabaseContext.GetInstance();
            string[] str = ExcelToString(FileName);
            LessonHelper lh = new LessonHelper();
            for(int i=0; ;i+=12)//循环一次一个班，写得极丑...
            {
                int OrderNum1=1,OrderNum2,Order;//num1是周，num2是第几节课
                if(str[i]=="")//全部录完了就跳出循环
                {
                    break;
                }
                string @class = str[i];
                for(int j=1;j<=11;j++)
                {
                    if(str[i+j]=="")//怕出bug就先检验一下
                    {
                        continue;
                    }
                    OrderNum2 = j - 1;
                    string[] Class = str[i+j].Split('|');//所有课
                    foreach(string item in Class) //item 是单独的每节课
                    {
                        Order = OrderNum1 * 100 + OrderNum2;
                        OrderNum1++;
                        string[] temp;
                        if(item.Contains("+"))
                        {
                            temp = item.Split('+');
                            string[] cls1 = temp[0].Split('\n');
                            string[] cls2 = temp[1].Split('\n');
                            lh.InputLesson(cls1[0], cls1[1], @class, new Time { Term = (int)TimeType.Default, Order = Order, Week = (int)TimeType.Default }, (int)TimeType.Default, 0.5);
                            lh.InputLesson(cls2[0], cls2[1], @class, new Time { Term = (int)TimeType.Default, Order = Order, Week = (int)TimeType.Default }, (int)TimeType.Default, 0.5);
                        }
                        else if(item.Contains("-"))
                        {
                            temp = item.Split('-');
                            string[] cls1 = temp[0].Split('\n');
                            string[] cls2 = temp[1].Split('\n');
                            lh.InputLesson(cls1[0], cls1[1], @class, new Time { Term = (int)TimeType.Default, Order = Order, Week = (int)TimeType.Sigle },(int)TimeType.Default,0.5);
                            lh.InputLesson(cls2[0], cls2[1], @class, new Time { Term = (int)TimeType.Default, Order = Order, Week = (int)TimeType.Double }, (int)TimeType.Default, 0.5);
                        }
                        else
                        {
                            temp = item.Split('\n');
                            lh.InputLesson(temp[0], temp[1], @class, new Time { Term = (int)TimeType.Default, Order = Order, Week = (int)TimeType.Default }, (int)TimeType.Default, 0.5);
                        }
                    }
                }
            }
        }

        private string[] ExcelToString(string FileName)
        {
            string[] fs = new string[StrNum];
            Open(FileName);
            fs = GetAllContent();
            return fs;
            ///返回的字符串格式  其中一个班的课表占12个字符串
            ///str0：                XXX班课表
            ///str1：    //早自习    "XX|XX|..." or ""
            ///str2：    //第一节
            ///str3：    //第二节
            ///str4：    //第三节
            ///str5：    //第四节
            ///str6：    //第五节
            ///str7：    //第六节
            ///str8：    //第七节
            ///str9：    //第八节
            ///str10：    //晚自习
            ///str11：   //晚自习
        }

        private void Open(string filename)
        {
            FileName = filename;
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
                s = s + "+" + ws.Cells[row + 1, column]; //一个课时两节课
            }
            if(GetCell(ws.Cells[row,column+1])!="")
            {
                s = s + "-" + ws.Cells[row, column + 1];  //晚自习单双周轮流
            }
            return s;
        }

        private string GetRowContent(int row)
        {
            string s;
            s = GetString(ws.Cells[row,4],row,4);
            if(s=="")
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
            string[] fs = new string[StrNum];
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
