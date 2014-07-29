using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Collections.Specialized;

namespace ApptBookingTestConsole

{
    class Program
    {
        static void Main(string[] args)
        {

            NameValueCollection apptTimeCollection = (NameValueCollection)ConfigurationManager.GetSection("apptTimeSlots");

            decimal apptTimeStart = Convert.ToDecimal(apptTimeCollection["apptTimeStart"]);
            decimal apptTimeEnd = Convert.ToDecimal(apptTimeCollection["apptTimeEnd"]);

            KSOSC.SE3ControllingService1 se3KSOSC1 = new KSOSC.SE3ControllingService1();
            // KSOSC.SE3ControllingService1SoapClient se3KSOSC1 = new KSOSC.SE3ControllingService1SoapClient();


            //find availability

            KSOSC.InputFromSE3ForFindAvailability se3FAObj = new KSOSC.InputFromSE3ForFindAvailability();
            se3FAObj.dateFrom = new DateTime(2014, 07, 16);
            se3FAObj.dateTo = new DateTime(2014, 07, 16);
          //  se3FAObj.AppointmentLocation = "Home";
           se3FAObj.AppointmentLocation = "Home";
            // string[] conList = new string[] { "dtm.designconsultant", "se3test.2010", "se4.cad2", "dtm2.user", "se3test.2003", "se3test.20032010" };
        //     string[] conList = new string[] { "mark.lyon" };
             string[] conList = new string[] { "se4.cad1" };
           // string[] conList = new string[] { "se3test2010" };
          // string[] conList = new string[] { "Nicola-Ann.Perrin", "George.Mackie", "Andrew.Heath", "se4.Cad2" };
            se3FAObj.ConsultantLists = conList;
            var testR3 = se3KSOSC1.GetAvailability(se3FAObj);

            //cancel appointment

            KSOSC.InputFromSE3ForCancelAppointment se3FAObjC = new KSOSC.InputFromSE3ForCancelAppointment();
            se3FAObjC.consultantID = "se3test.2010dd";
            se3FAObjC.exchangeID = "AVQAAAACTfxhAQAAAAW7Jh4AAAAA";
            // var testR;
            var testR2 = se3KSOSC1.CancelAppointment(se3FAObjC);

            //Book appointment
            KSOSC.InputFromSE3ForBookAppointment se3FAObjB1 = new KSOSC.InputFromSE3ForBookAppointment();
            //se3KSOSC.
            se3FAObjB1.AppointmentAttachment = " 123456.bat#~$-test SE3 first time";
            se3FAObjB1.appointmentLocation = "Store";
            se3FAObjB1.consultantID = "se3test2010";
            se3FAObjB1.dateFrom = new DateTime(2014, 07, 24);
            se3FAObjB1.dateTo = new DateTime(2014, 07, 24);
            se3FAObjB1.notes = "testNotesAri&Rob";
            se3FAObjB1.storeID = "ESH182";
            se3FAObjB1.timeFrom = 14.30m;
            se3FAObjB1.timeTo = 16.30m;

            var testR1 = se3KSOSC1.BookAppointment(se3FAObjB1);

            string dog = "1";
        }
    }
}
