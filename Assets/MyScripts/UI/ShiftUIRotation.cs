using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShiftUIRotation : MonoBehaviour
{
    public GameObject outerLines_1;
    public GameObject outerLines_2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        outerLines_1.transform.Rotate(0, 0, 50 * Time.deltaTime);
        outerLines_2.transform.Rotate(0, 0, -40 * Time.deltaTime);
    }
}
