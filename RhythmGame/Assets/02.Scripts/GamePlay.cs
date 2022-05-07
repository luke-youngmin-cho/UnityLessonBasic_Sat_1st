using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
public class GamePlay : MonoBehaviour
{
    public static GamePlay instance;

    [SerializeField] private VideoPlayer vp;

    public void Play()
    {
        if (SongSelector.instance != null &&
            SongSelector.instance.isPlayable)
            StartCoroutine(E_Play());
    }

    private IEnumerator E_Play()
    {
        NoteManager.instance.StartSpawn();
        yield return new WaitForEndOfFrame();
        yield return new WaitForSeconds(NoteManager.instance.noteFallingTime);
        vp.clip = SongSelector.instance.clip;
        vp.Play();
    }

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        Play();
    }
}
