using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mainMenuIntro : MonoBehaviour
{
   void Awake()
    {
        GetComponent<Animator>().Play("button_intro");
    }
}
