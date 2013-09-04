<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Creacion.aspx.cs" Inherits="Practica1.Practica1.WebForm1" %>

<!DOCTYPE html>

<html>
<head>
<title>Student Registration Form</title>
<style  type="text/css">
h3{font-family: Calibri; font-size: 22pt; font-style: normal; font-weight: bold; color:SlateBlue;
text-align: center; text-decoration: underline }
table{font-family: Calibri; color:white; font-size: 11pt; font-style: normal;
text-align:; background-color: SlateBlue; border-collapse: collapse; border: 2px solid navy}
table.inner{border: 0px}

    .auto-style1 {
        height: 55px;
    }
    #Hidden1 {
        z-index: 1;
        left: 0px;
        top: 0px;
        position: absolute;
    }

</style>
</head>
 
<body>
    <form id="form1" runat="server">
<h3>REGISTRO DE USUARIOS "EL BUEN SABOR"</h3>
 
<table align="center" cellpadding = "10">
 
<!----- First Name ---------------------------------------------------------->
<tr>
<td class="auto-style1">Nombre</td>
<td class="auto-style1">
    <asp:TextBox ID="nombre" runat="server"></asp:TextBox>
&nbsp;(max 30 characters a-z and A-Z)
    
</td>
</tr>
 
<!----- Last Name ---------------------------------------------------------->
<tr>
<td>Apellido<asp:TextBox ID="TextBox1" runat="server" OnTextChanged="TextBox1_TextChanged" style="z-index: 1; left: 271px; top: 137px; position: absolute">sin tex</asp:TextBox>
    </td>
<td><asp:TextBox ID="apellido" runat="server"></asp:TextBox>(max 30 characters a-z and A-Z)
</td>
</tr>
 
<tr>
    <td>Nacionalidad</td>
    <td><asp:TextBox ID="nacionalidad" runat="server"></asp:TextBox>
    (max 35 characters a-z and A-Z)
    </td>
</tr>

 
<!----- NIck ---------------------------------------------------------->
<tr>
<td>Nombre Usuario</td>
<td><asp:TextBox ID="nick" runat="server"></asp:TextBox>
    (max 30 characters a-z and A-Z)
</td>
</tr>
 
<!----- Pass---------------------------------------------------------->
<tr>
<td>Contraseña</td>
<td>
    <asp:TextBox ID="pass" textmode="Password" runat="server"></asp:TextBox>
</td>
</tr>
 

</table>
 
        <div style="width: 174px; height: 44px; margin-left: 416px; margin-top: 40px; z-index: 1; left: 169px; top: 301px; position: absolute;">
            <asp:Button ID="Button1" runat="server" style="margin-left: 0px; position: absolute; z-index: 1; left: 430px; top: 344px; height: 23px; width: 138px;" Text="Ingresar Usuario" />
            <asp:Button ID="loginBt" runat="server" OnClick="loginBt_Click" Text="Ingresar Usuario" />
        </div>
        <p>
            &nbsp;</p>
    </form>
 
</body>
</html>