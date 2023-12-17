using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PenguinSpawner : MonoBehaviour
{
    private GameObject[] penguins;
    private Vector3[] penguinLocations;
    private Vector3 offScreen;

    [SerializeField]
    private GameObject customerPenguin;

    static bool spawned = false;
    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        if (spawned)
        {
            Destroy(this.gameObject);
        }
        else
        {
            spawned = true;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        penguins = new GameObject[3];
        penguinLocations = new Vector3[3];
        penguinLocations[0] = new Vector3(6.04f, 0.03f, -1f);
        penguinLocations[1] = new Vector3(1.66f, 0.03f, -1f);
        penguinLocations[2] = new Vector3(-2.77f, 0.03f, -1f);
        offScreen = new Vector3(100f, 100f, -1f);
        SceneManager.activeSceneChanged += ChangedActiveScene;
        Invoke("TrySpawnPenguin", 0.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void TrySpawnPenguin()
    {
        if (penguins[0] == null)
        {
            penguins[0] = Instantiate(customerPenguin, SceneManager.GetActiveScene().name == "Cashier" ? penguinLocations[0] : offScreen, Quaternion.identity);
        }
        else if (penguins[1] == null)
        {
            penguins[1] = Instantiate(customerPenguin, SceneManager.GetActiveScene().name == "Cashier" ? penguinLocations[1] : offScreen, Quaternion.identity);
        }
        else if (penguins[2] == null)
        {
            penguins[2] = Instantiate(customerPenguin, SceneManager.GetActiveScene().name == "Cashier" ? penguinLocations[2] : offScreen, Quaternion.identity);
        }
        FindObjectOfType<AudioManager>().Play("NewCustomer");
        Invoke("TrySpawnPenguin", Random.Range(5.0f, 30.0f));
    }

    void ChangedActiveScene(Scene cur, Scene next)
    {
        // wtf unity
        if (cur.name == null || cur.name == "Cashier")
        {
            for (int i = 0; i < 3; i++)
            {
                if (penguins[i] != null)
                {
                    penguins[i].transform.position = offScreen;
                }
            }
        }
        if (next.name == "Cashier")
        {
            for (int i = 0; i < 3; i++)
            {
                if (penguins[i] != null)
                {
                    penguins[i].transform.position = penguinLocations[i];
                }
            }
        }
    }
}
