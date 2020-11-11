<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="visualizarQSF.aspx.cs" Inherits="FrontEnd.Admin_Solicitudes.visualizarQSF" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">

         <asp:ScriptManager ID="ScriptManager1" runat="server">
            <Services>
                <asp:ServiceReference Path="../ws/WSQSF.asmx" />
            </Services>
        </asp:ScriptManager>
        <button type="button" class="btn btn-primary">Primary</button>
        <div  id="alert"></div>
       
    </form>
    <table id="tableQSF" class="table table-bordered table-striped"></table>
</body>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.4/jquery.min.js">
    <script src="visualizarQSF.js"></script>
    <script src="../jss/bootstrap.js"></script>
    <script src="../jss/jquery-3.4.1.js"></script>
    <script src="../jss/datatables.js"></script>
    
</html>
