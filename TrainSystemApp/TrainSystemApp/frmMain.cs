using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TrainSystemApp
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
            //Таймер,показващ часа на закупуване на билета
            timerBuy.Start();
        }

        //Дата и час, показващи закупуването на билета
        private void timerBuy_Tick(object sender, EventArgs e)
        {
            DateTime iTime = DateTime.Now;
            lblTime.Text = iTime.ToLongTimeString();

            DateTime iDate = DateTime.Now;
            lblDate.Text = iDate.ToLongDateString();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            chkAddLuggage.Checked = true;
            chkAlone.Checked = true;
            chkBreakfast.Checked = true;
            //chkInsurance.Checked = true;
        }

        //Buttons "Next" + Button "Buy a Ticket"
        private void btnBuy_Click(object sender, EventArgs e)
        {
            Home.Visible = false;
            Travel.Visible = true;
            TypeTicket.Visible = false;
            Price.Visible = false;
            Users.Visible = false;
            Pay.Visible = false;
            Receipt.Visible = false;
        }

        private void btnNextTravel_Click_1(object sender, EventArgs e)
        {
            Home.Visible = false;
            Travel.Visible = false;
            TypeTicket.Visible = true;
            Price.Visible = false;
            Users.Visible = false;
            Pay.Visible = false;
            Receipt.Visible = false;
        }

        private void NextTypeTicket_Click(object sender, EventArgs e)
        {
            Home.Visible = false;
            Travel.Visible = false;
            TypeTicket.Visible = false;
            Price.Visible = true;
            Users.Visible = false;
            Pay.Visible = false;
            Receipt.Visible = false;
            cPrice Travelprice = new cPrice();
            iTax AirTax = new iTax();
            double[] TravelCost = new double[20];
            double[] TaxCost = new double[20];
            double Total;
            if (cmbDestination.Text == "София")
            {
                TravelCost[0] = Travelprice.Sofiya;
                TaxCost[0] = AirTax.iFindTax(TravelCost[0]);
                Total = TravelCost[0] + TaxCost[0];

                lblDeparture.Text = String.Format(cmbDeparture.Text);
                lblDestination.Text = String.Format(cmbDestination.Text);
                lblPrice.Text = String.Format("{0} лв.", Total);
            }
        }

        private void NextPrice_Click(object sender, EventArgs e)
        {
            Home.Visible = false;
            Travel.Visible = false;
            TypeTicket.Visible = false;
            Price.Visible = false;
            Users.Visible = true;
            Pay.Visible = false;
            Receipt.Visible = false;
        }


        private void BackPrice_Click(object sender, EventArgs e)
        {
            Home.Visible = false;
            Travel.Visible = true;
            TypeTicket.Visible = false;
            Price.Visible = false;
            Users.Visible = false;
            Pay.Visible = false;
            Receipt.Visible = false;
        }

        private void NextUsers_Click(object sender, EventArgs e)
        {
            Home.Visible = false;
            Travel.Visible = false;
            TypeTicket.Visible = false;
            Price.Visible = false;
            Users.Visible = false;
            Pay.Visible = true;
            Receipt.Visible = false;
        }

        private void NextPay_Click(object sender, EventArgs e)
        {
            Home.Visible = false;
            Travel.Visible = false;
            TypeTicket.Visible = false;
            Price.Visible = false;
            Users.Visible = false;
            Pay.Visible = false;
            Receipt.Visible = true;
            int num1;
            Random rnd = new Random();
            num1 = rnd.Next(4238, 34238);
            num1 = 1325 + num1;
            String refs = Convert.ToString(num1);

            //========Изчисляване на цена=======
            cPrice Travelprice = new cPrice();
            iTax Tax = new iTax();
            double[] TravelCost = new double[20];
            double[] TaxCost = new double[20];
            double Total;
            if (cmbDestination.Text == "София")
            {
                TravelCost[0] = Travelprice.Sofiya;
                TaxCost[0] = Tax.iFindTax(TravelCost[0]);
                Total = TravelCost[0] + TaxCost[0];
                //Total = total;
            }

            //==================================
            String Firstname = (txtFirstname.Text);
            String Lastame = (txtLastname.Text);
            String City = (txtCity.Text);
            String Number = (txtNumber.Text);
            String Email = (txtEmail.Text);


            rtReceipt.AppendText("Ref:\t\t\t" + refs
                + "\n_______________________________"
                + "\nИме:\t\t\t" + txtFirstname.Text
                + "\nФамилия:\t\t" + txtLastname.Text
                + "\nТелефон:\t\t" + txtNumber.Text
                + "\nЕл. поща:\t\t" + txtEmail.Text
                + "\nНачална гара:\t" + cmbDeparture.Text
                + "\nКрайна гара:\t\t" + cmbDestination.Text
                + "\n_______________________________"
                + "\nЦена:\t\t\t" + lblPrice.Text
                //+ "\n_______________________________"
                //+ "\n " + lblDate.Text + "  \t" + lblTime.Text
                + "\n_______________________________"
                + "\n\n\tЗакупен от bucketlist"
            );
        }

        private void label1_Click(object sender, EventArgs e)
        {
           
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }



        //========================


        //Minimize Aplication
        //private void btnMinimize_Click(object sender, EventArgs e)
        //{
        //    this.WindowState = FormWindowState.Minimized;
        //}
        //========================


        //Close Application
        //private void btnClose_Click(object sender, EventArgs e)
        //{
        //    this.Close();
        //}
        //========================


        //Move Application with Dragging
        //int mouseX = 0, mouseY = 0;
        //bool mouseDown;

        //private void Bar_MouseDown(object sender, MouseEventArgs e)
        //{
        //    mouseDown = true;
        //}

        //private void Bar_MouseUp(object sender, MouseEventArgs e)
        //{
        //    mouseDown = false;
        //}

        //private void Bar_MouseMove(object sender, MouseEventArgs e)
        //{
        //    if(mouseDown)
        //    {
        //        mouseX = MousePosition.X - 200;
        //        mouseY = MousePosition.Y - 40;

        //        this.SetDesktopLocation(mouseX,mouseY);
        //    }
        //}
        //========================
    }
}
