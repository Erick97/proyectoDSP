using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class IngresarNuevoEmpleado : System.Web.UI.Page
{

    procesos proce = new procesos();
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnRegistrar_Click(object sender, EventArgs e)
    {
        proce.crearEmpleado(txtDUI, txtNombre, txtApellido, txtdirecc, txtTelefono, txtCargo, Response, lblError);
        //Response.Redirect("empleado.aspx");
    }
}