using UnityEngine;

public class PlayerCollisionHandler : MonoBehaviour
{
    [SerializeField] Animator animator;

    [SerializeField] float cooldownTime = 1f;
    [SerializeField] float adjustChangeMoveSpeed = -2f;
    const string hitString = "Hit";

    LevelGenerator levelGenerator;

    void Start()
    {
        levelGenerator = FindAnyObjectByType<LevelGenerator>();
    }

    void Update()
    {
        cooldownTime -= Time.deltaTime;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (cooldownTime <= 0)
        {
            levelGenerator.ChangeChunkMoveSpeed(adjustChangeMoveSpeed);
            animator.SetTrigger(hitString);
            cooldownTime = 1f;
        }
    }
}
