using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SongSelectButton : MonoBehaviour
{
    public string clipName;
    public void OnClick()
    {
        SongSelector.instance.LoadSongData(clipName);
    }
}
