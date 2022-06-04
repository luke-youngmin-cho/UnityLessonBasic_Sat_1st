using System.Collections; 
using System.Collections.Generic;
using UnityEngine;

public class ModelAnimationTest : MonoBehaviour
{
    public Animator animator;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            DoRandomAnimation();
    }

    public void DoRandomAnimation()
    {
        var ac = animator.runtimeAnimatorController;

        int random = Random.Range(0, ac.animationClips.Length);
        //animator.Play(ac.animationClips[random]);
        
    }
}
