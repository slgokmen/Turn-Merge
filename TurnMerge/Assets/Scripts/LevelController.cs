using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    public GameObject countObjects;
    bool objectState;
   public void LevelControl()
   {
       SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
       
   }
   void Start()
   {
       if(countObjects == null)
       objectState = false;
       else
       objectState = true;
   }

   void Update()
   {
       if(objectState == true)
       CheckObjects();
       
   }

   void CheckObjects()
   {
       int _count = countObjects.transform.childCount;

       if(_count == 0)
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    
    
    }

    
}
