using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace NanoFundsSeed
{
    public partial class NanoFundsSeedDataGenerator : Form
    {
        DateTime dateOfService = DateTime.Today;

        public NanoFundsSeedDataGenerator()
        {
            InitializeComponent();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            dateOfService = datePicker.Value;
        }

        private void Generate_Click(object sender, EventArgs e)
        {
            var path = @"C:\Users\Adrienne\hackathon\NanoSeedData.txt";

            var rnd = new Random();
            var profit = 0;
            

            string[] lowDays = { "Monday", "Tuesday", "Wednesday", "Thursday" };
            string[] highDays = { "Friday", "Saturday", "Sunday" };

            if (!File.Exists(path))
            {
                File.Create(path).Dispose();
                using (TextWriter tw = new StreamWriter(path))
                {
                    for (int day = 0; day <= 365; day++)
                    {
                        var dayOfTheWeek = dateOfService.DayOfWeek.ToString();

                        if (lowDays.Any(dayOfTheWeek.Contains))
                        {
                            profit = rnd.Next(49, 101);
                        }
                        else if (highDays.Any(dayOfTheWeek.Contains))
                        {
                            profit = rnd.Next(100, 300);
                        }

                        tw.WriteLine(dayOfTheWeek + " " + dateOfService.ToShortDateString() + ": " + "$" + profit);
                        dateOfService = dateOfService.AddDays(1);
                    }
                    tw.Close();
                }

                MessageBox.Show("Generated seed data!");
            }
        }
    }
}
