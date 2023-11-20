using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    [SerializeField] GameObject[] objectPrefabs;
    [SerializeField] GameObject objectBossPrefabs;
    [SerializeField] float spawnInterval = 2f;
    [SerializeField] GameManager gameManager;


    private float timer = 0f;

    private void Start()
    {
        float temp = Time.time * 100f;
        Random.InitState((int)temp);

        objectBossPrefabs.GetComponent<SpriteRenderer>().sprite = FileCreate.LoadedSprite;
    }
    // Update is called once per frame 

    void Update()

    {

        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            if (gameManager.dateCount[0] == 10 && gameManager.dateCount[1] < 27)
                SpawnObjectMiddle();
            else if (gameManager.dateCount[0] == 12)
                SpawnObjectFinal();
            else
                SpawnObject();

            timer = spawnInterval;
        }
    }

    void SpawnObjectMiddle()

    {

        float randomX = Random.Range(-7.1f, 7.1f);

        Vector2 spawnPosition = new Vector2(randomX, 6f);

        float determObj = Random.Range(0, 3);

        int spawnIndex;

        if (determObj == 0) //33% È®·ü·Î ¼ÒÁÖ 

            spawnIndex = 0; //¼ÒÁÖ 

        else if (determObj == 1) //33% È®·ü·Î ¸ÆÁÖ 

            spawnIndex = 1; //¼ÒÁÖ 

        else 

            spawnIndex = 2; //½ÃÇèÁö A 

        for(int i = 0; i < 3; i++)
        {
            float _randomX = Random.Range(-7f, 7f);

            Vector2 _spawnPosition = new Vector2(_randomX, 6f);
            Instantiate(objectBossPrefabs, _spawnPosition, Quaternion.identity);
        }

        Instantiate(objectPrefabs[spawnIndex], spawnPosition, Quaternion.identity);
        //Instantiate(objectBossPrefabs, spawnPosition, Quaternion.identity);

        
    }

    void SpawnObjectFinal()

    {

        float randomX = Random.Range(-7f, 7f);

        Vector2 spawnPosition = new Vector2(randomX, 6f);

        for (int i = 0; i < 4; i++)
        {
            float _randomX = Random.Range(-7f, 7f);

            Vector2 _spawnPosition = new Vector2(_randomX, 6f);
            Instantiate(objectBossPrefabs, _spawnPosition, Quaternion.identity);
        }

        for (int i = 0; i < 2; i++)
        {
            float _randomX = Random.Range(-7f, 7f);

            Vector2 _spawnPosition = new Vector2(_randomX, 6f);
            Instantiate(objectPrefabs[3], _spawnPosition, Quaternion.identity);
        }

        

        //
    }

    void SpawnObject()

    {

        for (int i = 0; i < 2; i++)
        {
            float randomX = Random.Range(-7f, 7f);

            Vector2 spawnPosition = new Vector2(randomX, 6f);

            float determObj = Random.Range(0, 10);

            int spawnIndex;

            if (determObj == 0) //10% È®·ü·Î ¼ÒÁÖ 

                spawnIndex = 0; //¼ÒÁÖ 

            else if (determObj == 1) //10% È®·ü·Î ¸ÆÁÖ 

                spawnIndex = 1; //¼ÒÁÖ 

            else if (determObj >= 2 && determObj <= 6) //40% È®·ü·Î ¸ÆÁÖ 

                spawnIndex = 2; //½ÃÇèÁö A 

            else

                spawnIndex = 3; //½ÃÇèÁö F 

            Instantiate(objectPrefabs[spawnIndex], spawnPosition, Quaternion.identity);
        }

    }
}
