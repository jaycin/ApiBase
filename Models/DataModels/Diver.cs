using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace ApiBase.Models.DataModels
{
    [DataContract]
    public class Diver
    {
        [Key]
        public long ID { get; set; }
        public virtual ApplicationUser User { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public decimal Latitude { get; set; }
        public decimal Londitude { get; set; }
        public int PhoneNumber { get; set; }
        public string Email { get; set; }

        public virtual ICollection<DiveGear> Gear { get; set; }

    }
}