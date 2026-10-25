using UnityEngine;

public class PlayerCollisionHandler : MonoBehaviour
{
    [SerializeField] Animator animator;

    [SerializeField] float cooldownTime = 1f;

    const string hitString = "Hit";

    void Update()
    {
        cooldownTime -= Time.deltaTime;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (cooldownTime <= 0)
        {
            animator.SetTrigger(hitString);
            cooldownTime = 1f;
        }
    }
}
