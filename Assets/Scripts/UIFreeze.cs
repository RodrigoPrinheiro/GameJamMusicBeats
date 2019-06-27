using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIFreeze : MonoBehaviour
{
    private Vector3 frozenPos;

    // Start is called before the first frame update
    void Start()
    {
        frozenPos = transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = frozenPos;
    }
}
