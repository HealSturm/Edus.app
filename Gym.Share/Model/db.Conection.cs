using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edus.Share.Model
{
    public class dbConection

    {
        public string sqlConection { get; set; }


        public dbConection()
        {
            sqlConection = "Data Source=68.168.208.58; " + "Initial Catalog=Progra5; Persist Security Info=True;" +
                "TrustServerCertificate= True; User ID=PrograV;" +
                "Password= Vm#6p99r0";
        } 
    }
}
