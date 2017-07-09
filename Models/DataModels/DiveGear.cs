using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace ApiBase.Models.DataModels
{
    [DataContract]
    public class DiveGear
    {
        [Key]
        public long ID { get; set; }
        public virtual Supplier Supplier { get; set; }
        public virtual GearType Type { get; set; }
    }
}