using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{

    //�ĤH���ݩ�:�t�סB�����O�B�ͩR��
    [Tooltip("�t��")]public static float speed = 0.5f;
    [Tooltip("�����O")]public static int attack = 60;
    [Tooltip("�ͩR��")]public static int Max_hp = 100;
    public int currentHP;
    bool findSolider;
    Animator anim;

    public GameObject AttackRange;
    Collider2D AtkCol;

    //�s�@�����UI
    public GameObject HPBar;
    Slider HPSlider;


    public void getDamage(int damage)
    {
        this.currentHP -= damage;
        IfYouDie();
    }
    private void Awake()
    {
        AtkCol =AttackRange.GetComponent<Collider2D>();
        AttackRange.SetActive(false);
        this.currentHP = Max_hp;
        anim = GetComponent<Animator>();

        HPSlider = HPBar.GetComponent<Slider>();

    }

    private void FixedUpdate()
    {
        ///�˴��O�_���h�L�a��
        RaycastHit2D[] ray = Physics2D.RaycastAll(this.transform.position, Vector2.left,0.5f);
        anim.SetBool("FindSolider", false);
        foreach(var ray2 in ray)
        {
            if(ray2.collider.CompareTag("Solider"))
            {
                anim.SetBool("FindSolider" ,true);
                findSolider = true;
                break;
            }
            else
            {
                
                findSolider = false;
            }

           
        }



        ///�ĤH������
        if (!findSolider)
        {
            this.transform.parent.transform.position += Vector3.left * Time.fixedDeltaTime * speed;
        }

        UPdateHPUI();

    }

    public void AttackStart()
    {
        AttackRange.SetActive(true);
    }
    public void AttackEnd()
    {
        AttackRange.SetActive(false);
    }
    
    private void IfYouDie()
    {
        if (currentHP <= 0)
        {
            GameManager.Instance.EnemyKill++;
            Destroy(this.transform.parent.gameObject);
        }
    }

    private void UPdateHPUI()
    {
        HPSlider.value = (float)currentHP / Max_hp;
    }

    


}


