using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PizzaListController : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI pizzaTMP;
    [SerializeField]
    private List<GameObject> pizzaObjects;
    [SerializeField]
    private List<Pizza> pizzas;

    // Start is called before the first frame update
    void Start()
    {
        pizzas = new List<Pizza>();
    }

    public void AddPizza(Pizza pizza)
    {
        pizzas.Add(pizza);
        UpdatePizzasText();
    }

    public void RemovePizza(int id)
    {
        for (int i = 0; i < pizzas.Count; i++)
        {
            if (pizzas[i].id == id)
            {
                pizzas.RemoveAt(i);
                break;
            }
        }
        UpdatePizzasText();
    }

    void UpdatePizzasText()
    {
        string pizzasText = "";
        int i = 0;
        
        for (; i < pizzas.Count; i++)
        {
            pizzasText += pizzas[i].timeCooked + "\n";
            Debug.Log(pizzaObjects[i]);
            pizzas[i].pizzaObject.transform.parent = pizzaObjects[i].transform;
            pizzas[i].pizzaObject.transform.localPosition = new Vector3(0.0f, 0.0f, -0.1f);
            pizzas[i].pizzaObject.transform.localScale = new Vector3(25.0f, 25.0f, 25.0f);
        }
        pizzaTMP.text = pizzasText;
    }
}
