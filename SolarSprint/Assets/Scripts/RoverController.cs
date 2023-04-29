using UnityEngine;

public class RoverController : MonoBehaviour
{
    public float rotationSpeed = 1f;

    void FixedUpdate()
    {
        // Get the surface normal at the object's position
        Vector3 surfaceNormal = GetSurfaceNormal(transform.position);

        // Calculate the target rotation based on the surface normal
        Quaternion targetRotation = Quaternion.FromToRotation(transform.up, surfaceNormal) * transform.rotation;

        // Rotate the object towards the target rotation at a constant speed
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.fixedDeltaTime * rotationSpeed);
    }

    Vector3 GetSurfaceNormal(Vector3 position)
    {
        // Raycast downwards to get the surface normal
        RaycastHit hitInfo;
        if (Physics.Raycast(position, -transform.up, out hitInfo))
        {
            return hitInfo.normal;
        }
        else
        {
            return transform.up;
        }
    }
}
