using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WalkOut : MonoBehaviour
{
    private float timer;
    bool load = false;
    public Animator GerboMove;
  
    public void OnMouseDown()
    {
        SceneManager.LoadScene("TTTExterior+Town");

    }



   

}
