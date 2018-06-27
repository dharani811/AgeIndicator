using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DK.AgeIndicator
{
    public class AgeController:INotifyPropertyChanged
    {
        private string age;
        private readonly DateTime dob = new DateTime(1989, 11, 9, 11, 51, 40);

        public AgeController()
        {
            Task.Run(() => TriggerAge());
        }

        public string Age { get => age; set => age = value; }

        public event PropertyChangedEventHandler PropertyChanged;

        private void TriggerAge()
        {
            while (true)
            {
                System.Windows.Application.Current.Dispatcher.Invoke(() => {

                    //get age now
                    age = CalculateYourAge();

                    //notify UI
                    if (PropertyChanged != null)
                        PropertyChanged(this, new PropertyChangedEventArgs("Age"));

                    }
                    );
                Task.Delay(1000).Wait();
            }
        }

        /// <summary>  
        /// For calculating age  
        /// </summary>  
        /// <param name="Dob">Enter Date of Birth to Calculate the age</param>  
        /// <returns> years, months,days, hours...</returns>  
        private string CalculateYourAge()
        {
            DateTime Now = DateTime.Now;
            int Years = new DateTime(DateTime.Now.Subtract(dob).Ticks).Year - 1;
            DateTime PastYearDate = dob.AddYears(Years);
            int Months = 0;
            for (int i = 1; i <= 12; i++)
            {
                if (PastYearDate.AddMonths(i) == Now)
                {
                    Months = i;
                    break;
                }
                else if (PastYearDate.AddMonths(i) >= Now)
                {
                    Months = i - 1;
                    break;
                }
            }
            int Days = Now.Subtract(PastYearDate.AddMonths(Months)).Days;
            int Hours = Now.Subtract(PastYearDate).Hours;
            int Minutes = Now.Subtract(PastYearDate).Minutes;
            int Seconds = Now.Subtract(PastYearDate).Seconds;
            return String.Format("Age: {0} Year(s) {1} Month(s) {2} Day(s) {3} Hour(s) {4} Second(s)",
            Years, Months, Days, Hours, Seconds);
        }
    }
}
