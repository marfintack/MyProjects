<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BusRegistration.aspx.cs" Inherits="TraveloSystem.BusRegistration" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Bus Registration</title>
    <link href="css/bootstrap.css" rel="stylesheet" />
    <link href="css/bootstrap-select.css" rel="stylesheet" />
    <link href="css/style.css" rel="stylesheet" />
    <link href="css/color.css" rel="stylesheet" />
    <link href="css/custom-responsive.css" rel="stylesheet" />
    <link href="css/animate.css" rel="stylesheet" />
    <link href="css/component.css" rel="stylesheet" />
    <link href="css/default.css" rel="stylesheet" />
    <!-- font awesome this template -->
    <link href="fonts/css/font-awesome.css" rel="stylesheet" />
    <link href="fonts/css/font-awesome.min.css" rel="stylesheet" />
    <script src="/Scripts/jquery-1.6.4.min.js"></script>
    <script>

        // var person = prompt("Please enter your name", "Harry Potter");
        var element;
        function createDynamicTextBoxes() {
            document.getElementById("member").style.visibility = "hidden";
            document.getElementById("btnsbt").style.visibility = "hidden";
            element = document.getElementById("member").value;
            var myNode = document.getElementById("textboxescontrol");
            while (myNode.firstChild) {
                myNode.removeChild(myNode.firstChild);
            }
            var container = document.getElementById("textboxescontrol");
            for (var i = 1; i <= (element * 2) ; i++) {
                if (i % 2 == 1) {
                    //     container.style.cssText = "margin-left:30%;margin-top:10%;background: white; border: 1px solid #ffa853; border-radius: 5px;box-shadow: 0 0 5px 3px #ffa853; color: #666;outline: none;height:23px;width: 275px;";
                    container.appendChild(document.createTextNode("Enter Bus No"));
                    var input = document.createElement("input");
                    input.type = "text";
                    input.className = "form-control";
                    input.id = "Bus" + i;
                    container.appendChild(input);
                    container.appendChild(document.createElement("br"));
                }
                else {
                    container.appendChild(document.createTextNode("Enter Bus Capacity"));
                    var input = document.createElement("input");
                    input.type = "text";
                    input.className = "form-control";
                    input.id = "Capacity" + (i - 1);
                    container.appendChild(input);
                    container.appendChild(document.createElement("br"));
                }
            }
            var input = document.createElement("a");
            input.type = "href";
            input.id = "addedbtn";
            input.className = "btn btn-primary";
            var it = document.createTextNode("Submit")
            input.appendChild(it);
            container.appendChild(input);
            input.onclick = thisfunction;
        }

        function thisfunction() {
            var totaldata = [];
            for (var i = 1; i <= element * 2; i = i + 2) {
                var eleval = document.getElementById('Bus' + i).value;
                var capval = document.getElementById('Capacity' + i).value;
                if (eleval == "" || capval == "") {
                    var x = document.getElementById("hvdiv");
                    if (x.style.display === 'none') {
                        x.style.display = 'block';
                    }
                    else {
                        //style="display:none"
                        x.style.display = 'none';
                    }
                    return;
                }
                else {
                    totaldata.push(eleval);
                    totaldata.push(capval);
                }
            }
            $.ajax({
                url: 'TraveloSystem.asmx/addBusDetails',
                type: "POST",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                data: "{totalno:'" + element + "',arrayele:'" + totaldata + "'}",
                success: function (msg) {
                    alert("Details Inserted SuccessFully !!");
                    //   $("#divResult").html("success");
                },
                error: function (e) {
                    alert("Details Insertion Failed !!");
                    //  $("#divResult").html("Something Wrong.");
                }
            });
        }
    </script>
</head>
<body>
    <div class="map-wapper-opacity">
        <div class="container">
            <div class="row">
                <div class="row">
                    <div class="col-sm-3">
                        <div class="logo-wraper">
                            <div class="logo">
                                <a href="LoggedInHome.aspx">
                                    <img src="images/logo1.png" class=" img-responsive " alt="" />
                                </a>
                            </div>
                        </div>
                    </div>
                    <div class="col-sm-3">
                        <div id="navbar">
                            <ul>
                                <li><a href="BusRegistration.aspx">Add Buses</a></li>
                                <li><a href="RouteCreation.aspx">Create Route</a></li>
                                <li><a href="TuberIndex.aspx">Track Bus</a></li>
                            </ul>
                        </div>
                    </div>
                    <div class="dropdown">
                        <label class="btn btn-default dropdown-toggle fa fa-home dropbtn" id="dropdownMenu1" data-toggle="dropdown" aria-haspopup="true" aria-expanded="true">
                            Manage Account
    <span class="caret"></span>
                        </label>
                        <ul class="dropdown-menu dropdown-content" aria-labelledby="dropdownMenu1">
                            <li><a href="ShowRoutes.aspx" id="showroute">Show Routes</a></li>
                            <li role="separator" class="divider"></li>
                            <li><a href="ChangePassword.aspx" id="pass">Change Password</a></li>
                            <li role="separator" class="divider"></li>
                            <li><a onserverclick="Unnamed_ServerClick" runat="server">Logout</a></li>
                        </ul>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <br />
    <br />
    <br />
    <br />
    <form id="form1" runat="server">
        <div class="alert alert-danger" id="hvdiv" style="display: none;">
            <strong>Error!</strong> Please Fill All the Text Fields
        </div>
        <div class="container" style="margin: 0px; padding: 0px;">
            <div class="row vertical-offset-100">
                <div class="col-md-5 col-md-offset-4" style="position: absolute; top: 100px; left: 10px; z-index: 99;">
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <h3 class="panel-title" style="font-size: 20px; font-weight: bold">BUS Registration</h3>
                        </div>
                        <div class="panel-body">
                            <div class="form-group" id="textboxescontrol">
                                <label style="font-size: 16px">Enter Number of Buses</label>
                                <input type="text" id="member" name="member" class="form-control" runat="server" /><br />
                                <a href="#" class="btn btn-default" role="button" id="btnsbt" onclick="createDynamicTextBoxes()">Submit</a>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
    <link href="css/NavBarStyle.css" rel="stylesheet" />
</body>
</html>
