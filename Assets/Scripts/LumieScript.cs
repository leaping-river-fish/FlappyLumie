using UnityEngine;

// Character logic

public class LumieScript : MonoBehaviour
{
    // Physics and state
    public Rigidbody2D lumieRigidbody;
    public float flapStrength;
    public bool lumieAlive = true;

    // imported logic script
    public LogicScript logic;

    // SFX
    public AudioSource flapSFX;

    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>(); // uses tags
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) == true && lumieAlive == true)
        {
            lumieRigidbody.linearVelocity = Vector2.up * flapStrength;
            flapSFX.Play();
        }

        if (transform.position.y > 13 || transform.position.y < -13)
        {
            logic.GameOver();
            lumieAlive = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        logic.GameOver();
        lumieAlive = false;
    }
}
