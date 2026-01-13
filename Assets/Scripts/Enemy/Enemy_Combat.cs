using UnityEngine;

public class Enemy_Combat : MonoBehaviour
{
    public int damage = 1;

    public void DealDamage(GameObject target)
    {
        PlayerHealth hp = target.GetComponent<PlayerHealth>();
        if (hp != null)
        {
            hp.TakeDamage(-damage);
        }
    }
}
