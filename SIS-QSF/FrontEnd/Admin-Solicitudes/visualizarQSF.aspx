<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="visualizarQSF.aspx.cs" Inherits="FrontEnd.Admin_Solicitudes.visualizarQSF" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
   
    <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.8.1/css/all.css" integrity="sha384-50oBUHEmvpQ+1lW4y57PTFmhCaXp0ML5d60M1M7uH2+nqUivzIebhndOJK28anvf" crossorigin="anonymous">
     <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" integrity="sha384-JcKb8q3iqJ61gNV9KGb8thSsNjpSL0n8PARn9HuZOnIxN0hoP+VmmDGMN5t9UJ0Z" crossorigin="anonymous">
    <link rel="stylesheet" href="https://cdn.datatables.net/1.10.22/css/dataTables.bootstrap4.min.css">
    <title></title>
</head>
<body>

    <!--NavBar-->
    <nav class="navbar navbar-expand-lg navbar-dark bg-dark">
        <a class="navbar-brand" href="#"><h1><img style="width:6em" src="../Imagenes/sisqsf.png"/></h1></a>
        <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
        <span class="navbar-toggler-icon"></span>
        </button>

        <div class="collapse navbar-collapse" id="navbarSupportedContent">
        <ul class="navbar-nav mr-auto">
            <li class="nav-item">
            <a class="nav-link" href="#">Inicio <span class="sr-only">(current)</span></a>
            </li>
            <li class="nav-item">
            <a class="nav-link" href="visualizarQSF.aspx">Administrar solicitudes</a>
            </li>
            <li class="nav-item">
            <a class="nav-link" href="#">Reportes</a>
            </li>
            <li class="nav-item">
            <a class="nav-link" href="#">Acerca de </a>
            </li>
        </ul>
        <ul class="navbar-nav form-inline my-lg-0 nav-item">
            <a class="nav-link text-white" href="#" tabindex="-1" aria-disabled="true">Iniciar sesión</a>
        </ul>
        </div>
    </nav>
    <form id="form1" runat="server">

         <asp:ScriptManager ID="ScriptManager1" runat="server">
             <Services>
                <asp:ServiceReference Path="~/ws/WSQSF.asmx" />
            </Services>
        </asp:ScriptManager>
      
        <div class="container">
          <div class="row">
            <div class="col-sm-12">
               <h1>Desde aqui se podra visualizar todas las solicitudes generadas por los usuarios</h1>
            </div>
          </div>
          <div class="row">
            <div class="col-sm-12">
                <div id="alert" >
                </div>
            </div>
          </div>
          <div class="row">
            <div class="col-sm-12">
                <table id="tableQSF"  class="table table-bordered table-striped"></table>
            </div>
          </div>
        </div>
       <table id="tableQSF" class="table table-bordered table-striped"></table>
    </form>
    
    <%--  Inicia modal para editar la solicitud --%>
    <div class="modal " id="mdlEditar" tabindex="-1" >
      <div class="modal-dialog modal-dialog-centered modal-xl modal-dialog-scrollable" >
        <div class="modal-content">
          <div class="modal-header  text-white bg-dark  text-center">
            <h5 class="modal-title">Editar solicitud</h5>
            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
              <span aria-hidden="true">&times;</span>
            </button>
          </div>
          <div class="modal-body">
              <h5>Detalles de la solicitud</h5>
            <form>
                <div class="row">
                    <div class="col-md-4 form-group" >
                       <div class="input-group mb-3">
                            <div class="input-group-prepend">
                                <span class="input-group-text">Clave</span>
                            </div>
                            <input type="text" id="txtClaveQSF" name="txtClaveQSF" class="form-control" readonly />
                        </div>
                    </div>
                    <div class="col-md-8">
                       <div class="input-group mb-3 form-group">
                            <div class="input-group-prepend">
                                <span class="input-group-text">Usuario</span>
                            </div>
                            <input type="text" id="txtUsuarioSolicitante" name="txtUsuarioSolicitante" class="form-control" readonly />
                        </div>
                    </div>
                </div>

                <div class="row">
                    <div class="col-md-5">
                       <div class="input-group mb-3 form-group">
                        <div class="input-group-prepend">
                            <span class="input-group-text">Fecha</span>
                        </div>
                        <input type="text" id="txtFecha" name="txtFecha" class="form-control" readonly/>
                    </div>
                    </div>
                    <div class="col-md-3">
                       <div class="input-group mb-3 form-group">
                        <div class="input-group-prepend">
                            <span class="input-group-text">Prioridad</span>
                        </div>
                           <select class="form-control" id="cboPrioridad">
                              <option value="0">Alta</option>
                              <option value="1">Media</option>
                              <option value="2">Baja</option>
                            </select>
                        </div>
                    </div>
                    <div class="col-md-4">
                        <div class="input-group mb-3 form-group">
                        <div class="input-group-prepend">
                            <span class="input-group-text">Estatus</span>
                        </div>
                           <select class="form-control" id="cboEstatus"  name="cboEstatus">
                              <option value="0">No iniciada</option>
                              <option value="1">En proceso</option>
                              <option value="2">Finalizada</option>
                              <option value="3">Rechazada</option>
                            </select>
                        </div>
                    </div>
                </div>

                <div class="row">
                    
                    <div class="col-md-6">
                        <div class="input-group mb-3 form-group">
                        <div class="input-group-prepend">
                            <span class="input-group-text">Tipo de servicio</span>
                        </div>
                           <select class="form-control" id="cboTipo_Servicio"  name="cboTipo_Servicio">
                              <option  value="0">Queja</option>
                              <option value="1">Sugerencia</option>
                              <option value="2">Felicitacion</option>
                            </select>
                        </div>
                    </div>

                    <div class="col-md-6">
                        <div class="input-group mb-3 form-group">
                        <div class="input-group-prepend">
                            <span class="input-group-text">Departamento</span>
                        </div>
                           <select class="form-control" id="cboDepartamento"  name="cboDepartamento">
                              <option value="0">Calidad</option>
                              <option value="1">Vinculacion</option>
                              <option value="2">Academico</option> 
                               <option value="3">Planeacion</option> 
                              <option value="4">Administracion</option>
                            </select>
                        </div>
                    </div>
                </div>

               <div class="mb-3 form-group">
                    <label for="txtDescripcion">Descripcion</label>
                    <textarea class="form-control" id="txtDescripcion" rows="3" readonly></textarea>
               </div>
             
                <div class="mb-3 form-group">
                    <label for="txtObservaciones">Observaciones</label>
                    <textarea class="form-control" id="txtObservaciones" rows="3" ></textarea>
                </div>
            </form>
              <hr/>
              <h5>Envio de correo al departamento</h5>
              <div class="input-group mb-3">
                <div class="input-group-prepend">
                    <span class="input-group-text">Correo</span>
                </div>
                <input type="email" id="txtCorreo" name="txtCorreo" aria-describedby="emailHelp" class="form-control" placeholder="Correo a donde sera enviada la solicitud" />
              </div>
              <button type="button" id="btnEnviar"class="btn btn-primary">Enviar correo</button>
          </div>
          <div class="modal-footer">
            <button type="button" class="btn btn-danger" data-dismiss="modal">Cancelar</button>
            <button id="btnEditar" type="button" class="btn btn-success">Guardar</button>
          </div>
        </div>
      </div>
    </div>
    <%--  Termina modal --%> 

    <%--  Inicia modal para visualizar la solicitud --%>
    <div class="modal " id="mdlVisualizar" tabindex="-1" >
      <div class="modal-dialog modal-dialog-centered modal-xl modal-dialog-scrollable" >
        <div class="modal-content">
          <div class="modal-header  text-white bg-dark  text-center">
            <h5 class="modal-title">Visualizar solicitud</h5>
            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
              <span aria-hidden="true">&times;</span>
            </button>
          </div>
          <div class="modal-body">
              <h5>Detalles de la solicitud</h5>
            <form>
                <div class="row">
                    <div class="col-md-4">
                       <div class="input-group mb-3">
                            <div class="input-group-prepend">
                                <span class="input-group-text">Clave</span>
                            </div>
                            <input type="text" id="txtClaveQSF_V" name="txtClaveQSF_V" class="form-control" readonly />
                        </div>
                    </div>
                    <div class="col-md-8">
                       <div class="input-group mb-3">
                            <div class="input-group-prepend">
                                <span class="input-group-text">Usuario</span>
                            </div>
                            <input type="text" id="txtUsuarioSolicitante_V" name="txtUsuarioSolicitante_V" class="form-control" readonly />
                        </div>
                    </div>
                </div>

                <div class="row">
                    <div class="col-md-5">
                       <div class="input-group mb-3">
                        <div class="input-group-prepend">
                            <span class="input-group-text">Fecha</span>
                        </div>
                        <input type="text" id="txtFecha_V" name="txtFecha_V" class="form-control" placeholder="Fecha" readonly/>
                    </div>
                    </div>
                    <div class="col-md-3">
                       <div class="input-group mb-3">
                        <div class="input-group-prepend">
                            <span class="input-group-text">Prioridad</span>
                        </div>
                           <input type="text" id="txtPrioridad_V" name="txtPrioridad_V" class="form-control" readonly />
                        </div>
                    </div>
                    <div class="col-md-4">
                        <div class="input-group mb-3">
                        <div class="input-group-prepend">
                            <span class="input-group-text">Estatus</span>
                        </div>
                            <input type="text" id="txtEstatus_V" name="txtEstatus_V" class="form-control" readonly />
                        </div>
                    </div>
                </div>

                <div class="row">
                    
                    <div class="col-md-6">
                        <div class="input-group mb-3">
                        <div class="input-group-prepend">
                            <span class="input-group-text">Tipo de servicio</span>
                        </div>
                            <input type="text" id="txtTipo_Servicio_V" name="txtTipo_Servicio_V" class="form-control" readonly />
                        </div>
                    </div>

                    <div class="col-md-6">
                        <div class="input-group mb-3">
                        <div class="input-group-prepend">
                            <span class="input-group-text">Departamento</span>
                        </div>
                            <input type="text" id="txtDepartamento_V" name="txtDepartamento_V" class="form-control" readonly />
                        </div>
                    </div>
                </div>

               <div class="mb-3 form-group">
                    <label for="txtDescripcion">Descripcion</label>
                    <textarea class="form-control" id="txtDescripcion_V" rows="3" readonly></textarea>
               </div>
             
                <div class="mb-3 form-group">
                    <label for="txtObservaciones">Observaciones</label>
                    <textarea class="form-control" id="txtObservaciones_V" rows="3" readonly></textarea>
                </div>
            </form>
          </div>
          <div class="modal-footer">
            <button type="button" class="btn btn-success" data-dismiss="modal">OK</button>
          </div>
        </div>
      </div>
    </div>
    <%--  Termina modal --%> 

    <!-- Modal para confirmar el eliminar un servicio-->
    <div class="modal fade" id="mdlEliminar" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
      <div class="modal-dialog modal-dialog-centered">
        <div class="modal-content">
          <div class="modal-header">
            <h5 class="modal-title" id="exampleModalLabel">Eliminar un servicio</h5>
            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
              <span aria-hidden="true">&times;</span>
            </button>
          </div>
          <div class="modal-body">
            <p>¿Estas seguro que deseas eliminar el servicio?</p>
          </div>
          <div class="modal-footer">
            <button type="button" class="btn btn-danger" data-dismiss="modal">Cancelar</button>
            <button id="bntborrarServicio" type="button"  class="btn btn-primary" >Aceptar</button>
          </div>
        </div>
      </div>
    </div>
    
</body>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.4/jquery.min.js"></script>
    <script src="https://smtpjs.com/v3/smtp.js"></script>
    <script src="visualizarQSF.js"></script>
    <script src="../jss/bootstrap.js"></script>
    <script src="../jss/jquery-3.4.1.js"></script>
    <script src="../jss/datatables.js"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js" integrity="sha384-B4gt1jrGC7Jh4AgTPSdUtOBvfO8shuf57BaghqFfPlYxofvL8/KUEfYiJOMMV+rV" crossorigin="anonymous"></script>
    <script src="https://cdn.datatables.net/1.10.22/js/jquery.dataTables.min.js"></script>
    <script src="https://cdn.datatables.net/1.10.22/js/dataTables.bootstrap4.min.js"></script>
</html>
