using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.IO;
using System.Xml;

public static class Global
{
    public static DataSet dataSet = new DataSet();
    public static DataTable ConstraintTable = new DataTable();
          
    public static string Curtable;
    public static string FilePath = "tables.xml";
    public static bool from_Home = false;
}
public class ColumnProperties
{
    public ColumnProperties()
    {
        CheckCons = new List<string>();
    }
    public int index;
    public bool Isunique = false;
    public string Column_Name ="";
    public string Data_Type;
    public bool Allow_null =false;
    public bool IS_primKey = false;
    public string default_Value = "";
    
    public int seed = 0;
    public int step = 0;
    public bool inCrement = false;
    public bool deCrement = false;
   
    public List<string> CheckCons;

    public int Length = 25 ;
    public void GetAllData()
    {
        string CheckConsAsSTR="";
        for (int i = 0; i < CheckCons.Count; i++)
            CheckConsAsSTR += CheckCons[i];

        string str = "index = " + this.index.ToString() +
            "\n Col Name =  " + Column_Name +
            "\nData Type = " + Data_Type +
            "\nAllow_null = " + Allow_null.ToString() +
            "\nIS_primKey = " + IS_primKey.ToString() +
            "\ndefault_Value = " + default_Value +
            "\n unique = " + Isunique.ToString() +   
            (inCrement == true ? "\nincrement" + step.ToString() : "") +
            (deCrement == true ? "\ndeCrement" + step.ToString() : "")+
            "\n Length = " + Length.ToString()
            ;
        MessageBox.Show(str);
    }
}

namespace Table
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Home());
        }
    }
}
