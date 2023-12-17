using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Pizza
{
    public GameObject pizzaObject;
    public int id;
}

public class SavedPizzaManager : MonoBehaviour
{
    static int pizzaId = 0;

    private List<Pizza> pizzas;
    [SerializeField]
    private TextMeshProUGUI savedText;
    // Start is called before the first frame update
    void Start()
    {
        pizzas = new List<Pizza>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void AddPizza()
    {
        // should only be called in toppings scene
        GameObject thisPizza = GameObject.Find("Pizza");
        pizzas.Add(new Pizza { pizzaObject = thisPizza, id = pizzaId++ });
        GameObject newPizza = Instantiate(thisPizza);
        List<GameObject> children = new List<GameObject>();
        foreach (Transform child in newPizza.transform) children.Add(child.gameObject);
        children.ForEach(child => Destroy(child));
        thisPizza.transform.position = new Vector3(100, 100, 100);
        DontDestroyOnLoad(thisPizza);
        
        // TODO: instead of moving the pizza off screen, resize it and put it on the saved pizza list
        // the ForeverLoadedCanvas will have to be converted to a world space canvas otherwise the
        // pizza sprite will be covered up by the box. 
        string newText = "";
        for (int i = 0; i < pizzas.Count; i++)
        {
            // TODO; change to something more useful
            newText += pizzas[i].id + "\n";
        }
        savedText.text = newText;
    }
}
