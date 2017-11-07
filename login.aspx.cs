using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;




public partial class _Default : System.Web.UI.Page
{
   conexion conexionSQL = new conexion();
    procesos m = new procesos();
    
    protected void Page_Load(object sender, EventArgs e)
    {
     
    }

    protected void btnIngresar_Click(object sender, EventArgs e)
    {
        m.login(txtUsu, txtPass, lblAviso, Response);
    }

    protected void txtDesarrolladores_Click(object sender, EventArgs e)
    {
        Response.Redirect("Integrantes.aspx");
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("NuevoLogin.aspx");
    }
}