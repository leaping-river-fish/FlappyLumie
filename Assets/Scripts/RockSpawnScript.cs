using UnityEngine;

public class RockSpawnScript : MonoBehaviour
{
    public GameObject rock;

    // spawn variables
    public float heightOffset = 1;
    public float spawnRate = 4;
    private float timer = 0;

    void Start()
    {
        SpawnRock();
    }

    void Update()
    {
        if (timer < spawnRate)
        {
            timer += Time.deltaTime;
        } else
        {
            SpawnRock(); 
            timer = 0;
        }
    }

    void SpawnRock()
    {
        float lowestPoint = transform.position.y - heightOffset;
        float highestPoint = transform.position.y + heightOffset;
        // spawn prefab at random height
        Instantiate(rock, new Vector3(transform.position.x, Random.Range(lowestPoint, highestPoint), 0), transform.rotation);
    }
}
