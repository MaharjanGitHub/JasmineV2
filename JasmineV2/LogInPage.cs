using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JasmineV2
{
    public partial class FrmLogIn : Form
    {
        public FrmLogIn()
        {
            InitializeComponent();
        }
        
        private void FrmLogIn_Load(object sender, EventArgs e)
        {

        }
        public static string PassingUserNametext;
        public static String PassingPasswordtext;
        //Connecting to data base
        SqlConnection con = new SqlConnection("Data Source=RSFOREVER-PC;Initial Catalog=Party_Palace;Integrated Security=True");
        private void btnLogIn_Click(object sender, EventArgs e)
        {
            //opening connection to DB
            this.con.Open();
            //Quering to specific table into the DB:(Party_Palace), server: (RSFOREVER-P)
            string query = "SELECT * from Party_Palace..UserName_PassWord where UserName = '" + txtUserName.Text.Trim() + "' and PassWord = '" + txtPassWord.Text.Trim() + "'";
            SqlDataAdapter SDA = new SqlDataAdapter(query, con);
            DataTable TempTable = new DataTable();
            SDA.Fill(TempTable);

            if (TempTable.Rows.Count == 0)
            {
                PassingUserNametext = txtUserName.Text.Trim().ToUpper();
                PassingPasswordtext = txtPassWord.Text.Trim();
                this.Hide();
                frmHomePage home = new frmHomePage();
                home.ShowDialog();
            }
            else
            {
                MessageBox.Show("Please, make sure your User Name and Pass Word are correct. \n Please, try again");
                txtUserName.Focus();
            }
            this.con.Close();
        }

        private void chkShowPassWordLogInPg_CheckedChanged(object sender, EventArgs e)
        {
                if (chkShowPassWordLogInPg.Checked)
                {
                    //OPTION TO SHOW UNMASK THE TYPED CHARACTERS ON TEXTBOX
                    txtPassWord.UseSystemPasswordChar = true;
                }
                else
                {
                    txtPassWord.UseSystemPasswordChar = false;
                }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtUserName.Text = "";
            txtPassWord.Text = "";
            chkShowPassWordLogInPg.Checked = false;
            txtUserName.Focus();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();

        }
    }
}
