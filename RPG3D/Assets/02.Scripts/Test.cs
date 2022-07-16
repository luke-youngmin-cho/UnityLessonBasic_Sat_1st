using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        List<int> list = new List<int>();
        LinkedList<GameObject> go = new LinkedList<GameObject>();   
        Dictionary<string, GameObject> map = new Dictionary<string, GameObject>();  

        ArrayList arrayList = new ArrayList();
        arrayList.Add((object)3); // ¹Ú½Ì
        arrayList.Add(new Object());
        int a = (int)arrayList[0]; // ¾ð¹Ú½Ì

        Hashtable hashtable = new Hashtable();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
