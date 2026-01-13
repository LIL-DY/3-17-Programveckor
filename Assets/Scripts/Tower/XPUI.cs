using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class XPUI : MonoBehaviour
{
    public PlayerProgression playerprogression;
    public Slider xpBar;
    public TMP_Text levelText;
    public TMP_Text pointsText;


    void Update()
    {
        if (playerprogression == null || xpBar == null || levelText == null || pointsText == null) return;

        xpBar.maxValue = playerprogression.xpNeeded;
        xpBar.value = playerprogression.xp;
        pointsText.text = "Points: " + playerprogression.upgradePoints;


        levelText.text = "Level: " + playerprogression.level;
    }
}
