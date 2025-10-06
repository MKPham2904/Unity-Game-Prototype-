using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefabs;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Instantiate(enemyPrefabs, GenerateSpawnPosition() , enemyPrefabs.transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {

    }
    private Vector3 GenerateSpawnPosition()
    {
        float randomPosX = Random.Range(-9, 9);
        float randomPosZ = Random.Range(-9, 9);
        Vector3 randomPos = new Vector3(randomPosX, 0, randomPosZ);
        return randomPos;
    }
}
