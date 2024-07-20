using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSpawn : MonoBehaviour
{
    int index;
    [SerializeField] List<GameObject> fixedLevels;
    [SerializeField] int firstDuration;
    int firstCounter;
    [SerializeField] List<GameObject> firstMedley;

    public void SpawnLevel(float spawnOffset)
    {
        Vector3 spawnPoint = new Vector3(transform.position.x, transform.position.y + spawnOffset, 0);

        if(fixedLevels[index] == null)
        {
            if (firstCounter < firstDuration)
                FirstMedley(spawnPoint);
            return;
        }

        Instantiate(fixedLevels[index], spawnPoint, Quaternion.identity, transform);

        index++;
    }

    void FirstMedley(Vector3 spawnPoint)
    {
        int i = Random.Range(0, firstMedley.Count);
        Instantiate(firstMedley[i], spawnPoint, Quaternion.identity, transform);
        firstCounter++;
        if (firstCounter >= firstDuration)
            index++;
    }
}
