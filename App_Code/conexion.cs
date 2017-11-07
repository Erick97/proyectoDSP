using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

/// <summary>
/// Descripción breve de procedimiento
/// </summary>
/// 

public class conexion
{
    

    
    private String cadenaConexion;
    private SqlConnection conexionSQL;

    public conexion()
    {
        this.cadenaConexion = ConfigurationManager.ConnectionStrings["CadenaConexion"].ConnectionString;
    }

    public bool conectar()
    {
        try
        {
            this.conexionSQL = new SqlConnection(this.cadenaConexion);
            this.conexionSQL.Open();
            return (true);
        }
        catch (Exception e)
        {
            return (false);
        }
    }

    public void desconectar()
    {
        this.conexionSQL.Close();
    }

    public bool login(String user, String pass)
    {
        conectar();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;

            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = "select usuario, password from login where usuario='" + user + "' and password='" + pass + "'";
            comando.Connection = this.conexionSQL;
            lector = comando.ExecuteReader();
            if (lector.HasRows)
                return (true);
            else
                return (false);
    }

    public bool DUI(String dui)
    {
        conectar();
        SqlCommand comando = new SqlCommand();
        SqlDataReader lector;

        comando.CommandType = System.Data.CommandType.Text;
        comando.CommandText = "select dui from empleado where dui='" + dui + "'";
        comando.Connection = this.conexionSQL;
        lector = comando.ExecuteReader();

        if (lector.HasRows)
            return true;
        else
            return false;
    }

    public void mostrar(String dui, GridView mos)
    {
        conectar();
        String sql;

        DataTable t = new DataTable();
        

        sql = "select e.dui, nombre, apellido, direccionCasa, telefono, tipocargo from empleado e inner join cargo c on e.dui = c.dui where c.dui= @dui";
       

        SqlCommand comando = new SqlCommand(sql,conexionSQL);



        comando.Parameters.Clear();
        comando.Parameters.AddWithValue("@dui", dui);




        SqlDataAdapter dataAdaptador = new SqlDataAdapter(comando);


        dataAdaptador.Fill(t);
       

        t.Columns["dui"].ColumnName = "DUI";
        t.Columns["nombre"].ColumnName = "Nombre Empleado";
        t.Columns["apellido"].ColumnName = "Apellido Empleado";
        t.Columns["direccionCasa"].ColumnName = "Direccion Empleado";
        t.Columns["telefono"].ColumnName = "Telefono Empleado";
        t.Columns["tipoCargo"].ColumnName = "Tipo Cargo";


        mos.Visible = true;
        mos.DataSource = t;
        mos.DataBind();
    }


    public String insertarDatos(double sueldo, double afp, double renta, double prestamos, String nomEmpresa, double incentivos, double anticipo, double sueldoNeto, String dui, String fechaEntrada, String fechaSalida, double sueldoVaca, String tipoPlanilla)
    {
        conectar();
        String sqlplanilla = "update [planilla] set tipoPlanilla = @p2, sueldoBase = @p3, SueldoNeto = @p4, dui = @p1 where idPlanilla= '" + dui + "'";
        String sqlprestamos = "update [prestamos] set cantidad = @p5, nomEmpresa = @p6, dui = @p1 where idPrestamo='" + dui + "'";
        String sqlincentivos = "update [incentivos] set cantidad = @p7 where idIncentivo='" + dui + "'";
        String sqlvacaciones = "update [vacaciones] set fechaEntrada= @p8, fechaSalida = @p9, sueldoVacacion = @p10 where idVacaciones ='" + dui + "'";
        String sqlanticipos = "update [anticipos] set cantidad = @p11 where idAnticipos='" + dui + "'";
        String sqldescuentos = "update [descuentos] set afp = @p12, renta = @p13 where idDescuento='" + dui + "'";

 
        SqlCommand comando = new SqlCommand();
        SqlCommand comando2 = new SqlCommand();
        SqlCommand comando3 = new SqlCommand();
        SqlCommand comando4 = new SqlCommand();
        SqlCommand comando5 = new SqlCommand();
        SqlCommand comando6 = new SqlCommand();

        comando.CommandType = System.Data.CommandType.Text;
        comando.CommandText = sqlplanilla;
        comando.Connection = this.conexionSQL;

        comando2.CommandType = System.Data.CommandType.Text;
        comando2.CommandText = sqlprestamos;
        comando2.Connection = this.conexionSQL;

        comando3.CommandType = System.Data.CommandType.Text;
        comando3.CommandText = sqlincentivos;
        comando3.Connection = this.conexionSQL;

        comando4.CommandType = System.Data.CommandType.Text;
        comando4.CommandText = sqlvacaciones;
        comando4.Connection = this.conexionSQL;

        comando5.CommandType = System.Data.CommandType.Text;
        comando5.CommandText = sqlanticipos;
        comando5.Connection = this.conexionSQL;

        comando6.CommandType = System.Data.CommandType.Text;
        comando6.CommandText = sqldescuentos;
        comando6.Connection = this.conexionSQL;



        try
        {

            comando.Parameters.AddWithValue("@p1", dui);
            comando.Parameters.AddWithValue("@p2", tipoPlanilla);
            comando.Parameters.AddWithValue("@p3", sueldo);
            comando.Parameters.AddWithValue("@p4", sueldoNeto);
            comando.ExecuteNonQuery();

            comando2.Parameters.AddWithValue("@p5", prestamos);
            comando2.Parameters.AddWithValue("@p1", dui);
            comando2.Parameters.AddWithValue("@p6", nomEmpresa);
            comando2.ExecuteNonQuery();

            comando3.Parameters.AddWithValue("@p1", dui);
            comando3.Parameters.AddWithValue("@p7", incentivos);
            comando3.ExecuteNonQuery();

            comando4.Parameters.AddWithValue("@p1", dui);
            comando4.Parameters.AddWithValue("@p8", fechaEntrada);
            comando4.Parameters.AddWithValue("@p9", fechaSalida);
            comando4.Parameters.AddWithValue("@p10", sueldoVaca);
            comando4.ExecuteNonQuery();

            
            comando5.Parameters.AddWithValue("@p1", dui);
            comando5.Parameters.AddWithValue("@p11", anticipo);
            comando5.ExecuteNonQuery();

            comando6.Parameters.AddWithValue("@p1", dui);
            comando6.Parameters.AddWithValue("@p12", afp);
            comando6.Parameters.AddWithValue("@p13", renta);
            comando6.ExecuteNonQuery();


            return "1";
            

        }
        catch(Exception e)
        {
            return e.ToString();
        }
        
    }


    public string crearEmpleado(String dui, String nombre, String apellido, String direcc, String telefono, String cargo)
    {
        conectar();

        String sql = "insert into cargo(tipoCargo, dui) values (@p1, @p2)";
        String sql2 = "insert into empleado (dui, nombre, apellido, direccionCasa, telefono) values (@p3, @p4, @p5, @p6, @p7)";
        String sqlplanilla = "insert into planilla(idPlanilla) values (@p1)";
        String sqlprestamos = "insert into prestamos(idPrestamo) values (@p1)";
        String sqlincentivos = "insert into incentivos (idIncentivo) values (@p1)";
        String sqlvacaciones = "insert into vacaciones(idVacaciones) values (@p1)";
        String sqlanticipos = "insert into anticipos(idAnticipos) values (@p1)";
        String sqldescuentos = "insert into descuentos(idDescuento) values (@p1)";

        SqlCommand comando = new SqlCommand();
        SqlCommand comando2 = new SqlCommand();
        SqlCommand comando3 = new SqlCommand();
        SqlCommand comando4 = new SqlCommand();
        SqlCommand comando5 = new SqlCommand();
        SqlCommand comando6 = new SqlCommand();
        SqlCommand comando7 = new SqlCommand();
        SqlCommand comando8 = new SqlCommand();

        comando.CommandType = System.Data.CommandType.Text;
        comando.CommandText = sql;
        comando.Connection = this.conexionSQL;

        comando2.CommandType = System.Data.CommandType.Text;
        comando2.CommandText = sql2;
        comando2.Connection = this.conexionSQL;

        comando3.CommandType = System.Data.CommandType.Text;
        comando3.CommandText = sqlplanilla;
        comando3.Connection = this.conexionSQL;

        comando4.CommandType = System.Data.CommandType.Text;
        comando4.CommandText = sqlprestamos;
        comando4.Connection = this.conexionSQL;

        comando5.CommandType = System.Data.CommandType.Text;
        comando5.CommandText = sqlincentivos;
        comando5.Connection = this.conexionSQL;

        comando6.CommandType = System.Data.CommandType.Text;
        comando6.CommandText = sqlvacaciones;
        comando6.Connection = this.conexionSQL;

        comando7.CommandType = System.Data.CommandType.Text;
        comando7.CommandText = sqlanticipos;
        comando7.Connection = this.conexionSQL;

        comando8.CommandType = System.Data.CommandType.Text;
        comando8.CommandText = sqldescuentos;
        comando8.Connection = this.conexionSQL;


        try
        {
            comando.Parameters.AddWithValue("@p1", cargo);
            comando.Parameters.AddWithValue("@p2", dui);
            comando.ExecuteNonQuery();

            comando2.Parameters.AddWithValue("@p3", dui);
            comando2.Parameters.AddWithValue("@p4", nombre);
            comando2.Parameters.AddWithValue("@p5", apellido);
            comando2.Parameters.AddWithValue("@p6", direcc);
            comando2.Parameters.AddWithValue("@p7", telefono);
            comando2.ExecuteNonQuery();

            
            comando3.Parameters.AddWithValue("@p1", dui);
            comando3.ExecuteNonQuery();

            comando4.Parameters.AddWithValue("@p1", dui);
            comando4.ExecuteNonQuery();

            comando5.Parameters.AddWithValue("@p1", dui);
            comando5.ExecuteNonQuery();

            comando6.Parameters.AddWithValue("@p1", dui);
            comando6.ExecuteNonQuery();

            comando7.Parameters.AddWithValue("@p1", dui);
            comando7.ExecuteNonQuery();

            comando8.Parameters.AddWithValue("@p1", dui);
            comando8.ExecuteNonQuery();

    
            return "1";
        }
        catch (SqlException e)
        {
            return e.ToString() ;
        }


    }


    public bool crearUsuarioNuevo(String usuario, String password, String dui)
    {
        conectar();

        String sqlCargo = "insert into cargo (tipoCargo, dui) values (@p1, @p2)";
        String sqlLogin = "insert into login (usuario, password, dui) values (@p3, @p4, @p5)";

        SqlCommand comando = new SqlCommand();
        SqlCommand comando2 = new SqlCommand();

        comando.CommandType = System.Data.CommandType.Text;
        comando.CommandText = sqlCargo;
        comando.Connection = this.conexionSQL;

        comando2.CommandType = System.Data.CommandType.Text;
        comando2.CommandText = sqlLogin;
        comando2.Connection = this.conexionSQL;

        try
        {
            comando.Parameters.AddWithValue("@p1", "Administrador");
            comando.Parameters.AddWithValue("@p2", dui);
            comando.ExecuteNonQuery();

            comando2.Parameters.AddWithValue("@p3", usuario);
            comando2.Parameters.AddWithValue("@p4", password);
            comando2.Parameters.AddWithValue("@p5", dui);
            comando2.ExecuteNonQuery();

            return true;
        }
        catch (Exception e)
        {
            return false;
        }


    }


}