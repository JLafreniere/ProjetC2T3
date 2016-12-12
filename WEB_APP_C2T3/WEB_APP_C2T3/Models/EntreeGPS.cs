using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WEB_APP_C2T3.Models
{
    public class EntreeGPS
    {
        public int Id { get; set; }
        public virtual Appareil appareil { get; set; }
        public virtual double latitude { get; set; }
        public virtual double longitude { get; set; }
        public virtual DateTime date { get; set; }
    }
}
