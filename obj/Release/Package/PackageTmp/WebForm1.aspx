<%@ Page Title="" Language="C#" MasterPageFile="~/LoginMasterPage.Master" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="TraveloSystem.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <br /><br /><br /><br /><br />
        <div style="margin-left:10px;text-align:center">
            <h2>Routes and Capacity</h2>
            <asp:GridView ID="GridView1" runat="server"></asp:GridView>
        </div>
        <div style="margin-left:10px;text-align:center">
            <div>
                <asp:GridView ID="GridView2" runat="server"></asp:GridView>
            </div>
            <div>
                <asp:GridView ID="GridView3" runat="server"></asp:GridView>
            </div>
            <asp:Table ID="Table1" runat="server"></asp:Table>
        </div>
   </asp:Content>
