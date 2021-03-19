<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs"  MasterPageFile="~/Site.Master" Inherits="ParseFileApp.Home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <asp:LinkButton ID="lnkParseCSV" Text="Parse CSV" runat="server" OnClick="lnkParseCSV_Click"> Parse CSV</asp:LinkButton> <br />

        <asp:LinkButton ID="lnkParseXML" Text="Parse XML" runat="server" OnClick="lnkParseXML_Click"> Parse XML</asp:LinkButton><br />
        <asp:LinkButton ID="lnkParseXLS" Text="Parse XLS" runat="server"> Parse XLS</asp:LinkButton><br />
    </div>
    <div>
        <span id="spnJsonResult" runat="server">

        </span>
    </div>
</asp:Content>
