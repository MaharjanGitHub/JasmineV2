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
    public partial class frmHomePage : Form
    {

        public frmHomePage()
        {
            InitializeComponent();
        }

        private void HomePage_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'party_PalaceDataSet5.Jasmine_Booking' table. You can move, or remove it, as needed.
            this.jasmine_BookingTableAdapter5.Fill(this.party_PalaceDataSet5.Jasmine_Booking);
            // TODO: This line of code loads data into the 'party_PalaceDataSet4.Jasmine_Booking' table. You can move, or remove it, as needed.
            this.jasmine_BookingTableAdapter4.Fill(this.party_PalaceDataSet4.Jasmine_Booking);
            // TODO: This line of code loads data into the 'party_PalaceDataSet3.Jasmine_Booking' table. You can move, or remove it, as needed.
            this.jasmine_BookingTableAdapter3.Fill(this.party_PalaceDataSet3.Jasmine_Booking);
            // TODO: This line of code loads data into the 'party_PalaceDataSet2.Jasmine_Booking' table. You can move, or remove it, as needed.
            this.jasmine_BookingTableAdapter2.Fill(this.party_PalaceDataSet2.Jasmine_Booking);
            // TODO: This line of code loads data into the 'party_PalaceDataSet1.Jasmine_Booking' table. You can move, or remove it, as needed.
            this.jasmine_BookingTableAdapter1.Fill(this.party_PalaceDataSet1.Jasmine_Booking);
            // TODO: This line of code loads data into the 'party_PalaceDataSet.Jasmine_Booking' table. You can move, or remove it, as needed.
            this.jasmine_BookingTableAdapter.Fill(this.party_PalaceDataSet.Jasmine_Booking);

            tmrHomePg.Start();
            //passing the typed text from FrLogIn>>txtUserName
            string txtfromLogin = FrmLogIn.PassingUserNametext;
            string wellCome = string.Format("Hi {0:touppercase}, Well Come to the Jasmine Party Palace.", txtfromLogin); 
            lblWelComeHomePg.Text = wellCome;

            InitialDataGrideView();
            //to display empty value on the combo box
            cmbProgramTypeHomePg.SelectedIndex = -1;
            cmbEventTypeHomePg.SelectedIndex = -1;
            cmbBookedByClientNameHomePg.SelectedIndex = -1;
            cmbHostNameHomePg.SelectedIndex = -1;
            cmbHostPhoneHomePg.SelectedIndex = -1;
            cmbClientPhoneHomePg.SelectedIndex = -1;
            dtpFromHomePg.Text = InitialDateFordtpFromHomePg().ToString();
            
        }
        public void InitialDataGrideView()
        {
            SqlConnection con = new SqlConnection("Data Source=RSFOREVER-PC;Initial Catalog=Party_Palace;Integrated Security=True");
            con.Open();
            string query = "select ProgrameType as Program,ProgrameDate as Date,ProgrameTime as time,\n" +
                "BookedByClient,BookedByClientPhone1,BookedForClient as HostName,\n" +
                "BookedForClientPhone1 as HostPhone#,EstimatedByStaffNmae as EstimatedBy,\n" +
                "EstimatedDate,EstimatedPlates,PerPlateRate from party_palace..jasmine_booking";
            SqlDataAdapter SDA = new SqlDataAdapter(query, con);
            DataTable DT = new DataTable();
            SDA.Fill(DT);
            dgvBookingListHomePg.DataSource = DT;
            con.Close();
            //Alternative way to change the formate of calendar
            /*dtpFromHomePg.Format = DateTimePickerFormat.Custom;
            dtpFromHomePg.CustomFormat = "dd-MM-yyyy";*/
        }

        private void tmrHomePg_Tick(object sender, EventArgs e)
        {
            DateTime currentDateTime = DateTime.Now;
            //lblTime.Text = currentDateTime.ToLongTimeString();
            //lblTimeHomePg.Text = String.Format("{0:D:F}", currentDateTime);
            this.lblTime.Text = string.Format("{0:T}", currentDateTime);
        }
        public void getProgramTypeForCombo()
        {
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            //bool _searchCategory = chkProgramType.Checked;
            DateTime _fromDate = Convert.ToDateTime(dtpFromHomePg.Text);
            DateTime _todDate = Convert.ToDateTime(dtpToHomePg.Text);
            string _programType = cmbProgramTypeHomePg.Text.ToString();
            string _bookedBy = cmbBookedByClientNameHomePg.Text.ToString();
            string _hostName = cmbHostNameHomePg.Text.ToString();
            searchData(_fromDate,_todDate, _programType,  _bookedBy, _hostName);
        }
        public void searchData(DateTime fromDate,DateTime toDate, string ProgramType="%", string BookedBy="%",string HostName ="%")
        {
            if (cmbProgramTypeHomePg.Text!=""|| dtpFromHomePg.Text!="")
            {
                SqlConnection con = new SqlConnection("Data Source=RSFOREVER-PC;Initial Catalog=Party_Palace;Integrated Security=True");
                con.Open();
                string query = "select ProgrameType as Program,ProgrameDate as Date,ProgrameTime as time, BookedByClient,BookedByClientPhone1,BookedForClient as HostName,BookedForClientPhone1 as HostPhone#,EstimatedByStaffNmae as EstimatedBy,EstimatedDate,EstimatedPlates,PerPlateRate from party_palace..jasmine_booking " +
                    "where ProgrameType like '%" + ProgramType + "'" + "and BookedByClient like '%"
                    +BookedBy+"'"+ "and BookedForClient like '%" + HostName + "'"+ "and ProgrameDate >=" +"'"+ fromDate+"'"+ "and ProgrameDate <=" + "'"+toDate+"'";
                SqlDataAdapter SDA = new SqlDataAdapter(query, con);
                DataTable DT = new DataTable();
                SDA.Fill(DT);
                dgvBookingListHomePg.DataSource = DT;
                con.Close();
            }
            else 
            {
                MessageBox.Show("Please, select at leaset one value from the dropdown box");
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            InitialDataGrideView();
            InitialDateFordtpFromHomePg();
            clear();
            
        }
        void clear()
        {
            chkFromDateHomePg.Checked = false;
            dtpFromHomePg.Text = InitialDateFordtpFromHomePg().ToString();
            chkToDateHomePg.Checked = false;
            dtpToHomePg.Text = "";
            chkProgramType.Checked = false;
            cmbProgramTypeHomePg.Text = "";
            chkEventType.Checked = false;
            cmbEventTypeHomePg.Text = "";
            chkBookedByClientName.Checked = false;
            cmbBookedByClientNameHomePg.Text = "";
            chkHostName.Checked = false;
            cmbHostNameHomePg.Text = "";
            chkBookedClientPhone.Checked = false;
            cmbClientPhoneHomePg.Text = "";
            chkHostPhone.Checked = false;
            cmbHostPhoneHomePg.Text = "";
        }

        private void dgvBookingListHomePg_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            this.dgvBookingListHomePg.Rows[e.RowIndex].Cells["SN"].Value = (e.RowIndex + 1).ToString();
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            this.Close();
            FrmLogIn LoginPg = new FrmLogIn();
            LoginPg.Show();
        }

        private void bookingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            frmBookingPage gotoBookingPg = new frmBookingPage();
            gotoBookingPg.Show();
        }
        public static DateTime InitialDateFordtpFromHomePg()
        {
            SqlConnection con = new SqlConnection("Data Source=RSFOREVER-PC;Initial Catalog=Party_Palace;Integrated Security=True");
            con.Open();
            string query = "select top 1 ProgrameDate from party_palace..jasmine_booking\n" +
                            "order by 1 asc";
            SqlDataAdapter SDA = new SqlDataAdapter(query, con);
            DataTable DT = new DataTable();
            SDA.Fill(DT);
            var startdate = Convert.ToDateTime(DT.Rows[0][0]);
            con.Close();
            return startdate;
            
        }
    }
}
