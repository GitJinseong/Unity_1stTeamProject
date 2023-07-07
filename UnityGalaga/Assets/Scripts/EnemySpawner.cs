using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameManager gameManager = default;
    public GameObject enemyPrefap = default;
    public float spawnRateMin = 3.0f;
    public float spawnRateMax = 5.0f;
    public float spawnRate = default;
    public float timeAfterSpawn = default;
    public Vector3 enemyPosition = default;
    Quaternion enemyRotation = Quaternion.Euler(0, 0, -180);

    // Start is called before the first frame update
    void Start()
    {
        gameManager = new GameManager();
        timeAfterSpawn = 0f;
        spawnRate = 1f;
        enemyPosition = new Vector3(transform.position.x, 
            transform.position.y + 10f, transform.position.z - 10f);
    }

    // Update is called once per frame
    void Update()
    {
        timeAfterSpawn += Time.deltaTime;

        if (spawnRate < timeAfterSpawn)
        {
            timeAfterSpawn = 0f;

            GameObject enemy = Instantiate(enemyPrefap,
                enemyPosition, enemyRotation);

            spawnRate = Random.Range(spawnRateMin, spawnRateMax);

        }
    }
}
