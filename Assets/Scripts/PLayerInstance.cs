using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PLayerInstance : MonoBehaviour {


    public static PLayerInstance instance;
    private void Awake()
    {
        instance = this;
    }
}
