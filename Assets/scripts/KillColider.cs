using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillColider : MonoBehaviour
{
    [Header("Player")]
    public Transform player;
    [Space(10)]

    [Header("SpawnPoint")]
    public Transform spawn;
    
    void OnTriggerEnter2D(Collider2D other)
    {
        player.transform.position = new Vector3(spawn.transform.position.x, spawn.transform.position.y, spawn.transform.position.z);
    }
}
