using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Ability/Dash", fileName = "DashAbility")]
public class DashAbility : GenericAbiity
{
    [SerializeField] private float dashSpeed;

    public override void UseAbility(Vector2 PlayerPostion, Vector2 PlayerFacingDirection
    , Animator playerAni, Rigidbody2D playerRigi)
    {
        if(PlayerMagic.Point >= magicCost)
        {
            PlayerMagic.Point -= magicCost;
            usPlayerMagic.Rasie();
        }

        if (playerRigi)
        {
            playerRigi.linearVelocity = PlayerFacingDirection * dashSpeed;
            
            
        }
    }
}
