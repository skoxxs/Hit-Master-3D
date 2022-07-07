using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealsLookOnCamera : MonoBehaviour
{

    private GameObject camera;
    // Start is called before the first frame update
    void Start()
    {
        camera = Camera.main.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.rotation = camera.transform.rotation;
    }
}
