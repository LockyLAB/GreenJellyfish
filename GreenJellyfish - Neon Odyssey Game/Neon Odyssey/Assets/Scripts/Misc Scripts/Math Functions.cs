using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MathFunctions
{
    public Vector3 Lerp(Vector3 a, Vector3 b, float p)
    {
        return a + (b - a) * p;
    }

    public Vector3 QuadraticBezier(Vector3 p0, Vector3 p1, Vector3 p2, float p)
    {
        //Get each mid point
        Vector3 cMid0 = Lerp(p0, p1, p);
        Vector3 cMid1 = Lerp(p1, p2, p);
        return Lerp(cMid0, cMid1, p);
    }

    public Vector3 CubicBezier(Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3, float p)
    {
        Vector3 cMid0 = Lerp(p0, p1, p);
        Vector3 cMid1 = Lerp(p1, p2, p);
        Vector3 cMid2 = Lerp(p2, p3, p);
        return QuadraticBezier(cMid0, cMid1, cMid2, p);
    }
}
