using SplashKitSDK;

namespace SplashKitDemo;

internal class Drawing
{
    private List<Shape> _shapes;
    private Color _background;

    public Color Background
    {
        get { return _background; }
        set { _background = value; }
    }
    public List<Shape> SelectedShapes { get => _shapes.Where(s => s.Selected).ToList(); }
    public int ShapeCount { get { return _shapes.Count; } }

    public Drawing() : this(Color.White)
    {

    }

    public Drawing(Color background)
    {
        _shapes = new List<Shape>();
        _background = background;
    }

    public void AddShape(Shape shape)
    {
        _shapes.Add(shape);
    }

    public void RemoveShape(Shape shape)
    {
        _shapes.Remove(shape);
    }

    public void Draw()
    {
        SplashKit.ClearScreen(_background);
        foreach (Shape shape in _shapes)
        {
            shape.Draw();
        }
    }

    public void SelectShapeAt(Point2D pt)
    {
        foreach (Shape shape in _shapes)
        {
            shape.Selected = shape.IsAt(pt);
        }
    }
}
