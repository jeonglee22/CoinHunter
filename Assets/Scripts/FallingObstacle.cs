using UnityEngine;

public class FallingObstacle : MonoBehaviour
{
    public float fallingSpeed = 5f;
    public float fallingRoll = 10f;
	public float bounce = 200f;

    private Rigidbody rb;

	private void Start()
	{
		rb = GetComponent<Rigidbody>();
		rb.linearVelocity = Vector3.down * fallingSpeed;
		float angleX = Random.Range(-fallingRoll, fallingRoll);
		float angleZ = Random.Range(-fallingRoll, fallingRoll);
		Vector3 angle = new Vector3(angleX,0,angleZ);
		rb.angularVelocity = angle;

		Destroy(gameObject, 5f);
	}

	// Update is called once per frame
	void Update()
    {
    }

	private void OnCollisionEnter(Collision collision)
	{
		if (collision.collider.CompareTag("Plane"))
		{
			rb.AddForce(Vector3.up * bounce);
		}
		if (collision.collider.CompareTag("Player"))
		{
			var playerController = collision.collider.GetComponent<PlayerController>();
			playerController.Die();
		}
	}
}
