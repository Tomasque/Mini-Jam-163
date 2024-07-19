using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSpawn : MonoBehaviour
{
    [SerializeField] GameObject level;

    public void SpawnLevel(float spawnOffset)
    {
        Vector3 spawnPoint = new Vector3(transform.position.x, transform.position.y + spawnOffset, 0);

        Instantiate(level, spawnPoint, Quaternion.identity, transform);
    }
}
