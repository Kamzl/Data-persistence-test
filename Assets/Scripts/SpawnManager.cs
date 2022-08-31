using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject lilypads;
    public GameObject enemyLilypads;
    public GameObject seaTile;

    private Transform playerTransform;

    public int lilypadCounter = 1;

    // Start is called before the first frame update
    void Start()
    {
        playerTransform = GameObject.Find("Player").GetComponent<Transform>();
        SpawnPlatforms(6);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnPlatforms(int maxPlatforms)
    {
        Debug.Log(maxPlatforms);
        while(maxPlatforms > lilypadCounter)
        {
            float lilypadRangeX = 7.0f;
            float minLilypadRange = lilypadCounter * 10 - 5;
            float maxLilypadRange = lilypadCounter * 10;
            Vector3 LilypadPosition = new Vector3(Random.Range(-lilypadRangeX, lilypadRangeX), 0, Random.Range(minLilypadRange, maxLilypadRange));
            Instantiate(lilypads, LilypadPosition, lilypads.transform.rotation);
            Vector3 EnemyLilypadPosition = new Vector3(Random.Range(-lilypadRangeX, lilypadRangeX), 0, Random.Range(minLilypadRange, maxLilypadRange));
            while ((EnemyLilypadPosition.x - LilypadPosition.x < 3) && (EnemyLilypadPosition.x - LilypadPosition.x > -3))
            {
                EnemyLilypadPosition.x = Random.Range(-7, 7);
            }
            Instantiate(enemyLilypads, EnemyLilypadPosition, lilypads.transform.rotation);
            if (lilypadCounter % 10 == 7)
            {
                Instantiate(seaTile, new Vector3(0, -1, (lilypadCounter + 3) * 10 + 40), seaTile.transform.rotation);
            }
            lilypadCounter += 1;
        }
    }
}
