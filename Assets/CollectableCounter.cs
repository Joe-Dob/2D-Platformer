using UnityEngine;
using TMPro;

public class CollectableCounter : MonoBehaviour
{
    public static CollectableCounter instance;

    public int count = 0;
    public TextMeshProUGUI counterText;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);

        UpdateText();
    }

    public void add(int amount)
    {
        count += amount;
        UpdateText();
    }

    void UpdateText()
    {
        if (counterText != null)
            counterText.text = "x " + count;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
