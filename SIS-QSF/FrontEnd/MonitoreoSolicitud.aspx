<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MonitoreoSolicitud.aspx.cs" Inherits="FrontEnd.MonitoreoSolicitud" %>

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
    <link rel="stylesheet" href="css/style.css" />
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/js/bootstrap.min.js"></script>

    <script src="MS.js"></script>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.4/jquery.min.js"></script>

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
                    <li class="nav-item">
                        <a class="nav-link" href="LlenadoSolicitud.aspx">Llenar Solicitud</a>
                    </li>
                    <li class="nav-item active">
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
            <form runat="server">
                <div class="row">
                    <div class="col-md-5">
                        <p class="text-light font-weight-bold">*Correo Electronico</p>
                        <asp:TextBox ID="txtcorreo" runat="server" class="form-control" placeholder="Correo Electronico"></asp:TextBox>

                     <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="*Correo Obligatorio" ControlToValidate="txtcorreo" ForeColor="Red"></asp:RequiredFieldValidator>
                    <asp:Label ID="lblMensaje" runat="server" BackColor="Red" ForeColor="White" ></asp:Label>

                    </div>
                    <div class="col-md-4">
                        <p class="mb-5"></p>
                        <asp:Button ID="Button1" class="btn btn-primary" runat="server" OnClick="Button1_Click" Text="Ver Progreso" />
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-12">
                        <h2 class="text-light display-2">Datos del Usuario</h2>
                    </div>
                </div>
                <div class="row mb-4">
                    <div class="col-md-5">
                        <p class="text-light font-weight-bold text-center">Clave De Usuario</p>
                        <asp:Label ID="lblclaveusuario" runat="server"  class="form-control" Text="********"></asp:Label>
                    </div>
                    <div class="col-md-5">
                        <p class="text-light font-weight-bold text-center">Nombre</p>
                        <asp:Label ID="lblNombre" runat="server"  class="form-control" Text="********"></asp:Label>
                    </div>
                </div>
                <div class="row mb-4">
                    <div class="col-md-5">
                        <p class="text-light font-weight-bold text-center">No. Control</p>
                        <asp:Label ID="lblNoc" runat="server" class="form-control" Text="********"></asp:Label>
                    </div>
                    <div class="col-md-5">
                        <p class="text-light font-weight-bold text-center">Telefono</p>
                        <asp:Label ID="lblTelefono" runat="server" class="form-control" Text="********"></asp:Label>
                    </div>
                </div>
                <div class="row mb-4">
                    <div class="col-md-5">
                        <p class="text-light font-weight-bold text-center">Correo Electronico</p>
                        <asp:Label ID="lblCorreo" runat="server" class="form-control" Text="********"></asp:Label>
                    </div>
                    <div class="col-md-5">
                        <p class="text-light font-weight-bold text-center">Es Alumno</p>
                        <asp:Label ID="lblEsal" runat="server" class="form-control" Text="********"></asp:Label>
                    </div>
                </div>
                <div class="row mb-4">
                    <div class="col-md-12">
                        <h2 class="text-light display-2">Datos del Servicio Solicitado</h2>
                    </div>
                </div>
                <div class="row mb-4">
                    <div class="col-md-5">
                        <p class="text-light font-weight-bold text-center">Clave de Solicitud</p>
                        <asp:Label ID="lblclaveqsf" runat="server"  class="form-control" Text="********"></asp:Label>
                    </div>
                    <div class="col-md-5">
                        <p class="text-light font-weight-bold text-center">Fecha</p>
                        <asp:Label ID="lblFecha" runat="server" class="form-control" Text="********"></asp:Label>
                    </div>
                </div>
                <div class="row mb-4">
                    <div class="col-md-5">
                        <p class="text-light font-weight-bold text-center">Servicio Solicitado</p>
                        <asp:Label ID="lblTipoServ" runat="server" class="form-control" Text="********"></asp:Label>
                    </div>
                    <div class="col-md-5">
                        <p class="text-light font-weight-bold text-center">Departamento a cargo de su Atención</p>
                        <asp:Label ID="lbldepartamento" runat="server"  class="form-control" Text="********"></asp:Label>
                    </div>
                </div>
                <div class="row mb-4">
                    <div class="col-md-5">
                        <p class="text-light font-weight-bold text-center">Prioridad identificada</p>
                        <asp:Label ID="lblPrio" runat="server"  class="form-control" Text="********"></asp:Label>
                    </div>
                    <div class="col-md-5">
                        <p class="text-light font-weight-bold text-center">Estatus</p>
                        <asp:Label ID="lblestatus" runat="server" class="form-control"  Text="********"></asp:Label>
                    </div>
                </div>
                <div class="row mb-4">
                    <div class="col-md-5">
                        <p class="text-light font-weight-bold text-center">Descripción</p>
                        <asp:Label ID="lblDescrip" runat="server" class="form-control" Text="***********************"></asp:Label>
                    </div>
                    <div class="col-md-5">
                        <p class="text-light font-weight-bold text-center">Observaciones</p>
                        <asp:Label ID="lblobservaciones" runat="server" class="form-control" Text="***********************"></asp:Label>
                    </div>
                </div>
                <div class="row mb-4">
                    <div class="col-md-5 justify-content-start">
                        <asp:Button ID="Btnatras" class="btn btn-block" runat="server" style="background-color:lightblue" Text="<<" OnClick="Btnatras_Click" />
                    </div>
                    <div class="col-md-5 justify-content-end">
                        <asp:Button ID="Btnadelante" class="btn btn-block" runat="server" style="background-color:lightblue" Text=">>" OnClick="Btnadelante_Click" />
                    </div>
                </div>
            </form>
        </div>

         <!-- Footer -->
<footer class="page-footer font-small unique-color-dark pt-4">

  <!-- Footer Elements -->
  <div class="container">

    <!-- Call to action -->
    <ul class="list-unstyled list-inline text-center py-2">
      <li class="list-inline-item">
       
      </li>
      <li class="list-inline-item">
        <a href="#!" id="btnLogin" class="btn btn-outline-white btn-rounded  btn-light">Inicia Sesion!</a>
      </li>
    </ul>
    <!-- Call to action -->

  </div>
  <!-- Footer Elements -->

  <!-- Copyright -->
  <div class="footer-copyright text-center py-3 text-white">Visita el Sitio
    <a href="http://www.itsur.edu.mx/home.php">itsur.edu.mx</a>
  </div>
  <!-- Copyright -->

</footer>
<!-- Footer -->

    </div>
    <script src="MS.js"></script>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.4/jquery.min.js"></script>
</body>
</html>
