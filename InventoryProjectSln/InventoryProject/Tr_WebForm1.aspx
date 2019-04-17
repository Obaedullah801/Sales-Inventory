
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Tr_WebForm1.aspx.cs" Inherits="InventoryProject.Tr_WebForm" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <h1>Report</h1>
    <div>
        <rsweb:ReportViewer ID="ReportViewer1" runat="server">
            <LocalReport ReportPath="rpt_Tr.rdlc"></LocalReport>
        </rsweb:ReportViewer>

        <%--<rsweb:ReportViewer ID="ReportViewer1" runat="server" Width="1000" Font-Size="8px" Font-Names="Vardana" WaitMessageFont-Names="Vardana" >--%>
            <%--<LocalReport ReportPath="rpt_Tr.rdlc"></LocalReport>--%>
       <%-- </rsweb:ReportViewer>--%>
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

    </div>
    </form>
</body>
</html>
