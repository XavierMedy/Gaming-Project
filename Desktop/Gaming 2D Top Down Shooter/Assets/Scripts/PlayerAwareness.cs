using UnityEngine;

public class PlayerAwareness : MonoBehaviour
{
    public float detectionRadius = 5f;

    public bool IsPlayerNearby()
    {
        Collider2D[] cols = Physics2D.OverlapCircleAll(transform.position, detectionRadius);
        foreach (var c in cols) if (c.CompareTag("Player")) return true;
        return false;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }
}
