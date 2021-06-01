using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace DBlivreDeconn1
{
    public partial class FormBiblio : Form
    {
        private DeConn cx = new DeConn("biblio");
        private DataSet ds = new DataSet("autr");
        private MySqlDataAdapter adapt1;
        private MySqlDataAdapter adapt2;

        public FormBiblio()
        {
            adapt1 = new MySqlDataAdapter("select * from auteur", cx.getOleCnx());
            adapt2 = new MySqlDataAdapter("select * from livre", cx.getOleCnx());
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cx.OuvOleCnx();
            adapt1.Fill(ds, "aut");
            adapt2.Fill(ds, "liv");
            dgv1.DataSource = ds;
            dgv1.DataMember = "aut";
            ds.Relations.Add("livaut", ds.Tables["aut"].Columns["num"], ds.Tables["liv"].Columns["numAuteur"]);
            dgv2.DataSource = ds;
            dgv2.DataMember = "aut.livaut";
        }

        private void bt_Click(object sender, EventArgs e)
        {
            MySqlCommandBuilder cmd1 = new MySqlCommandBuilder(adapt1);
            MySqlCommandBuilder cmd2 = new MySqlCommandBuilder(adapt2);
            try
            {
                adapt1.Update(ds, "aut");
                adapt2.Update(ds, "liv");
            }
            catch (System.Exception ex) { MessageBox.Show(ex.Message); }
        }
    }
}
