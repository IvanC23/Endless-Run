using UnityEngine;

public class Apple : PickUp
{
    [SerializeField] float adjustChangeMoveSpeed = 2f;
    const string hitString = "Hit";

    LevelGenerator levelGenerator;

    void Start()
    {
        levelGenerator = FindAnyObjectByType<LevelGenerator>();
    }
    
    protected override void OnPickup()
    {
        levelGenerator.ChangeChunkMoveSpeed(adjustChangeMoveSpeed);
    }
}
