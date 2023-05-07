using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zoom : MonoBehaviour
{
    public Camera cam;
    public float normalFov = 90;
    public float multiplier = 2;
    public float zoomTime = 2;

    void Update()
    {
      if (Input.GetMouseButton(1))
      {
        ZoomCamera(normalFov / multiplier);
      }
      else if (cam.fieldOfView != normalFov)
      {
        ZoomCamera(normalFov);
      }
    }

  void ZoomCamera(float target)
  {
  float angle = Mathf.Abs((normalFov / multiplier) - normalFov);
  cam.fieldOfView = Mathf.MoveTowards(cam.fieldOfView, target, angle / zoomTime * Time.deltaTime);
  }
}
