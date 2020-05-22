using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MiApiRest.Models
{
    public class Response
    { 
        public int code { get; set; }
        public string message { get; set; }
        public GpsData[] values { get; set; }
    }
}