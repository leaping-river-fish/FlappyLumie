using UnityEngine;

public class RockMiddleScript : MonoBehaviour
{

    // imported script
    public LogicScript logic;
    private bool hasScored = false;

    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>(); // uses tags
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (hasScored) return;

        if (collision.gameObject.layer == 3) // Lumie layer
        {
            logic.AddScore(1);   
            hasScored = true;
        }
    }
}
