using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToppingController : MonoBehaviour
{
    [SerializeField]
    private Button fishButton;
    [SerializeField]
    private Button shrimpButton;
    [SerializeField]
    private Button squidButton;
    [SerializeField]
    private Button saveButton;
    [SerializeField]
    private GameObject fishTopping;
    [SerializeField]
    private GameObject shrimpTopping;
    [SerializeField]
    private GameObject squidTopping;


    // Start is called before the first frame update
    void Start()
    {
        fishButton.onClick.AddListener(AddFish);
        shrimpButton.onClick.AddListener(AddShrimp);
        squidButton.onClick.AddListener(AddSquid);
        saveButton.onClick.AddListener(SavePizza);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void AddFish()
    {
        Vector3 pos = Random.insideUnitSphere;
        Instantiate(fishTopping, new Vector3(pos.x * 3, pos.y, -2), Quaternion.Euler(0.0f, 0.0f, Random.Range(0.0f, 360.0f)), transform);
        FindObjectOfType<AudioManager>().Play("FishPlop");

    }

    void AddShrimp()
    {
        Vector3 pos = Random.insideUnitSphere;
        Instantiate(shrimpTopping, new Vector3(pos.x * 3, pos.y, -2), Quaternion.Euler(0.0f, 0.0f, Random.Range(0.0f, 360.0f)), transform);
        FindObjectOfType<AudioManager>().Play("ShrimpPlop");

    }

    void AddSquid()
    {
        Vector3 pos = Random.insideUnitSphere;
        Instantiate(squidTopping, new Vector3(pos.x * 3, pos.y, -2), Quaternion.Euler(0.0f, 0.0f, Random.Range(0.0f, 360.0f)), transform);
        FindObjectOfType<AudioManager>().Play("SquidPlop");

    }

    void SavePizza()
    {
        // TODO
    }

}
