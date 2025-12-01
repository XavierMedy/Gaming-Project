using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float lifeSeconds = 5f;

    private void Start()
    {
        Destroy(gameObject, lifeSeconds);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<EnemyMovement>())
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
