using UnityEngine;
public static class Helper
{
    public static Rect RectFromCenter(Vector2 center, Vector2 size)
    {
        return new Rect(center.x - size.x / 2, center.y - size.y / 2, size.x, size.y);
    }


}