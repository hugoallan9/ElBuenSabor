using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Practica1.Practica1
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
       
        }

        protected void loginBt_Click(object sender, EventArgs e)
        {
            TextBox1.Text = " me he conectado";
            BaseDatos dab = new BaseDatos();
            bool f = dab.verificarconexion();
            if (f)
            {
                TextBox1.Text = " me he conectado";
            }
            int id = 1;
            string datos = "insert into Usuario(nombrePila,apellido,nacionalidad,nombreUsuario,contrasenia)values(\'" + nombre.Text +"\',\'"+ apellido.Text+"\', \'" + nacionalidad.Text+"\',\'"+ nick.Text+"\', PWDENCRYPT(\'"+pass.Text +"\')  )" ;
            TextBox1.Text = dab.insertarDatos(datos);  
 
        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}