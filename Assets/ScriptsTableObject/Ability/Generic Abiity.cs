using UnityEngine;
using UnityEngine.Playables;

[CreateAssetMenu(menuName = "Scriptable Ability/Generic", fileName = "New Generic Ability")]
public class GenericAbiity : ScriptableObject
{ 
    public float magicCost;
    public float duration;

    public FloatValue PlayerMagic;
    public Signal usPlayerMagic;
    public virtual void UseAbility(Vector2 PlayerPostion, Vector2 PlayerFacingDirection
    , Animator playerAni, Rigidbody2D playerRigi)
    {

    }
}
