using SplashKitSDK;

namespace ShapeDrawer;

internal abstract class Shape
{
    private Color _color;
    private float _x;
    private float _y;
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
    public bool Selected
    {
        get { return _selected; }
        set { _selected = value; }
    }

    public Shape() : this(Color.Yellow)
    {
        _x = 0;
        _y = 0;
    }

    protected Shape(Color color)
    {
        _color = color;
    }

    public abstract void Draw();

    public abstract void DrawOutline();

    public virtual bool IsAt(Point2D pt)
    {
        return false;
    }

    public virtual void SaveTo(StreamWriter writer)
    {
        writer.WriteColor(Color);
        writer.WriteLine(_x);
        writer.WriteLine(_y);
    }

    public virtual void LoadTo(StreamReader reader)
    {
        _color = reader.ReadColor();
        _x = reader.ReadInteger();
        _y = reader.ReadInteger();
    }
}
