using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
public class SongSelector : MonoBehaviour
{
    public static SongSelector instance;
    private void Awake()
    {

        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public bool isPlayable
    {
        get
        {
            return (clip != null) && (songData != null) ? true : false;
        }
    }
    public VideoClip clip;
    public SongData songData;

    public void LoadSongData(string clipName)
    {
        Debug.Log($"Trying to load {clipName}");
        // 비디오 클립 로드
        clip = Resources.Load<VideoClip>($"VideoClips/{clipName}");
        
        // 노래 json 데이터 로드
        TextAsset songDataText = Resources.Load<TextAsset>($"SongDatas/{clipName}");

        // json 데이터 Deserialize
        songData = JsonUtility.FromJson<SongData>(songDataText.ToString());

    }
}
