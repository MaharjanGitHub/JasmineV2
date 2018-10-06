using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;

namespace JasmineV2
{
    public class DataBaseConnection:frmHomePage
    {
        private frmHomePage home;
        public static string ConnectToDb(object sender, EventArgs e)
        {
            string temptable;
            //Initializing connection string
            SqlConnection con = new SqlConnection("Data Source=RSFOREVER-PC;Initial Catalog=Party_Palace;Integrated Security=True");

            //opening the connection to DB
            con.Open();

            //Quering to specific table into the DB:(Party_Palace), server: (RSFOREVER-P)
            string query = "SELECT * from Party_Palace..UserName_PassWord where UserName = '" + FrmLogIn.PassingUserNametext + "' and PassWord = '" +FrmLogIn.PassingPasswordtext + "'";
            SqlDataAdapter SDA = new SqlDataAdapter(query, con);
            DataTable TempTable = new DataTable();
            return temptable = (SDA.Fill(TempTable)).ToString();

        }
        void Clear()
        {

            //frmHomePage home = new frmHomePage();
            //home.
        }

    }
}
