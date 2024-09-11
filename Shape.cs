using SplashKitSDK;

namespace SplashKitDemo;

internal class Shape
{
    private Color _color;
    private float _x;
    private float _y;
    private int _width;
    private int _height;
    private bool _selected;

    public Color Color
    {
        get { return _color; }
        set { _color = value; }
    }
    public float X
    {
        get { return _x; }
        set { _x = value; }
    }
    public float Y
    {
        get { return _y; }
        set { _y = value; }
    }
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
    public bool Selected
    {
        get { return _selected; }
        set { _selected = value; }
    }


    public Shape()
    {
        _color = Color.Green;
        _x = 0;
        _y = 0;
        _width = 100;
        _height = 100;
    }

    public void Draw()
    {
        SplashKit.FillRectangle(_color, _x, _y, _width, _height);
        if (_selected)
        {
            DrawOutline();
        }
    }

    public void DrawOutline()
    {
        int idLastDigit = 3;
        int offset = 5 + idLastDigit;
        SplashKit.DrawRectangle(Color.Black, X - offset, Y - offset, _width + 2*offset, _height + 2*offset);
    }

    public bool IsAt(Point2D pt)
    {
        return _x <= pt.X && pt.X <= _x + _width && _y <= pt.Y && pt.Y <= _y + _height;
    }
}
