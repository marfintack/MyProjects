<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="TraveloSystem.WebForm2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>D3 Test</title>
    <%--<script src="https://d3js.org/d3.v4.min.js"></script>--%>
    <script src="scripts/d3.js"></script>
    <script src="/scripts/jquery-1.10.2.js"></script>
</head>
<body>

    <form id="form1" runat="server">
    </form>
      <script>
          $(function () {
              var data = {
                  nodes: [{
                      name: "A",
                      x: 200,
                      y: 150
                  }, {
                      name: "B",
                      x: 140,
                      y: 300
                  }, {
                      name: "C",
                      x: 300,
                      y: 300
                  }, {
                      name: "D",
                      x: 300,
                      y: 180
                  }],
                  links: [{
                      source: 0,
                      target: 1
                  }, {
                      source: 1,
                      target: 2
                  }, {
                      source: 2,
                      target: 3
                  }, ]
              };

              var c10 = d3.scale.category10();
              var svg = d3.select("body")
                .append("svg")
                .attr("width", 1200)
                .attr("height", 800);

              var drag = d3.behavior.drag()
                .on("drag", function (d, i) {
                    d.x += d3.event.dx
                    d.y += d3.event.dy
                    d3.select(this).attr("cx", d.x).attr("cy", d.y);
                    links.each(function (l, li) {
                        if (l.source == i) {
                            d3.select(this).attr("x1", d.x).attr("y1", d.y);
                        } else if (l.target == i) {
                            d3.select(this).attr("x2", d.x).attr("y2", d.y);
                        }
                    });
                });

              var links = svg.selectAll("link")
                .data(data.links)
                .enter()
                .append("line")
                .attr("class", "link")
                .attr("x1", function (l) {
                    var sourceNode = data.nodes.filter(function (d, i) {
                        return i == l.source
                    })[0];
                    d3.select(this).attr("y1", sourceNode.y);
                    return sourceNode.x
                })
                .attr("x2", function (l) {
                    var targetNode = data.nodes.filter(function (d, i) {
                        return i == l.target
                    })[0];
                    d3.select(this).attr("y2", targetNode.y);
                    return targetNode.x
                })
                .attr("fill", "none")
                .attr("stroke", "white");

              var nodes = svg.selectAll("node")
                .data(data.nodes)
                .enter()
                .append("circle")
                .attr("class", "node")
                .attr("cx", function (d) {
                    return d.x
                })
                .attr("cy", function (d) {
                    return d.y
                })
                .attr("r", 15)
                .attr("fill", function (d, i) {
                    return c10(i);
                })
                .call(drag);
          });
    //        var chartData = [20000, 500000, 700000, 1100000];
    //        var colors = [];
    //        for (var i = 0; i < chartData.length; i++) {
    //            var currentColor = '#' + Math.floor(Math.random() * chartData[i] + 5566656).toString(16);
    //            colors.push(currentColor);
    //        }
    //        var radius = 300;
    //        var colorScale = d3.scale.ordinal().range(colors);

    //        var area = d3.select('body').append('svg')
    //                     .attr('width', 1500)
    //                     .attr('height', 1500);
    //    var pieGroup = area.append('g').attr('transform', 'translate(300, 300)');
    //    var arc = d3.svg.arc()
    //                    .innerRadius(0)
    //                    .outerRadius(radius);
    //    var arc = d3.svg.arc()
    //.innerRadius(200)
    //.outerRadius(radius);
    //    var pie = d3.layout.pie()
    //   .value(function (data) { return data; })
    //    var arcs = pieGroup.selectAll('.arc')
    //           .data(pie(chartData))
    //           .enter()
    //           .append('g')
    //           .attr('class', 'arc');
    //    arcs.append('path')
    //.attr('d', arc)
    //.attr('fill', function (d) { return colorScale(d.data); });

    //    arcs.append('text')
    //        .attr('transform', function (data) { return 'translate(' + arc.centroid(data) + ')'; })
    //        .attr('text-anchor', 'middle')
    //        .attr('font-size', '1em')
    //        .text(function (data) { return data.data; });
    //    });
    </script>
</body>
</html>
