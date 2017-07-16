﻿<%@ Page Title="" Language="C#" MasterPageFile="~/AdminLoginMaster.Master" AutoEventWireup="true" CodeBehind="ShowRoutes.aspx.cs" Inherits="TraveloSystem.ShowRoutes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<link rel="stylesheet" href="styles/codemirror.css">
<link rel="stylesheet" href="styles/codemirror-neo.css">
<link rel="stylesheet" href="styles/cy2neo.css">
<link rel="stylesheet" href="styles/neod3.css">
<link rel="stylesheet" href="styles/datatable.css">
<link rel="stylesheet" href="styles/vendor.css"> <!-- bootstrap-->
<link rel="stylesheet" href="styles/sweet-alert.css">
<link rel="stylesheet" href="styles/gh-fork-ribbon.css">
<title>Cy2NeoD3 - Tiny Neo4j Cypher Workbench</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br /><br /><br />
<script src="scripts/codemirror.js"></script>
<script src="scripts/codemirror-cypher.js"></script>
<script src="scripts/vendor.js"></script>
<script src="scripts/sweet-alert.min.js"></script>
<script src="scripts/neod3.js"></script>
<script src="scripts/neod3-visualization.js"></script>
<script src="scripts/neo4d3.js"></script>
<script src="scripts/cy2neod3.js"></script>
<script src="scripts/jquery.dataTables.min.js"></script>
<script src="scripts/cypher.datatable.js"></script>
<div class="container">
<%--<div class="row">
<div class="col-lg-12">--%>
  <input class="form-control" type="url" value="http://localhost:7474" id="neo4jUrl"style="display:none;"><br/>
  <input class="form-control" type="text" size="8" value="neo4j" id="neo4jUser" style="display:none;"/>
  <input class="form-control" type="password" size="8" placeholder="password" value="neo4travelo" id="neo4jPass" style="display:none;"/><br/>
  <textarea name="cypher" id="cypher" rows="4" cols="120" data-lang="cypher" class="code form-control" hidden>
  MATCH (n)-[r]->(m)
  RETURN n,r,m
  LIMIT 50;
  </textarea>
  <a href="#" title="Execute" id="execute"><i class="fa fa-play-circle-o" style="display:none;"></i></a>
<div role="tabpanel">
  <!-- Nav tabs -->
  <ul class="nav nav-tabs" role="tablist">
    <li role="presentation" class="active"><a href="#graph" aria-controls="home" role="tab" data-toggle="tab">Graph</a></li>
    <!-- <li role="presentation"><a href="#table" aria-controls="table" role="tab" data-toggle="tab">Table</a></li> -->
  </ul>
  <!-- Tab panes -->
  <div class="tab-content">
    <div role="tabpanel" class="tab-pane active" id="graph">
    	<div class="tab-pane active" id="graph">&nbsp;</div>
    </div>
  </div>
</div>
</div>
<%--</div>    
</div>--%>
<%--     <div class="container" style="margin: 0px; padding: 0px; display:none">
            <div class="row vertical-offset-100">
                <div class="col-lg-8" style="position: absolute; top: 100px; left: 150px; z-index: 20;">
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <h3 class="panel-title" style="font-size: 20px; font-weight: bold">Routes and Capacities</h3>
                    <%--         //   <asp:GridView ID="GridView1" CssClass="table table-striped" runat="server"></asp:GridView>
                            //<asp:GridView ID="GridView2" class="table table-striped" runat="server"></asp:GridView>
                     
          </div>
                    </div>
                </div>
            </div>
        </div>--%>
<script type="text/javascript">
    $(document).ready(function() {
		//todo dynamic configuration
	//	alert('Hii');
		var config = {}
	    var connection = function() { return {url:$("#neo4jUrl").val(), user:$("#neo4jUser").val(),pass:$("#neo4jPass").val()}; }		
		new Cy2NeoD3(config,"graph","datatable","cypher","execute", connection , true);
		
	});
</script>
</asp:Content>
