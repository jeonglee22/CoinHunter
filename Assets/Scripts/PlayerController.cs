using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10f;
    private Rigidbody rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float v = Input.GetAxis("Vertical");
        float h = Input.GetAxis("Horizontal");
        var velocity = new Vector3(h, 0, v);
        if(velocity.magnitude > 1f)
        {
            velocity.Normalize();
        }

        rb.linearVelocity = velocity * speed;
    }

    public void Die()
    {
        gameObject.SetActive(false);

        var go = GameObject.FindWithTag("GameController");
        go.GetComponent<GameManager>().GameOver();
    }
}
