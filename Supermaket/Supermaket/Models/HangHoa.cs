using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Supermaket.Models
{
    public class HangHoa
    {
        [DisplayName("Upload image")]
        public string ANHHHs{ get; set; }
        public string CHITIETPHIEUNHAPs { get; set; }
        public string CHITIETPHIEUXUATs { get; set; }
        public string CHUCVUs { get; set; }
        public string HANGHOAs { get; set; }
        public string KHACHHANGs { get; set; }
        public string NHACCs { get; set; }
        public string NHANVIENs { get; set; }
        public string NHASANXUATs { get; set; }
        public string NHOMHANGs { get; set; }

        public string PHIEUNHAPs { get; set; }

        public string PHIEUXUATs { get; set; }


        public HttpPostedFileBase ImageFile { get; set; }


    }
}