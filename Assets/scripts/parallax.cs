using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class parallax : MonoBehaviour
{
    [Header("Parallax Backgrounds")]
    public Transform background1;
    public Transform background2;
    public Transform background3;

    void Update()
    {
        float cameraX = GetComponent<Camera>().transform.position.x;
        background1.transform.position = new Vector3(cameraX * 0.1f, background1.transform.position.y, background1.transform.position.z);
        background2.transform.position = new Vector3(cameraX * 0.2f, background2.transform.position.y, background2.transform.position.z);
        background3.transform.position = new Vector3(cameraX * 0.3f, background3.transform.position.y, background3.transform.position.z);
    }
}
