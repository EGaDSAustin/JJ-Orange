using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavedPizza : MonoBehaviour
{
    public Pizza pizza;

    private PizzaListController pizzaListController;
    private OvenManager ovenManager;
    private CustomerPenguin customer;
    private bool inList;
    private bool inOven;
    private bool inCustomer;

    void Start()
    {
        pizzaListController = transform.parent.parent.Find("Pizzas").GetComponent<PizzaListController>();
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
            ovenManager.CloseOven(pizza);
        }
        else if (inCustomer)
        {
            customer.ChangeEmotionHappy();
            customer.Leave();
            Destroy(this.gameObject);
        }

    }

    private void OnMouseDown()
    {
        if (inOven) { ovenManager.OpenOven(); }
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
            if (ovenManager != null) ovenManager.CloseOven(); // Close previous oven in case it hasn't been done already
            ovenManager = collision.gameObject.GetComponent<OvenManager>();
            ovenManager.OpenOven();
        }
        else if (collision.collider.CompareTag("Customer"))
        {
            inCustomer = true;
            customer = collision.gameObject.GetComponent<CustomerPenguin>();
            Debug.Log("Customer Spotted");
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
