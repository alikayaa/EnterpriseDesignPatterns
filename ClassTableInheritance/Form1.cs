using ClassTableInheritance.Mapper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClassTableInheritance
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            SqlConnection conn = new SqlConnection(@"Data Source=WINDOZE\SQLEXPRESS;Initial Catalog=DAI;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False");
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Kullanici", conn);
            SqlDataAdapter _adapter = new SqlDataAdapter("SELECT * FROM NormalKullanici", conn);
            SqlDataAdapter __adapter = new SqlDataAdapter("SELECT * FROM YoneticiKullanici", conn);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "Kullanici");
            _adapter.Fill(ds, "NormalKullanici");
            __adapter.Fill(ds, "YoneticiKullanici");
            UserMapper _mapper = new UserMapper();
            _mapper.gateway.Data = ds;
            User _user = _mapper.Find(1);
        }


    }
}
