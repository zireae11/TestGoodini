using UnityEngine;
using UnityEngine.EventSystems;
using Cinemachine;

public class TouchpadController : MonoBehaviour, IDragHandler, IEndDragHandler
{
    public float rotationSpeed = 5f;
    public CinemachineVirtualCamera virtualCamera;
    private Vector2 lastDragPosition;

    void Start()
    {
        virtualCamera = FindObjectOfType<CinemachineVirtualCamera>();
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 currentDragPosition = eventData.position;

        if (lastDragPosition != Vector2.zero)
        {
            float delta = (currentDragPosition.x - lastDragPosition.x) * rotationSpeed * Time.deltaTime;
            CinemachineTrackedDolly trackedDolly = virtualCamera.GetCinemachineComponent<CinemachineTrackedDolly>();

            if (trackedDolly != null)
            {
                float smoothedDelta = Mathf.Lerp(0, delta, Time.deltaTime);
                trackedDolly.m_PathPosition = Mathf.Clamp(trackedDolly.m_PathPosition + smoothedDelta, -4f, 4f);
                if (trackedDolly.m_PathPosition >= 4f || trackedDolly.m_PathPosition <=-4f)
                {
                    trackedDolly.m_PathPosition = 0f;
                }
            }
        }

        lastDragPosition = currentDragPosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        lastDragPosition = Vector2.zero;
    }
}
