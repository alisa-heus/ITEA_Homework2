using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyWithDelay : MonoBehaviour
{
    [SerializeField] float _delay = 2.5f;
    void Start()
    {
        Destroy(gameObject, _delay);
    }
}
