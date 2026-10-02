using Raylib_cs;
namespace LineaPixeles;

internal static class Program
{
    public static void Main()
    {
        const int anchoVentana = 600;
        const int altoVentana = 600;

        Raylib.InitWindow(anchoVentana, altoVentana, "Lineas");
        Raylib.SetTargetFPS(60);

        while (!Raylib.WindowShouldClose())
        {
            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.White);
            
            //Dibujar
            DrawLineDDA(5, 4, 12, 7, Color.Black);

            Raylib.EndDrawing();
        }

        Raylib.CloseWindow();
    }

    static void DrawLineDDA(int x1, int y1, int x2, int y2, Color color)
    {
        int dx = x2 - x1;
        int dy = y2 - y1;
        int steps = Math.Max(Math.Abs(dx), Math.Abs(dy));
        if (steps == 0) { Raylib.DrawPixel(x1, y1, color); return; }

        float x = x1, y = y1;
        float xInc = dx / (float)steps;
        float yInc = dy / (float)steps;
        for (int i = 0; i <= steps; i++) {
            Raylib.DrawPixel((int)MathF.Round(x), (int)MathF.Round(y), color);
            x += xInc; y += yInc;
        }
    }
}