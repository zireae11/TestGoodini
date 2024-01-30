using UnityEngine;
using Cinemachine;

public class ClickButton : MonoBehaviour
{
    public CinemachineVirtualCamera virtualCamera;
    public CinemachinePathBase path;

    //дорожки дял камеры
    public CinemachinePathBase DollyTrack1, DollyTrack2, DollyTrack3, DollyTrack4;
    //объекты для фокусировки камеры(здания)
    public Transform target1, target2, target3, target4;

    public float VerticalFOV = 60.0f;
    private float currentFOV = 80.0f;
    bool activate1, activate2, activate3, activate4;

    void Start()
    {
        virtualCamera.GetCinemachineComponent<CinemachineTrackedDolly>().m_Path = path; // инициализация дорожки камеры при запуске
        activate1 = activate2 = activate3 = activate4 = false; // кнопки не нажаты
        virtualCamera.m_Lens.FieldOfView = currentFOV; // начальный FOV
        virtualCamera.GetCinemachineComponent<CinemachineTrackedDolly>().m_PathPosition = 0f; //начальная позиция у дорожки при запуске

    }

    void Update()
    {
        if (activate1 || activate2 || activate3 || activate4)
        {
            UpZoom();
        }  
    }

    public void UpZoom()
    {
        currentFOV = Mathf.Lerp(currentFOV, VerticalFOV, Time.deltaTime);
        virtualCamera.m_Lens.FieldOfView = currentFOV;
    }

    public void SetLookAtTarget(Transform target)
    {
        virtualCamera.LookAt = target;
    }

    public void ButtonPress1() //первая кнопка
    {
        if (!activate1)
        {
            SetLookAtTarget(target1);
            activate1 = true;
            activate2 = activate3 = activate4 = false;
            virtualCamera.GetCinemachineComponent<CinemachineTrackedDolly>().m_Path = DollyTrack1;
        }
    }

    public void ButtonPress2() //вторая кнопка
    {
        if (!activate2)
        {
            SetLookAtTarget(target2);
            activate2 = true;
            activate1 = activate3 = activate4 = false;
            virtualCamera.GetCinemachineComponent<CinemachineTrackedDolly>().m_Path = DollyTrack2;
        }
    }

    public void ButtonPress3() //третья кнопка
    {
        if (!activate3)
        {
            SetLookAtTarget(target3);
            activate3 = true;
            activate2 = activate1 = activate4 = false;
            virtualCamera.GetCinemachineComponent<CinemachineTrackedDolly>().m_Path = DollyTrack3;
        }
    }

    public void ButtonPress4() //четвертая кнопка
    {
        if (!activate4)
        {
            SetLookAtTarget(target4);
            activate4 = true;
            activate2 = activate3 = activate1 = false;
            virtualCamera.GetCinemachineComponent<CinemachineTrackedDolly>().m_Path = DollyTrack4;
        }
    }
}
