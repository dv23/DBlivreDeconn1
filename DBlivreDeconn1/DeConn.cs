using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace DBlivreDeconn1
{
    class DeConn
    {
        private static DeConn cnx = null;
        private MySqlConnection oleCnx;
        private string db;

        public DeConn(string d)
        {
            db = d;
            string cnxStr;
            try
            {   // maj 02 2020 pour mig database sql : ajout ;Port=3308
                cnxStr = "server=localhost;User Id=root;Port=3308;database=" + db;
                //cnxStr = "SERVER=" + unProvider + ";" + "DATABASE=" +
                //uneDataBase + ";" + "UID=" + unUid + ";" + "PASSWORD=" + unMdp + ";";
                try { oleCnx = new MySqlConnection(cnxStr); }
                catch (Exception emp) { MessageBox.Show(emp.Message); }
            }
            catch (Exception emp) { MessageBox.Show(emp.Message); }
        }

        public static DeConn getCnx(string d)
        {
            try { if (cnx == null) { cnx = new DeConn(d); } }
            catch (Exception emp) { MessageBox.Show(emp.Message); }
            return cnx;
        }

        public MySqlConnection getOleCnx() { return (this.oleCnx); }

        public void OuvOleCnx()
        {
            try { oleCnx.Open(); }
            catch (Exception emp) { MessageBox.Show(emp.Message); }
        }

        public void FermOleCnx() { oleCnx.Close(); }
    }
}
