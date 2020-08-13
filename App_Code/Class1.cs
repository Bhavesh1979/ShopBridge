using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using MySql.Data.MySqlClient;
using System.Configuration;


/// <summary>
/// Summary description for Class1
/// </summary>
public class Class1
{
    MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["mysql"].ConnectionString);
    
	public Class1()
	{
		
	}
    public int getID(string ta)
    {

        string que = "";
        string high = "";
        que = "select max(ID) from " + ta;
        MySqlDataAdapter da = new MySqlDataAdapter(que, con);
        DataSet ds = new DataSet();
        da.Fill(ds);
        DataTable dt = ds.Tables[0];
        foreach (DataRow dr in dt.Rows)
        {
            high = dr[0].ToString();
        }
        if (high.Length == 0)
            return 0;
        else
            return Int32.Parse(high);

    }
 
}