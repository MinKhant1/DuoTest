using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveScript : MonoBehaviour {


    public Vector3 t;
    public int TileSize = 1;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
      
        if (Input.GetKeyDown(KeyCode.Space))
        {
           t = Vector3.forward * TileSize;

            StartCoroutine(MoveAim(t));

            //transform.Translate(Vector3.forward * TileSize*3);
           // transform.position =Vector3.forward*TileSize ;
        }

      //  Debug.Log(t);

	}


   private IEnumerator MoveAim(Vector3 target)
    {
        while (Vector3.Distance(transform.position,target)>0.5f)
        {
            Debug.Log(Vector3.Distance(transform.position, target));
            transform.Translate ( Vector3.Lerp(transform.position, target,1f));

            yield return null;
        }
        
    }
   
}
