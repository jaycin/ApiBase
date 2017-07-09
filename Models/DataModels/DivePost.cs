using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace ApiBase.Models.DataModels
{
    [DataContract]
    public class DivePost
    {
        [Key]
        public long ID { get; set; }
        
        public virtual Diver Poster { get; set; }
        public string Content { get; set; }
    }
}