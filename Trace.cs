using CG_Rasterizacao.Variables;

namespace CG_Rasterizacao;

public static class Trace
{
    private const float AMBIENT = 0.15f;

    public static Color GetColor(Ray ray, Light light,Sphere[] spheres)
    {
        float hit = float.MaxValue;
        int index = -1;

        for (int i = 0; i < spheres.Length; i++)
        {
            float t0 = float.MaxValue;
            float t1 = float.MaxValue;

            if (spheres[i].Intersection(ray, ref t0, ref t1))
            {
                if (t0 < hit)
                {
                    hit = t0;
                    index = i;
                }
            }
        }
        if (index == -1) return Background.GetColor((int)ray.position.x, (int)ray.position.y);

        Vector3 hitPoint = ray.position + (ray.direction * hit);

        float pointDistance = Vector3.Distance(hitPoint, light.position);
        float distanceSquared = (pointDistance * pointDistance) + 0.0001f;

        Vector3 normal = hitPoint - spheres[index].Center;
        normal = Vector3.Normalize(normal);
        Vector3 lightDirection = light.position - hitPoint;
        lightDirection = Vector3.Normalize(lightDirection);

        float dot = Vector3.Dot(normal, lightDirection);
        float intensity = MathF.Max(dot, 0.0f);

        Color sphereColor = spheres[index].Color;
        float lightIntensity = light.intensity / distanceSquared;

        int r = (int)((sphereColor.R * intensity * lightIntensity) + (sphereColor.R * AMBIENT));
        int g = (int)((sphereColor.G * intensity * lightIntensity) + (sphereColor.G * AMBIENT));
        int b = (int)((sphereColor.B * intensity * lightIntensity) + (sphereColor.B * AMBIENT));

        r = r > Constants.MaxColor ? Constants.MaxColor : r;
        g = g > Constants.MaxColor ? Constants.MaxColor : g;
        b = b > Constants.MaxColor ? Constants.MaxColor : b;

        return new Color(r, g, b);
    }
}
