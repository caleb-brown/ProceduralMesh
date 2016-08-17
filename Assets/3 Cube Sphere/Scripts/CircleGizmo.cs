using UnityEngine;
using System.Collections;

public class CircleGizmo : MonoBehaviour {

    public int resolution = 10;

    void OnDrawGizmosSelected()
    {
        float step = 2.0f / resolution;
        for (int i = 0; i <= resolution; i++)
        {
            ShowPoint(i * step - 1.0f, -1.0f);
            ShowPoint(i * step - 1.0f, 1.0f);
        }

        for (int i = 1; i < resolution; i++)
        {
            ShowPoint(-1.0f, i * step - 1.0f);
            ShowPoint(1.0f, i * step - 1.0f);
        }
    }

    void ShowPoint(float x, float y)
    {
        Vector2 square = new Vector2(x, y);
        Vector2 circle;
        circle.x = square.x * Mathf.Sqrt(1.0f - square.y * square.y * 0.5f);
        circle.y = square.y * Mathf.Sqrt(1.0f - square.x * square.x * 0.5f);

        Gizmos.color = Color.black;
        Gizmos.DrawSphere(square, 0.025f);

        Gizmos.color = Color.white;
        Gizmos.DrawSphere(circle, 0.025f);

        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(square, circle);

        Gizmos.color = Color.grey;
        Gizmos.DrawLine(circle, Vector2.zero);
    }
}
