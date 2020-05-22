using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MiApiRest.Models
{
    public class GpsData
    {
       public int id { get; set; }
       public string dateSystem { get; set; }
       public string dateEvent { get; set; }
       public float latitude { get; set; }
       public float longitude { get; set; }
       public int battery { get; set; }
       public int source { get; set; }
       public int type { get; set; }
    }
}