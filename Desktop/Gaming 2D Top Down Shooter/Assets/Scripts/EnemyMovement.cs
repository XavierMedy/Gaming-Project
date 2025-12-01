using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 1.5f;
    public bool moveTowardsPlayer = true;
    private Transform player;

    void Start()
    {
        var p = GameObject.FindWithTag("Player");
        if (p) player = p.transform;
    }

    void Update()
    {
        if (moveTowardsPlayer && player != null)
        {
            var dir = (player.position - transform.position).normalized;
            transform.position += (Vector3)dir * speed * Time.deltaTime;
        }
        else
        {
            transform.position += Vector3.down * speed * Time.deltaTime;
        }
    }
}
