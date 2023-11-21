using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI collectibleText;
    private int collectibleCollected = 0;

    private List<GameObject> collectibles = new List<GameObject>();

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
        updateCoinDisplay();
    }


    private void updateCoinDisplay()
    {
        collectibleText.text = "Collectible : " + collectibleCollected;
    }

    public void ResetCollectibles()
    {
        foreach (GameObject collectible in collectibles)
        {
            collectible.SetActive(true);
        }
        collectibleCollected = 0;
        updateCoinDisplay();
    }


}
