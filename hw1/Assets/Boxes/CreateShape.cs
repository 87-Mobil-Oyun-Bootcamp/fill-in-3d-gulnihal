using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateShape : MonoBehaviour
{
    [Space]
    [SerializeField]
    private Sprite pika; // Serializable, for being able to attach the photo from unity

    [Space]
    [SerializeField]
    private GameObject cube; // take original object from unity
                             // and get the clone of it in line 30 (Instantiate)

    Vector3 cubePos;
    Texture2D texture2D;

    private float offsetX = 1f;
    private float offsetY = 1f;

    void Awake()
    {
        texture2D = pika.texture;

        for(int i=0; i< texture2D.width; i++)
        {
            for(int j=0; j< texture2D.height; j++)
            {

                Color color = texture2D.GetPixel(i, j);
                // color.a : alpha component of the color ( 0- transparent, 1- opaque ) 
                if(color.a == 0)
                {
                    continue;
                }
                cubePos = new Vector3(i*offsetX - texture2D.width*0.5f, 0f, j*offsetY-texture2D.height*.5f); // neden offset ile çarpıyoruz?
                GameObject cubeObj = Instantiate(cube, cubePos, Quaternion.identity, transform); 
                cubeObj.GetComponent<Renderer>().material.color = color;
            }
        }
    }

    void Update()
    {
        
    }
}
