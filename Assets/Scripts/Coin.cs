using UnityEngine;

public class Coin : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Destroy(gameObject, 5f);
    }

	private void OnTriggerEnter(Collider other)
	{
        if (other.CompareTag("Player"))
        {
            gameObject.SetActive(false);

            var go = GameObject.FindWithTag("GameController");
            go.GetComponent<GameManager>().AddCoin();
        }
	}
}
