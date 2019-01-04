using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Outlook = Microsoft.Office.Interop.Outlook;

namespace DateCalculator.BusinessClasses
{
    public class OutlookConnector
    {
        private Outlook.Application oApp;

        public OutlookConnector()
        {
            oApp = new Outlook.Application();
        }

        public void CreateAniversaryAppointment(string value, string type, DateTime day)
        {
            var appoint = oApp.CreateItem(Outlook.OlItemType.olAppointmentItem) as Outlook.AppointmentItem;
            appoint.Subject = $"Beziehungs-Jubiläum {value} {type}";
            appoint.Start = day;
            appoint.End = day;
            appoint.ReminderSet = true;
            appoint.ReminderMinutesBeforeStart = 60 * 24; // 1 hour * 24 = 1 day
            appoint.Save();
        }
    }
}
