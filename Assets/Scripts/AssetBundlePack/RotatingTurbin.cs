using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingTurbin : MonoBehaviour
{
    [SerializeField] private GameObject rotateTurbin;
    [SerializeField] private float speedTurbin = 1f;
    [SerializeField] private int rotateY = 0;


    void Update()
    {
        Vector3 rotatePosihn = new Vector3(0, rotateY, 0);
        rotateTurbin.transform.rotation *= Quaternion.AngleAxis(speedTurbin * Time.deltaTime, rotatePosihn);
    }
}
