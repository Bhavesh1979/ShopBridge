using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using MySql.Data.MySqlClient;
using System.IO;
public partial class _Default : System.Web.UI.Page 
{
    MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["mysql"].ConnectionString);
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        fillItems();
    }
    
    public void fillItems()
    {
        ListBox1.Items.Clear();
        string query = "";
        query = "select Itemname from items order by itemname desc";
        MySqlDataAdapter da = new MySqlDataAdapter(query, con);
        DataSet ds = new DataSet();
        da.Fill(ds);
        DataTable dt = ds.Tables[0];
        foreach (DataRow dr in dt.Rows)
        {
            ListBox1.Items.Add(dr["Itemname"].ToString().Trim());
            
        }

    }

    protected void Button1_Click1(object sender, EventArgs e)
    {
        AddItems();    
        
    }
    public void AddItems()
    {
        Class1 cl = new Class1();
        if (TextBox1.Text.Length != 0 && TextBox2.Text.Length != 0 && TextBox3.Text.Length != 0)
        {
            int id = 0;
            id = cl.getID("items");
            id = id + 1;

            string dpath = Server.MapPath(@"~\photos\");
            if (!Directory.Exists(dpath))
                Directory.CreateDirectory(dpath);

            if (FileUpload1.HasFile)
            {
                FileUpload1.SaveAs(Server.MapPath(@"~\photos\") + "\\" + id.ToString().Trim() + Path.GetExtension(FileUpload1.FileName));
            }

            string query;
            con.Open();
            if (FileUpload1.HasFile == true)
                query = "insert into items(Itemname,Price,image,description) values (@in,@ip,@ii,@id)";
            else
                query = "insert into items(Itemname,Price,description) values (@in,@ip,@id)";
            MySqlCommand cmd = new MySqlCommand(query, con);

            cmd.Parameters.Add("@in", MySqlDbType.VarChar, 45).Value = TextBox1.Text.Trim().ToUpper();
            try
            {
                cmd.Parameters.Add("@ip", MySqlDbType.Double).Value = Double.Parse(TextBox3.Text.Trim());


                cmd.Parameters.Add("@id", MySqlDbType.Text).Value = TextBox2.Text.Trim();
                if (FileUpload1.HasFile)
                    cmd.Parameters.Add("@ii", MySqlDbType.Text).Value = @"~\photos\" + id.ToString().Trim() + Path.GetExtension(FileUpload1.FileName);
                cmd.ExecuteNonQuery();
                con.Close();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Record Status", "<script> alert('Item added Successfully!');</script>", false);
                clearTextbox();
            }
            catch { ScriptManager.RegisterStartupScript(this, this.GetType(), "Record Status", "<script> alert('Enter price in numbers!');</script>", false); }

        }
        else
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Record Status", "<script> alert('Item fiels can not be empty!');</script>", false);
        
    }
    protected void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillData();
    }
    public void fillData()
    {
        string que;
        que = "select * from items where itemname='" + ListBox1.SelectedItem.Value.Trim() + "'";
        MySqlDataAdapter da = new MySqlDataAdapter(que, con);
        DataSet ds = new DataSet();
        da.Fill(ds);
        DataTable dt = ds.Tables[0];

        if (dt.Rows.Count > 0)
        {
            foreach (DataRow dr in dt.Rows)
            {
                Label1.Text = dr["ID"].ToString().Trim();
                Label2.Text = dr["itemname"].ToString().Trim();
                Label3.Text = dr["description"].ToString().Trim();
                Label4.Text = dr["price"].ToString().Trim();
                Image1.ImageUrl = dr["image"].ToString().Trim();
                                   
            }
        }      
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        deleteItems();
    }
    public void deleteItems()
    {
        string que = "";
        con.Open();
        que = "delete from items where id=" + Label1.Text.Trim();
        MySqlCommand cmd4 = new MySqlCommand(que, con);
        cmd4.ExecuteNonQuery();
        con.Close();
        File.Delete(Server.MapPath(@Image1.ImageUrl.ToString().Trim()));
        ScriptManager.RegisterStartupScript(this, this.GetType(), "Record Status", "<script> alert('Item deleted Successfully!');</script>", false);
        clearTextbox();
    }
    public void clearTextbox()
    {
        Label1.Text = "";
        Label2.Text = "";
        Label3.Text = "";
        TextBox1.Text = "";
        TextBox2.Text = "";
        TextBox3.Text = "";
        fillItems();
    }
}