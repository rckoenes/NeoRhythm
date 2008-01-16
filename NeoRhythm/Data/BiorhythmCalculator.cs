using System;
using System.Data;

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

        public event EventHandler Updated;
		
		public DateTime BirthDate {
			get { 
                return birthDate; 
            }
			set { 
                birthDate = value;
                FireUpdate();
            }
		}

        private void FireUpdate()
        {
            if (Updated != null)
                Updated( this, EventArgs.Empty);
        }

		public DateTime CurrentDate {
			get { return currentDate; }
			set { currentDate = value; }
		}
		
		public int DaysSinceBirth{
			get { return currentDate.Subtract(birthDate).Days; }
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
		
		private double CalculateRhithm(int periode, int days){
			return (Math.Sin((2*Math.PI*days)/periode)*100);
		}
		
		public BiorhythmCalculator()
		{
			currentDate = DateTime.Now;	
		}
	}
}
