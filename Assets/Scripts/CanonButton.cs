using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanonButton : MonoBehaviour
{
    [SerializeField] private GameObject canonPrefab;
    [SerializeField]private Sprite sprite;
    [SerializeField]private int price;
    [SerializeField]private Text priceText;

    public GameObject CanonPrefab { get => canonPrefab;  }
    public Sprite Sprite { get => sprite;  }
    public int Price { get => price; private set => price = value; }

    private void Start()
    {
        priceText.text = Price + "$";
    }
}
