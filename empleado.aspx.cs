using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class empleado : System.Web.UI.Page
{
    procesos M = new procesos();
    conexion N = new conexion();

    protected void Page_Load(object sender, EventArgs e)
    {
        btnPlanilla.Visible = false;
        gvMostrar.Visible = false;
    }

    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        M.buscar(lbldui, txtDUI, btnPlanilla, gvMostrar);
       
        
    }

    protected void btnPlanilla_Click(object sender, EventArgs e)
    {
        Response.Redirect("Planilla.aspx?valor=" + txtDUI.Text + "");
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("IngresarNuevoEmpleado.aspx");
    }



    protected void Button1_Click1(object sender, EventArgs e)
    {
        Response.Redirect("Integrantes.aspx");
    }
}