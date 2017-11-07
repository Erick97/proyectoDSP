<%@ Page Language="C#" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
    
<head runat="server">
    <link href="css/csslogin.css" rel="stylesheet"/>
    <link rel="stylesheet" href="fonts/css/font-awesome.min.css">
    <link href="https://fonts.googleapis.com/css?family=Lato" rel="stylesheet">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Planillas de Empleado</title>
</head>
<body>
    <form id="form1" runat="server">
       <header class="header">
            <h1>Aplicacion para Generar Planillas</h1>
        </header>
      <div id="login1">
        <h1 class="h1login">Login</h1>
          </div>
   <div id="container">
        <asp:Label ID="Label1" runat="server" Text="Usuario:"></asp:Label>
        <p>
          <i class="fa fa-user" aria-hidden="true"></i> <asp:TextBox ID="txtUsu" runat="server" Width="228px"></asp:TextBox>
        </p>
        <asp:Label ID="Label2" runat="server" Text="Password: "></asp:Label>
        <p>
           <i class="fa fa-unlock-alt" aria-hidden="true"></i> <asp:TextBox ID="txtPass" runat="server" Width="228px" TextMode="Password"></asp:TextBox>
        </p>
        <asp:Button ID="btnIngresar" runat="server" Height="40px" OnClick="btnIngresar_Click" Text="Ingresar" Width="100px" />
        <asp:Label ID="lblAviso" runat="server"></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="txtDesarrolladores" runat="server" OnClick="txtDesarrolladores_Click" Text="Desarrolladores" />
            &nbsp;
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Crear Nuevo Usuario" />
            </div>
    </form>
</body>
</html>
