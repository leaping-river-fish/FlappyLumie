using UnityEngine;

public class LumieScript : MonoBehaviour
{
    public Rigidbody2D lumieRigidbody;
    public float flapStrength;
    public LogicScript logic;
    public bool lumieAlive = true;
    public AudioSource flapSFX;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>(); // uses tags
    }

    // Update is called once per frame
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
