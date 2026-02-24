using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] monsterReference;

    [SerializeField]
    private Transform leftPos, rightPos;

    private int randomIndex;
    private int randSide;

    void Start()
    {
        StartCoroutine(SpawnMonsters());
    }

    IEnumerator SpawnMonsters()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(2f, 8f));

            randomIndex = Random.Range(0, monsterReference.Length);
            randSide = Random.Range(0, 2);

            GameObject spawnedMonster = Instantiate(monsterReference[randomIndex]);

            if (randSide == 0)
            {
                // Left Spawner
                spawnedMonster.transform.position = leftPos.position;
                spawnedMonster.GetComponent<monster>().speed = Random.Range(4f, 7f);
            }
            else
            {
                // Right Spawner
                spawnedMonster.transform.position = rightPos.position;
                spawnedMonster.GetComponent<monster>().speed = -Random.Range(4f, 7f);
                spawnedMonster.transform.localScale = new Vector3(-1f, 1f, 1f);
            }
        }
    }
}