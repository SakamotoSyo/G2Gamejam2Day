using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class run : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.position += new Vector3(2, 0, 0) * Time.deltaTime;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
