<%@ Page Title="" Language="C#" MasterPageFile="~/RegistrationLogin.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="TraveloSystem.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
 <style>
        /*body{
    background: url(http://mymaplist.com/img/parallax/back.png);
	background-color: #444;
    background: url(http://mymaplist.com/img/parallax/pinlayer2.png),url(http://mymaplist.com/img/parallax/pinlayer1.png),url(http://mymaplist.com/img/parallax/back.png);    
}

.vertical-offset-100{
    padding-top:100px;
}*/
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <%--    <script src="http://mymaplist.com/js/vendor/TweenLite.min.js"></script>--%>
<!-- This is a very simple parallax effect achieved by simple CSS 3 multiple backgrounds, made by http://twitter.com/msurguy -->
    <form runat="server">
<div class="container" style="margin:0px;padding:0px;">
            <div id="googleMap" style="width:1360px; height: 700px;margin:0px;  "></div>
    <div class="row vertical-offset-100">
    	<div class="col-md-5 col-md-offset-4" style=" position: absolute; top: 180px; left: 10px; z-index: 99;">
    		<div class="panel panel-default">
			  	<div class="panel-heading">
			    	<h3 class="panel-title" style="font-size:20px;font-weight:bold"> Traveler Log in</h3>
			 	</div>
			  	<div class="panel-body">
                    <fieldset>
			    	  	<div class="form-group">
                              <label style="font-size:16px">Registration number</label><br />
			    		  <input type="text" class="form-control" runat="server" Id="nameField" name="name" placeholder="Reg no">
                             <asp:RequiredFieldValidator ID="RequiredFieldValidator1" Font-Size="Medium" Font-Bold="true" ForeColor="Red" ControlToValidate="nameField" SetFocusOnError="true" runat="server" ErrorMessage="Reg no is require"></asp:RequiredFieldValidator>
                          </div>
			    		<div class="form-group" style="margin-top:0px">
                               <label style="font-size:16px">Password</label><br />
			    		 <input type="password" class="form-control" runat="server" Id="passwordField"  name="password" placeholder="Password">
                   <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"  Font-size="Medium" Font-Bold="true" ForeColor="Red" SetFocusOnError="true"  ErrorMessage="Password is Require" ControlToValidate="passwordField" ></asp:RequiredFieldValidator>
                   </div>
			    	    <asp:Button ID="Button1" class="btn form-btn btn-lg btn-block" runat="server" Text="Login" OnClick="LoginBtn" />
                    </fieldset>
			    </div>
			</div>
		</div>
	</div>
</div>
        </form>
</asp:Content>
