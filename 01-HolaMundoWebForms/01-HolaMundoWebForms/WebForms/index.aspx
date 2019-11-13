<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="_01_HolaMundoWebForms.WebForms.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        #form1 {
            height: 267px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Hola mundo
        </div>
        <p>
            <asp:Label ID="lblNombre" runat="server" Text="Nombre:"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtTexto" runat="server"></asp:TextBox>
            <asp:Label ID="lblAlerta" runat="server" Visible="False"></asp:Label>
        </p>
        <p>
            <asp:Label ID="lblApellido1" runat="server" Text="Primer Apellido:"></asp:Label>
&nbsp;&nbsp;
            <asp:TextBox ID="txtApellido1" runat="server" style="margin-left: 0px"></asp:TextBox>
        </p>
        <asp:Label ID="lblApellido2" runat="server" Text="Segundo Apellido:"></asp:Label>
        <asp:TextBox ID="txtApellido2" runat="server"></asp:TextBox>
        <br />
        <asp:Calendar ID="calendario" runat="server" Height="16px" Width="204px"></asp:Calendar>
        <br />
        <asp:Button ID="btnSaludo" runat="server" Height="23px" OnClick="btnSaludo_Click" Text="Saludar" Width="67px" />
        <br />
        <br />
        <asp:Label ID="lblSaludo" runat="server" Visible="False"></asp:Label>
    </form>
</body>
</html>
