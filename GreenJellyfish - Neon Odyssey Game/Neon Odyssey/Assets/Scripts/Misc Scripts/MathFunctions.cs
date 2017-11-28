using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//---------------------------------------------------------
//-written by: Samuel
//-contributors:
//---------------------------------------------------------

public class MathFunctions
{

    //--------------------------------------------------------------------------------------
    // Get Lerp position
    //
    // Param:
    //		p1: first position vector
    //		p1: second position vector
    //		t: percent through lerp
    //
    // Return:
    //		Vector3 - position in Lerp between two vectors
    //--------------------------------------------------------------------------------------
    public Vector3 Lerp(Vector3 p0, Vector3 p1, float t)
    {
        return p0 + (p1 - p0) * t;
    }

    //--------------------------------------------------------------------------------------
    // Get quadratic bezier position
    //
    // Param:
    //		p0: first position vector
    //		p1: second position vector
    //		p2: third position vector
    //		t: percent through lerp
    //
    // Return:
    //		Vector3 - position in Lerp between two vectors
    //--------------------------------------------------------------------------------------
    public Vector3 QuadraticBezier(Vector3 p0, Vector3 p1, Vector3 p2, float t)
    {
        //Get each mid point
        Vector3 cMid0 = Lerp(p0, p1, t);
        Vector3 cMid1 = Lerp(p1, p2, t);
        return Lerp(cMid0, cMid1, t);
    }

    //--------------------------------------------------------------------------------------
    // Get cubic bezier position
    //
    // Param:
    //		p0: first position vector
    //		p1: second position vector
    //		p2: third position vector
    //		t: percent through lerp
    //
    // Return:
    //		Vector3 - position in Lerp between two vectors
    //--------------------------------------------------------------------------------------
    public Vector3 CubicBezier(Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3, float t)
    {
        Vector3 cMid0 = Lerp(p0, p1, t);
        Vector3 cMid1 = Lerp(p1, p2, t);
        Vector3 cMid2 = Lerp(p2, p3, t);
        return QuadraticBezier(cMid0, cMid1, cMid2, t);
    }
}
