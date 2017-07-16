<%@ Page Title="" Language="C#" MasterPageFile="~/AdminLoginMaster.Master" AutoEventWireup="true" CodeBehind="RouteCreation.aspx.cs" Inherits="TraveloSystem.RouteCreation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <br />
    <br />
    <div class="container" style="margin: 0px; padding: 0px;">
        <div class="row vertical-offset-100">
            <div class="col-lg-8" style="position: absolute; top: 100px; left: 150px; z-index: 20;">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <h3 class="panel-title" style="font-size: 20px; font-weight: bold">Initial Routes and Capacities</h3>
                        <asp:GridView ID="GridView1" CssClass="table table-striped" runat="server"></asp:GridView>
                        <asp:GridView ID="GridView2" class="table table-striped" runat="server"></asp:GridView>
                        <asp:GridView ID="GridView3" class="table table-striped" runat="server"></asp:GridView>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
