using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bombScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject,3);//3秒後に消える
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
