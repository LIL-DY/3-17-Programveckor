using UnityEngine;

public class GemPickUp : MonoBehaviour
{
    public int amount = 1;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;

        var prog = FindFirstObjectByType<PlayerProgression>();
        if (prog != null)
            prog.AddCurrency(amount);

        Destroy(gameObject);
    }
}
