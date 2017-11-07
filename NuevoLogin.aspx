<%@ Page Language="C#" AutoEventWireup="true" CodeFile="NuevoLogin.aspx.cs" Inherits="NuevoLogin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Label ID="title" runat="server" Text="Creacion de Nuevo Login"></asp:Label>
        <br />
        <br />
        <br />
        <asp:Label ID="lblUsuario" runat="server" Text="Nuevo Usuario"></asp:Label>
        <asp:TextBox ID="txtUsuario" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="lblPassword" runat="server" Text="Password"></asp:Label>
        <asp:TextBox ID="txtPassword" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="lblDUI" runat="server" Text="Dui"></asp:Label>
        <asp:TextBox ID="txtDUI" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="btnIngresar" runat="server" OnClick="btnIngresar_Click" Text="Ingresar" />
        <asp:Label ID="lblError" runat="server" Text=":"></asp:Label>
    
    </div>
    </form>
</body>
</html>
