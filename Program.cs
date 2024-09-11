using SplashKitSDK;

namespace SplashKitDemo;

public class Program
{
    public static void Main()
    {
        Test_3_3P_DrawingClass();
    }

    static void Test_2_3P_BasicShape()
    {
        Shape myShape = new();
        Window window = new("Win", 800, 600);
        do
        {
            SplashKit.ProcessEvents();
            SplashKit.ClearScreen();

            if (SplashKit.MouseClicked(MouseButton.LeftButton))
            {
                myShape.X = SplashKit.MouseX();
                myShape.Y = SplashKit.MouseY();
            }

            if (myShape.IsAt(SplashKit.MousePosition()) && SplashKit.KeyTyped(KeyCode.SpaceKey))
            {
                myShape.Color = SplashKit.RandomColor();
            }

            myShape.Draw();

            SplashKit.RefreshScreen();
        } while (!window.CloseRequested);
    }

    static void Test_3_3P_DrawingClass()
    {
        Drawing myDrawing = new();
        Window window = new("Win", 800, 600);

        do
        {
            SplashKit.ProcessEvents();
            SplashKit.ClearScreen();

            if (SplashKit.MouseClicked(MouseButton.LeftButton))
            {
                Shape shape = new()
                {
                    X = SplashKit.MouseX(),
                    Y = SplashKit.MouseY()
                };
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

            SplashKit.RefreshScreen();
        } while (!window.CloseRequested);
    }
}
