<%@ Page Title="" Language="C#" MasterPageFile="~/RegistrationLogin.Master" AutoEventWireup="true" CodeBehind="AdminLogin.aspx.cs" Inherits="TraveloSystem.AdminLogin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
       <script src="http://mymaplist.com/js/vendor/TweenLite.min.js"></script>
<!-- This is a very simple parallax effect achieved by simple CSS 3 multiple backgrounds, made by http://twitter.com/msurguy -->
<form runat="server">
<div class="container" style="margin:0px;padding:0px;">
    <div class="row vertical-offset-100">
    	<div class="col-md-5 col-md-offset-4" style=" position: absolute; top: 180px; left: 10px; z-index: 99;">
    		<div class="panel panel-default">
			  	<div class="panel-heading">
			    	<h3 class="panel-title" style="font-size:20px;font-weight:bold"> Admin Log in</h3>
			 	</div>
			  	<div class="panel-body">
                    <fieldset>
			    	  	<div class="form-group">
                              <label style="font-size:16px">username</label><br />
			    		  <input type="text" class="form-control" runat="server" Id="nameField" name="name" placeholder="Username">
                             <asp:RequiredFieldValidator ID="RequiredFieldValidator1" Font-Size="Medium" Font-Bold="true" ForeColor="Red" ControlToValidate="nameField" SetFocusOnError="true" runat="server" ErrorMessage="Username is require"></asp:RequiredFieldValidator>
                          </div>
			    		<div class="form-group" style="margin-top:0px">
                               <label style="font-size:16px">Password</label><br />
			    		 <input type="password" class="form-control" runat="server" Id="passwordField"  name="password" placeholder="Password">
                   <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"  Font-size="Medium" Font-Bold="true" ForeColor="Red" SetFocusOnError="true"  ErrorMessage="Password is Require" ControlToValidate="passwordField" ></asp:RequiredFieldValidator>
                   </div>
			    	    <asp:Button ID="Button1" class="btn form-btn btn-lg btn-block" runat="server" Text="Login" OnClick="LoginBtn"/>
                    </fieldset>
			    </div>
			</div>
		</div>
	</div>
</div>
</form>
</asp:Content>
