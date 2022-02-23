using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSelector : MonoBehaviour
{
   Touch touch;
   GameObject selectedObject1;
   GameObject selectedObject2;
   GameObject firstRayHit;
   GameObject secondRayHit;
   int selectionState = 1;

   string material1;
   string material2;

   public Material selectionMaterial;
   Material originalMaterial;

  
   bool selectible = false;
   bool compareMaterial = false;



    void Update()
    {

        PickItem();
        
        
    }

     void PickItem()
    {
        if(Input.touchCount>0)
        {
            Debug.Log("1");
            touch = Input.GetTouch(0);
           
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(touch.position);

            if(Physics.Raycast(ray, out hit))
            {
                Debug.Log("12");
                if(hit.collider.CompareTag ("Touchable"))
                {   
                    GameObject coliHit = hit.collider.gameObject;
                    
                    HitCheck(coliHit);
                   
                    
                    if(selectible == true && selectionState == 1)
                    {
                        selectedObject1 = coliHit;
                        material1 = selectedObject1.GetComponent<Renderer>().material.name;
                        
                        
                        originalMaterial = selectedObject1.GetComponent<Renderer>().material;
                        selectedObject1.GetComponent<Renderer>().material = selectionMaterial;
                        
                        
                        selectionState = 2;
                        selectible = false;
                        
                       

                    }              
                    if(selectible == true && selectionState == 2)
                    {
                        selectedObject2 = coliHit;
                        material2 = selectedObject2.GetComponent<Renderer>().material.name;
                        
                        selectionState = 1;
                        selectible = false;
                        compareMaterial = true;
                        
                         if(compareMaterial == true)
                            {
                                MaterialCheck();
                                compareMaterial = false;
                                
                            }
                       


                    }
                    Debug.Log("2");


                    
                }
            }
        }

   

}

 

void HitCheck(GameObject coliHit)
{
    
    if(touch.phase == TouchPhase.Began)
    {
 
        firstRayHit = coliHit;
    }
 
    if(touch.phase == TouchPhase.Ended)
    {
        secondRayHit = coliHit;
    }

    if(firstRayHit == secondRayHit && secondRayHit != null && firstRayHit != null)
    {
        selectible = true;

        firstRayHit = null;
        secondRayHit= null;
           
    }
    // move objenin içindeyken seçme işlemi devam edebilir. bu yöntem de eklenebilir.
    if(touch.phase == TouchPhase.Moved)
    {
        
        firstRayHit = null;
        secondRayHit = null;
        
    }
    #region Alternatif
    // while(firstRayHit == coliHit)
    // {
    //     if(firstRayHit != coliHit)
    //     {
    //         firstRayHit = null;
    //         break;
    //     }
        
    //     Debug.Log("asdasd");
    //     break;

    // }
    #endregion

    Debug.Log("1");
   
}

void MaterialCheck()
    {
        if(material2 == material1)
        {
            
            Destroy(selectedObject1);
            Destroy(selectedObject2);
            material1 = null;
            material2 = null;
            Debug.Log("2");
            
        }
        
        if(material1 != material2)
        {
            selectedObject1.GetComponent<Renderer>().material = originalMaterial;
            selectedObject1 = null;
            selectedObject2=null;
            material2=null;
            material1=null;

        }


        
        
        
    }








#region AlternateHitCheck

      // if(touch.phase == TouchPhase.Began)
                    // {   
                    //     selectedObject1 = coliHit;
                    
                    // }
                    // if(touch.phase == TouchPhase.Ended && coliHit == selectedObject1 )
                    // {
                    //     selectionStart = true;
                    //     selectedObject1.GetComponent<Renderer>().material = selectionMaterial;
                        
                    // }
#endregion






}
