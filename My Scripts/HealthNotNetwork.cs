using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HealthNotNetwork : MonoBehaviour
{
    public const int maxHealth = 100;
    public RectTransform healthbar;
    public bool destroyOnDeath;
    public int thisHealth = 50;

    [SerializeField] Animator Anim;

    void Start()
    {

    }

    

    void Update()
    {
        healthbar.sizeDelta = new Vector2(thisHealth * 2, healthbar.sizeDelta.y);

        if(thisHealth < 1)
        {
            Anim.SetTrigger("Death");
        }
    }
}
