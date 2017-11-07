<%@ Page Language="C#" AutoEventWireup="true" CodeFile="empleado.aspx.cs" Inherits="empleado" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
      <link rel="stylesheet" href="fonts/css/font-awesome.min.css">
    <link href="css/cssempleado.css" rel="stylesheet"/>
     <link href="https://fonts.googleapis.com/css?family=Lato" rel="stylesheet">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
   
    <title>Busqueda del empleado</title>
</head>
<body>
    <form id="form1" runat="server">
        <header id="header">
            <h1 >Busqueda del Empleado</h1>
        </header>
    
    <div class="container">
        <p>
            <asp:Label ID="Label1" runat="server" Text="Ingrese No de DUI del Empleado"></asp:Label>
        </p>
        <p>
       <i class="fa fa-search" aria-hidden="true"></i> <asp:TextBox ID="txtDUI" runat="server"></asp:TextBox>
        <asp:Button ID="btnBuscar" runat="server" Text="Bucar" OnClick="btnBuscar_Click" style="height: 26px" />
        <asp:Button ID="Ingresarem" runat="server" OnClick="Button1_Click" Text="Ingresar nuevo Empleado" />
        </p>
        <p>
            <asp:Label ID="lbldui" runat="server"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        </p>
        <asp:GridView ID="gvMostrar" runat="server"  Height="16px">
        </asp:GridView>
        <br />
        <p>
            <asp:Button ID="btnPlanilla" runat="server" OnClick="btnPlanilla_Click" Text="Crear Planilla" />
        </p>
        </div>
    </form>
</body>
</html>
