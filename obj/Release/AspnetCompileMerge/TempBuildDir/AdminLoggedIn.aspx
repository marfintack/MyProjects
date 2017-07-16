<%@ Page Title="" Language="C#" MasterPageFile="~/AdminLoginMaster.Master" AutoEventWireup="true" CodeBehind="AdminLoggedIn.aspx.cs" Inherits="TraveloSystem.AdminLoggedIn" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <br />
    <br />
    <br />
    <div class="row">
        <div class="col-lg-6 col-lg-push-3">
            <ul style="margin: 0; padding: 0; list-style-type: none; text-align: center;">
                <li style="display: inline">
                    <input type="button" id="busreg" class="btn btn-primary" value="changePassword" /></li>
                <li style="display: inline">
<%--                   <input type="button"  Id="routecreation" class="btn btn-primary" value="Create Route" /></li>--%>
                   <a href="WebForm1.aspx">Create Route</a>
                     </li>
                <li style="display: inline">
                   <%-- <asp:Button ID="showroute" class="btn btn-primary" runat="server" Text="Show Routes" /></li>--%>
                     <a href="TuberIndex.aspx">TuberIndex</a>
                     </li>
                <li style="display: inline">
                    <asp:Button ID="delroute" class="btn btn-primary" runat="server" Text="Delete Routes" /></li>
            </ul>
        </div>
    </div>

    <div class="row">
        <div class="col-lg-4 col-lg-push-4">
            <div id="changepassword">
                <div class="form-group">
                    <label>Old Password</label>
                    <input type="password" class="form-control" runat="server" id="opass" name="oldpassname" />
                    <asp:RequiredFieldValidator SetFocusOnError="true" ID="RequiredFieldValidator1" ControlToValidate="opass" runat="server" ErrorMessage="Old Password is Require"></asp:RequiredFieldValidator>
                </div>
                <div class="form-group">
                    <label>New Password</label>
                    <input type="password" class="form-control" runat="server" id="npass" name="newpassname" />
                    <asp:RequiredFieldValidator SetFocusOnError="true" ID="RequiredFieldValidator2" ControlToValidate="npass" runat="server" ErrorMessage="New Password is Require"></asp:RequiredFieldValidator>
                </div>
                <div class="form-group">
                    <label>Re-Enter Password</label>
                    <input type="password" class="form-control" runat="server" id="repass" name="retypepassname" />
                    <asp:RequiredFieldValidator SetFocusOnError="true" ID="RequiredFieldValidator3" ControlToValidate="repass" runat="server" ErrorMessage="New Password is Require"></asp:RequiredFieldValidator>
                </div>
                <asp:CompareValidator ID="CompareValidator1" ControlToCompare="npass" ControlToValidate="repass" runat="server" ErrorMessage="Password Not Match"></asp:CompareValidator>
                <asp:Button ID="Button1" class="btn form-btn btn-lg btn-block" runat="server" Text="Change Password" />
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-lg-4 col-lg-push-4">
            <div id="changecontact">
                <div class="form-group">
                    <label>Enter Contact Number</label>
                    <input type="text" class="form-control" runat="server" id="confield" name="oldpassname" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ControlToValidate="confield" runat="server" ErrorMessage="Contact Number is Require" SetFocusOnError="true"></asp:RequiredFieldValidator>
                </div>
                <asp:Button ID="Button2" class="btn form-btn btn-lg btn-block" runat="server" Text="Submit" />
            </div>

        </div>
    </div>
    <div class="row">
        <div class="col-lg-12">
            <div id="createroute">
                <h2>Routes and Capacity</h2>
                <asp:GridView ID="GridView1" runat="server"></asp:GridView>
            </div>
             <div>
                <asp:GridView ID="GridView2" runat="server"></asp:GridView>
            </div>
        </div>
    </div>
    <script src="/scripts/jquery-1.6.4.min.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $('#changepassword').hide();
            $('#changecontact').hide();
            $('#createroute').hide();
            $('#busreg').click(function () {
                $('#changepassword').show();
                $('#changecontact').show();
            });
            $('#routecreation').click(function () {
                $('#personaldetails').hide();
                $('#changecontact').hide();
                $('#createroute').show();
                $.ajax({
                    url: "AdminLoggedIn.aspx/createandShowRoute",
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    data:'',
                    success: function (msg) {
                        alert("Success");
                        //   $("#divResult").html("success");
                    },
                    error: function (e) {
                        alert("Failed");
                        //  $("#divResult").html("Something Wrong.");
                    }
                });
            });
            $('#logout').click(function () {

            });
        });
    </script>
</asp:Content>
