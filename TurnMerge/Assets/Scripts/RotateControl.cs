using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateControl : MonoBehaviour
{
   public Touch touch;
   public GameObject turnObject;
   public float rotateSpeed;
   
  
    void Update()
    {
       
        RotateCube();


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

   

    
}
   


