using System;
using System.Data;
using System.Collections.Generic;


namespace TripleSoftware.NeoRhythm.Data
{

	/// <summary>
	/// Description of BiorhythmCalculator.
	/// </summary>
	public class BiorhythmCalculator
	{
		private const int physical = 23;
		private const int emotional = 28;
		private const int intellectual = 33;

		private DateTime currentDate;
		private DateTime birthDate;
		
        public DateTime BirthDate {
			get { 
                return birthDate; 
            }
			set { 
                birthDate = value;
                FireUpdate();
            }
		}

		public DateTime CurrentDate {
			get { 
                return currentDate; 
            }
			set { 
                currentDate = value;
                FireUpdate();
            }
		}

        public event EventHandler Updated;

        private void FireUpdate()
        {
            if (Updated != null)
                Updated(this, EventArgs.Empty);
        }

        public int DaysSinceBirth{
			get {
                TimeSpan timeBetween = currentDate - birthDate;
                return (timeBetween.Days + 1);
            }
		}
		
		public double Physical{
			get { return CalculateRhithm( physical, DaysSinceBirth); }
		}
		
		public double Emotional{
			get { return CalculateRhithm( emotional, DaysSinceBirth); }
		}

		public double Intellactual{
			get { return CalculateRhithm( intellectual, DaysSinceBirth); }
		}

        private int[] Calculate5Day(int periode)
        {
            List<int> result = new List<int>();

            for (int i = -5; i <= 6; i++) {
                double rhytm = CalculateRhithm(periode, (this.DaysSinceBirth + i));
                int point = Convert.ToInt32((Math.Round(rhytm, 0) + 100) / 2);
                result.Add(point);
            }
            return result.ToArray();
        }
        
        public int[] GetPhysical()
        {
            return Calculate5Day(physical);
        }

        public int[] GetEmotional()
        {
            return Calculate5Day(emotional);
        }

        public int[] GetIntellactual()
        {
            return Calculate5Day(intellectual);
        }

		private double CalculateRhithm(int periode, int days){

			return (Math.Sin((2*Math.PI*Convert.ToDouble(days))/Convert.ToDouble(periode))*100);
		}
		
		public BiorhythmCalculator()
		{
			currentDate = DateTime.Now;	
		}

        public void Save()
        {
            Settings setting = new Settings(true);
            setting.SaveSetting("NeoRhtyhm", "BirthDate", "BirthDate", this.BirthDate.ToString());
        }

        public void Load()
        {
            Settings setting = new Settings(true);
            string date = setting.GetSetting("NeoRhtyhm", "BirthDate", "BirthDate", DateTime.MinValue.ToString());
            this.BirthDate = Convert.ToDateTime(date);
        }

	}
}