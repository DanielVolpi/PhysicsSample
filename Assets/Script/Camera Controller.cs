using UnityEngine;

public class CameraController : MonoBehaviour
{
    public readonly float ROTATIONSPEED = 3f;

    public void Move(float p_xMovement, float p_yMovement)
    {
        transform.Rotate(Vector3.up, p_xMovement * ROTATIONSPEED);
        transform.Rotate(Vector3.left, p_yMovement * ROTATIONSPEED);

        transform.rotation = Quaternion.Euler(
            transform.rotation.eulerAngles.x,
            transform.rotation.eulerAngles.y,
            0.0f
        );
    }
}
