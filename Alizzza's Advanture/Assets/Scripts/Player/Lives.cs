using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lives : MonoBehaviour
{
    [SerializeField] GameObject _heartPrefab;

    public void ResetRound()
    {
        for(int i = 1; i < 4; i++)
        {
            Instantiate(_heartPrefab, transform);
        }   
    }

    public void HeartDamage()
    {
        if (transform.childCount > 0)
        {
            Destroy(transform.GetChild(0).gameObject);
        }  
    }

    public void AddHeart()
    {
        if (transform.childCount < 3)
        {
            Instantiate(_heartPrefab, transform);
        }
    }
}
