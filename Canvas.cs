using Godot;
using System.Collections.Generic;
public partial class Canvas : RefCounted
{
    public static void DrawRoundRect(Node2D node2D, Rect2 rect, float radius, Color color, bool fill)
    {
        var rectPos = rect.Position;
        var rectSize = rect.Size;
            
        var r = Mathf.Min(Mathf.Min(rectSize.X, rectSize.Y) / 2, radius);
        const int arcSegments = 12;

        // 四角圆心
        var tl = rectPos + new Vector2(r, r);
        var tr = rectPos + new Vector2(rectSize.X - r, r);
        var br = rectPos + new Vector2(rectSize.X - r, rectSize.Y - r);
        var bl = rectPos + new Vector2(r, rectSize.Y - r);
        var points = new List<Vector2>();

        AddArc(tl, Mathf.Pi, Mathf.Pi * 1.5f);
        AddArc(tr, Mathf.Pi * 1.5f, Mathf.Pi * 2);
        AddArc(br, 0, Mathf.Pi * 0.5f);
        AddArc(bl, Mathf.Pi * 0.5f, Mathf.Pi);
        points.Add(points[0]);
        if (fill)
        {
            node2D.DrawColoredPolygon(points.ToArray(), color);
        }
        else
        {
            node2D.DrawPolyline(points.ToArray(), color);
        }
        return;

        void AddArc(Vector2 center, float startAngle, float endAngle)
        {
            for (var i = 0; i < arcSegments; i++)
            {
                var t = i / (float)arcSegments;
                var angle = Mathf.Lerp(startAngle, endAngle, t);
                points.Add(center + new Vector2(Mathf.Cos(angle), Mathf.Sin(angle)) * r);
            }
        }
    }
}
