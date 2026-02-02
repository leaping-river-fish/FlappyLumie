using UnityEngine;

public class RockMoveScript : MonoBehaviour
{
    // variables
    public float moveSpeed = 10;
    public float deadZone = -30;

    void Update()
    {
        transform.position = transform.position + Vector3.left * moveSpeed * Time.deltaTime;

        // cleans up unused objects
        if (transform.position.x < deadZone)
        {
            Destroy(gameObject);
        }
    }
}
