<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="FrontEnd.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <meta name="viewport" content="width=device-width, initial-scale=1.0"/>
    <meta http-equiv="X-UA-Compatible" content="ie=edge"/>
    <title>Login</title>
    <link rel=icon type="image/jpg" href="Imagenes/itsur.jpg">
    <link rel="stylesheet" href="css/bootstrap.css"/>
    <link rel="stylesheet" href="css/estilo.css"/>
</head>
<body>
   <nav class="navbar navbar-expand-md navbar-dark fixed-top bg-dark">
        <h1><img src="Imagenes/sisqsf.png"/></h1>
         &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
         <h4 style="color:white;">Sistema de Quejas, Sugerencias y/o Felicitaciones</h4>
         &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
         &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <div class="collapse navbar-collapse" id="navbarMenu">
            <ul class="navbar-nav mr-auto" style="border:solid; border-color:aqua;">
                <li class="nav-item">
                    <a href="LlenadoSolicitud.aspx" class="nav-link"><h6 style="color:white;">Llenar Solicitud</h6></a>
                </li>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <li class="nav-item">
                    <a href="MonitoreoSolicitud.aspx" class="nav-link"><h6 style="color:white;">Monitorear Solicitud</h6></a>
                </li>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <li class="nav-item">
                    <a href="Login.aspx" class="nav-link"><h6 style="color:white;">Administración</h6></a>
                </li>
            </ul>
        </div>
    </nav>
    <form id="form1" runat="server">
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <div class="container">
        <div class="row">
            <div class="col-md-4 offset-md-4">
                <div class="card text-white bg-success mb-3" style="max-width: 18rem;">
                    <div class="card-header">
                        <h3>Acceso</h3>
                    </div>
                    <div class="card-body">
                        <asp:TextBox ID="txtUsuario" runat="server" class="form-control input-group-sm chat-input" placeholder="Usuario" ></asp:TextBox>
                        <br />
                        <asp:TextBox ID="txtPass" runat="server" class="form-control input-group-sm chat-input" placeholder="Contraseña" TextMode="Password"></asp:TextBox>
                    </div>
                    <div class="card-footer text-muted">
                        <asp:Label ID="lblMensaje" runat="server" class="alert-danger" Text=""></asp:Label>
                        <asp:Button class="btn btn-light" ID="id" runat="server" Text="Iniciar Sesión" OnClick="inicio_Click"/>
                    </div>
                </div>
            </div>
        </div>
    </div>
    </form>
</body>
</html>
