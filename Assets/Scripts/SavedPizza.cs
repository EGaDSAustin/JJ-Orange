using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavedPizza : MonoBehaviour
{
    public Pizza pizza;

    private PizzaListController pizzaListController;
    private OvenManager ovenManager;
    private bool inList;
    private bool inOven;

    // Start is called before the first frame update
    void Start()
    {
        pizzaListController = transform.parent.parent.Find("Pizzas").GetComponent<PizzaListController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDrag()
    {
        pizzaListController.RemovePizza(pizza.id);
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(mousePos.x, mousePos.y, -1.1f);
    }

    void OnMouseUp()
    {
        if (inList)
        {
            pizzaListController.AddPizza(pizza);
        }
        else if (inOven)
        {
            ovenManager.CloseOven();
        }

    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("SavedPizzas"))
        {
            inList = true;
        }
        else if (collision.collider.CompareTag("Oven"))
        {
            inOven = true;
            ovenManager.CloseOven(); // Close previous oven in case it hasn't been done already
            ovenManager = collision.gameObject.GetComponent<OvenManager>();
            ovenManager.OpenOven();
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.collider.CompareTag("SavedPizzas"))
        {
            inList = false;
            pizzaListController.RemovePizza(pizza.id);
        }
        else if (collision.collider.CompareTag("Oven"))
        {
            inOven = false;
            ovenManager.CloseOven();
        }
    }
}
