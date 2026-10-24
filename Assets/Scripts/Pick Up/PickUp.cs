using UnityEngine;

public class PickUp : MonoBehaviour
{
    const string playerTag = "Player";
    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag(playerTag))
        {
            Destroy(gameObject);
        }
    }
}
