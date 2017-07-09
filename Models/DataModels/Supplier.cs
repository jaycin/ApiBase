using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace ApiBase.Models.DataModels
{
    [DataContract]
    public class Supplier
    {
        [Key]
        public long ID { get; set; }

        public string Name { get; set; }
    }
}