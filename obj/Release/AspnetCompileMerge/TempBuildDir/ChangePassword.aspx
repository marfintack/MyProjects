<%@ Page Title="" Language="C#" MasterPageFile="~/LoginMasterPage.Master" AutoEventWireup="true" CodeBehind="ChangePassword.aspx.cs" Inherits="TraveloSystem.ChangePassword" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <%-- <form runat="server">--%>
    <div class="container">
        <br /><br /><br /><br /><br /><br />
    <div class="row vertical-offset-100">
    	<div class="col-md-6 col-md-offset-3">
    		<div class="panel panel-default">
			  	<div class="panel-heading">
			    	<h3 class="panel-title" style="font-size:20px;font-weight:bold">Change Password</h3>
			 	</div>
			  	<div class="panel-body">
                    <fieldset>
                         <div class="form-group">
                          <label style="font-size:16px">Old Password</label>
                         <input type="password" class="form-control" runat="server" id="opass" name="oldpassname"/>
                              <asp:RequiredFieldValidator  Font-Size="Medium" Font-Bold="true" ForeColor="Red" SetFocusOnError="true" ID="RequiredFieldValidator1" ControlToValidate="opass" runat="server" ErrorMessage="Old Password is Require"></asp:RequiredFieldValidator>
                         </div>
                          <div class="form-group">
                          <label style="font-size:16px">New Password</label>
                         <input type="password" class="form-control" runat="server" id="npass" name="newpassname"/>
                              <asp:RequiredFieldValidator Font-Size="Medium" Font-Bold="true" ForeColor="Red" SetFocusOnError="true" ID="RequiredFieldValidator2" ControlToValidate="npass" runat="server" ErrorMessage="New Password is Require"></asp:RequiredFieldValidator>
                                </div>
                          <div class="form-group">
                           <label style="font-size:16px">Re-Enter Password</label> 
                         <input type="password" class="form-control" runat="server" id="repass" name="retypepassname"/>
                              <asp:RequiredFieldValidator Font-Size="Medium" Font-Bold="true" ForeColor="Red" SetFocusOnError="true" ID="RequiredFieldValidator3" ControlToValidate="repass" runat="server" ErrorMessage="New Password is Require"></asp:RequiredFieldValidator>
                         </div>
                         <asp:CompareValidator  Font-Size="Medium" Font-Bold="true" ForeColor="Red" ID="CompareValidator1" ControlToCompare="npass" ControlToValidate="repass" runat="server" ErrorMessage="Password Not Match"></asp:CompareValidator>
                               <asp:Button ID="Button1" class="btn form-btn btn-lg btn-block" runat="server" Text="Change Password" OnClick="Button1_Click" />
                        </fieldset>
                        </div>
                </div>
            </div>
        </div>
        </div>
<%--        </form>--%>
</asp:Content>
