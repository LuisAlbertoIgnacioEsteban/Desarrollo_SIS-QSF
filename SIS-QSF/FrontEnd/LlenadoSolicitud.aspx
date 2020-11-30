﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LlenadoSolicitud.aspx.cs" Inherits="FrontEnd.LlenadoSolicitud" %>

<!DOCTYPE html>

<html>
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <meta name="viewport" content="width=device-width, initial-scale=1.0"/>
    <meta http-equiv="X-UA-Compatible" content="ie=edge"/>
    <title>Formulario QSF</title>
    <link rel=icon type="image/jpg" href="Imagenes/itsur.jpg">
    <link rel="stylesheet" href="css/bootstrap.css" />
    <link rel="stylesheet" href="css/estilo.css" />
    <link rel="stylesheet" href="css/style.css" />
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/js/bootstrap.min.js"></script>
</head>
<body>
    <div class="fondo"></div>
    <div class="contenedor">        
    <nav class="navbar navbar-expand-lg navbar-dark bg-primary"">
        <a class="navbar-nav">
            <img src="Imagenes/sisqsf.png" width="120" height="50" class="d-inline-block align-top">
        </a>
        <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
            <span class="navbar-toggler-icon"></span>
        </button>
        <div class="collapse navbar-collapse" id="navbarSupportedContent">
            <ul class="navbar-nav mr-auto">
                <li class="nav-item active">
                    <a class="nav-link" href="LlenadoSolicitud.aspx">Llenar Solicitud</a>
                </li>
                <li class="nav-item">
                    <a class="nav-link" href="MonitoreoSolicitud.aspx">Monitorear Solicitud</a>
                </li>
                <!--
                        <li class="nav-item">
                            <a class="nav-link" href="Admin-Solicitudes/visualizarQSF.aspx">Administración</a>
                         
                        </li>
                        <li class="nav-item">
                            <a class="nav-link" href="Admin-Solicitudes/GenerarReportes.aspx">Generar Reportes</a>
                        </li>
                        !-->
            </ul>
        </div>
    </nav>
    <div class="container">
        <form runat="server" id="frmLlenadoSolicitud">
            <div class="row mb-4">
                <div class="col-md-5">
                    <p class="text-light font-weight-bold text-center">Nombre</p>
                    <asp:TextBox ID="txtnombre" class="form-control" placeholder="Nombre del alumno" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*Es obligatorio ingresar tu nombre" ControlToValidate="txtnombre" ForeColor="Red"></asp:RequiredFieldValidator>
                </div>
                <div class="col-md-5">
                    <p class="text-light font-weight-bold text-center">Telefono</p>
                    <asp:TextBox ID="txttelefono" class="form-control" placeholder="Teléfono del alumno" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="row mb-4">
                <div class="col-md-5">
                    <p class="text-light font-weight-bold text-center">Correo Electronico</p>
                    <asp:TextBox ID="txtcorreo" class="form-control" placeholder="Correo electronico del alumno" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*Es obligatorio ingresar el correo" ControlToValidate="txtcorreo" ForeColor="Red"></asp:RequiredFieldValidator>
                </div>
                <div class="col-md-5">
                    <p class="text-light font-weight-bold text-center">No. Control</p>
                    <asp:TextBox ID="txtnocontrol" class="form-control" placeholder="No.Control del alumno" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="row mb-4">
                <div class="col-md-5">
                    <p class="text-light font-weight-bold">Tipo de Servicio</p>
                    <asp:RadioButtonList ID="rblservicio" runat="server" CellSpacing = "10"  RepeatDirection="Horizontal">
                            <asp:ListItem Text="Queja" Value="1" ></asp:ListItem>
                            <asp:ListItem Text="Sugerencia" Value="2"></asp:ListItem>
                            <asp:ListItem Text="Felicitación" Value="3"></asp:ListItem>
                    </asp:RadioButtonList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="*Debes seleccionar una opción" ControlToValidate="rblservicio" ForeColor="Red"></asp:RequiredFieldValidator> 
                </div>
                <div class="col-md-5">
                    <p class="text-light font-weight-bold">Alumno</p>
                    <asp:RadioButtonList ID="rblalumno" runat="server" RepeatDirection="Horizontal" CellSpacing="10">
                        <asp:ListItem Text="Si" Value="1"></asp:ListItem>
                        <asp:ListItem Text="No" Value="2"></asp:ListItem>
                    </asp:RadioButtonList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*Debes seleccionar una opción" ControlToValidate="rblalumno" ForeColor="Red"></asp:RequiredFieldValidator>
                </div>

            </div>
            <div class="row mb-4">
                <div class="col-md-12">
                    <p class="text-light font-weight-bold">Describa la problematica</p>
                    <asp:TextBox ID="txtdescripcion" class="form-control" placeholder="Descripción de la problematica" runat="server" TextMode="MultiLine"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="*Descripción Obligatoria" ControlToValidate="txtdescripcion" ForeColor="Red"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="row mb-4">
                <div class="col-md-12">
                    <asp:Button ID="btnregistrar" class="btn btn-primary btn-lg btn-block" runat="server" Text="Generar Registro" OnClick="btnregistrar_Click" />
                </div>
            </div>
        </form>
    </div>
    </div>
</body>
</html>
