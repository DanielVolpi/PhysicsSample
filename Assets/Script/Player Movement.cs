using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    CameraController m_cameraController;
    [SerializeField]
    Shooter m_shooter;
    [SerializeField]
    TimeManager m_timeManager;
    bool m_hasContactWithAnything;
    CubeData m_lastCubeHit;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        if(m_timeManager.IsAnyTimeLeft())
        {
            m_cameraController.Move(
                Input.GetAxisRaw("Mouse X"),
                Input.GetAxisRaw("Mouse Y")
            );

            if (Input.GetMouseButtonDown(0)) 
            {
                m_shooter.Shoot();
            }

            RayCasting();
        }
    }

    void RayCasting()
    {
        Ray l_ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
        Debug.DrawRay(l_ray.origin, l_ray.direction * 900, Color.blue);
        if(Physics.Raycast(l_ray, out var l_hitInfo))
        {
            if(l_hitInfo.transform.TryGetComponent<CubeData>(out var l_cube))
            {
                m_hasContactWithAnything = true;
                l_cube.SetColor();
                if(m_lastCubeHit != l_cube)
                {
                    ResetCube();
                }
                m_lastCubeHit = l_cube;
            }
            else
            {
                ResetCube();
            }
        }
    }

    void ResetCube()
    {
        m_hasContactWithAnything = false;
        if (m_lastCubeHit != null)
        {
            m_lastCubeHit.ResetColor();
            m_lastCubeHit = null;
        }
    }
}
