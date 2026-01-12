using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class XPUI : MonoBehaviour
{
    public PlayerProgression playerprogression;
    public Slider xpBar;
    public TMP_Text levelText;

    void Update()
    {
        
        xpBar.maxValue = playerprogression.xpNeeded;
        xpBar.value = playerprogression.xp;

        
        levelText.text = "Level: " + playerprogression.level;
    }
}
