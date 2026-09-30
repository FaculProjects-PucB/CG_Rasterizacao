namespace CG_Rasterizacao.Variables;

public class Vector3(float x, float y, float z)
{
    public float x = x, y = y, z = z;

    public static float Dot(Vector3 v, Vector3 w)
    {
        return (v.x * w.x) + (v.y * w.y) + (v.z * w.z);
    }

    public static float Magnitude(Vector3 v)
    {
        return MathF.Sqrt((v.x * v.x) + (v.y * v.y) + (v.z * v.z));
    }

    public static Vector3 Normalize(Vector3 v)
    {
        return v / Magnitude(v);
    }

    public static float Distance(Vector3 v, Vector3 w)
    {
        Vector3 diff = v - w;
        return Magnitude(diff);
    }

    // Metodos Uteis

    public static Vector3 operator+(Vector3 v, Vector3 w)
    {
        return new Vector3(
        v.x + w.x,
        v.y + w.y,
        v.z + w.z);
    }

    public static Vector3 operator-(Vector3 v, Vector3 w)
    {
        return new Vector3(
        v.x - w.x,
        v.y - w.y,
        v.z - w.z);
    }

    public static Vector3 operator*(Vector3 v, float f)
    {
        return new Vector3(
        v.x * f,
        v.y * f,
        v.z * f);
    }

    public static Vector3 operator/(Vector3 v, float f)
    {
        return new Vector3(
        v.x / f,
        v.y / f,
        v.z / f);
    }

    public static Vector3 Zero { get { return new Vector3(0, 0, 0); } }
    public static Vector3 One { get { return new Vector3(1, 1, 1); } }
    public static Vector3 Forward { get { return new Vector3(0, 0, 1); } }

    public override string ToString()
    {
        return $"({x}, {y}, {z})";
    }
}
