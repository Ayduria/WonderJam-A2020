using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class getReceip : MonoBehaviour
{

    private GameObject[] ingredients;
    private int[] ingredientsQuantity;
    private string[] ingredientsName;
    public Text textarea;
    private string totalText;

    // Start is called before the first frame update
    void Start()
    {
        ingredientsName = GameObject.FindGameObjectWithTag("substance").GetComponent<getIngredients>().ingredientsName;
        ingredientsQuantity = GameObject.FindGameObjectWithTag("substance").GetComponent<getIngredients>().ingredientsQuantity;

        for (int i = 0; i < ingredientsName.Length; i++)
        {
            totalText += ingredientsName[i] + " X " + ingredientsQuantity[i] + "\n";
        }

        textarea.text = totalText;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
