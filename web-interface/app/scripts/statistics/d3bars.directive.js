app.directive('d3Bars', function () {
    return {
        restrict: 'E',
        scope: {
            data: '=',
            edgemin: '=',
            edgemax: '='
        },
        link: function (scope, element, attrs) {

            scope.$watch('data', function(newVals, oldVals) {
                if (newVals != oldVals) {
                    return scope.render(newVals);
                }
            }, true);

            scope.render = function (data) {
                if (!data) return;

                d3.select(element[0]).select("svg").remove();

                var margin = {top: 20, right: 80, bottom: 30, left: 40},
                    width = 960 - margin.left - margin.right,
                    height = 500 - margin.top - margin.bottom;

                var svg = d3.select(element[0])
                    .append("svg")
                    .attr("width", width + margin.left + margin.right)
                    .attr("height", height + margin.top + margin.bottom)
                    .append("g")
                    .attr("transform", "translate(" + margin.left + "," + margin.top + ")");

                var x,y;

                if (data.length == 3) {
                    x = d3.scale.ordinal()
                        .rangeRoundBands([0, width], 0.1)
                        .domain(data[0].map(function(d) { return d.range; }));

                    y = d3.scale.linear()
                        .range([height, 0])
                        .domain([0, d3.max(data[0], function(d) { return d.frequency; })]);
                } else {
                    x = d3.scale.ordinal()
                        .rangeRoundBands([0, width], 0.1)
                        .domain(data.map(function(d) { return d.range; }));

                    y = d3.scale.linear()
                        .range([height, 0])
                        .domain([0, d3.max(data, function(d) { return d.frequency; })]);
                }

                var xAxis = d3.svg.axis()
                    .scale(x)
                    .orient("bottom");

                var yAxis = d3.svg.axis()
                    .scale(y)
                    .orient("left");
                    //.ticks(10);

                svg.append("g")
                    .attr("class", "x axis")
                    .attr("transform", "translate(0," + height + ")")
                    .call(xAxis);

                svg.append("g")
                    .attr("class", "y axis")
                    .call(yAxis)
                    .append("text")
                    .attr("transform", "rotate(-90)")
                    .attr("y", 6)
                    .attr("dy", ".71em")
                    .style("text-anchor", "end")
                    .text("Frequency");

                if (data.length == 3) {
                    svg.selectAll(".bar")
                        .data(data[0])
                        .enter().append("rect")
                        .attr("class", "bar")
                        .attr("x", function(d) { return x(d.range); })
                        .attr("width", x.rangeBand())
                        .attr("y", function(d) {return y(d.frequency);})
                        .attr("height", function(d) { return height - y(d.frequency); });

                    svg.selectAll(".bar1")
                        .data(data[1])
                        .enter().append("rect")
                        .attr("class", "bar1")
                        .attr("x", function(d) { return x(d.range); })
                        .attr("width", x.rangeBand())
                        .attr("y", function(d, index) {return y(d.frequency);})
                        .attr("height", function(d) { return height - y(d.frequency); });

                    svg.selectAll(".bar2")
                        .data(data[2])
                        .enter().append("rect")
                        .attr("class", "bar2")
                        .attr("x", function(d) { return x(d.range); })
                        .attr("width", x.rangeBand())
                        .attr("y", function(d) { return y(d.frequency); })
                        .attr("height", function(d) { return height - y(d.frequency); });

                    svg.append("rect")
                        .attr("class", "bar")
                        .attr("height", 20)
                        .attr("width", 20)
                        .attr("x", 20)
                        .attr("rx", 10)
                        .attr("ry", 10);

                    svg.append("text")
                        .attr("dx", 50)
                        .attr("dy", 15)
                        .text("Асистенти");

                    svg.append("rect")
                        .attr("class", "bar1")
                        .attr("height", 20)
                        .attr("width", 20)
                        .attr("x", 20)
                        .attr("y", 25)
                        .attr("rx", 10)
                        .attr("ry", 10);

                    svg.append("text")
                        .attr("dx", 50)
                        .attr("dy", 40)
                        .text("Доценти");

                    svg.append("rect")
                        .attr("class", "bar2")
                        .attr("height", 20)
                        .attr("width", 20)
                        .attr("x", 20)
                        .attr("y", 50)
                        .attr("rx", 10)
                        .attr("ry", 10);

                    svg.append("text")
                        .attr("dx", 50)
                        .attr("dy", 65)
                        .text("Професори");
                }
                else {
                    svg.attr("class", "post");
                    svg.selectAll(".bar")
                        .data(data)
                        .enter().append("rect")
                        .attr("class", "bar")
                        .attr("x", function(d) { return x(d.range) + 10.5; })
                        .attr("width", x.rangeBand())
                        .attr("y", function(d) { return y(d.frequency); })
                        .attr("height", function(d) { return height - y(d.frequency); })
                        .on("click", function (d) {
                            d3.select(".selected").attr("class", "bar");
                            d3.select(this).attr("class", "selected");

                            d3.select(".teachers").remove();
                            var textPoint = width -margin.right - 50;



                            var textContainer = svg.append("g")
                                .attr("transform", "translate(" + textPoint + ", 20)")
                                .attr("class", "teachers");
                            var cellWidth = 100;
                            var cellHeight = 25;

                            textContainer.append("rect")
                                .attr("width", cellWidth)
                                .attr("height", cellHeight)
                                .attr("stroke", "black")
                                .attr("stroke-width", 2)
                                .attr("fill", "white")
                                .attr("fill-opacity", 0);

                            textContainer.append("text")
                                .attr("dy", cellHeight/2 + 5)
                                .attr("dx", 5)
                                .text("Викладач");

                            textContainer.append("rect")
                                .attr("x", cellWidth)
                                .attr("width", cellWidth)
                                .attr("height", cellHeight)
                                .attr("stroke", "black")
                                .attr("stroke-width", 2)
                                .attr("fill", "white")
                                .attr("fill-opacity", 0);

                            textContainer.append("text")
                                .attr("dy", cellHeight/2 + 5)
                                .attr("dx", cellWidth + 5)
                                .text("Години");


                            _.forEach(d.teachers, function (teacher, index) {
                                textContainer.append("rect")
                                    .attr("y", (index + 1)*cellHeight)
                                    .attr("width", cellWidth)
                                    .attr("height", cellHeight)
                                    .attr("stroke", "black")
                                    .attr("stroke-width", 2)
                                    .attr("fill", "white")
                                    .attr("fill-opacity", 0);

                                textContainer.append("text")
                                    .attr("dy", (index + 1)*cellHeight + (cellHeight/2 + 5))
                                    .attr("dx", 5)
                                    .text(teacher.id);

                                textContainer.append("rect")
                                    .attr("y", (index + 1)*cellHeight)
                                    .attr("x", cellWidth)
                                    .attr("width", cellWidth)
                                    .attr("height", cellHeight)
                                    .attr("stroke", "black")
                                    .attr("stroke-width", 2)
                                    .attr("fill", "white")
                                    .attr("fill-opacity", 0);

                                textContainer.append("text")
                                    .attr("dy", (index + 1)*cellHeight + (cellHeight/2 + 5))
                                    .attr("dx", cellWidth + 5)
                                    .text(teacher.sumIncluded);

                            });
                        });

                    svg.append("line")
                        .attr("x1", width - 150)
                        .attr("x2",width - 135)
                        .attr("y1", 0)
                        .attr("y1", 0)
                        .attr("stroke", "red")
                        .attr("stroke-width", 2);

                    //700-715 718
                    svg.append("text")
                        .attr("dx", width - 120)
                        .attr("dy", 5)
                        .text("Межі визначені стандартом");


                    svg.append("line")
                        .attr("x1", x(scope.edgemin) + 10)
                        .attr("x2", x(scope.edgemin) + 10)
                        .attr("y1", 0)
                        .attr("y1", height)
                        .attr("stroke", "red")
                        .attr("stroke-width", 2);

                    svg.append("line")
                        .attr("x1", x(scope.edgemax) + 10)
                        .attr("x2", x(scope.edgemax) + 10)
                        .attr("y1", 0)
                        .attr("y1", height)
                        .attr("stroke", "red")
                        .attr("stroke-width", 2);//aa
                }
            };

            scope.render(scope.data);
        }
    };
});