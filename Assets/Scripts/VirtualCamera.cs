using UnityEngine;
using Cinemachine;

public class VirtualCamera : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera StartCamera;
    [SerializeField] private CinemachineVirtualCamera GameCamera;
    [SerializeField] private CinemachineVirtualCamera FinishCameras;

    public void GameCameraOn()
    {
        StartCamera.Priority = 0;
        GameCamera.Priority = 2;
    }

    public void FinishCameraOn()
    {
        GameCamera.Priority = 1;
        FinishCameras.Priority = 2;
    }

}
