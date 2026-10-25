using UnityEngine;

public class Apple : PickUp
{
    [SerializeField] float adjustChangeMoveSpeed = 2f;
    LevelGenerator levelGenerator;

    public void Init(LevelGenerator levelGenerator)
    {
        this.levelGenerator = levelGenerator;
    }

    protected override void OnPickup()
    {
        levelGenerator.ChangeChunkMoveSpeed(adjustChangeMoveSpeed);
        Destroy(gameObject);
    }
}
