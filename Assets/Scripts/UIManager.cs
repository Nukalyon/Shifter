using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEssentials.Extensions;


public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI collectibleText;
    [SerializeField] private GameObject listPowerUps;
    private int collectibleCollected = 0;

    private List<GameObject> collectibles = new List<GameObject>();

    private List<Item> items = new List<Item>();

    private UIManager manager = null;


    // Start is called before the first frame update
    void Start()
    {
        manager = GameObject.Find("Canvas").GetComponent<UIManager>();
        if(manager == null)
        {
            Debug.Log("UIManager is null");
        }

        //Ajouter tt les gameobjects avec tag "Collectible" a la liste collectibles.
        collectibles.AddRange(GameObject.FindGameObjectsWithTag("Collectible"));

    }

    public void addCollectible()
    {
        collectibleCollected++;
        updateDisplay();
    }


    private void updateDisplay()
    {
        collectibleText.text = "Collectible : " + collectibleCollected;
        int nbChildren = listPowerUps.transform.childCount;
        for(int i = 0; i < nbChildren; i++)
        {

        }
    }

    public void ResetCollectibles()
    {
        foreach (GameObject collectible in collectibles)
        {
            collectible.SetActive(true);
        }
        collectibleCollected = 0;
        updateDisplay();
    }

    internal void AddPower(Item item)
    {
        if(!items.Contains(item))
        {
            items.Add(item);
            string col = ExtColorToNames.FindColor(item.GetColor());
            GameObject temp = new GameObject(col);
            temp.transform.parent = listPowerUps.transform;
            temp.AddComponent<TextMeshProUGUI>();
            temp.GetComponent<TextMeshProUGUI>().text = col;
            temp.GetComponent<TextMeshProUGUI>().fontSize = 30;
            temp.SetActive(true);
        }
        updateDisplay();
    }
}
