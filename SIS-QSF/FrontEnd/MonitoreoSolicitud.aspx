﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MonitoreoSolicitud.aspx.cs" Inherits="FrontEnd.MonitoreoSolicitud" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <meta http-equiv="X-UA-Compatible" content="ie=edge" />
    <title>Progreso QSF</title>
    <link rel="icon" type="image/jpg" href="Imagenes/itsur.jpg">
    <link rel="stylesheet" href="css/bootstrap.css" />
    <link rel="stylesheet" href="css/estilo.css" />
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
    <br />
    <br />
    <br />
    <br />
    <div class="col-12">
        <div class="row">
          <form class="mt-5 col-12" runat="server">
            <div class="col-12"> 
                    <div class="input-group col-12">
                        <p>*Nombre completo&nbsp;&nbsp;&nbsp;</p>
                        <asp:TextBox ID="txtnombre" runat="server" class="form-control" placeholder="Nombre completo"></asp:TextBox>
                         <div class="col-md-3 col-sm-3 col-xs-3 pad-adjust">
                            <asp:Button ID="Button1" class="btn btn-block" runat="server" style="background-color:lightblue" OnClick="Button1_Click" Text="Ver Progreso" />
                         </div>   
                    </div>
                    <br />
                    <div class="input-group col-12">
                        <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="XX-Large" Text="Datos del usuario :"></asp:Label>
                    </div>
                    <br />
                    <div class="input-group col-12">
                        <p>Nombre :&nbsp;&nbsp;&nbsp;</p>
                        <asp:Label ID="lblNombre" runat="server"  class="form-control" Text="********"></asp:Label>
                        &nbsp;&nbsp;&nbsp;
                        <p>Teléfono :&nbsp;&nbsp;&nbsp;</p>
                        <asp:Label ID="lblTelefono" runat="server" class="form-control" Text="********"></asp:Label>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <p>Correo electronico :&nbsp;&nbsp;&nbsp;</p>
                        <asp:Label ID="lblCorreo" runat="server" class="form-control" Text="********"></asp:Label>
                    </div>
                    <br />
                    <div class="input-group col-12">
                        <p>No. Control :&nbsp;&nbsp;&nbsp;</p>
                        <asp:Label ID="lblNoc" runat="server" class="form-control" Text="********"></asp:Label>
                        <p>&nbsp;&nbsp;Es Alumno :&nbsp;&nbsp;&nbsp;</p>
                        <asp:Label ID="lblEsal" runat="server" class="form-control" Text="********"></asp:Label>
                    </div>
                    <br />
                    <div class="input-group col-12">
                        <asp:Label ID="lbl6" runat="server" Font-Bold="True" Font-Size="XX-Large" Text="Datos de la QSF :"></asp:Label>
                    </div>
                    <br />
                    <div class="input-group col-12">
                        <p>Fecha :&nbsp;&nbsp;&nbsp;</p>
                         <asp:Label ID="lblFecha" runat="server" class="form-control" Text="********"></asp:Label>
                        <p>&nbsp;&nbsp;Servicio Solicitado :&nbsp;&nbsp;&nbsp;</p>
                        <asp:Label ID="lblTipoServ" runat="server" class="form-control" Text="********"></asp:Label>
                    </div>
                    <br />
                    <div class="input-group col-12">
                        <p>Prioridad Identificada :&nbsp;&nbsp;&nbsp;</p>
                         <asp:Label ID="lblPrio" runat="server"  class="form-control" Text="********"></asp:Label>
                        <p>&nbsp;&nbsp;Estatus :&nbsp;&nbsp;&nbsp;</p>
                        <asp:Label ID="lblestatus" runat="server" class="form-control"  Text="********"></asp:Label>
                    </div>
                    <br />
                    <div class="input-group col-12">
                         <p>Descripción :&nbsp;&nbsp;&nbsp;</p>
                         <asp:Label ID="lblDescrip" runat="server" class="form-control" Text="***********************"></asp:Label>
                    </div>
                </div>
            </form>
        </div>
    </div>
</body>
</html>