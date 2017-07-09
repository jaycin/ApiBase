using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace ApiBase.Models.DataModels
{
    [DataContract]
    public class Dive
    {
        [Key]
        public long ID { get; set; }

        public decimal Latitude { get; set; }
        public decimal Londitude { get; set; }
        public string Name { get; set; }
        public DateTime? Time { get; set; }

        public virtual ICollection<Diver> Divers { get; set; }
        public virtual ICollection<DivePost> Posts { get; set; }
    }
}