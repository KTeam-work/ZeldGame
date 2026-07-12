using UnityEngine;

public class Statemachine : MonoBehaviour
{

    public enum PlayerState
    {
        idle,
        walk,
        attack,
        stagger,
        ability,
        Interact

    }
    
    public PlayerState CurrPlayerState;
    void Awake()
    {
        CurrPlayerState = PlayerState.idle;
    }
     
}
