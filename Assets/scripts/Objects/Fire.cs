using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    
    private Animator _ani;
    private bool IsFire = false;
    private bool _isFireMax = false;

    [SerializeField] private GameObject Tourch;
    
   
    void Start()
    {
      _ani = GetComponent<Animator>();
      Tourch.SetActive(false);
    }

    // Start Fire
    public void SetOnFire()
    {
        Tourch.SetActive(true);
        IsFire = !IsFire;
        if (IsFire)
        {
            _ani.SetBool("CanFire",IsFire);
        }
        else
        {
           _ani.SetBool("CanFire",IsFire);
        }

        if(_isFireMax == true)
        {
            _isFireMax = false;
            _ani.SetBool("FireMax",_isFireMax);
        }
    }

    public void FireForever()
    {
        Tourch.SetActive(false);
        _isFireMax = !_isFireMax;

        if (_isFireMax)
        {
            _ani.SetBool("FireMax",_isFireMax);
        }
        else
        {
            _ani.SetBool("FireMax",_isFireMax);
        }

        if(IsFire == true)
        {
            IsFire = false;
            _ani.SetBool("CanFire",IsFire);
        }
    }


    
    void Update()
    {
        
    }
}
