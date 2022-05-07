using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteAssets : MonoBehaviour
{
    private static NoteAssets _instance;
    public static NoteAssets Instance
    {
        get
        {
            if (_instance == null)
                _instance = Instantiate(Resources.Load<NoteAssets>("NoteAssets"));
            return _instance;
        }
    }

    public List<Note> notes = new List<Note>();

    public static Note GetNote(KeyCode keyCode) =>
        Instance.notes.Find(x => x.keyCode == keyCode);




}
