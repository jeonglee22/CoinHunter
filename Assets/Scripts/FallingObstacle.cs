using UnityEngine;

public class FallingObstacle : MonoBehaviour
{
    public float fallingSpeed = 5f;
    private Rigidbody rb;

	private void Start()
	{
		rb = GetComponent<Rigidbody>();
	}

	// Update is called once per frame
	void Update()
    {
        rb.linearVelocity = Vector3.down * fallingSpeed;

        if(transform.position.y < 0f)
        {
            Destroy(gameObject);
        }
    }

	private void OnTriggerEnter(Collider other)
	{
		if(other.CompareTag("Player"))
		{
			var playerController = other.GetComponent<PlayerController>();
			playerController.Die();
		}
	}
}
