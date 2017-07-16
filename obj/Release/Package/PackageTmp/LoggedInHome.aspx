<%@ Page Title="" Language="C#" MasterPageFile="~/LoginMasterPage.Master" AutoEventWireup="true" CodeBehind="LoggedInHome.aspx.cs" Inherits="TraveloSystem.LoggedInHome" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="js/jquery.js"></script>
    <script type="text/javascript" src="http://maps.googleapis.com/maps/api/js?key=AIzaSyC3OOEzWt9h4QqB9hmR6Ru8T1qNaffofoE"></script>
    <script lang="en" type="text/javascript">

        //  var long = 33.736462;
        //  var lat = 73.083843;
        //  $(document).ready(function(){
        ////  var toolval = document.cookie.split(';');
        //  //var long = toolval[0];
        //  //var lat = toolval[1];
        //      var myCenter = new google.maps.LatLng(long,lat);
        //      function initialize() {
        //          var mapProp = {
        //              center: myCenter,
        //              zoom: 10,
        //              mapTypeId: google.maps.MapTypeId.HYBRID
        //          };

        //          var map = new google.maps.Map(document.getElementById("googleMap"), mapProp);

        //          var marker = new google.maps.Marker({
        //              position: myCenter,
        //          });

        //          marker.setMap(map);
        //      }
        //  google.maps.event.addDomListener(window, 'load', initialize);
        //  });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container" style="margin: 0px; padding: 0px;">
        <div id="googleMap" style="width: 1360px; height: 700px; margin: 0px;"></div>
        <div class="row vertical-offset-100">
            <div class="col-md-5 col-md-offset-4" style="position: absolute; top: 180px; left: 10px; z-index: 99;">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <h3 class="panel-title" style="font-size: 20px; font-weight: bold">Personal Details</h3>
                    </div>
                    <div class="panel-body">
                        <fieldset>
                            <div class="form-group">
                            </div>
                        <table class="table" style="font-size: 20px; font-weight: 200;">
                            <tr>
                                <td>Name</td>
                                <td>
                                    <asp:Label ID="cusField" runat="server"></asp:Label>

                                </td>
                            </tr>
                            <tr>
                                <td>Contact No</td>
                                <td>
                                    <asp:Label ID="contactField" runat="server"></asp:Label></td>
                            </tr>
                            <tr>
                                <td>Source Stop</td>
                                <td>
                                    <asp:Label ID="sourceField" runat="server"></asp:Label></td>
                            </tr>
                        </table>

                        </fieldset>
                    </div>
                </div>
            </div>
        </div>
    </div>

<%--    <div class="container" style="margin: 0px; padding: 0px;">
        <div id="googleMap" style="width: 1360px; height: 700px; margin: 0px;"></div>
        <br />
        <br />
        <br />
        <div class="row">
            <div class="col-lg-4 col-lg-push-4" style="border: 3px solid black; position: absolute; top: 140px; left: 10px; z-index: 99; background-color: cadetblue">
                <div class="form-group">
                    <div id="personaldetails">
                        <div id="id01" class="w3-modal">
                            <div class="w3-modal-content">
                                <header class="w3-container w3-teal">
                                    <h2 style="font-weight: bold">Personal Details</h2>
                                    <br />
                                </header>
                            </div>
                        </div>
                        <table class="table" style="font-size: 20px; font-weight: 200; color: aqua">
                            <tr>
                                <td>Name</td>
                                <td>
                                    <asp:Label ID="cusField" runat="server"></asp:Label>

                                </td>
                            </tr>
                            <tr>
                                <td>Contact No</td>
                                <td>
                                    <asp:Label ID="contactField" runat="server"></asp:Label></td>
                            </tr>
                            <tr>
                                <td>Source Stop</td>
                                <td>
                                    <asp:Label ID="sourceField" runat="server"></asp:Label></td>
                            </tr>
                        </table>

                    </div>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-lg-12">
            </div>

        </div>
        <div id="map_canvas"></div>
    </div>--%>

</asp:Content>
