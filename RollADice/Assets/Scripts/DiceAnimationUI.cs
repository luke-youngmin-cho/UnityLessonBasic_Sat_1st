using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DiceAnimationUI : MonoBehaviour
{
    public static DiceAnimationUI instance;
    private void Awake()
    {
        instance = this;
    }

    public Image diceAnimationImage;   
    public float diceAnimationTime;
    private Sprite[] sprites;

    public delegate void AnimationFinshedEvent(int diceValue);

    private void Start()
    {
        sprites = Resources.LoadAll<Sprite>("DiceVectorDark");
    }

    public IEnumerator E_DiceAnimation(int diceValue, DicePlayManager manager, AnimationFinshedEvent finishEvent)
    {
        float elapsedTime = 0;
        while (elapsedTime < diceAnimationTime)
        {
            elapsedTime += diceAnimationTime / 10;
            int tmpIdx = Random.Range(0, sprites.Length);
            diceAnimationImage.sprite = sprites[tmpIdx];
            yield return new WaitForSeconds(diceAnimationTime / 10);
        }
        diceAnimationImage.sprite = sprites[diceValue - 1];

        if(finishEvent != null)
            finishEvent(diceValue);

        manager.animationCoroutine = null;
    }




}
