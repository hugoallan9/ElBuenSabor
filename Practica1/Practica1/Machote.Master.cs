using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Practica1.Practica1
{
    public partial class Machote : System.Web.UI.MasterPage
    {
        public static int funcionamiento = 0;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void logeoBt_Click(object sender, EventArgs e)
        {
            login.Text = "" + funcionamiento;
            BaseDatos datab = new BaseDatos();
            SqlDataReader lector = datab.Consulta("select *from Usuario where nombreUsuario ='" + userName.Text + "' and PWDCOMPARE('" + pass.Text + "', contrasenia)= 1");
            if (lector.HasRows && funcionamiento == 0)
            {
                lector.Read();
                login.Text = "Bienvenido  " + lector.GetString(1);
                userName.Text = null;
                userName.Visible = false;
                pass.Text = null;
                pass.Visible = false;
                usuarioLb.Visible = false;
                passLb.Visible = false;
                funcionamiento = 1;
                logeoBt.Text = "Presiona acá para salir del sistema" + funcionamiento;
            }
            else if (funcionamiento == 1)
            {
                userName.Visible = true;
                pass.Visible = true;
                usuarioLb.Visible = true;
                passLb.Visible = true;
                logeoBt.Text = "Logeate aca";
            }
            else
            {
                
            }

            
        }
    }
}