using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public AudioSource MainTheme;
    public Transform target;
    public float smoothSpeed = 0.2f;
    public Vector3 offset;

    void Start(){
      playTheme();
    }
    void LateUpdate (){
      Vector3 desiredpos = target.position + offset;
      Vector3 smoothedpos = Vector3.Lerp(transform.position, desiredpos, smoothSpeed);
      transform.position = smoothedpos;
    }

    public void playTheme(){
      MainTheme.Play();
    }
}
