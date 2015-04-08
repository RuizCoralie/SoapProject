using System;

namespace WebServiceMobileSMR.Models
{
    public class LocationModels
    {
        private string _Email;

        public string Email
        {
            get { return _Email; }
            set { _Email = value; }
        }

        private string _Latitute;

        public string Latitute
        {
            get { return _Latitute; }
            set { _Latitute = value; }
        }

        private string _Longitude;

        public string Longitude
        {
            get { return _Longitude; }
            set { _Longitude = value; }
        }

        private DateTime _Date;

        public DateTime Date
        {
            get { return _Date; }
            set { _Date = value; }
        }

        public override string ToString()
        {
            var s = string.Concat("User : ", Email, " in lat ", Latitute, "and long ", Longitude);
            return s;
        }

    }
}