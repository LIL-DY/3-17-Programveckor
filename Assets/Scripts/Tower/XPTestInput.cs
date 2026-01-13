using UnityEngine;

public class XPTestInput : MonoBehaviour
{
    public PlayerProgression playerprogression;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerprogression.AddXP(100);
            Debug.Log("Gav 100 XP");
        }
    }
}
