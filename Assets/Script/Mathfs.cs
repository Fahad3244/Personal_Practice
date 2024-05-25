using UnityEngine;

public static class Mathfs
{
    public const float Tan = 6.28318530718f;

    public static Vector2 GetUnitVectorByAngle(float angRad)
    {
        return new(
            Mathf.Cos(angRad) ,
            Mathf.Sin(angRad)  
        );
    }
    
}
