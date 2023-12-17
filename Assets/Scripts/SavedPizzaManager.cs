using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Pizza
{
    public GameObject pizzaObject;
    public int toppingsMask;
    public int timeCooked;
    public int id;
}

public class SavedPizzaManager : MonoBehaviour
{
    static int pizzaId = 0;

    private GameObject mainPizza;
    [SerializeField]
    private PizzaListController pizzaListController;
    [SerializeField]
    private TextMeshProUGUI savedText;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddPizza()
    {
        // should only be called in toppings scene
        mainPizza = GameObject.Find("Pizza");

        int toppingMask = 0;

        List<GameObject> children = new List<GameObject>();
        if (mainPizza.transform.Find("Fish") != null) { toppingMask += 4; }
        if (mainPizza.transform.Find("Shrimp") != null) { toppingMask += 2; }
        if (mainPizza.transform.Find("Squid") != null) { toppingMask += 1; }

        // Create pizza clone and save it
        GameObject savedPizza = Instantiate(mainPizza);

        // Get component because pizza list controller gets destroyed for some reason after scene load
        if (pizzaListController == null)
        {
            pizzaListController = GetComponentInChildren<PizzaListController>();
        }

        Pizza sp = new Pizza { pizzaObject = savedPizza, toppingsMask = toppingMask, timeCooked = 0, id = pizzaId++ };
        pizzaListController.AddPizza(sp);

        // Set up pizza game object components
        // Box collider and rigidbody for mouse drags
        savedPizza.AddComponent<SavedPizza>().pizza = sp;
        savedPizza.AddComponent<BoxCollider>();
        savedPizza.AddComponent<Rigidbody>().isKinematic = true ; // Creates a kinematic rigidbody 
        Destroy(savedPizza.GetComponent<ToppingController>());

        foreach (Transform child in mainPizza.transform)
        {
            Destroy(child.gameObject);
        }

        // TODO: instead of moving the pizza off screen, resize it and put it on the saved pizza list
        // the ForeverLoadedCanvas will have to be converted to a world space canvas otherwise the
        // pizza sprite will be covered up by the box. 
    }
}
