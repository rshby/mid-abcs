namespace inq_accont.Helper
{
    public class HelperJulianDate
    {
        public HelperJulianDate()
        {

        }

        public string GetJulianDate()
        {
            return (DateTime.Now.ToLocalTime().Date.Year * 1000 + DateTime.Now.ToLocalTime().Date.DayOfYear).ToString();
        }

        public string GetTransactionDate()
        {
            return DateTime.Now.ToLocalTime().ToString("ddMMyy");
        }

        public string GetTime()
        {
            return DateTime.Now.ToLocalTime().ToString("HHmmss");
        }
    }
}
