<%@ Page Title="" Language="C#" MasterPageFile="~/LoginMasterPage.Master" AutoEventWireup="true" CodeBehind="ChangeContact.aspx.cs" Inherits="TraveloSystem.ChangeContact" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <%--   <form runat="server">--%>
        <div class="container">
      <br /><br /><br /><br /><br /><br />
    <div class="row vertical-offset-100">
    	<div class="col-md-6 col-md-offset-3">
    		<div class="panel panel-default">
			  	<div class="panel-heading">
			    	<h3 class="panel-title" style="font-size:20px;font-weight:bold">Change Contact</h3>
			 	</div>
			  	<div class="panel-body">
                    <fieldset>
                          <div class="form-group">
                          <label>Enter Contact Number</label>
                         <input type="text" class="form-control" runat="server" id="confield" name="oldpassname"/>
                              <asp:RequiredFieldValidator Font-Size="Medium" Font-Bold="true" ForeColor="Red" ID="RequiredFieldValidator4" ControlToValidate="confield" runat="server" ErrorMessage="Contact Number is Require" SetFocusOnError="true"></asp:RequiredFieldValidator>
                          </div>
                               <asp:Button ID="Button2" class="btn form-btn btn-lg btn-block" runat="server" Text="Submit" OnClick="Button2_Click"/>
                        </fieldset>
            </div>
                 </div>
        </div>
        </div>
        </div>
      <%--  </form>--%>
</asp:Content>
