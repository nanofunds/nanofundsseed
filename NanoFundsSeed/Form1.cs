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
            var path = @"C:\Users\Adrienne\hackathon\NanoSeedData.sql";

            string[] merchantNames = { "The Stalk Market", "Specs Appeal", "Nothing Bundt Cakes" };
            Random rndIndex = new Random();
            int index = rndIndex.Next(0, merchantNames.Length);

            Guid merchantId = Guid.NewGuid();

            var merchantName = merchantNames[index];
            var balance = 0.0;

            var rnd = new Random();
            var profit = 0;
            
            string[] lowDays = { "Monday", "Tuesday", "Wednesday", "Thursday" };
            string[] highDays = { "Friday", "Saturday", "Sunday" };

            if (!File.Exists(path))
            {
                File.Create(path).Dispose();

                using (TextWriter tw = new StreamWriter(path))
                {
                    tw.WriteLine("USE [nanofunds]");

                    string merchantScript = String.Format(@"INSERT INTO dbo.Merchants (Id, Name, Balance) VALUES ('{0}', '{1}', {2});", merchantId, merchantName, balance);
                    tw.WriteLine(merchantScript);

                    tw.WriteLine("INSERT INTO dbo.ActualReceipts (Id, Amount, Date, Merchant_Id) VALUES ");

                    for (int day = 0; day <= 125; day++)
                    {
                        var dayOfTheWeek = dateOfService.DayOfWeek.ToString();
                        Guid actualReceiptId = Guid.NewGuid();

                        if (lowDays.Any(dayOfTheWeek.Contains))
                        {
                            profit = rnd.Next(49, 101);
                        }
                        else if (highDays.Any(dayOfTheWeek.Contains))
                        {
                            profit = rnd.Next(100, 300);
                        }

                        string merchantDataScript = String.Format(@"('{0}', {1}, {2}, '{3}')", actualReceiptId, profit, dateOfService.ToShortDateString(), merchantId);


                        if (day == 125)
                        {
                            tw.WriteLine(merchantDataScript + ";");
                        }
                        else
                        {
                            tw.WriteLine(merchantDataScript + ",");
                        }

                        dateOfService = dateOfService.AddDays(-1);
                    }
                    tw.Close();
                }

                MessageBox.Show("Generated seed script!");
            }
        }
    }
}
