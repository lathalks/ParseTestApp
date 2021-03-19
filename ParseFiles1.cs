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
              string s=  Convert.ToString(bytedata);
              return  JsonConvert.SerializeObject(s);
                
            }
               


        }

        public void ParseFromXMLtoSQL()
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(@"D:\L\ParseFileApp\InputFiles\Sample XML.xml");

            XmlNodeList xmlNodeList = xmlDoc.GetElementsByTagName("details");
            DataTable dt = new DataTable();
            dt.Columns.Add("ID");
            dt.Columns.Add("firstname");
            dt.Columns.Add("lastname");
            dt.Columns.Add("title");
            dt.Columns.Add("division");
            dt.Columns.Add("building");
            dt.Columns.Add("room");
            dt.Columns.Add("country");
            dt.Columns.Add("state");
            DataRow dr = dt.NewRow();// new DataRow();
            int i = 1;
            foreach (XmlNode xnode in xmlNodeList)
            {
                dr = dt.NewRow();
                dr["ID"] = i;
                dr["firstname"] = xnode.ChildNodes[0].ChildNodes[0].InnerText;//firstname
                dr["lastname"] = xnode.ChildNodes[0].ChildNodes[1].InnerText;//firstname
                dr["title"] = xnode.ChildNodes[1].InnerText;//title
                dr["division"] = xnode.ChildNodes[2].InnerText;//division
                dr["building"] = xnode.ChildNodes[3].InnerText;//room
                dr["room"] = xnode.ChildNodes[4].InnerText;//room
                dr["country"] = xnode.ChildNodes[5].FirstChild.InnerText;//country
                dr["state"] = xnode.ChildNodes[5].LastChild.InnerText;//country
                dt.Rows.Add(dr);
                i++;
            }
            using (SqlConnection sqlcon = new SqlConnection(@"Server=localhost\SQLEXPRESS;Database=Sample;Trusted_Connection=True"))
            {
                sqlcon.Open();
                SqlBulkCopy bulkCopy = new SqlBulkCopy(sqlcon);
                bulkCopy.DestinationTableName = "Employees";
                bulkCopy.WriteToServer(dt);
                sqlcon.Close();
            }
        }
    }
}