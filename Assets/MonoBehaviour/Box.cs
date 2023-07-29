using System;
using Infrastructure.Gameplay.Persons.Common.Injuring;
using UnityEngine;

public class Box : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("1");
        if (other.TryGetComponent(out ICharacterNotifier characterNotifier))
        {
            Debug.Log("2");
            
            characterNotifier.TakeDamage(5f);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("1");
        if (collision.collider.TryGetComponent(out ICharacterNotifier characterNotifier))
        {
            Debug.Log("2");
            
            characterNotifier.TakeDamage(5f);
        }
    }
}
