using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
//М: връзка за база данни
using System.Data.SqlClient;

namespace TrainSystemApp
{
    public partial class frmMain : Form
    {
        //UserTable user = new UserTable();
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

        //private void frmMain_Load(object sender, EventArgs e)
        //{
        //    chkAddLuggage.Checked = true;
        //    chkAlone.Checked = true;
        //    chkBreakfast.Checked = true;
        //    chkInsurance.Checked = true;
        //}

        //Buttons "Next" + Button "Buy a Ticket"


        //M: Слайд за посочване на гара на тръгване и на пристигане
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

        //М: Слайд за вид билет; години на пътника; допълнителни услуги
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

        //М: Слайд за изчисляване на цената
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
            //iTax Tax = new iTax();
            double[] TravelCost = new double[20];
            //double[] TaxCost = new double[20];
            double Total;
            if (cmbDestination.Text == "София")
            {
                TravelCost[0] = Travelprice.Sofiya;
                //TaxCost[0] = Tax.iFindTax(TravelCost[0]);
                if (rbLuxury.Checked == true)
                {
                    //+20 lv za luksozna klasa
                    if (rbTeen.Checked == true) //ako 7 god.<user<18 god.
                    {
                        Total = (((TravelCost[0]*0.2)+TravelCost[0]) / 2) + 20; //50% namalenie, no s za luksozna klasa
                        if (chkBreakfast.Checked == true)
                        {
                            Total += 5; /*za zakuska*/
                        }
                        if (chkAlone.Checked == true)
                        {
                            Total += 8; /*za samostoqtelno kupe*/
                        }
                        if (chkAddLuggage.Checked == true)
                        {
                            Total += 4; /*za dopylnitelen bagaj*/
                        }
                        lblDeparture.Text = String.Format(cmbDeparture.Text);
                        lblDestination.Text = String.Format(cmbDestination.Text);
                        lblPrice.Text = String.Format("{0} лв.", Total);
                    }
                    else if (rbChild.Checked == true) //ako user<7 god.
                    {
                        Total = 0; //za deca pod 7 vsichko e bezplatno;                      
                    }
                    else if (rbAdult.Checked == true) //ako 18 god.<user
                    {
                        Total = ((TravelCost[0] * 0.2) + TravelCost[0]) + 20; /*za luksozna klasa*/
                        if (chkBreakfast.Checked == true)
                        {
                            Total += 10; /*za zakuska*/
                        }
                        if (chkAlone.Checked == true)
                        {
                            Total += 15; /*za samostoqtelno kupe*/
                        }
                        if (chkAddLuggage.Checked == true)
                        {
                            Total += 7; /*za dopylnitelen bagaj*/
                        }
                    }
                }
                else if(rbStandart.Checked == true)
                {
                    if (rbTeen.Checked == true) //ako 7 god.<user<18 god.
                    {
                        Total = (((TravelCost[0] * 0.2) + TravelCost[0]) / 2); //50% namalenie
                        if (chkBreakfast.Checked == true)
                        {
                            Total += 5; /*za zakuska*/
                        }
                        if (chkAlone.Checked == true)
                        {
                            Total += 8; /*za samostoqtelno kupe*/
                        }
                        if (chkAddLuggage.Checked == true)
                        {
                            Total += 4; /*za dopylnitelen bagaj*/
                        }
                    }
                    else if (rbChild.Checked == true) //ako user<7 god.
                    {
                        Total = 0; //za deca pod 7 vsichko e bezplatno;                      
                    }
                    else if (rbAdult.Checked == true) //ako 18 god.<user
                    {
                        Total = (TravelCost[0] * 0.2) + TravelCost[0];
                        if (chkBreakfast.Checked == true)
                        {
                            Total += 10; /*za zakuska*/
                        }
                        if (chkAlone.Checked == true)
                        {
                            Total += 15; /*za samostoqtelno kupe*/
                        }
                        if (chkAddLuggage.Checked == true)
                        {
                            Total += 7; /*za dopylnitelen bagaj*/
                        }
                    }
                }


            }
            //if (cmbDestination.Text == "Бургас")
            //{
            //    TravelCost[0] = Travelprice.Bourgas;
            //    TaxCost[0] = Tax.iFindTax(TravelCost[0]);
            //    if (rbLuxury.Checked == true)
            //    {
            //        //+20 lv za luksozna klasa
            //        if (rbTeen.Checked == true) //ako 7 god.<user<18 god.
            //        {
            //            Total = ((TravelCost[0] + TaxCost[0]) / 2) + 20; //50% namalenie, no s za luksozna klasa
            //            if (chkBreakfast.Checked == true)
            //            {
            //                Total += 5; /*za zakuska*/
            //            }
            //            if (chkAlone.Checked == true)
            //            {
            //                Total += 8; /*za samostoqtelno kupe*/
            //            }
            //            if (chkAddLuggage.Checked == true)
            //            {
            //                Total += 4; /*za dopylnitelen bagaj*/
            //            }
            //        }
            //        else if (rbChild.Checked == true) //ako user<7 god.
            //        {
            //            Total = 0; //za deca pod 7 vsichko e bezplatno;                      
            //        }
            //        else if (rbAdult.Checked == true) //ako 18 god.<user
            //        {
            //            Total = TravelCost[0] + TaxCost[0] + 20; /*za luksozna klasa*/
            //            if (chkBreakfast.Checked == true)
            //            {
            //                Total += 10; /*za zakuska*/
            //            }
            //            if (chkAlone.Checked == true)
            //            {
            //                Total += 15; /*za samostoqtelno kupe*/
            //            }
            //            if (chkAddLuggage.Checked == true)
            //            {
            //                Total += 7; /*za dopylnitelen bagaj*/
            //            }
            //        }
            //    }
            //    else
            //    {
            //        if (rbTeen.Checked == true) //ako 7 god.<user<18 god.
            //        {
            //            Total = (TravelCost[0] + TaxCost[0]) / 2; //50% namalenie
            //            if (chkBreakfast.Checked == true)
            //            {
            //                Total += 5; /*za zakuska*/
            //            }
            //            if (chkAlone.Checked == true)
            //            {
            //                Total += 8; /*za samostoqtelno kupe*/
            //            }
            //            if (chkAddLuggage.Checked == true)
            //            {
            //                Total += 4; /*za dopylnitelen bagaj*/
            //            }
            //        }
            //        else if (rbChild.Checked == true) //ako user<7 god.
            //        {
            //            Total = 0; //za deca pod 7 vsichko e bezplatno;                      
            //        }
            //        else if (rbAdult.Checked == true) //ako 18 god.<user
            //        {
            //            Total = TravelCost[0] + TaxCost[0];
            //            if (chkBreakfast.Checked == true)
            //            {
            //                Total += 10; /*za zakuska*/
            //            }
            //            if (chkAlone.Checked == true)
            //            {
            //                Total += 15; /*za samostoqtelno kupe*/
            //            }
            //            if (chkAddLuggage.Checked == true)
            //            {
            //                Total += 7; /*za dopylnitelen bagaj*/
            //            }
            //        }
            //    }

            //}
            //if (cmbDestination.Text == "Варна")
            //{
            //    TravelCost[0] = Travelprice.Varna;
            //    TaxCost[0] = Tax.iFindTax(TravelCost[0]);
            //    if (rbLuxury.Checked == true)
            //    {
            //        //+20 lv za luksozna klasa
            //        if (rbTeen.Checked == true) //ako 7 god.<user<18 god.
            //        {
            //            Total = ((TravelCost[0] + TaxCost[0]) / 2) + 20; //50% namalenie, no s za luksozna klasa
            //            if (chkBreakfast.Checked == true)
            //            {
            //                Total += 5; /*za zakuska*/
            //            }
            //            if (chkAlone.Checked == true)
            //            {
            //                Total += 8; /*za samostoqtelno kupe*/
            //            }
            //            if (chkAddLuggage.Checked == true)
            //            {
            //                Total += 4; /*za dopylnitelen bagaj*/
            //            }
            //        }
            //        else if (rbChild.Checked == true) //ako user<7 god.
            //        {
            //            Total = 0; //za deca pod 7 vsichko e bezplatno;                      
            //        }
            //        else if (rbAdult.Checked == true) //ako 18 god.<user
            //        {
            //            Total = TravelCost[0] + TaxCost[0] + 20; /*za luksozna klasa*/
            //            if (chkBreakfast.Checked == true)
            //            {
            //                Total += 10; /*za zakuska*/
            //            }
            //            if (chkAlone.Checked == true)
            //            {
            //                Total += 15; /*za samostoqtelno kupe*/
            //            }
            //            if (chkAddLuggage.Checked == true)
            //            {
            //                Total += 7; /*za dopylnitelen bagaj*/
            //            }
            //        }
            //    }
            //    else
            //    {
            //        if (rbTeen.Checked == true) //ako 7 god.<user<18 god.
            //        {
            //            Total = (TravelCost[0] + TaxCost[0]) / 2; //50% namalenie
            //            if (chkBreakfast.Checked == true)
            //            {
            //                Total += 5; /*za zakuska*/
            //            }
            //            if (chkAlone.Checked == true)
            //            {
            //                Total += 8; /*za samostoqtelno kupe*/
            //            }
            //            if (chkAddLuggage.Checked == true)
            //            {
            //                Total += 4; /*za dopylnitelen bagaj*/
            //            }
            //        }
            //        else if (rbChild.Checked == true) //ako user<7 god.
            //        {
            //            Total = 0; //za deca pod 7 vsichko e bezplatno;                      
            //        }
            //        else if (rbAdult.Checked == true) //ako 18 god.<user
            //        {
            //            Total = TravelCost[0] + TaxCost[0];
            //            if (chkBreakfast.Checked == true)
            //            {
            //                Total += 10; /*za zakuska*/
            //            }
            //            if (chkAlone.Checked == true)
            //            {
            //                Total += 15; /*za samostoqtelno kupe*/
            //            }
            //            if (chkAddLuggage.Checked == true)
            //            {
            //                Total += 7; /*za dopylnitelen bagaj*/
            //            }
            //        }
            //    }

            //}
            //if (cmbDestination.Text == "Пловдив")
            //{
            //    TravelCost[0] = Travelprice.Plovdiv;
            //    TaxCost[0] = Tax.iFindTax(TravelCost[0]);
            //    if (rbLuxury.Checked == true)
            //    {
            //        //+20 lv za luksozna klasa
            //        if (rbTeen.Checked == true) //ako 7 god.<user<18 god.
            //        {
            //            Total = ((TravelCost[0] + TaxCost[0]) / 2) + 20; //50% namalenie, no s za luksozna klasa
            //            if (chkBreakfast.Checked == true)
            //            {
            //                Total += 5; /*za zakuska*/
            //            }
            //            if (chkAlone.Checked == true)
            //            {
            //                Total += 8; /*za samostoqtelno kupe*/
            //            }
            //            if (chkAddLuggage.Checked == true)
            //            {
            //                Total += 4; /*za dopylnitelen bagaj*/
            //            }
            //        }
            //        else if (rbChild.Checked == true) //ako user<7 god.
            //        {
            //            Total = 0; //za deca pod 7 vsichko e bezplatno;                      
            //        }
            //        else if (rbAdult.Checked == true) //ako 18 god.<user
            //        {
            //            Total = TravelCost[0] + TaxCost[0] + 20; /*za luksozna klasa*/
            //            if (chkBreakfast.Checked == true)
            //            {
            //                Total += 10; /*za zakuska*/
            //            }
            //            if (chkAlone.Checked == true)
            //            {
            //                Total += 15; /*za samostoqtelno kupe*/
            //            }
            //            if (chkAddLuggage.Checked == true)
            //            {
            //                Total += 7; /*za dopylnitelen bagaj*/
            //            }
            //        }
            //    }
            //    else
            //    {
            //        if (rbTeen.Checked == true) //ako 7 god.<user<18 god.
            //        {
            //            Total = (TravelCost[0] + TaxCost[0]) / 2; //50% namalenie
            //            if (chkBreakfast.Checked == true)
            //            {
            //                Total += 5; /*za zakuska*/
            //            }
            //            if (chkAlone.Checked == true)
            //            {
            //                Total += 8; /*za samostoqtelno kupe*/
            //            }
            //            if (chkAddLuggage.Checked == true)
            //            {
            //                Total += 4; /*za dopylnitelen bagaj*/
            //            }
            //        }
            //        else if (rbChild.Checked == true) //ako user<7 god.
            //        {
            //            Total = 0; //za deca pod 7 vsichko e bezplatno;                      
            //        }
            //        else if (rbAdult.Checked == true) //ako 18 god.<user
            //        {
            //            Total = TravelCost[0] + TaxCost[0];
            //            if (chkBreakfast.Checked == true)
            //            {
            //                Total += 10; /*za zakuska*/
            //            }
            //            if (chkAlone.Checked == true)
            //            {
            //                Total += 15; /*za samostoqtelno kupe*/
            //            }
            //            if (chkAddLuggage.Checked == true)
            //            {
            //                Total += 7; /*za dopylnitelen bagaj*/
            //            }
            //        }
            //    }

            //}
            //if (cmbDestination.Text == "Горна Оряховица")
            //{
            //    TravelCost[0] = Travelprice.GornaOrqhovica;
            //    TaxCost[0] = Tax.iFindTax(TravelCost[0]);
            //    if (rbLuxury.Checked == true)
            //    {
            //        //+20 lv za luksozna klasa
            //        if (rbTeen.Checked == true) //ako 7 god.<user<18 god.
            //        {
            //            Total = ((TravelCost[0] + TaxCost[0]) / 2) + 20; //50% namalenie, no s za luksozna klasa
            //            if (chkBreakfast.Checked == true)
            //            {
            //                Total += 5; /*za zakuska*/
            //            }
            //            if (chkAlone.Checked == true)
            //            {
            //                Total += 8; /*za samostoqtelno kupe*/
            //            }
            //            if (chkAddLuggage.Checked == true)
            //            {
            //                Total += 4; /*za dopylnitelen bagaj*/
            //            }
            //        }
            //        else if (rbChild.Checked == true) //ako user<7 god.
            //        {
            //            Total = 0; //za deca pod 7 vsichko e bezplatno;                      
            //        }
            //        else if (rbAdult.Checked == true) //ako 18 god.<user
            //        {
            //            Total = TravelCost[0] + TaxCost[0] + 20; /*za luksozna klasa*/
            //            if (chkBreakfast.Checked == true)
            //            {
            //                Total += 10; /*za zakuska*/
            //            }
            //            if (chkAlone.Checked == true)
            //            {
            //                Total += 15; /*za samostoqtelno kupe*/
            //            }
            //            if (chkAddLuggage.Checked == true)
            //            {
            //                Total += 7; /*za dopylnitelen bagaj*/
            //            }
            //        }
            //    }
            //    else
            //    {
            //        if (rbTeen.Checked == true) //ako 7 god.<user<18 god.
            //        {
            //            Total = (TravelCost[0] + TaxCost[0]) / 2; //50% namalenie
            //            if (chkBreakfast.Checked == true)
            //            {
            //                Total += 5; /*za zakuska*/
            //            }
            //            if (chkAlone.Checked == true)
            //            {
            //                Total += 8; /*za samostoqtelno kupe*/
            //            }
            //            if (chkAddLuggage.Checked == true)
            //            {
            //                Total += 4; /*za dopylnitelen bagaj*/
            //            }
            //        }
            //        else if (rbChild.Checked == true) //ako user<7 god.
            //        {
            //            Total = 0; //za deca pod 7 vsichko e bezplatno;                      
            //        }
            //        else if (rbAdult.Checked == true) //ako 18 god.<user
            //        {
            //            Total = TravelCost[0] + TaxCost[0];
            //            if (chkBreakfast.Checked == true)
            //            {
            //                Total += 10; /*za zakuska*/
            //            }
            //            if (chkAlone.Checked == true)
            //            {
            //                Total += 15; /*za samostoqtelno kupe*/
            //            }
            //            if (chkAddLuggage.Checked == true)
            //            {
            //                Total += 7; /*za dopylnitelen bagaj*/
            //            }
            //        }
            //    }

            //}
            //if (cmbDestination.Text == "Перник")
            //{
            //    TravelCost[0] = Travelprice.Pernik;
            //    TaxCost[0] = Tax.iFindTax(TravelCost[0]);
            //    if (rbLuxury.Checked == true)
            //    {
            //        //+20 lv za luksozna klasa
            //        if (rbTeen.Checked == true) //ako 7 god.<user<18 god.
            //        {
            //            Total = ((TravelCost[0] + TaxCost[0]) / 2) + 20; //50% namalenie, no s za luksozna klasa
            //            if (chkBreakfast.Checked == true)
            //            {
            //                Total += 5; /*za zakuska*/
            //            }
            //            if (chkAlone.Checked == true)
            //            {
            //                Total += 8; /*za samostoqtelno kupe*/
            //            }
            //            if (chkAddLuggage.Checked == true)
            //            {
            //                Total += 4; /*za dopylnitelen bagaj*/
            //            }
            //        }
            //        else if (rbChild.Checked == true) //ako user<7 god.
            //        {
            //            Total = 0; //za deca pod 7 vsichko e bezplatno;                      
            //        }
            //        else if (rbAdult.Checked == true) //ako 18 god.<user
            //        {
            //            Total = TravelCost[0] + TaxCost[0] + 20; /*za luksozna klasa*/
            //            if (chkBreakfast.Checked == true)
            //            {
            //                Total += 10; /*za zakuska*/
            //            }
            //            if (chkAlone.Checked == true)
            //            {
            //                Total += 15; /*za samostoqtelno kupe*/
            //            }
            //            if (chkAddLuggage.Checked == true)
            //            {
            //                Total += 7; /*za dopylnitelen bagaj*/
            //            }
            //        }
            //    }
            //    else
            //    {
            //        if (rbTeen.Checked == true) //ako 7 god.<user<18 god.
            //        {
            //            Total = (TravelCost[0] + TaxCost[0]) / 2; //50% namalenie
            //            if (chkBreakfast.Checked == true)
            //            {
            //                Total += 5; /*za zakuska*/
            //            }
            //            if (chkAlone.Checked == true)
            //            {
            //                Total += 8; /*za samostoqtelno kupe*/
            //            }
            //            if (chkAddLuggage.Checked == true)
            //            {
            //                Total += 4; /*za dopylnitelen bagaj*/
            //            }
            //        }
            //        else if (rbChild.Checked == true) //ako user<7 god.
            //        {
            //            Total = 0; //za deca pod 7 vsichko e bezplatno;                      
            //        }
            //        else if (rbAdult.Checked == true) //ako 18 god.<user
            //        {
            //            Total = TravelCost[0] + TaxCost[0];
            //            if (chkBreakfast.Checked == true)
            //            {
            //                Total += 10; /*za zakuska*/
            //            }
            //            if (chkAlone.Checked == true)
            //            {
            //                Total += 15; /*za samostoqtelno kupe*/
            //            }
            //            if (chkAddLuggage.Checked == true)
            //            {
            //                Total += 7; /*za dopylnitelen bagaj*/
            //            }
            //        }
            //    }

            //}
            //if (cmbDestination.Text == "Плевен")
            //{
            //    TravelCost[0] = Travelprice.Pleven;
            //    TaxCost[0] = Tax.iFindTax(TravelCost[0]);
            //    if (rbLuxury.Checked == true)
            //    {
            //        //+20 lv za luksozna klasa
            //        if (rbTeen.Checked == true) //ako 7 god.<user<18 god.
            //        {
            //            Total = ((TravelCost[0] + TaxCost[0]) / 2) + 20; //50% namalenie, no s za luksozna klasa
            //            if (chkBreakfast.Checked == true)
            //            {
            //                Total += 5; /*za zakuska*/
            //            }
            //            if (chkAlone.Checked == true)
            //            {
            //                Total += 8; /*za samostoqtelno kupe*/
            //            }
            //            if (chkAddLuggage.Checked == true)
            //            {
            //                Total += 4; /*za dopylnitelen bagaj*/
            //            }
            //        }
            //        else if (rbChild.Checked == true) //ako user<7 god.
            //        {
            //            Total = 0; //za deca pod 7 vsichko e bezplatno;                      
            //        }
            //        else if (rbAdult.Checked == true) //ako 18 god.<user
            //        {
            //            Total = TravelCost[0] + TaxCost[0] + 20; /*za luksozna klasa*/
            //            if (chkBreakfast.Checked == true)
            //            {
            //                Total += 10; /*za zakuska*/
            //            }
            //            if (chkAlone.Checked == true)
            //            {
            //                Total += 15; /*za samostoqtelno kupe*/
            //            }
            //            if (chkAddLuggage.Checked == true)
            //            {
            //                Total += 7; /*za dopylnitelen bagaj*/
            //            }
            //        }
            //    }
            //    else
            //    {
            //        if (rbTeen.Checked == true) //ako 7 god.<user<18 god.
            //        {
            //            Total = (TravelCost[0] + TaxCost[0]) / 2; //50% namalenie
            //            if (chkBreakfast.Checked == true)
            //            {
            //                Total += 5; /*za zakuska*/
            //            }
            //            if (chkAlone.Checked == true)
            //            {
            //                Total += 8; /*za samostoqtelno kupe*/
            //            }
            //            if (chkAddLuggage.Checked == true)
            //            {
            //                Total += 4; /*za dopylnitelen bagaj*/
            //            }
            //        }
            //        else if (rbChild.Checked == true) //ako user<7 god.
            //        {
            //            Total = 0; //za deca pod 7 vsichko e bezplatno;                      
            //        }
            //        else if (rbAdult.Checked == true) //ako 18 god.<user
            //        {
            //            Total = TravelCost[0] + TaxCost[0];
            //            if (chkBreakfast.Checked == true)
            //            {
            //                Total += 10; /*za zakuska*/
            //            }
            //            if (chkAlone.Checked == true)
            //            {
            //                Total += 15; /*za samostoqtelno kupe*/
            //            }
            //            if (chkAddLuggage.Checked == true)
            //            {
            //                Total += 7; /*za dopylnitelen bagaj*/
            //            }
            //        }
            //    }

            //}
            //if (cmbDestination.Text == "Благоевград")
            //{
            //    TravelCost[0] = Travelprice.Blagoevgrad;
            //    TaxCost[0] = Tax.iFindTax(TravelCost[0]);
            //    if (rbLuxury.Checked == true)
            //    {
            //        //+20 lv za luksozna klasa
            //        if (rbTeen.Checked == true) //ako 7 god.<user<18 god.
            //        {
            //            Total = ((TravelCost[0] + TaxCost[0]) / 2) + 20; //50% namalenie, no s za luksozna klasa
            //            if (chkBreakfast.Checked == true)
            //            {
            //                Total += 5; /*za zakuska*/
            //            }
            //            if (chkAlone.Checked == true)
            //            {
            //                Total += 8; /*za samostoqtelno kupe*/
            //            }
            //            if (chkAddLuggage.Checked == true)
            //            {
            //                Total += 4; /*za dopylnitelen bagaj*/
            //            }
            //        }
            //        else if (rbChild.Checked == true) //ako user<7 god.
            //        {
            //            Total = 0; //za deca pod 7 vsichko e bezplatno;                      
            //        }
            //        else if (rbAdult.Checked == true) //ako 18 god.<user
            //        {
            //            Total = TravelCost[0] + TaxCost[0] + 20; /*za luksozna klasa*/
            //            if (chkBreakfast.Checked == true)
            //            {
            //                Total += 10; /*za zakuska*/
            //            }
            //            if (chkAlone.Checked == true)
            //            {
            //                Total += 15; /*za samostoqtelno kupe*/
            //            }
            //            if (chkAddLuggage.Checked == true)
            //            {
            //                Total += 7; /*za dopylnitelen bagaj*/
            //            }
            //        }
            //    }
            //    else
            //    {
            //        if (rbTeen.Checked == true) //ako 7 god.<user<18 god.
            //        {
            //            Total = (TravelCost[0] + TaxCost[0]) / 2; //50% namalenie
            //            if (chkBreakfast.Checked == true)
            //            {
            //                Total += 5; /*za zakuska*/
            //            }
            //            if (chkAlone.Checked == true)
            //            {
            //                Total += 8; /*za samostoqtelno kupe*/
            //            }
            //            if (chkAddLuggage.Checked == true)
            //            {
            //                Total += 4; /*za dopylnitelen bagaj*/
            //            }
            //        }
            //        else if (rbChild.Checked == true) //ako user<7 god.
            //        {
            //            Total = 0; //za deca pod 7 vsichko e bezplatno;                      
            //        }
            //        else if (rbAdult.Checked == true) //ako 18 god.<user
            //        {
            //            Total = TravelCost[0] + TaxCost[0];
            //            if (chkBreakfast.Checked == true)
            //            {
            //                Total += 10; /*za zakuska*/
            //            }
            //            if (chkAlone.Checked == true)
            //            {
            //                Total += 15; /*za samostoqtelno kupe*/
            //            }
            //            if (chkAddLuggage.Checked == true)
            //            {
            //                Total += 7; /*za dopylnitelen bagaj*/
            //            }
            //        }
            //    }

            //}
            //if (cmbDestination.Text == "София") // ne e vqrno !!!!! 
            //{
            //    TravelCost[0] = Travelprice.Sofiya;
            //    TaxCost[0] = AirTax.iFindTax(TravelCost[0]);
            //    Total = TravelCost[0] + TaxCost[0];

            //    lblDeparture.Text = String.Format(cmbDeparture.Text);
            //    lblDestination.Text = String.Format(cmbDestination.Text);
            //    lblPrice.Text = String.Format("{0} лв.", Total);
            //}

            
        }


        //M: Метод за изчистване на данни
        /*void Clear()
        {
            txtFirstname.Text = txtLastname.Text = txtNumber.Text = txtEmail.Text = txtCity.Text = "";
            NextUsers.Text = "Save";
            user.user_id = 0;
        }*/
        //М: Слайд за въвеждане на данните на пътника
        private void NextPrice_Click(object sender, EventArgs e)
        {
            /*//М: пази информация в базата данни за пътника
            user.first_name = txtFirstname.Text.Trim();
            user.last_name = txtLastname.Text.Trim();
            user.phone_number = txtNumber.Text.Trim();
            user.email = txtEmail.Text.Trim();
            user.town = txtCity.Text.Trim();
            using (Database1Entities db = new Database1Entities())
            {
                db.UserTable.Add(user);
                db.SaveChanges();
            }
           // Clear();

            */
            //слайдове visibility
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

        //М: Слайд за плащане
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

        //Слайд за бележка
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
                if (rbLuxury.Checked == true)
                {
                    //+20 lv za luksozna klasa
                    if (rbTeen.Checked == true) //ako 7 god.<user<18 god.
                    {
                        Total = ((TravelCost[0] + TaxCost[0]) / 2) + 20; //50% namalenie, no s za luksozna klasa
                        if (chkBreakfast.Checked == true)
                        {
                            Total = Total + 5; /*za zakuska*/
                        }
                        if (chkAlone.Checked == true)
                        {
                            Total += 8; /*za samostoqtelno kupe*/
                        }
                        if (chkAddLuggage.Checked == true)
                        {
                            Total += 4; /*za dopylnitelen bagaj*/
                        }
                    }
                    else if (rbChild.Checked == true) //ako user<7 god.
                    {
                        Total = 0; //za deca pod 7 vsichko e bezplatno;                      
                    }
                    else if (rbAdult.Checked == true ) //ako 18 god.<user
                    {
                        Total = TravelCost[0] + TaxCost[0] + 20; /*za luksozna klasa*/
                        if (chkBreakfast.Checked == true)
                        {
                            Total += 10; /*za zakuska*/
                        }
                        if (chkAlone.Checked == true)
                        {
                            Total += 15; /*za samostoqtelno kupe*/
                        }
                        if (chkAddLuggage.Checked == true)
                        {
                            Total += 7; /*za dopylnitelen bagaj*/
                        }
                    }
                }
                else
                {
                    if (rbTeen.Checked == true) //ako 7 god.<user<18 god.
                    {
                        Total = (TravelCost[0] + TaxCost[0]) / 2; //50% namalenie
                        if (chkBreakfast.Checked == true)
                        {
                            Total += 5; /*za zakuska*/
                        }
                        if (chkAlone.Checked == true)
                        {
                            Total += 8; /*za samostoqtelno kupe*/
                        }
                        if (chkAddLuggage.Checked == true)
                        {
                            Total += 4; /*za dopylnitelen bagaj*/
                        }
                    }
                    else if (rbChild.Checked == true) //ako user<7 god.
                    {
                        Total = 0; //za deca pod 7 vsichko e bezplatno;                      
                    }
                    else if (rbAdult.Checked == true) //ako 18 god.<user
                    {
                        Total = TravelCost[0] + TaxCost[0];
                        if (chkBreakfast.Checked == true)
                        {
                            Total += 10; /*za zakuska*/
                        }
                        if (chkAlone.Checked == true)
                        {
                            Total += 15; /*za samostoqtelno kupe*/
                        }
                        if (chkAddLuggage.Checked == true)
                        {
                            Total += 7; /*za dopylnitelen bagaj*/
                        }
                    }
                }
                
            }
            if (cmbDestination.Text == "Бургас")
            {
                TravelCost[0] = Travelprice.Bourgas;
                TaxCost[0] = Tax.iFindTax(TravelCost[0]);
                if (rbLuxury.Checked == true)
                {
                    //+20 lv za luksozna klasa
                    if (rbTeen.Checked == true) //ako 7 god.<user<18 god.
                    {
                        Total = ((TravelCost[0] + TaxCost[0]) / 2) + 20; //50% namalenie, no s za luksozna klasa
                        if (chkBreakfast.Checked == true)
                        {
                            Total += 5; /*za zakuska*/
                        }
                        if (chkAlone.Checked == true)
                        {
                            Total += 8; /*za samostoqtelno kupe*/
                        }
                        if (chkAddLuggage.Checked == true)
                        {
                            Total += 4; /*za dopylnitelen bagaj*/
                        }
                    }
                    else if (rbChild.Checked == true) //ako user<7 god.
                    {
                        Total = 0; //za deca pod 7 vsichko e bezplatno;                      
                    }
                    else if (rbAdult.Checked == true) //ako 18 god.<user
                    {
                        Total = TravelCost[0] + TaxCost[0] + 20; /*za luksozna klasa*/
                        if (chkBreakfast.Checked == true)
                        {
                            Total += 10; /*za zakuska*/
                        }
                        if (chkAlone.Checked == true)
                        {
                            Total += 15; /*za samostoqtelno kupe*/
                        }
                        if (chkAddLuggage.Checked == true)
                        {
                            Total += 7; /*za dopylnitelen bagaj*/
                        }
                    }
                }
                else
                {
                    if (rbTeen.Checked == true) //ako 7 god.<user<18 god.
                    {
                        Total = (TravelCost[0] + TaxCost[0]) / 2; //50% namalenie
                        if (chkBreakfast.Checked == true)
                        {
                            Total += 5; /*za zakuska*/
                        }
                        if (chkAlone.Checked == true)
                        {
                            Total += 8; /*za samostoqtelno kupe*/
                        }
                        if (chkAddLuggage.Checked == true)
                        {
                            Total += 4; /*za dopylnitelen bagaj*/
                        }
                    }
                    else if (rbChild.Checked == true) //ako user<7 god.
                    {
                        Total = 0; //za deca pod 7 vsichko e bezplatno;                      
                    }
                    else if (rbAdult.Checked == true) //ako 18 god.<user
                    {
                        Total = TravelCost[0] + TaxCost[0];
                        if (chkBreakfast.Checked == true)
                        {
                            Total += 10; /*za zakuska*/
                        }
                        if (chkAlone.Checked == true)
                        {
                            Total += 15; /*za samostoqtelno kupe*/
                        }
                        if (chkAddLuggage.Checked == true)
                        {
                            Total += 7; /*za dopylnitelen bagaj*/
                        }
                    }
                }

            }
            if (cmbDestination.Text == "Варна")
            {
                TravelCost[0] = Travelprice.Varna;
                TaxCost[0] = Tax.iFindTax(TravelCost[0]);
                if (rbLuxury.Checked == true)
                {
                    //+20 lv za luksozna klasa
                    if (rbTeen.Checked == true) //ako 7 god.<user<18 god.
                    {
                        Total = ((TravelCost[0] + TaxCost[0]) / 2) + 20; //50% namalenie, no s za luksozna klasa
                        if (chkBreakfast.Checked == true)
                        {
                            Total += 5; /*za zakuska*/
                        }
                        if (chkAlone.Checked == true)
                        {
                            Total += 8; /*za samostoqtelno kupe*/
                        }
                        if (chkAddLuggage.Checked == true)
                        {
                            Total += 4; /*za dopylnitelen bagaj*/
                        }
                    }
                    else if (rbChild.Checked == true) //ako user<7 god.
                    {
                        Total = 0; //za deca pod 7 vsichko e bezplatno;                      
                    }
                    else if (rbAdult.Checked == true) //ako 18 god.<user
                    {
                        Total = TravelCost[0] + TaxCost[0] + 20; /*za luksozna klasa*/
                        if (chkBreakfast.Checked == true)
                        {
                            Total += 10; /*za zakuska*/
                        }
                        if (chkAlone.Checked == true)
                        {
                            Total += 15; /*za samostoqtelno kupe*/
                        }
                        if (chkAddLuggage.Checked == true)
                        {
                            Total += 7; /*za dopylnitelen bagaj*/
                        }
                    }
                }
                else
                {
                    if (rbTeen.Checked == true) //ako 7 god.<user<18 god.
                    {
                        Total = (TravelCost[0] + TaxCost[0]) / 2; //50% namalenie
                        if (chkBreakfast.Checked == true)
                        {
                            Total += 5; /*za zakuska*/
                        }
                        if (chkAlone.Checked == true)
                        {
                            Total += 8; /*za samostoqtelno kupe*/
                        }
                        if (chkAddLuggage.Checked == true)
                        {
                            Total += 4; /*za dopylnitelen bagaj*/
                        }
                    }
                    else if (rbChild.Checked == true) //ako user<7 god.
                    {
                        Total = 0; //za deca pod 7 vsichko e bezplatno;                      
                    }
                    else if (rbAdult.Checked == true) //ako 18 god.<user
                    {
                        Total = TravelCost[0] + TaxCost[0];
                        if (chkBreakfast.Checked == true)
                        {
                            Total += 10; /*za zakuska*/
                        }
                        if (chkAlone.Checked == true)
                        {
                            Total += 15; /*za samostoqtelno kupe*/
                        }
                        if (chkAddLuggage.Checked == true)
                        {
                            Total += 7; /*za dopylnitelen bagaj*/
                        }
                    }
                }

            }
            if (cmbDestination.Text == "Пловдив")
            {
                TravelCost[0] = Travelprice.Plovdiv;
                TaxCost[0] = Tax.iFindTax(TravelCost[0]);
                if (rbLuxury.Checked == true)
                {
                    //+20 lv za luksozna klasa
                    if (rbTeen.Checked == true) //ako 7 god.<user<18 god.
                    {
                        Total = ((TravelCost[0] + TaxCost[0]) / 2) + 20; //50% namalenie, no s za luksozna klasa
                        if (chkBreakfast.Checked == true)
                        {
                            Total += 5; /*za zakuska*/
                        }
                        if (chkAlone.Checked == true)
                        {
                            Total += 8; /*za samostoqtelno kupe*/
                        }
                        if (chkAddLuggage.Checked == true)
                        {
                            Total += 4; /*za dopylnitelen bagaj*/
                        }
                    }
                    else if (rbChild.Checked == true) //ako user<7 god.
                    {
                        Total = 0; //za deca pod 7 vsichko e bezplatno;                      
                    }
                    else if (rbAdult.Checked == true) //ako 18 god.<user
                    {
                        Total = TravelCost[0] + TaxCost[0] + 20; /*za luksozna klasa*/
                        if (chkBreakfast.Checked == true)
                        {
                            Total += 10; /*za zakuska*/
                        }
                        if (chkAlone.Checked == true)
                        {
                            Total += 15; /*za samostoqtelno kupe*/
                        }
                        if (chkAddLuggage.Checked == true)
                        {
                            Total += 7; /*za dopylnitelen bagaj*/
                        }
                    }
                }
                else
                {
                    if (rbTeen.Checked == true) //ako 7 god.<user<18 god.
                    {
                        Total = (TravelCost[0] + TaxCost[0]) / 2; //50% namalenie
                        if (chkBreakfast.Checked == true)
                        {
                            Total += 5; /*za zakuska*/
                        }
                        if (chkAlone.Checked == true)
                        {
                            Total += 8; /*za samostoqtelno kupe*/
                        }
                        if (chkAddLuggage.Checked == true)
                        {
                            Total += 4; /*za dopylnitelen bagaj*/
                        }
                    }
                    else if (rbChild.Checked == true) //ako user<7 god.
                    {
                        Total = 0; //za deca pod 7 vsichko e bezplatno;                      
                    }
                    else if (rbAdult.Checked == true) //ako 18 god.<user
                    {
                        Total = TravelCost[0] + TaxCost[0];
                        if (chkBreakfast.Checked == true)
                        {
                            Total += 10; /*za zakuska*/
                        }
                        if (chkAlone.Checked == true)
                        {
                            Total += 15; /*za samostoqtelno kupe*/
                        }
                        if (chkAddLuggage.Checked == true)
                        {
                            Total += 7; /*za dopylnitelen bagaj*/
                        }
                    }
                }

            }
            if (cmbDestination.Text == "Горна Оряховица")
            {
                TravelCost[0] = Travelprice.GornaOrqhovica;
                TaxCost[0] = Tax.iFindTax(TravelCost[0]);
                if (rbLuxury.Checked == true)
                {
                    //+20 lv za luksozna klasa
                    if (rbTeen.Checked == true) //ako 7 god.<user<18 god.
                    {
                        Total = ((TravelCost[0] + TaxCost[0]) / 2) + 20; //50% namalenie, no s za luksozna klasa
                        if (chkBreakfast.Checked == true)
                        {
                            Total += 5; /*za zakuska*/
                        }
                        if (chkAlone.Checked == true)
                        {
                            Total += 8; /*za samostoqtelno kupe*/
                        }
                        if (chkAddLuggage.Checked == true)
                        {
                            Total += 4; /*za dopylnitelen bagaj*/
                        }
                    }
                    else if (rbChild.Checked == true) //ako user<7 god.
                    {
                        Total = 0; //za deca pod 7 vsichko e bezplatno;                      
                    }
                    else if (rbAdult.Checked == true) //ako 18 god.<user
                    {
                        Total = TravelCost[0] + TaxCost[0] + 20; /*za luksozna klasa*/
                        if (chkBreakfast.Checked == true)
                        {
                            Total += 10; /*za zakuska*/
                        }
                        if (chkAlone.Checked == true)
                        {
                            Total += 15; /*za samostoqtelno kupe*/
                        }
                        if (chkAddLuggage.Checked == true)
                        {
                            Total += 7; /*za dopylnitelen bagaj*/
                        }
                    }
                }
                else
                {
                    if (rbTeen.Checked == true) //ako 7 god.<user<18 god.
                    {
                        Total = (TravelCost[0] + TaxCost[0]) / 2; //50% namalenie
                        if (chkBreakfast.Checked == true)
                        {
                            Total += 5; /*za zakuska*/
                        }
                        if (chkAlone.Checked == true)
                        {
                            Total += 8; /*za samostoqtelno kupe*/
                        }
                        if (chkAddLuggage.Checked == true)
                        {
                            Total += 4; /*za dopylnitelen bagaj*/
                        }
                    }
                    else if (rbChild.Checked == true) //ako user<7 god.
                    {
                        Total = 0; //za deca pod 7 vsichko e bezplatno;                      
                    }
                    else if (rbAdult.Checked == true) //ako 18 god.<user
                    {
                        Total = TravelCost[0] + TaxCost[0];
                        if (chkBreakfast.Checked == true)
                        {
                            Total += 10; /*za zakuska*/
                        }
                        if (chkAlone.Checked == true)
                        {
                            Total += 15; /*za samostoqtelno kupe*/
                        }
                        if (chkAddLuggage.Checked == true)
                        {
                            Total += 7; /*za dopylnitelen bagaj*/
                        }
                    }
                }

            }
            if (cmbDestination.Text == "Перник")
            {
                TravelCost[0] = Travelprice.Pernik;
                TaxCost[0] = Tax.iFindTax(TravelCost[0]);
                if (rbLuxury.Checked == true)
                {
                    //+20 lv za luksozna klasa
                    if (rbTeen.Checked == true) //ako 7 god.<user<18 god.
                    {
                        Total = ((TravelCost[0] + TaxCost[0]) / 2) + 20; //50% namalenie, no s za luksozna klasa
                        if (chkBreakfast.Checked == true)
                        {
                            Total += 5; /*za zakuska*/
                        }
                        if (chkAlone.Checked == true)
                        {
                            Total += 8; /*za samostoqtelno kupe*/
                        }
                        if (chkAddLuggage.Checked == true)
                        {
                            Total += 4; /*za dopylnitelen bagaj*/
                        }
                    }
                    else if (rbChild.Checked == true) //ako user<7 god.
                    {
                        Total = 0; //za deca pod 7 vsichko e bezplatno;                      
                    }
                    else if (rbAdult.Checked == true) //ako 18 god.<user
                    {
                        Total = TravelCost[0] + TaxCost[0] + 20; /*za luksozna klasa*/
                        if (chkBreakfast.Checked == true)
                        {
                            Total += 10; /*za zakuska*/
                        }
                        if (chkAlone.Checked == true)
                        {
                            Total += 15; /*za samostoqtelno kupe*/
                        }
                        if (chkAddLuggage.Checked == true)
                        {
                            Total += 7; /*za dopylnitelen bagaj*/
                        }
                    }
                }
                else
                {
                    if (rbTeen.Checked == true) //ako 7 god.<user<18 god.
                    {
                        Total = (TravelCost[0] + TaxCost[0]) / 2; //50% namalenie
                        if (chkBreakfast.Checked == true)
                        {
                            Total += 5; /*za zakuska*/
                        }
                        if (chkAlone.Checked == true)
                        {
                            Total += 8; /*za samostoqtelno kupe*/
                        }
                        if (chkAddLuggage.Checked == true)
                        {
                            Total += 4; /*za dopylnitelen bagaj*/
                        }
                    }
                    else if (rbChild.Checked == true) //ako user<7 god.
                    {
                        Total = 0; //za deca pod 7 vsichko e bezplatno;                      
                    }
                    else if (rbAdult.Checked == true) //ako 18 god.<user
                    {
                        Total = TravelCost[0] + TaxCost[0];
                        if (chkBreakfast.Checked == true)
                        {
                            Total += 10; /*za zakuska*/
                        }
                        if (chkAlone.Checked == true)
                        {
                            Total += 15; /*za samostoqtelno kupe*/
                        }
                        if (chkAddLuggage.Checked == true)
                        {
                            Total += 7; /*za dopylnitelen bagaj*/
                        }
                    }
                }

            }
            if (cmbDestination.Text == "Плевен")
            {
                TravelCost[0] = Travelprice.Pleven;
                TaxCost[0] = Tax.iFindTax(TravelCost[0]);
                if (rbLuxury.Checked == true)
                {
                    //+20 lv za luksozna klasa
                    if (rbTeen.Checked == true) //ako 7 god.<user<18 god.
                    {
                        Total = ((TravelCost[0] + TaxCost[0]) / 2) + 20; //50% namalenie, no s za luksozna klasa
                        if (chkBreakfast.Checked == true)
                        {
                            Total += 5; /*za zakuska*/
                        }
                        if (chkAlone.Checked == true)
                        {
                            Total += 8; /*za samostoqtelno kupe*/
                        }
                        if (chkAddLuggage.Checked == true)
                        {
                            Total += 4; /*za dopylnitelen bagaj*/
                        }
                    }
                    else if (rbChild.Checked == true) //ako user<7 god.
                    {
                        Total = 0; //za deca pod 7 vsichko e bezplatno;                      
                    }
                    else if (rbAdult.Checked == true) //ako 18 god.<user
                    {
                        Total = TravelCost[0] + TaxCost[0] + 20; /*za luksozna klasa*/
                        if (chkBreakfast.Checked == true)
                        {
                            Total += 10; /*za zakuska*/
                        }
                        if (chkAlone.Checked == true)
                        {
                            Total += 15; /*za samostoqtelno kupe*/
                        }
                        if (chkAddLuggage.Checked == true)
                        {
                            Total += 7; /*za dopylnitelen bagaj*/
                        }
                    }
                }
                else
                {
                    if (rbTeen.Checked == true) //ako 7 god.<user<18 god.
                    {
                        Total = (TravelCost[0] + TaxCost[0]) / 2; //50% namalenie
                        if (chkBreakfast.Checked == true)
                        {
                            Total += 5; /*za zakuska*/
                        }
                        if (chkAlone.Checked == true)
                        {
                            Total += 8; /*za samostoqtelno kupe*/
                        }
                        if (chkAddLuggage.Checked == true)
                        {
                            Total += 4; /*za dopylnitelen bagaj*/
                        }
                    }
                    else if (rbChild.Checked == true) //ako user<7 god.
                    {
                        Total = 0; //za deca pod 7 vsichko e bezplatno;                      
                    }
                    else if (rbAdult.Checked == true) //ako 18 god.<user
                    {
                        Total = TravelCost[0] + TaxCost[0];
                        if (chkBreakfast.Checked == true)
                        {
                            Total += 10; /*za zakuska*/
                        }
                        if (chkAlone.Checked == true)
                        {
                            Total += 15; /*za samostoqtelno kupe*/
                        }
                        if (chkAddLuggage.Checked == true)
                        {
                            Total += 7; /*za dopylnitelen bagaj*/
                        }
                    }
                }

            }
            if (cmbDestination.Text == "Благоевград")
            {
                TravelCost[0] = Travelprice.Blagoevgrad;
                TaxCost[0] = Tax.iFindTax(TravelCost[0]);
                if (rbLuxury.Checked == true)
                {
                    //+20 lv za luksozna klasa
                    if (rbTeen.Checked == true) //ako 7 god.<user<18 god.
                    {
                        Total = ((TravelCost[0] + TaxCost[0]) / 2) + 20; //50% namalenie, no s za luksozna klasa
                        if (chkBreakfast.Checked == true)
                        {
                            Total += 5; /*za zakuska*/
                        }
                        if (chkAlone.Checked == true)
                        {
                            Total += 8; /*za samostoqtelno kupe*/
                        }
                        if (chkAddLuggage.Checked == true)
                        {
                            Total += 4; /*za dopylnitelen bagaj*/
                        }
                    }
                    else if (rbChild.Checked == true) //ako user<7 god.
                    {
                        Total = 0; //za deca pod 7 vsichko e bezplatno;                      
                    }
                    else if (rbAdult.Checked == true) //ako 18 god.<user
                    {
                        Total = TravelCost[0] + TaxCost[0] + 20; /*za luksozna klasa*/
                        if (chkBreakfast.Checked == true)
                        {
                            Total += 10; /*za zakuska*/
                        }
                        if (chkAlone.Checked == true)
                        {
                            Total += 15; /*za samostoqtelno kupe*/
                        }
                        if (chkAddLuggage.Checked == true)
                        {
                            Total += 7; /*za dopylnitelen bagaj*/
                        }
                    }
                }
                else
                {
                    if (rbTeen.Checked == true) //ako 7 god.<user<18 god.
                    {
                        Total = (TravelCost[0] + TaxCost[0]) / 2; //50% namalenie
                        if (chkBreakfast.Checked == true)
                        {
                            Total += 5; /*za zakuska*/
                        }
                        if (chkAlone.Checked == true)
                        {
                            Total += 8; /*za samostoqtelno kupe*/
                        }
                        if (chkAddLuggage.Checked == true)
                        {
                            Total += 4; /*za dopylnitelen bagaj*/
                        }
                    }
                    else if (rbChild.Checked == true) //ako user<7 god.
                    {
                        Total = 0; //za deca pod 7 vsichko e bezplatno;                      
                    }
                    else if (rbAdult.Checked == true) //ako 18 god.<user
                    {
                        Total = TravelCost[0] + TaxCost[0];
                        if (chkBreakfast.Checked == true)
                        {
                            Total += 10; /*za zakuska*/
                        }
                        if (chkAlone.Checked == true)
                        {
                            Total += 15; /*za samostoqtelno kupe*/
                        }
                        if (chkAddLuggage.Checked == true)
                        {
                            Total += 7; /*za dopylnitelen bagaj*/
                        }
                    }
                }

            }

            //==================================
            String Firstname = (txtFirstname.Text);
            String Lastame = (txtLastname.Text);
            String City = (txtCity.Text);
            String Number = (txtNumber.Text);
            String Email = (txtEmail.Text);


            rtReceipt.AppendText("Ref:\t\t" + refs
                + "\n--------------------------------"
                + "\nИме:\t\t" + txtFirstname.Text
                + "\nФамилия:\t" + txtLastname.Text
                + "\nТелефон:\t" + txtNumber.Text
                + "\nЕл. поща:\t" + txtEmail.Text
                + "\nНачална гара:" + cmbDeparture.Text
                + "\nКрайна гара:\t" + cmbDestination.Text               
                + "\n--------------------------------"
                + "\nЦена:\t\t" + lblPrice.Text
            //+ "\n--------------------------------"
            //+ "\n " + lblDate.Text + "  \t" + lblTime.Text                
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

        ////////////////////// М: ВРЪЗКА КЪМ БАЗА ДАННИ

       // SqlConnection sqlcon = new SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\User\Desktop\TrainSystemApp\TrafficSystem1.0\Data\Database1.mdf;Integrated Security=True;Connect Timeout=30");
        

        //Начална гара бутон
        private void cmbDeparture_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }
        //Крайна гара
        private void cmbDestination_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        //Стандартна класа check
        private void rbStandart_CheckedChanged(object sender, EventArgs e)
        {

        }

        //Луксозна класа check
        private void rbLuxury_CheckedChanged(object sender, EventArgs e)
        {

        }

        //Пътник - име
        private void txtFirstname_TextChanged(object sender, EventArgs e)
        {
            
        }
        //Пътник - фамилия
        private void txtLastname_TextChanged(object sender, EventArgs e)
        {

        }
        //Пътник - телефон
        private void txtNumber_TextChanged(object sender, EventArgs e)
        {

        }
        //Пътник-имейл
        private void txtEmail_TextChanged(object sender, EventArgs e)
        {

        }
        //Пътник - населено място
        private void txtCity_TextChanged(object sender, EventArgs e)
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
