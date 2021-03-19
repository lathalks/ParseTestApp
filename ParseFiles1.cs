using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Xml;
using Newtonsoft.Json;
using System.Data.SqlClient;

namespace ParseFileApp
{
    public class ParseFiles1
    {
       
        public string ParseFromCSVToJSON()
        {
            
            using (FileStream fileStream = new FileStream(@"D:\L\ParseFileApp\InputFiles\Sample Csv.csv", FileMode.Open))
            {
                byte[] bytedata = new byte[fileStream.Length];
                int res = fileStream.Read(bytedata, 0, Convert.ToInt32(fileStream.Length));
                int ln = bytedata.Length;
                //convert byte to json
              string s=  Convert.ToBase64String(bytedata);
              return  JsonConvert.SerializeObject(s);
                
            }
               


        }

        public void ParseFromXMLtoSQL()
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(@"D:\L\ParseFileApp\InputFiles\Sample XML.xml");

            XmlNodeList xmlNodeList = xmlDoc.GetElementsByTagName("details");
            DataTable dt = new DataTable();
            dt.Columns.Add("firstname");
            dt.Columns.Add("lastname");
            dt.Columns.Add("title");
            dt.Columns.Add("division");
            dt.Columns.Add("building");
            dt.Columns.Add("room");
            DataRow dr = dt.NewRow();// new DataRow();

            foreach (XmlNode xnode in xmlNodeList)
            {
                dr = dt.NewRow();
                dt.Rows.Add(dr);
                string s = xnode.Value;
            }
            using (SqlConnection sqlcon = new SqlConnection(@"Server=localhost\SQLEXPRESS;Database=Sample;Trusted_Connection=True"))
            {

            }
        }
    }
}