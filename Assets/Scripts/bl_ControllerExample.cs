using UnityEngine;
using Cinemachine;
public class bl_ControllerExample : MonoBehaviour
{
    [SerializeField] private bl_Joystick Joystick;
    [SerializeField] private float RotationSpeed = 8.0f;
    public CinemachineVirtualCamera virtualCamera;

    private void Start()
    {
        virtualCamera = FindObjectOfType<CinemachineVirtualCamera>();
    }

    void Update()
    {
        float h = Joystick.Horizontal;
        float v = Joystick.Vertical;

        if (Mathf.Abs(h) > 0.1f || Mathf.Abs(v) > 0.1f)
        {
            float angle = Mathf.Atan2(h, v) ;

            CinemachineTrackedDolly trackedDolly = virtualCamera.GetCinemachineComponent<CinemachineTrackedDolly>();

            if (trackedDolly != null)
            {
                float delta = angle * RotationSpeed * Time.deltaTime;
                float smoothedDelta = Mathf.Lerp(0, delta, Time.deltaTime);
                trackedDolly.m_PathPosition = Mathf.Clamp(trackedDolly.m_PathPosition + smoothedDelta, -4f, 4f);

                if (trackedDolly.m_PathPosition >= 4f || trackedDolly.m_PathPosition <= -4f)
                {
                    trackedDolly.m_PathPosition = 0f;
                }
            }
        }
    }
}
