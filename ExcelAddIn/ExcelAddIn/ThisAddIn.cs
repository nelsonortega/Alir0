﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Excel = Microsoft.Office.Interop.Excel;
using Office = Microsoft.Office.Core;
using Microsoft.Office.Tools.Excel;
using System.Windows.Forms;


namespace ExcelAddIn
{
    public partial class ThisAddIn
    {
        private void ThisAddIn_Startup(object sender, System.EventArgs e)
        {
        }

        private void ThisAddIn_Shutdown(object sender, System.EventArgs e)
        {
        }

        void InternalStartup()
        {
        }

        public void BertCall(string functionName, String dataRange)
        {
            if(dataRange.Equals("00:00"))
            {
                MessageBox.Show("Please check your empty cells");
            }
            else
            {
                object resultado = Application.Run("BERT.Call", functionName, getCurrentActiveSheet().Range[dataRange]);
                MessageBox.Show(resultado.ToString());
            }
        }

        public void BertCallTEST(string functionName, string[] dataRangeParameters)
        {
            object resultado = 0; ;
            if (dataRangeParameters[0] != "00:00")//in all analysis, position 1 will be filled, if not, there's empty selection
            {
                switch (dataRangeParameters.Length)
                {
                    case 1:
                       resultado = Application.Run("BERT.Call", functionName, dataRangeParameters[0]);
                        break;
                    case 2:
                        resultado = Application.Run("BERT.Call", functionName, 
                            dataRangeParameters[0], 
                            dataRangeParameters[1]);
                        break;
                    case 3:
                        resultado = Application.Run("BERT.Call", functionName,
                            dataRangeParameters[0], 
                            dataRangeParameters[1], 
                            dataRangeParameters[2] );
                        break;
                    case 4:
                        resultado = Application.Run("BERT.Call", functionName, dataRangeParameters[0],
                            dataRangeParameters[1],
                            dataRangeParameters[2],
                            dataRangeParameters[3]);
                        break;
                    case 5:
                        resultado = Application.Run("BERT.Call", functionName, 
                            dataRangeParameters[0], 
                            dataRangeParameters[1],
                            dataRangeParameters[2], 
                            dataRangeParameters[3], 
                            dataRangeParameters[4]);
                        break;
                    default:
                        break;
                }

                MessageBox.Show(resultado.ToString());
            }
            else
            {
                MessageBox.Show("There's no data selected");
            }
                
            
        }

        private Excel.Worksheet getCurrentActiveSheet()
        {
            Excel.Workbook currentWorkBook = this.Application.ActiveWorkbook;
            return currentWorkBook.ActiveSheet;
        }
        public void FillCellsFromDataBase(List<String> DataBaseQuery, String columnindex) {
                    
            Excel.Worksheet currentWorkBook = getCurrentActiveSheet();
            
            for (int i = 0; i < DataBaseQuery.Count; i++)
            {
                currentWorkBook.Range[columnindex + (i + 1)].Value2 = DataBaseQuery[i];
            }
            
            
        }
        
    }
}
