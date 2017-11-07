using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Planilla : System.Web.UI.Page
{
    procesos validar = new procesos();

    String dui;
    

protected void Page_Load(object sender, EventArgs e)
    {
         dui = Request.QueryString["valor"];
    }




    protected void btnIngresar_Click1(object sender, EventArgs e)
    {
        
        String planilla = ddpPlanilla.Text;
        validar.crearPlanilla(txtSueldobase, txtAFP, txtRenta, txtPrestamos, txtnomEmprestamo, txtIncentivo, txtAnticipo, dui, txtVacaEntrada, txtVacaSalida, txtVacaRemune, planilla, lblError, Response);
    }
}