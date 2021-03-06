using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]

public class BlockSpawner : MonoBehaviour
{
    
    [Space]
    [SerializeField]
    private Sprite pikaSprite; 

    [Space]
    [SerializeField]
    private GameObject PikaCube; 

    [Space]
    [SerializeField]
    private float cubeSize = .1f;
    
    private Vector3 cubePos;
    private Texture2D texture2D;

    public Dictionary<Transform, Color> dict;
    public Material pikaMaterial;
    private Color color;

    void Awake()
    {
        texture2D = pikaSprite.texture;
        dict = new Dictionary<Transform, Color>();
        CreateShape();
    }

    private void CreateShape()
    {
        for (int i = 0; i < texture2D.width; i++)
        {
            for (int j = 0; j < texture2D.height; j++)
            {
                color = texture2D.GetPixel(i, j);
                // color.a : alpha component of the color ( 0- transparent, 1- opaque ) 
                if (color.a == 0) continue;
                
                cubePos = new Vector3(cubeSize * (i - (texture2D.width * 0.5f)), 0f, cubeSize * (j - (texture2D.height * .5f)));
                //GameObject cubeObj = Instantiate(PikaCube, cubePos, Quaternion.identity, transform);
                GameObject cubeObj = Instantiate(PikaCube, transform);
                cubeObj.transform.localPosition = cubePos;
                cubeObj.transform.localScale = cubeSize * Vector3.one;
                cubeObj.GetComponent<Renderer>().material.color = pikaMaterial.color;

                dict.Add(cubeObj.transform, color);
            }
        }
    }

}
