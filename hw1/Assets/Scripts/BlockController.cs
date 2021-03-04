using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockController : MonoBehaviour
{
    public GameObject sp;
    //public BlockSpawner sp;
    private void Awake()
    {
        // sp = GameObject.Find("CreateShape");
        sp = GameObject.FindGameObjectWithTag("BlockSpawner");
    }

    private void OnTriggerEnter(Collider other)
    {
        //GameObject pikaCubes = other.GetComponent<GameObject>();
        GameObject pikaCubes = other.gameObject; // gameObject: the game object this component attached to

        if ( other.tag == "Uncolored")
        {
            Debug.Log("dfghjklşi");

            // get the original color of pika cubes to set back
            Color color = sp.GetComponent<BlockSpawner>().dict[pikaCubes.transform];
            pikaCubes.GetComponent<Renderer>().material.color = color;
            Object.Destroy(gameObject);
            pikaCubes.tag = "colored";
        }

    }
}
