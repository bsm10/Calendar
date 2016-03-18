using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Calendar
{
    public partial class Form1 : Form
    {
        DateTime dt_now = new DateTime(DateTime.Now.Year,DateTime.Now.Month, 1);
        DateTime dt;
        MonthCalendar mc;
        int i; //Counter
        int current_month;//месяц который сейчас отображается

        public Form1()
        {
            InitializeComponent();

            

            dt = dt_now;
            UpdateCalendar(dt_now);

        }

        private void buttonForward_Click(object sender, EventArgs e)
        {
            dt=dt.AddMonths(1);
            UpdateCalendar(dt);
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            dt = dt.AddMonths(-1);
            UpdateCalendar(dt);
        }

        void UpdateCalendar(DateTime _date)
        {
            labelNow.Text = _date.ToString("MMMM yyyy");
            current_month = _date.Month;
            int firstDay = (int)_date.DayOfWeek;
            int delta = 0;
            switch (firstDay)
            {
                case 1:
                    delta = 0;
                    break;
                case 2:
                    delta = 1;
                    break;
                case 3:
                    delta = 2;
                    break;
                case 4:
                    delta = 3;
                    break;
                case 5:
                    delta = 4;
                    break;
                case 6:
                    delta = 5;
                    break;
                case 0:
                    delta = 6;//sunday - is 0 day of week!
                    break;
            }
            i = 0;
            DateTime startDate = _date.Subtract(TimeSpan.FromDays(delta));
            for (int row = 2; row < 7; row++)
            {
                for (int col = 0; col < 7; col++)
                {
                    Label lb = (Label)tableLayoutPanel.GetControlFromPosition(col, row);
                    FillLabel(lb, startDate);
                }
            }
        }
        private void FillLabel(Label l, DateTime startDate)
        {
            DateTime dt = startDate.AddDays(i);
            l.Text = dt.Day.ToString();
            l.Tag = dt.Date.ToString("dd.MM.yyyy");
            l.BackColor = Color.LightGray;
            if (dt.DayOfWeek == DayOfWeek.Sunday | dt.DayOfWeek == DayOfWeek.Saturday)
            {
                l.ForeColor = dt.Month != current_month ? Color.RosyBrown : Color.Red;
            }
            else 
            {
                l.ForeColor = dt.Month != current_month ? Color.Gray : Color.Black;
            }
            if(dt.Date==DateTime.Now.Date) 
            {
                l.BackColor = Color.DarkBlue;
                l.ForeColor = Color.Cyan;
            }
            i++;
        }

    }
}
