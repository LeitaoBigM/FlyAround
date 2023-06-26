using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentoDoLaser : MonoBehaviour
{
    public float velocLaser = 12f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * velocLaser * Time.deltaTime);
    }
}
