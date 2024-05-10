using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Level : MonoBehaviour
{
    private void OnEnable()
    {
        GetComponent<TextMeshProUGUI>().text = "LEVEL: " + LevelManager.currentLevel;
    }
}
