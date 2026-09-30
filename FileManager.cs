using System.IO;
namespace CG_Rasterizacao;

public static class FileManager
{
    // p1 -> preto e branco
    // p2 -> escala de cinza
    // p3 -> cores
    public const string CMODE = "P3";
    public const string FNAME = "image.ppm";

    public static void SaveImage(string data)
    {
        string header = $"{CMODE}\n{Constants.WINDOW_WIDTH} {Constants.WINDOW_HEIGHT}\n{Constants.MaxColor-1}\n";

        File.WriteAllText(FNAME, header + data);
    }
}
