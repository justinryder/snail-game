using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour 
{
    private static Vector3 sTarget = new Vector3();
    private Vector3 mCurrentVelocity = new Vector3();

    void Update()
    {
        transform.position = Vector3.SmoothDamp(transform.position, sTarget, ref mCurrentVelocity, 1f);
    }

    public static void SetTarget(Vector3 target)
    {
        sTarget = target;
    }
}
