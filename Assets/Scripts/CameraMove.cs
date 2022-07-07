using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [SerializeField] private GameObject target;
    [SerializeField] private Vector3 delta ;
 


    private void LateUpdate()
    {
        this.transform.position = target.transform.position - delta;
    }
}
