<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReportWebForm.aspx.cs" Inherits="InventoryProject.ReportWebForm" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="position: relative; text-align: center; color: #CCFFCC; border-style: groove; border-width: 3px">
            <rsweb:ReportViewer ID="ReportViewer1" runat="server" Width="100%" Height="600" Font-Names="Vardana" Font-Size="8pt" WaitMessageFont-Names="Vardana" WaitMessageFont-Size="8pt" style="color: #009900">
                <LocalReport ReportPath="Report1.rdlc" />
            </rsweb:ReportViewer>
            <asp:ObjectDataSource runat="server" TypeName="dsMasterDetailsOrder1TableAdapters." ID="ObjectDataSource1" ViewStateMode="Enabled"></asp:ObjectDataSource>
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        </div>
    </form>
</body>
</html>
