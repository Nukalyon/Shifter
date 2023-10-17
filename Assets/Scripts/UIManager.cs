using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI collectibleText;
    private int collectibleCollected = 0;
    private UIManager manager = null;

    // Start is called before the first frame update
    void Start()
    {
        manager = GameObject.Find("Canvas").GetComponent<UIManager>();
        if(manager == null)
        {
            Debug.Log("UIManager is null");
        }
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


}
