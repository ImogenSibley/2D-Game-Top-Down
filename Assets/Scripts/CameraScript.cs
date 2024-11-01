using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{

    public Transform attachedPlayer;
    public float blendAmount = 0.5f;
    Vector3 currentPosition;
    Vector3 targetPosition;
    float zValue;

    // Start is called before the first frame update
    void Start()
    {
        currentPosition = transform.position;
        zValue = currentPosition.z;
    }

    // Update is called once per frame
    void Update()
    {
        targetPosition = attachedPlayer.transform.position;
        currentPosition = targetPosition * blendAmount + currentPosition * (1.0f - blendAmount);
        currentPosition.z = zValue;
        transform.position = currentPosition;
    }
}
