using TMPro;
using UnityEngine;

public class Level : MonoBehaviour
{
    private void OnEnable()
    {
        GetComponent<TextMeshProUGUI>().text = "LEVEL: " + LevelManager.currentLevel;
    }
}
