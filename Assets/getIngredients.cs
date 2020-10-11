using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class getIngredients : MonoBehaviour
{

    public GameObject[] ingredients;
    public int[] ingredientsQuantity;
    private float malus = 0;
    private bool ingredientExist = false;





    // Start is called before the first frame update
    void Start()
    {
         for (int i = 0; i < ingredients.Length; i++)
        {
            Debug.Log(ingredients[i]);
        } 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D ingredientColliding) {
  

          
        for (int i = 0; i < ingredients.Length; i++)
        {
            var trimmedName = ingredientColliding.gameObject.name.Replace("(clone)","");

            if(ingredientColliding.gameObject.name.Replace("(Clone)","") == ingredients[i].name){
                ingredientExist = true;
            }
        } 

        

        if(ingredientExist == false){
            malus++;
            Debug.Log(malus);
        }
        else{
            ingredientExist = false;
        }

    }
}
