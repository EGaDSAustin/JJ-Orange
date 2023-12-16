using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CustomerPenguin : MonoBehaviour
{
    private bool accepted = false;
    private int acceptTime = 30;
    public TextMeshProUGUI timerText;
    public Button button;
    public SpriteRenderer timeBackground;
    public SpriteRenderer fish;
    public SpriteRenderer shrimp;
    public SpriteRenderer squid;
    public SpriteRenderer emotion;
    private int cookTime = 0;
    private int toppingsMask = 1; // TODO migrate to some kind of array; makes much more sense and will support specific #s of each type of topping
    static int orderID = 0;
    private int id;
    private ListController listController;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        button.onClick.AddListener(Accept);
        toppingsMask = (int)Random.Range(1f, 8f);
        if (toppingsMask / 4 % 2 == 0) fish.enabled = false;
        if (toppingsMask / 2 % 2 == 0) shrimp.enabled = false;
        if (toppingsMask / 1 % 2 == 0) squid.enabled = false;
        id = orderID++;
        listController = GameObject.Find("List").GetComponent<ListController>();
        Invoke("DecrementTimer", 1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Accept()
    {
        if (!accepted)
        {
            accepted = true;
            cookTime = (int)Random.Range(10f, 61f);
            timerText.text = cookTime + "s";
            timeBackground.color = new Color(0f, 1f, 0f, 1f);
            listController.AddOrder(id, toppingsMask, cookTime);
            emotion.enabled = true;
            emotion.sprite = Resources.Load<Sprite>("happypenguin");
            Invoke("ChangeEmotionNeutral", 30f);
        }
        else
        {
            // TODO
        }
    }

    void ChangeEmotionNeutral()
    {
        emotion.sprite = Resources.Load<Sprite>("neutralpenguin");
        Invoke("ChangeEmotionAngry", 30f);
    }

    void ChangeEmotionAngry()
    {
        emotion.sprite = Resources.Load<Sprite>("angrypenguin");
        Invoke("Leave", 30f);
    }

    void Leave()
    {
        listController.RemoveOrder(id);
        Destroy(this.gameObject);
    }

    void DecrementTimer()
    {
        if (accepted) return;
        if (acceptTime <= 0)
        {
            Destroy(this.gameObject);
            return;
        }
        timerText.text = --acceptTime + "";
        Invoke("DecrementTimer", 1f);
    }
}
