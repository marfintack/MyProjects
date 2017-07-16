<%@ Page Title="" Language="C#" MasterPageFile="~/RegistrationLogin.Master" AutoEventWireup="true" CodeBehind="Traveller.aspx.cs" Inherits="TraveloSystem.Traveller" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="aspp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="js\jquery.js"></script>
  <%--  <style>
        body {
            background: url(http://mymaplist.com/img/parallax/back.png);
            background-color: #444;
            background: url(http://mymaplist.com/img/parallax/pinlayer2.png),url(http://mymaplist.com/img/parallax/pinlayer1.png),url(http://mymaplist.com/img/parallax/back.png);
        }

        .vertical-offset-100 {
            padding-top: 100px;
        }
    </style>--%>
    <script>
        function doclick() {
            alert("Registered Sucessfully !!");
            $('#id01').show();
            return false;
        }
         </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="google-image">
        <div id="directions-panel"></div>
        <div id="map-canvas"></div>
    </div>
<%--    <script src="http://mymaplist.com/js/vendor/TweenLite.min.js"></script>--%>
    <!-- This is a very simple parallax effect achieved by simple CSS 3 multiple backgrounds, made by http://twitter.com/msurguy -->
    <form runat="server">
        <div id="id01" class="w3-modal">
            <div class="w3-modal-content">
                <header class="w3-container w3-teal">
                    <span onclick="document.getElementById('id01').style.display='none'"
                        class="w3-closebtn">&times;</span>
                    <h2>Modal Header</h2>
                </header>
                <div class="w3-container">
                    <p>Some text..</p>
                    <p>Some text..</p>
                    <button id="close" onclick="doLogin()">OK</button>
                </div>
                <footer class="w3-container w3-teal">
                    <p>Modal Footer</p>
                </footer>
            </div>
        </div>
        <div class="container" style="margin: 0px; padding: 0px;">
            <%--            <div id="googleMap" style="width:1360px; height: 830px;margin:0px;  "></div>--%>
            <div class="row vertical-offset-100">
                <div class="col-md-5 col-md-offset-5" style="position: absolute; top: 100px; left: 15px; z-index: 99;">
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <h3 class="panel-title" style="font-size: 20px; font-weight: bold">Sign up</h3>
                        </div>
                        <div class="panel-body">
                            <fieldset>
                                <div class="form-group">
                                    <label style="font-size: 16px">Reg No</label>
                                    <input type="text" class="form-control" runat="server" id="regno" name="name" placeholder="Reg No">
                                    <asp:RequiredFieldValidator Font-Size="Medium" Font-Bold="true" ForeColor="Red" ID="RequiredFieldValidator5" ControlToValidate="regno" runat="server" ErrorMessage="Reg no is require"></asp:RequiredFieldValidator>
                                </div>
                                <div class="form-group">
                                    <label style="font-size: 16px">Name</label>
                                    <input type="text" class="form-control" runat="server" id="namefield" name="name" placeholder="Name">
                                    <asp:RequiredFieldValidator Font-Size="Medium" Font-Bold="true" ForeColor="Red" ID="RequiredFieldValidator1" ControlToValidate="namefield" runat="server" ErrorMessage="Name is require"></asp:RequiredFieldValidator>
                                </div>
                                <div class="form-group">
                                    <label style="font-size: 16px">Password</label>
                                    <input type="password" class="form-control" runat="server" id="passwordField" name="password" placeholder="Password">
                                    <asp:RequiredFieldValidator Font-Size="Medium" Font-Bold="true" ForeColor="Red" ID="RequiredFieldValidator2" ControlToValidate="passwordField" runat="server" ErrorMessage="Password is require"></asp:RequiredFieldValidator>
                                </div>
                                <div class="form-group">
                                    <label style="font-size: 16px">Contact No</label>
                                    <input type="number" class="form-control" runat="server" id="setfield" name="Contact" placeholder="Contact No">
                                    <asp:RequiredFieldValidator Font-Size="Medium" Font-Bold="true" ForeColor="Red" ID="RequiredFieldValidator3" ControlToValidate="setfield" runat="server" ErrorMessage="Contact No is require"></asp:RequiredFieldValidator>
                                    <%--<asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="setfield" Font-Size="Medium" Font-Bold="true" ForeColor="Red" ValidationExpression="[0-9]{3}-[0-9]{4}" runat="server" ErrorMessage="Phone No is Not Correct"></asp:RegularExpressionValidator>--%>
                                </div>
                                <div class="form-group">
                                    <label style="font-size: 16px">Source Location</label>
                                    <%--<input type="text" id="txtautocomplete" class="form-control" name="Source" placeholder="Source Stop">--%>
                                    <asp:ScriptManager ID="ScriptManager1" runat="server">
                                    </asp:ScriptManager>
                                    <asp:TextBox ID="TextBox1" runat="server"  class="form-control"></asp:TextBox>
                                    <aspp:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server"
                                        ServiceMethod="AutoCompleteAjaxRequest"
                                        ServicePath="TraveloSystem.asmx"
                                        MinimumPrefixLength="1"
                                        CompletionInterval="100"
                                        EnableCaching="false"
                                        CompletionSetCount="100"
                                        TargetControlID="TextBox1"
                                        FirstRowSelected="false">
                                    </aspp:AutoCompleteExtender>
                                </div>
                                <div class="form-group">
                                    <label style="font-size: 16px">Destination</label>
                                    <input type="text" class="form-control" runat="server" name="Destination" placeholder="C.U.S.T University" disabled>
                                </div>
                                <input type="hidden" runat="server" name="adress" id="hidden1" />
                                <input type="hidden" runat="server" name="latt" id="hidden2" />
                                <input type="hidden" runat="server" name="lng" id="hidden3" />
                                <div class="form-button">

                                    <asp:Button runat="server" Text="Register Now" type="submit" class="btn form-btn btn-lg btn-block" OnClick="Unnamed1_Click"></asp:Button>
                                </div>
                            </fieldset>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
    <script src="https://maps.googleapis.com/maps/api/js?key=AIzaSyC3OOEzWt9h4QqB9hmR6Ru8T1qNaffofoE&libraries=places&callback=initMap"
        async defer></script>
    <script type="text/javascript">
        //callback=intilize google.maps.event.addDomListener(window, 'load', intilize);
        function initMap() {
            var autocomplete = new google.maps.places.Autocomplete(document.getElementById("txtautocomplete"));

            google.maps.event.addListener(autocomplete, 'place_changed', function () {

                var place = autocomplete.getPlace();
                //var location = "Address: " + place.formatted_address + "<br/>";
                //location += "Latitude: " + place.geometry.location.lat() + "<br/>";
                //location += "Longitude: " + place.geometry.location.lng();
                var h1 = document.getElementById('<%= hidden1.ClientID %>');
                var h2 = document.getElementById('<%= hidden2.ClientID %>');
                var h3 = document.getElementById('<%= hidden3.ClientID %>');
                h1.value = place.formatted_address;
                h2.value = place.geometry.location.lat();
                h3.value = place.geometry.location.lng();
                alert(place.placeid);
            });

        };
    </script>
</asp:Content>
