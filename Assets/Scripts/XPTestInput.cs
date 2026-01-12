using UnityEngine;

public class XPTestInput : MonoBehaviour
{
    public XPSystem xpSystem;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            xpSystem.AddXP(100);
            Debug.Log("Gav 100 XP");
        }
    }
}
