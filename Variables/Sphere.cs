using CG_Rasterizacao.Variables;

namespace CG_Rasterizacao.Variables;

public class Sphere
{
    public Vector3 Center { get; }
    public float Radius { get; }
    public Color Color { get; }

    public Sphere(Vector3 center, float radius, Color color)
    {
        Center = center;
        Radius = radius;
        Color = color;
    }

    public bool Intersection(Ray ray, ref float t0, ref float t1)
    {
        Vector3 dir = Center - ray.position;
        float tca = Vector3.Dot(dir, ray.direction);
        if (tca < 0) return false;

        float dir2 = Vector3.Dot(dir, dir) - (tca * tca);
        if (dir2 > Radius * Radius) return false;

        float thc = MathF.Sqrt((Radius * Radius) - dir2);
        t0 = tca - thc;
        t1 = tca + thc;

        return true;
    }

}
