using System.Collections;
using UnityEngine;

public class Pot : MonoBehaviour
{
    private Animator potDes;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        potDes = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void DestoryPot()
    {
        StartCoroutine(Samsh());
    }

    public IEnumerator Samsh() // Dùng Đẻ làm Hoạt Động Huỷ
    {
        potDes.SetBool("Destroy",true);
        yield return new WaitForSeconds(1f);
        gameObject.SetActive(false);
    }
}
