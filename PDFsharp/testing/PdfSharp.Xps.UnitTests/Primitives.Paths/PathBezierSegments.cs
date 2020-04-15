﻿using System;
using System.Text;
using System.Collections.Generic;
using NUnit.Framework;
using System.Windows;
using System.Windows.Media;
using PdfSharp.Xps.UnitTests.Helpers;

namespace PdfSharp.Xps.UnitTests.Primitives.Paths
{
  /// <summary>
  /// Test Bezier segments.
  /// </summary>
  
  public class PathBezierSegments : TestBase
  {
    public TestContext TestContext { get; set; }

    [SetUp]
    public void TestInitialize()
    {
    }

    [TearDown]
    public void TestCleanup()
    {
    }

    [Test]
    public void TestPathBezierSegments()
    {
      RenderVisual("BezierSegments", CreateBezierSegments);
    }

    Visual CreateBezierSegments()
    {
      DrawingContext dc;
      DrawingVisual dv = PrepareDrawingVisual(out dc);

      Point startPoint = new Point(20, 120);
      Point[] points = { new Point(30, 20), new Point(150, 200), new Point(200, 20) };
      PathGeometry path;
      PathFigure figure;
      Brush brush = Brushes.DarkOrange;
      Pen pen = new Pen(Brushes.DarkBlue, 3);

      BeginBox(dc, 1, BoxOptions.Tile, "stroke");
      path = new PathGeometry();
      path.Figures.Add(figure = new PathFigure());
      figure.StartPoint = startPoint;
      figure.Segments.Add(new PolyBezierSegment(points, true));
      dc.DrawGeometry(null, pen, path);
      EndBox(dc);

      BeginBox(dc, 2, BoxOptions.Tile, "stroke, figure closed");
      path = new PathGeometry();
      path.Figures.Add(figure = new PathFigure());
      figure.StartPoint = startPoint;
      figure.IsClosed = true;
      figure.Segments.Add(new PolyBezierSegment(points, true));
      dc.DrawGeometry(null, pen, path);
      EndBox(dc);

      BeginBox(dc, 3, BoxOptions.Tile, "fill");
      path = new PathGeometry();
      path.Figures.Add(figure = new PathFigure());
      figure.StartPoint = startPoint;
      figure.Segments.Add(new PolyBezierSegment(points, true));
      dc.DrawGeometry(brush, null, path);
      EndBox(dc);

      BeginBox(dc, 4, BoxOptions.Tile, "fill, figure closed");
      path = new PathGeometry();
      path.Figures.Add(figure = new PathFigure());
      figure.StartPoint = startPoint;
      figure.IsClosed = true;
      figure.Segments.Add(new PolyBezierSegment(points, true));
      dc.DrawGeometry(brush, null, path);
      EndBox(dc);

      BeginBox(dc, 5, BoxOptions.Tile, "fill & stroke");
      path = new PathGeometry();
      path.Figures.Add(figure = new PathFigure());
      figure.StartPoint = startPoint;
      figure.Segments.Add(new PolyBezierSegment(points, true));
      dc.DrawGeometry(brush, pen, path);
      EndBox(dc);

      BeginBox(dc, 6, BoxOptions.Tile, "fill & stroke, figure closed");
      path = new PathGeometry();
      path.Figures.Add(figure = new PathFigure());
      figure.StartPoint = startPoint;
      figure.IsClosed = true;
      figure.Segments.Add(new PolyBezierSegment(points, true));
      dc.DrawGeometry(brush, pen, path);
      EndBox(dc);

      //BeginBox(dc, 7);
      //EndBox(dc);

      //BeginBox(dc, 8);
      //EndBox(dc);

      dc.Close();
      return dv;
    }
  }
}