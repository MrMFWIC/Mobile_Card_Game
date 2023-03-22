using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(Animator))]
public class Coin : MonoBehaviour
{
    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void Player1Flip()
    {
        anim.SetTrigger("CoinFlipP1");
    }

    public void Player2Flip()
    {
        anim.SetTrigger("CoinFlipP2");
    }
}
