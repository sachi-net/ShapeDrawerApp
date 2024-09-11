using SplashKitSDK;

namespace ShapeDrawer;

internal class MyCircle : Shape
{
    private int _radius;

    public int Radius 
    {
        get { return _radius; }
        set { _radius = value; }
    }

    public MyCircle() : this(Color.Blue, 0, 0, 50 + 30)
    {
        
    }

    public MyCircle(Color color, int x, int y, int radius) : base(color)
    {
        X = x;
        Y = y;
        _radius = radius;
    }

    public override void Draw()
    {
        SplashKit.FillCircle(Color, X, Y, _radius);
        if (Selected)
        {
            DrawOutline();
        }
    }

    public override void DrawOutline()
    {
        int idLastDigit = 3;
        int offset = 5 + idLastDigit;
        SplashKit.DrawCircle(Color.Black, X, Y, _radius + offset);
    }

    public override bool IsAt(Point2D pt)
    {
        return Math.Pow(X - pt.X, 2) + Math.Pow(Y - pt.Y, 2) <= Math.Pow(_radius, 2);
    }
}
