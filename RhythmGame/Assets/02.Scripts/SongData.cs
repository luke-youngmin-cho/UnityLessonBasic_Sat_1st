using System.Collections.Generic;

[System.Serializable]
public class SongData
{
    public string videoName; // 뮤직비디오 이름
    public List<NoteData> notes; // 노트들

    public SongData()
    {
        notes = new List<NoteData>();
    }
}