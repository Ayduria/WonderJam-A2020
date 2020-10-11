using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class getIngredients : MonoBehaviour
{

    public GameObject[] ingredients;
    public int[] ingredientsQuantity;
    public string[] ingredientsName;
    public float malus = 1;
    private bool ingredientExist = false;





    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D ingredientColliding) {
  

          if(ingredientColliding.gameObject.tag == "Grabbable"){
              for (int i = 0; i < ingredients.Length; i++)
                {
                    var trimmedName = ingredientColliding.gameObject.name.Replace("(clone)","");

                    if(ingredientColliding.gameObject.name.Replace("(Clone)","") == ingredients[i].name){
                        ingredientExist = true;


                        ingredientsQuantity[i] -= ingredientsQuantity[i];
                        if(ingredientsQuantity[i] < 0){
                            malus ++;
                            if(malus > 10){
                                malus = 10;
                            }
                        }

                        
                    }


                } 

                

                if(ingredientExist == false){
                    malus++;
                    if(malus > 10){
                        malus = 10;
                    }
                }
                else{
                    ingredientExist = false;
                }
                }
                

            }
}
