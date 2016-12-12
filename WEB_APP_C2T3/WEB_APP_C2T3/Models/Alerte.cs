using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WEB_APP_C2T3.Models
{
    public class Alerte
    {
        public int Id { get; set; }
        [Display(Name = "Alerte")]
        public virtual string message { get; set; }
        [Display(Name = "Alerte Résolue")]
        public virtual bool resolu { get; set; }
        [Display(Name = "Date de l'enregistrement")]
        public virtual DateTime date { get; set; }
    }

}