using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanonButton : MonoBehaviour
{
    [SerializeField] private List<GameObject> canonPrefab;
    [SerializeField] private List<Sprite> sprite;
    [SerializeField] private Text priceText;
    public int Level;
    public List<int> price;
    public GameObject CanonPrefab { get => canonPrefab[Level];  }
    public Sprite Sprite { get => sprite[Level];  }

    private void Start()
    {
        priceText.text = price[Level] + "$";
    }
    public void Upgrade(Image UI)
    {
        if (Level == sprite.Count - 1) return;
        Level++;
        GetComponent<Image>().sprite = sprite[Level];
        UI.sprite = sprite[Level];
        priceText.text = price[Level] + "$";
    }
}
