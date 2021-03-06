﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="FrontEnd.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <meta http-equiv="X-UA-Compatible" content="ie=edge" />
    <title>Login</title>
    <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.8.1/css/all.css"/>
    <link rel="stylesheet" href="css/style.css" />


</head>
<body>
    <div class="fondo"></div>
    <div class="contenedor">
        <div id="login"  class="margin-left margin-right">
            <form runat="server">
                <div class="center-text">
                    <br />
                    <i id="title" class="far fa-arrow-alt-circle-right fa-2x"></i>
                    <h3 class="display-inline-flex">Inicia sesión</h3>
                </div>
                <div id="form">
                    <div>
                        <i id="iconInput" class="fas fa-user"></i>
                        <asp:TextBox ID="txtUsuario" runat="server" class="mytext" placeholder="Usuario"></asp:TextBox>
                    </div>
                    <div>
                        <i id="iconInput" class="fas fa-key"></i>
                        <asp:TextBox ID="txtPass" runat="server" class="mytext" placeholder="Contraseña" TextMode="Password"></asp:TextBox>
                    </div>
                    <div>
                        <asp:Label ID="lblMensaje" runat="server" BackColor="Red" ForeColor="White" ></asp:Label>
                        <asp:Button class="mybtn" ID="id" runat="server" Text="Iniciar Sesión" OnClick="inicio_Click"/>
                    </div>
                </div>
            </form>
        </div>
    </div>
</body>
</html>
