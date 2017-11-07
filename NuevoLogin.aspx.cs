using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class NuevoLogin : System.Web.UI.Page
{
    procesos pro = new procesos();
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnIngresar_Click(object sender, EventArgs e)
    {
        pro.crearLogin(txtUsuario, txtPassword, txtDUI, lblError, Response);
    }
}