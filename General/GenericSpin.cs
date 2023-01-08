using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericSpin : MonoBehaviour
{

    public float speed;
    public bool skybox;

    // Update is called once per frame
    void Update()
    {
        if(skybox == true)
		{
            gameObject.transform.Rotate(new Vector3(0f, 0f, speed * Time.deltaTime));
        }
		else
		{
            gameObject.transform.Rotate(new Vector3(0f, speed * Time.deltaTime, 0f));
        }
        
    }
}
