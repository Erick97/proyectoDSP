using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

/// <summary>
/// Descripción breve de procesos
/// </summary>
public class procesos
{

    conexion conexionSQL = new conexion();

    public bool comprobar(TextBox m)
    {
        if (m.MaxLength == 0)
            return false;
        else
            return true;
    }

    public bool comprobarPlanilla(TextBox a, TextBox b, TextBox c, TextBox d, TextBox e, TextBox f, TextBox g, TextBox h, TextBox i, TextBox j)
    {
        if (a.Text.Length > 0 && b.Text.Length > 0 && c.Text.Length > 0 && d.Text.Length > 0 && e.Text.Length > 0 && f.Text.Length > 0 && g.Text.Length > 0 && h.Text.Length > 0 && i.Text.Length > 0 && j.Text.Length > 0)
            return true;
        else
            return false;
    }

    public bool comprobarEmpleado(TextBox a, TextBox b, TextBox c, TextBox d, TextBox e, TextBox f)
    {
        if (a.Text.Length > 0 && b.Text.Length > 0 && c.Text.Length > 0 && d.Text.Length > 0 && e.Text.Length > 0 && f.Text.Length > 0)
            return true;
        else
            return false;
    }

    public bool comprobarLogin(TextBox a, TextBox b, TextBox c)
    {
        if (a.Text.Length > 0 && b.Text.Length > 0 && c.Text.Length > 0)
            return true;
        else
            return false;
    }



    public void buscar(Label m, TextBox n, Button l, GridView most)
    {
        try
        {
            if (!comprobar(n) && conexionSQL.DUI(n.Text))
               
            {
                m.Text = "Empleado Encontrado";
                l.Visible = true;
                conexionSQL.mostrar(n.Text, most);
            }
                
            else
                m.Text = "DUI del empleado no existe, por favor verificar";
        }
        catch (Exception e)
        {

        }
    }
        
       
        public void login(TextBox l, TextBox n, Label m, HttpResponse j)
    {
        if (conexionSQL.login(l.Text, n.Text))
        {
            j.Redirect("empleado.aspx");
        }
        else
            m.Text = "Usuario Incorrecto";
    }

    public Double descuentos(double sueldo, double afp, double renta, double prestamos, double incentivos, double anticipo)
    {
        double descuento;
        double pa;
        double sueldoNeto;
        descuento = sueldo * (afp + renta);
        pa = prestamos + anticipo;
        sueldoNeto = sueldo - descuento - pa + incentivos;

        return sueldoNeto;
    }


    public void crearPlanilla(TextBox sueldo, TextBox afp, TextBox renta, TextBox prestamos, TextBox nomEmpresa, TextBox incentivos, TextBox anticipo, String dui, TextBox fechaEntrada, TextBox fechaSalida, TextBox sueldoVaca, String tipoPlanilla, Label error, HttpResponse j)
    {
        if (comprobarPlanilla(sueldo, afp, renta, prestamos, nomEmpresa, incentivos, anticipo, fechaEntrada, fechaSalida, sueldoVaca) == true)
        {
            capturarDatos(Convert.ToDouble(sueldo.Text), Convert.ToDouble(afp.Text), Convert.ToDouble(renta.Text), Convert.ToDouble(prestamos.Text), nomEmpresa.Text, Convert.ToDouble(incentivos.Text), Convert.ToDouble(anticipo.Text), dui, fechaEntrada.Text, fechaSalida.Text, Convert.ToDouble(sueldoVaca.Text), tipoPlanilla, error);
            j.Redirect("empleado.aspx");
                
        }
        else
            error.Text = "Ha dejado un campo vacio";
        
    }

   public string capturarDatos(double sueldo, double afp, double renta, double prestamos, String nomEmpresa, double incentivos, double anticipo, String dui, String fechaEntrada, String fechaSalida, double sueldoVaca, String tipoPlanilla, Label e)
    {
        double sueldoNeto = descuentos(sueldo, afp, renta, prestamos, incentivos, anticipo);

        string valor= conexionSQL.insertarDatos(sueldo, afp, renta, prestamos, nomEmpresa, incentivos, anticipo, sueldoNeto, dui, fechaEntrada, fechaSalida, sueldoVaca, tipoPlanilla);
        if (valor == "1")
            return "1";
        else
            e.Text = valor;
        return "";
            
           
        

    }


    public void crearEmpleado(TextBox dui, TextBox nombre, TextBox apellido, TextBox direcc, TextBox telefono, TextBox cargo, HttpResponse j, Label error)
    {
        string valor = "";


        if (comprobarEmpleado(dui, nombre, apellido, direcc, telefono, cargo))
        {
             valor = conexionSQL.crearEmpleado(dui.Text, nombre.Text, apellido.Text, direcc.Text, telefono.Text, cargo.Text);
            if (valor == "1")
                j.Redirect("empleado.aspx");
            else error.Text = valor;
        }
            
        else
            error.Text = "Ha dejado campos vacios";
    }

    public void crearLogin(TextBox usuario, TextBox password, TextBox dui, Label error, HttpResponse j)
    {
        if (conexionSQL.crearUsuarioNuevo(usuario.Text, password.Text, dui.Text) == true && comprobarLogin(usuario, password, dui) == true)
        {
            j.Redirect("login.aspx");
        }
        else
            error.Text = "Error al ingresar los datos";
    }
}

    

    
   

