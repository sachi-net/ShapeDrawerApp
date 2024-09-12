using SplashKitSDK;

namespace ShapeDrawer;

public class Program
{
    private enum ShapeKind
    {
        Rectangle,
        Circle,
        Line
    }

    public static void Main()
    {
        Drawing myDrawing = new();
        Window window = new("Win", 800, 600);
        ShapeKind kindToAdd = ShapeKind.Rectangle;
        int numOfLines = 3;
        string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "TestDrawing.txt");

        do
        {
            SplashKit.ProcessEvents();
            SplashKit.ClearScreen();

            if (SplashKit.KeyTyped(KeyCode.OKey))
            {
                try
                {
                    myDrawing.Load(path);
                }
                catch (Exception exp)
                {
                    Console.WriteLine("Error loading file: {0}", exp.Message);
                }
            }

            if (SplashKit.KeyTyped(KeyCode.RKey))
            {
                kindToAdd = ShapeKind.Rectangle;
            }

            if (SplashKit.KeyTyped(KeyCode.CKey))
            {
                kindToAdd = ShapeKind.Circle;
            }

            if (SplashKit.KeyTyped(KeyCode.LKey))
            {
                kindToAdd = ShapeKind.Line;
            }

            if (numOfLines is 0)
            {
                numOfLines = 5;
            }

            if (SplashKit.MouseClicked(MouseButton.LeftButton))
            {
                Shape shape;

                switch (kindToAdd)
                {
                    case ShapeKind.Circle:
                        shape = new MyCircle();
                        break;
                    case ShapeKind.Line:
                        shape = new MyLine();
                        numOfLines--;
                        break;
                    default:
                        shape = new MyRectangle();
                        break;
                }

                shape.X = SplashKit.MouseX();
                shape.Y = SplashKit.MouseY();

                myDrawing.AddShape(shape);
            }

            if (SplashKit.KeyTyped(KeyCode.SpaceKey))
            {
                myDrawing.Background = SplashKit.RandomColor();
            }

            if (SplashKit.MouseClicked(MouseButton.RightButton))
            {
                myDrawing.SelectShapeAt(SplashKit.MousePosition());
            }

            if (SplashKit.KeyTyped(KeyCode.DeleteKey) || SplashKit.KeyTyped(KeyCode.BackspaceKey))
            {
                foreach (Shape shape in myDrawing.SelectedShapes)
                {
                    myDrawing.RemoveShape(shape);
                }
            }

            myDrawing.Draw();

            if (SplashKit.KeyTyped(KeyCode.SKey))
            {
                myDrawing.Save(path);
            }

            SplashKit.RefreshScreen();
        } while (!window.CloseRequested);
    }
}
