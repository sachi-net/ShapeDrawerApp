using SplashKitSDK;

namespace ShapeDrawer;

internal class MyLine : Shape
{
    private float _endX;
    private float _endY;

    public float EndX { 
        get { return _endX; } 
        set { _endX = value; }
    }

    public float EndY
    {
        get { return _endY; }
        set { _endY = value; }
    }

    public MyLine() : this(Color.Red, 0, 0, 400, 300)
    {
        
    }

    public MyLine(Color color, float startX, float startY, float endX, float endY) : base(color)
    {
        X = startX;
        Y = startY;
        _endX = endX;
        _endY = endY;
    }

    public override void Draw()
    {
        SplashKit.DrawLine(Color, X, Y, _endX, _endY);
        if (Selected)
        {
            DrawOutline();
        }
    }

    public override void DrawOutline()
    {
        SplashKit.DrawCircle(Color.Black, X, Y, 4);
        SplashKit.DrawCircle(Color.Black, _endX, _endY, 4);
    }

    public override bool IsAt(Point2D pt)
    {
        Line line = new()
        {
            StartPoint = new() { X = X, Y = Y },
            EndPoint = new() { X = _endX, Y = _endY }
        };
        return SplashKit.PointOnLine(pt, line);
    }

    public override void SaveTo(StreamWriter writer)
    {
        writer.WriteLine("Line");
        base.SaveTo(writer);
        writer.WriteLine(_endX);
        writer.WriteLine(_endY);
    }

    public override void LoadTo(StreamReader reader)
    {
        base.LoadTo(reader);
        _endX = reader.ReadInteger();
        _endY = reader.ReadInteger();
    }
}
