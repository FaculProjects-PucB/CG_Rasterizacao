namespace CG_Rasterizacao.Variables;

public class Ray(Vector3 position, Vector3 direction)
{
    public Vector3 position = position;
    public Vector3 direction = direction;

    public void SetPosition(float x, float y, float z)
    {
        position.x = x;
        position.y = y;
        position.z = z;
    }
}
