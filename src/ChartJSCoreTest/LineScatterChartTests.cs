﻿using System.Collections.Generic;
using ChartJSCore.Models;
using NUnit.Framework;

namespace ChartJSCoreTest
{
    [TestFixture]
    public class LineScatterChartTests
    {
        private const string KNOWN_GOOD_CHART = "var lineScatterChartElement = document.getElementById(\"lineScatterChart\");\r\nvar lineScatterChart = new Chart(lineScatterChartElement, {\"type\":\"line\",\"data\":{\"datasets\":[{\"data\":[{\"x\":-10.0,\"y\":0.0},{\"x\":0.0,\"y\":10.0},{\"x\":10.0,\"y\":5.0}],\"type\":\"line\",\"label\":\"Scatter Dataset\"}]},\"options\":{\"scales\":{\"xAxes\":[{\"type\":\"linear\",\"position\":\"bottom\",\"ticks\":{\"beginAtZero\":true}}]}}}\r\n);";

        [Test]
        public void Generate_LineChartScatter_Generates_Valid_Chart()
        {
            string expected = KNOWN_GOOD_CHART;

            string actual = GenerateLineScatterChart().CreateChartCode("lineScatterChart");

            Assert.AreEqual(expected, actual);
        }

        private static Chart GenerateLineScatterChart()
        {
            var chart = new Chart { Type = Enums.ChartType.Line };

            var data = new Data();

            var dataset = new LineScatterDataset
            {
                Label = "Scatter Dataset",
                Data = new List<LineScatterData>()
            };

            var scatterData1 = new LineScatterData();
            var scatterData2 = new LineScatterData();
            var scatterData3 = new LineScatterData();

            scatterData1.x = "-10";
            scatterData1.y = "0";
            dataset.Data.Add(scatterData1);

            scatterData2.x = "0";
            scatterData2.y = "10";
            dataset.Data.Add(scatterData2);

            scatterData3.x = "10";
            scatterData3.y = "5";
            dataset.Data.Add(scatterData3);

            data.Datasets = new List<Dataset> { dataset };

            chart.Data = data;

            var options = new Options
            {
                Scales = new Scales()
            };

            var scales = new Scales
            {
                XAxes = new List<Scale>
                {
                    new CartesianScale
                    {
                        Type = "linear",
                        Position = "bottom",
                        Ticks = new CartesianLinearTick
                        {
                            BeginAtZero = true
                        }
                    }
                }
            };

            options.Scales = scales;

            chart.Options = options;
            return chart;
        }
    }

}
