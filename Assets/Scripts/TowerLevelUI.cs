using UnityEngine;
using TMPro;

public class TowerLevelUI : MonoBehaviour
{
    public Tower tower;
    public TMP_Text text;

    void Reset()
    {
        text = GetComponent<TMP_Text>();
    }

    void Update()
    {
        if (tower == null || text == null) return;
        text.text = "Lv " + tower.towerLevel;
    }
}
