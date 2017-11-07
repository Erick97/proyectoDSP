<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BoletaPago.aspx.cs" Inherits="BoletaPago" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link rel="stylesheet" href="fonts/css/font-awesome.min.css">
    <link href="css/cssboleta.css" rel="stylesheet"/>
     <link href="https://fonts.googleapis.com/css?family=Lato" rel="stylesheet">
    <title>Boleta de pago</title>
</head>
<body>
    <form id="form1" runat="server">
        <header>
            <h1>Creacion de boleta de pago</h1>
        </header>
    <div class="container">
    
        <asp:Label ID="lblnomEmpleado" runat="server"></asp:Label>
        <asp:Label ID="lblapeEmpleado" runat="server"></asp:Label>
    
    </div>
    </form>
</body>
</html>
