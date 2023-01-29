using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshChanger : MonoBehaviour
{


    [Header("Timer")]
    [Range(0,600)] public int timer = 0;
    [Space(10)]

    [Header("Meshes")]
    public Mesh[] Meshes;

    private bool isJumping = false;

    void Update()
    {
        if (Input.GetKey(KeyCode.Space) && !isJumping) {
            isJumping = true;
        }

        //If Horizontal
        if ((Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)) && !isJumping) {
            if (timer < 600) {
                timer += 1;
            }
            else {
                timer = 100;
            }
        }
        else {
            timer = 0;
        }

        ChangeMesh(Meshes[timer/100]);
    }

    public void ChangeMesh(Mesh mesh) {
        MeshFilter meshFilter = GetComponent<MeshFilter>();
        meshFilter.mesh = mesh;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
        }
    }
}
