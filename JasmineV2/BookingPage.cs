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
    public partial class frmBookingPage : Form
    {
        public frmBookingPage()
        {
            InitializeComponent();
        }

        private void lblToBookingPg_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void groupBoxClientInformation_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox5_Enter(object sender, EventArgs e)
        {

        }

        private void btnSubmite_Click(object sender, EventArgs e)
        {
            if (txtProgrameType.Text == "" || grupEventType_BookingPg.Text == "" || dtpProgrameStartDate.Text == ""
                || dtpProgrameEndDate.Text == "" || dtpProgrameStartTime.Text == "" || dtpProgrameEndTime.Text == "" || lblRatePerPerson.Text == ""
                || txtEstPeople.Text == "" || txtBookingPreparedBy.Text == "" || txtClientFirstName.Text == "")
                MessageBox.Show("Please, Fillup all the Mendatory Fields:" +
                    "\n" + "that has \"*\" sign.");
            //con.Open();
            //string query = "INSERT into Jasmine_Booking " +
            //    "(ProgrameType,ProgrameDate,ProgrameTime,BookedByClient,BookedByClientEmailAdd,BookedByClientHomeAdd,BookedByClientPhone1,BookedByClientPhone2,BookedForClient,BookedForClientEmailAdd,BookedForClientHomeAdd,BookedForClientPhone1,BookedForClientPhone2,EstimatedPlates,PerPlateRate,Djs,Drinks,Photoes_Videos,Transportations,Decorations,InvitationCards,MakeUp,Botique,DiscountPercent,DiscountAmount,EstimatedByStaffNmae,EstimatedDate) " +
            //    "VALUE('"+ txtProgrameType + "','" + txtProgrameType + "')";
            else
            {
                SqlConnection con = new SqlConnection("Data Source=RSFOREVER-PC;Initial Catalog=Party_PalaceV2;Integrated Security=True");
                con.Open();
                SqlCommand sqlCmd = new SqlCommand("Proc_Jasmine_Booking", con);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@ProgrameType", txtProgrameType.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@EventType", grupEventType_BookingPg.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@ProgrameStartDate", dtpProgrameStartDate.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@ProgrameEndDate", dtpProgrameEndDate.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@ProgrameStartTime", dtpProgrameStartTime.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@ProgrameEndTime", dtpProgrameEndTime.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@RatePerPerson", lblRatePerPerson.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@EstimateGuests", lblEstGuests.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@AdvanceCash", txtCash.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@AdvanceCheque", txtCheque.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@DJ", chkDJ.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@Botique", chkBotique.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@BandBaja", chkBandBaja.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@MakeUp", chkMakeUp.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@Decoration", chkDecoration.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@Stage", chkStage.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@HardDrinks", chkHardDrink.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@SoftDrinks", chkSoftDrink.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@Transportations", chkTransportation.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@InvitationCards", chkInvitationCards.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@StaffInfoId", txtBookingPreparedBy.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@BookingDate", dtpBookingDate.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@Note", txtBookingNotes.Text.Trim());
                //sqlCmd.Parameters.AddWithValue("@ClientPicture", chkBotique.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@Name", txtClientFirstName.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@LastName", txtClientLastName.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@StreetName", txtClientStreetName.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@WardNumber", txtClientWardNumber.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@CityId", txtClientCityName.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@Email", txtClientEmail.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@MobileNumber", txtClientMobile.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@LandLineNumber", txtClientLandLine.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@Name", txtHostName.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@LastName", txtHostLastName.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@StreetName", txtHostStreetName.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@WardNumber", txtHostWardNumber.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@CityId", txtHostCity.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@Email", txtHostCity.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@MobileNumber", txtHostMobile.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@LandLineNumber", txtHostLandLine.Text.Trim());

                sqlCmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Registration is successful");
            }
        }

        private void btnBackToHome_Click(object sender, EventArgs e)
        {
            this.Close();
            frmHomePage HomePg = new frmHomePage();
            HomePg.Show();
        }
    }
}
