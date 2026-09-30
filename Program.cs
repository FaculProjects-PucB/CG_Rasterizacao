using CG_Rasterizacao.Variables;

namespace CG_Rasterizacao;

public static class Program
{
    public static void Main()
    {
        Sphere[] spheres =
        [
            new(
                center: new(128, 128, 40),
                radius: 25,
                color: new(255, 255, 0)),
            new(
                center: new(50, 50, 50),
                radius: 40,
                color: new(0, 0, 255)),
            new(
                center: new(190, 190, 0),
                radius: 60,
                color: new(255, 0, 128)
            )
        ];
        Ray ray = new(Vector3.Zero, Vector3.Forward);
        Light light = new(new(0, 0, 0), 100000);

        DrawImage(spheres, light, ray);
    }

    private static void DrawImage(Sphere[] spheres, Light light,Ray ray)
    {
        string frame = "";

        for (int y = 0; y < Constants.WINDOW_HEIGHT; y++)
        {
            for (int x = 0; x < Constants.WINDOW_WIDTH; x++)
            {
                ray.SetPosition(x, y, 0);
                Color pixel = Trace.GetColor(ray, light, spheres);
                frame += pixel.R + " " + pixel.G + " " + pixel.B + " ";
            }
            frame += "\n";
        }
        FileManager.SaveImage(frame);
    }
}