using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NavigationController : MonoBehaviour
{

    [SerializeField]
    private Button cashierButton;
    [SerializeField]
    private Button toppingsButton;
    [SerializeField]
    private Button ovenButton;

    static bool spawned = false;
    void Awake()
    {
        DontDestroyOnLoad(transform.parent.gameObject);
        if (spawned)
        {
            Destroy(transform.parent.gameObject);
        }
        else
        {
            spawned = true;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        cashierButton.onClick.AddListener(Cashier);
        toppingsButton.onClick.AddListener(Toppings);
        ovenButton.onClick.AddListener(Oven);
    }

    void Cashier()
    {
        if (SceneManager.GetActiveScene().name != "Cashier")
        {
            SceneManager.LoadScene("Cashier");
        }
    }

    void Toppings()
    {
        if (SceneManager.GetActiveScene().name != "Toppings")
        {
            SceneManager.LoadScene("Toppings");
        }
    }

    void Oven()
    {
        if (SceneManager.GetActiveScene().name != "Oven")
        {
            SceneManager.LoadScene("Oven");
        }
    }
}
