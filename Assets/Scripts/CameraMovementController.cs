using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using DG.Tweening;

public class CameraMovementController : MonoBehaviour
{
    public CinemachineVirtualCamera virtualCam;
    private CinemachineOrbitalTransposer transposer;
    public float cameraStep = 90;
    public float time = .5f;

    private void Start()
    {
        transposer = virtualCam.GetCinemachineComponent<CinemachineOrbitalTransposer>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Q))
            DOVirtual.Float(transposer.m_XAxis.Value, transposer.m_XAxis.Value + cameraStep, time, SetCameraAxis)
                .SetEase(Ease.OutSine);
        if (Input.GetKey(KeyCode.E))
            DOVirtual.Float(transposer.m_XAxis.Value, transposer.m_XAxis.Value - cameraStep, time, SetCameraAxis)
                .SetEase(Ease.OutSine);
    }

    void SetCameraAxis(float x)
    {
        transposer.m_XAxis.Value = x;
    }
}