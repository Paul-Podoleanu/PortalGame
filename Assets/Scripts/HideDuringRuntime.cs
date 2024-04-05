using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideDuringRuntime : MonoBehaviour
{
    Renderer rendererComponent;
    // Start is called before the first frame update
    void Start()
    {
        rendererComponent = GetComponent<Renderer>();
        rendererComponent.enabled = false;

    }

    // Update is called once per frame
    void Update()
    {
    }
}
