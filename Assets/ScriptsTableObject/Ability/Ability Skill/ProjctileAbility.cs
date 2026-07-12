using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Ability/Projectile", fileName = "ProjectileAbility")]
public class ProjctileAbility : GenericAbiity
{
    [SerializeField] private int BulletCount;
    [SerializeField] private float totalAngle;

    [SerializeField] private GameObject thisProjectile;
 
     public override void UseAbility(Vector2 PlayerPostion, Vector2 PlayerFacingDirection
    , Animator playerAni, Rigidbody2D playerRigi)
    {
        if(PlayerMagic.Point >= magicCost)
        {
            float Anglestep = totalAngle /(float) (BulletCount -1);  // Ví dụ 5 đạn thì có 4 góc *....*....*...*...*
            float startAngle = -totalAngle/(float)2;

            for(int i =0; i < BulletCount; i++)
                {
                    float AngleRotation = startAngle + (i * Anglestep);
                    GameObject NenObject =  Instantiate(thisProjectile,PlayerPostion,Quaternion.Euler(0f,0f,AngleRotation));
                    GenericProjectile myProjectile = NenObject.GetComponent<GenericProjectile>();
                    
                    
                    if (myProjectile)
                    {
                        Vector2 NewDircetion = Quaternion.Euler(0f,0f,AngleRotation)*PlayerFacingDirection;
                        myProjectile.SetUp(NewDircetion);
                    }
                }

       
        
            PlayerMagic.Point -= magicCost;
            usPlayerMagic.Rasie();
        }
    }
}
