using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

class Test : LogBehaviour
{
    void Awake()
    {
        Log("Awake");
    }
    void Start()
    {
        Log("Start");

    }
    void OnEnable()
    {
        Log("OnEnable");
    }


}
