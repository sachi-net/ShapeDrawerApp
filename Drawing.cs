using SplashKitSDK;

namespace ShapeDrawer;

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

    public void Save(string filename)
    {
        StreamWriter writer = new(filename);

        try
        {
            writer.WriteColor(Background);
            writer.WriteLine(_shapes.Count);

            foreach (Shape shape in _shapes)
            {
                shape.SaveTo(writer);
            }
        }
        finally
        {
            writer.Close();
        }
    }

    public void Load(string filename)
    {
        StreamReader reader = new(filename);
        string kind = string.Empty;
        Shape shape = null;

        try
        {
            _background = reader.ReadColor();
            int count = reader.ReadInteger();

            _shapes.Clear();

            for (int i = 0; i < count; i++)
            {
                kind = reader.ReadLine();
                switch (kind)
                {
                    case "Rectangle":
                        shape = new MyRectangle(); break;
                    case "Circle":
                        shape = new MyCircle(); break;
                    case "Line":
                        shape = new MyLine(); break;
                    default:
                        throw new InvalidDataException("Unknown shape kind: " + kind);
                }

                shape.LoadTo(reader);
                AddShape(shape);
            }
        }
        finally
        {
            reader.Close();
        }
    }
}
