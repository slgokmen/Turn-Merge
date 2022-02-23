using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllinOne : MonoBehaviour
{

    #region Variabl
   Touch touch;
   GameObject selectedObject1;
   GameObject selectedObject2;
   GameObject firstRayHit;
   GameObject secondRayHit;
   public GameObject turnObject;
   public Material warningMaterial;
   Material orginalMaterial;

   int touchState = 0;
   public float rotateSpeed;
   bool selectible=false;
   
   // karşılaştırmaya açık veya kapalı.
   bool materialState = false;
   string material1;
   string material2;



#endregion

   




    void Update()
    {
        
        //PickItem();
        TouchMechanic();
        
        
        
        
    }

    void LateUpdate()
    {
        RotateCube();
    }

void PickItem()
    {
        if(Input.touchCount>0)
        {
            
           
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(touch.position);

            if(Physics.Raycast(ray, out hit))
            {
                
                
                if(hit.collider.CompareTag ("Touchable"))
                {   
                    GameObject coliHit = hit.collider.gameObject;

                    if(touch.phase == TouchPhase.Began)
                    {
                        selectible = true;
                        Debug.Log("began");
                    }
                    

                    if(selectible == true && touch.phase == TouchPhase.Ended)
                    {   
                       
                       

                        switch(touchState)
                        {
                            case 0:
                                
                                selectedObject1 = coliHit;
                                
                                if(selectedObject1 != selectedObject2)
                                {
                                    
                                    material1 = selectedObject1.GetComponent<Renderer>().material.name;
                                    orginalMaterial = selectedObject1.GetComponent<Renderer>().material;
                                    
                                    
                                    materialState = true;


                                  Debug.Log("materal1" + material1);
                                    touchState=1;
                                }

                                break;
                                
                            case 1:
                                 
                                 
                                 selectedObject2 = coliHit;
                                 
                                 if(selectedObject2 != selectedObject1)
                                 {
                                 
                                    material2 = selectedObject2.GetComponent<Renderer>().material.name;
                                    Debug.Log("materal2" + material2);
                                    touchState = 0;

                                    if(material1 != material2)
                                    {
                                        materialState = false;
                                    }
                                 }
                                 
                                 break;
                            

                        }

                        
                    selectible = false;
                    }
                
                        
                    
                    
                }
            }
        }
    MaterialCheck();
}
void RotateCube()
    {
        if(Input.touchCount>0)
        {
            touch = Input.GetTouch(0);

            if(touch.phase == TouchPhase.Moved)
            {
                turnObject.transform.RotateAround
                (transform.position,Vector3.left,touch.deltaPosition.y * rotateSpeed);
                
                turnObject.transform.RotateAround
                (transform.position,Vector3.up,touch.deltaPosition.x * rotateSpeed);
            }




        }
    }

 void MaterialCheck()
    {
        
        if(material1 == material2)
        {
            if(material2 != null)
            {
            
                Destroy(selectedObject1);
                Destroy(selectedObject2);
                material1 = null;
                material2 = null;
                orginalMaterial = null;

            }
           
            
        }

        // Material Change for first objects
        if(materialState == true && selectedObject1 != null)
        {
            selectedObject1.GetComponent<Renderer>().material = warningMaterial;
        }

        if(materialState == false && orginalMaterial != null)
        {
            selectedObject1.GetComponent<Renderer>().material = orginalMaterial;
            orginalMaterial = null;
        }
        

    }

void TouchMechanic()
{
    if(Input.touchCount > 0)
    {
        touch = Input.GetTouch(0);
        Debug.Log(touch.phase);

        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(touch.position);

            if(Physics.Raycast(ray, out hit))
            {
                
             if (hit.collider.CompareTag ("Touchable"))
             {   
                    GameObject coliHit = hit.collider.gameObject;

                    
                    #region HitChecks
                    
                    //Aynı küp üzerinde began ve end olayı gerçekleşiyor mu?
                    if(touch.phase == TouchPhase.Began)
                    {
                        firstRayHit = coliHit;
                        selectible = true;
                        Debug.Log(firstRayHit);
                    }

                    if(touch.phase == TouchPhase.Ended)
                    {
                        secondRayHit = coliHit;
                        Debug.Log(secondRayHit);
                    }
                    
                    if(touch.phase == TouchPhase.Moved)
                    {
                        firstRayHit = null;
                        secondRayHit = null;
                    }

                    #endregion

                   
                    

                    if(firstRayHit && secondRayHit != null && firstRayHit == secondRayHit)
                    {   
                       
                       

                        switch(touchState)
                        {
                            case 0:
                                
                                selectedObject1 = coliHit;
                                
                                if(selectedObject1 != selectedObject2)
                                {
                                    // original material veriable assigment 
                                    orginalMaterial = selectedObject1.GetComponent<Renderer>().material;
                                   
                                    // material name set
                                    material1 = selectedObject1.GetComponent<Renderer>().material.name;
                                    
                                    
                                    materialState = true;

                                    touchState=1;

                                                                        
                                }

                                break;
                                
                            case 1:
                                 
                                 
                                 selectedObject2 = coliHit;
                                 
                                 if(selectedObject2 != selectedObject1)
                                 {
                                    //material name set
                                    material2 = selectedObject2.GetComponent<Renderer>().material.name;
                                    
                                    touchState = 0;

                                    if(material1 != material2)
                                    {
                                        //eşleştirme başarısız
                                        materialState = false;
                                        material2 = null;
                                        material1 = null;
                                    }
                                 }
                                 
                                 break;
                            

                        }

                        
                    selectible = false;
                    }
             }
            }
    } 
    MaterialCheck();

        
}

void IsSameRayHit()
{
     
}
    





        
        
        
        



}