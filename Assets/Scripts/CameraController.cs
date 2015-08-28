﻿using UnityEngine;

public class CameraController : MonoBehaviour {
    private const float TARGET_ASPECT_RATIO = 16f / 9f;

    void Start()
    {
        Screen.orientation = ScreenOrientation.LandscapeLeft;
        ScaleCameraToShowTargetAspectRatioWithBlackBars();
    }

    private void ScaleCameraToShowTargetAspectRatioWithBlackBars()
    {
        var aspectRatioOfWindow = (float)Screen.width / (float)Screen.height;
        var camera = GetComponent<Camera>();
        var cameraRect = camera.rect;
        if (aspectRatioOfWindow < TARGET_ASPECT_RATIO)
        {
            cameraRect.width = 1f;
            cameraRect.height = aspectRatioOfWindow / TARGET_ASPECT_RATIO;
            cameraRect.x = 0f;
            cameraRect.y = (1f - aspectRatioOfWindow / TARGET_ASPECT_RATIO) / 2f;
        }
        else if (aspectRatioOfWindow > TARGET_ASPECT_RATIO)
        {
            cameraRect.width = aspectRatioOfWindow / TARGET_ASPECT_RATIO;
            cameraRect.height = 1f;
            cameraRect.x = (1f - aspectRatioOfWindow / TARGET_ASPECT_RATIO) / 2f;
            cameraRect.y = 0f;
        }
        camera.rect = cameraRect;
    }
}