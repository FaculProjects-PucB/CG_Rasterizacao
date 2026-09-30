using CG_Rasterizacao.Variables;

namespace CG_Rasterizacao;

public static class Background
{
    public static Color GetColor(int x, int y)
    {
        const int quadradoXadrez = 16;
        const int tonsXadrez = 6;
        int corCinza = ((x / quadradoXadrez) + (y / quadradoXadrez)) % tonsXadrez;
        corCinza *= Constants.MaxColor / (tonsXadrez-1);

        return new Color(corCinza, corCinza, corCinza);
    }
}
