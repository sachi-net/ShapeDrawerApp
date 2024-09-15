using SplashKitSDK;

namespace ShapeDrawer;

internal class MyRectangle : Shape
{
    private int _width;
    private int _height;

    public int Width
    {
        get { return _width; }
        set { _width = value; }
    }
    public int Height
    {
        get { return _height; }
        set { _height = value; }
    }

    public MyRectangle() : this(Color.Green, 0, 0, 100 + 30, 100 + 30)
    {
        
    }

    public MyRectangle(Color color, int x, int y, int width, int height) : base(color)
    {
        Width = width;
        Height = height;
        X = x; 
        Y = y;
    }

    public override void Draw()
    {
        SplashKit.FillRectangle(Color, X, Y, _width, _height);
        if (Selected)
        {
            DrawOutline();
        }
    }

    public override void DrawOutline()
    {
        int idLastDigit = 3;
        int offset = 5 + idLastDigit;
        SplashKit.DrawRectangle(Color.Black, X - offset, Y - offset, _width + 2 * offset, _height + 2 * offset);
    }

    public override bool IsAt(Point2D pt)
    {
        return X <= pt.X && pt.X <= X + _width && Y <= pt.Y && pt.Y <= Y + _height;
    }

    public override void SaveTo(StreamWriter writer)
    {
        writer.WriteLine("Rectangle");
        base.SaveTo(writer);
        writer.WriteLine(_width);
        writer.WriteLine(_height);
    }

    public override void LoadTo(StreamReader reader)
    {
        base.LoadTo(reader);
        _width = reader.ReadInteger();
        _height = reader.ReadInteger();
    }
}
