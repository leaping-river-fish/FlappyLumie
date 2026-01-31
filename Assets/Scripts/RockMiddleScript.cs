using Unity.VisualScripting;
using UnityEngine;

public class RockMiddleScript : MonoBehaviour
{
    public LogicScript logic;
    private bool hasScored = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>(); // uses tags
    }

    // Update is called once per frame
    void Update()
    {
        
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
