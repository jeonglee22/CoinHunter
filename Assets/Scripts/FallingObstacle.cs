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
        rb.linearVelocity = Vector3.back * fallingSpeed;

        if(transform.position.z < -15f)
        {
            Destroy(gameObject);
        }
    }
}
