using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pasta : MonoBehaviour
{
    public Transform pointPrefab;
    public PastaFunctionName function;

    private Transform[] points;
    private Vector3 parameters;
    private PastaFunction f;

    static PastaFunction[] functions =
        {
            Buccoli,
            Cappelletti,
            Fusilli,
            Gigli,
            Spirali
        };

    public void SetFunction(int functionIndex)
    {
        function = (PastaFunctionName) functionIndex;
        f = functions[functionIndex];
    }

    void Start()
    {
        parameters = PastaFunctionParameters.getParameters(function);

        points = new Transform[(int)parameters.x * (int)parameters.y];

        float step = 500f / points.Length;
        Vector3 scale = Vector3.one * step;

        for (int i = 0; i < points.Length; i++)
        {
            Transform point = Instantiate(pointPrefab);
            point.localScale = scale;
            point.SetParent(transform, false);
            points[i] = point;
        }
    }

    void Update()
    {
        float step = parameters.z / points.Length;
        for (int i = 0, z = 0; z < parameters.y; z++)
        {
            float v = z * step;
            for (int x = 0; x < parameters.x; x++, i++)
            {
                float u = x * step;
                points[i].localPosition = f(u, v);
            }
        }
    }

    const float pi = Mathf.PI;

    static Vector3 Buccoli(float u, float v)
    {
        Vector3 p;
        float scale = 2f;

        p.x = scale * ((0.7f + 0.2f * Mathf.Sin(pi * 21 * v / 250)) * Mathf.Cos(pi * u / 20));
        p.y = scale * (39 * u / 1000 + 1.5f * Mathf.Sin(pi * v / 50));
        p.z = scale * ((0.7f + 0.2f * Mathf.Sin(pi * 21 * v / 250)) * Mathf.Sin(pi * u * -1 / 20));

        return p;
    }

    static Vector3 Cappelletti(float u, float v)
    {
        Vector3 p;
        float scale = 10f;

        p.x = scale * ((0.1f + Mathf.Sin(pi * 3 * u / 160)) * Mathf.Cos(pi * 2.3f * v / 120));
        p.y = scale * (0.1f + (v / 400) + (0.3f - 0.231f * u / 40) * Mathf.Cos(pi * u / 20));
        p.z = scale * ((0.1f + Mathf.Sin(pi * 3 * u / 160)) * Mathf.Sin(pi * 2.3f * v / 120));

        return p;
    }

    static Vector3 Fusilli(float u, float v)
    {
        Vector3 p;

        p.x = 6 * Mathf.Cos(pi * (3 * u + 10) / 100) * Mathf.Cos(pi * v / 25);
        p.y = 3 * u / 20 + 2.5f * Mathf.Cos(pi * (v + 12.5f) / 25);
        p.z = 6 * Mathf.Sin(pi * (3 * u + 10) / 100) * Mathf.Cos(pi * v / 25);

        return p;
    }

    static Vector3 Gigli(float u, float v)
    {
        Vector3 p;
        float scale = 1f;

        p.x = scale * ((0.8f - 0.6f * Mathf.Pow(Mathf.Sin(pi * v * 80), 0.5f)) * Mathf.Cos(pi * u / 50) + 0.08f * Mathf.Sin(pi * v / 40));
        p.y = scale * (1.1f * v / 40 + 0.7f * (1 - Mathf.Pow(Mathf.Sin(pi * (150 - u) / 300), 2)));
        p.z = scale * ((0.8f - 0.6f * Mathf.Pow(Mathf.Sin(pi * v * 80), 0.5f)) * Mathf.Sin(pi * u / 50) + 0.08f * Mathf.Sin(pi * v / 40));

        return p;
    }

    static Vector3 Spirali(float u, float v)
    {
        Vector3 p;

        p.x = (2.5f + 2 * Mathf.Cos(pi * u / 50) + 0.1f * Mathf.Cos(pi * u / 5)) * Mathf.Cos(pi * v / 30);
        p.y = 2.5f + 2 * Mathf.Sin(pi * u / 50) + 0.1f * Mathf.Sin(pi * u / 5) + v / 6;
        p.z = (2.5f + 2 * Mathf.Cos(pi * u / 50) + 0.1f * Mathf.Cos(pi * u / 5)) * Mathf.Sin(pi * v / 30);

        return p;
    }
}
