using UnityEngine;

public class FollowTargetAtDistance : MonoBehaviour
{
    public Transform target;

    public float smoothSpeed = 0.125f;
    public Vector3 offset;
    public float multiplier;
    public float smoothTime = 1f;

 
    public void FixedUpdate()
    {
        Vector3 desiredPosition = target.position + offset;
     
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        transform.position = smoothedPosition;

    }

    public void ChangeOffset()
    {
        offset = new Vector3(7, 0, 0);

        FixedUpdate();
    }
    
}
