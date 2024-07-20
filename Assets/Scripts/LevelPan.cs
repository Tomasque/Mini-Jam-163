using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelPan : MonoBehaviour
{
    [SerializeField] float panDuration;
    [SerializeField] float panPow;
    [SerializeField] float spawnLevelOffset;
    [SerializeField] LevelSpawn levelSpawn;

    Transform currentLevel;

    private void Awake()
    {
        Ref.levelPan = this;
    }

    public void TriggerPanUp(Transform nextLevel)
    {
        StopAllCoroutines();

        if(currentLevel == null)
        {
            currentLevel = nextLevel;
            return;
        }

        levelSpawn.SpawnLevel(nextLevel.position.y + spawnLevelOffset);
        StartCoroutine(PanUp(nextLevel));
    }

    IEnumerator PanUp(Transform nextLevel)
    {
        Vector3 currentPosition = transform.position;
        Vector3 newPosition = Vector3.up * nextLevel.position.y;

        for(float t = 0; t < panDuration; t += Time.deltaTime)
        {
            float x = t / panDuration;
            float y = x * x * (3f - 2f * x);
            transform.position = Vector3.Lerp(currentPosition, newPosition, y);

            yield return new WaitForSeconds(0);
        }

        transform.position = newPosition;
        Destroy(currentLevel.parent.gameObject);
        currentLevel = nextLevel;
    }
}
