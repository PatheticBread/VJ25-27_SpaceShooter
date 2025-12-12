using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject SpawnedEnemy;
    [SerializeField] private float BirthRate = 2f;
    [SerializeField] private bool LRSpawner = false;
    void Start()
    {
        StartCoroutine("SpawnEnemy");
    }

    IEnumerator SpawnEnemy()
    {
        yield return new WaitForSeconds(BirthRate);

        Vector2 pivot = transform.position;

        Vector2 RandomPos;

        if(LRSpawner == true)
        {
            RandomPos = new Vector2(pivot.x, pivot.y + Random.Range(-1f,1f));
        }
        else
        {
            RandomPos = new Vector2(pivot.x + Random.Range(-1f,1f), pivot.y);
        }


        Instantiate(SpawnedEnemy, RandomPos, Quaternion.identity);

        StartCoroutine("SpawnEnemy");
    }
}
