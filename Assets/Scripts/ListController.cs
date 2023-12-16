using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ListController : MonoBehaviour
{
    class Order
    {
        public int id;
        public int toppingsMask;
        public int cookTime;
    }

    private List<Order> orders;
    [SerializeField]
    private TextMeshProUGUI orderTMP;
    [SerializeField]
    private List<GameObject> orderObjects;

    // Start is called before the first frame update
    void Start()
    {
        orders = new List<Order>();
    }

    public void AddOrder(int id, int mask, int time)
    {
        orders.Add(new Order { id = id, toppingsMask = mask, cookTime = time });
        UpdateOrdersText();
    }

    public void RemoveOrder(int id)
    {
        for (int i = 0; i < orders.Count; i++)
        {
            if (orders[i].id == id)
            {
                orders.Remove(orders[i]);
                break;
            }
        }
        UpdateOrdersText();
    }

    void UpdateOrdersText()
    {
        string orderText = "";
        int i = 0;
        for (; i < orders.Count; i++) { 
            orderText += orders[i].cookTime + "\n";
            int j = 0;
            if (orders[i].toppingsMask / 4 % 2 != 0) orderObjects[i].transform.Find("Topping" + (j++)).GetComponent<Image>().sprite = Resources.Load<Sprite>("fishui");
            if (orders[i].toppingsMask / 2 % 2 != 0) orderObjects[i].transform.Find("Topping" + (j++)).GetComponent<Image>().sprite = Resources.Load<Sprite>("shrimpui");
            if (orders[i].toppingsMask / 1 % 2 != 0) orderObjects[i].transform.Find("Topping" + (j++)).GetComponent<Image>().sprite = Resources.Load<Sprite>("squidui");
            for (; j < 3; j++)
            {
                orderObjects[i].transform.Find("Topping" + j).GetComponent<Image>().sprite = null;
            }
        }
        for (; i < 5; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                orderObjects[i].transform.Find("Topping" + j).GetComponent<Image>().sprite = null;
            }
        }
        orderTMP.text = orderText;
    }
}
