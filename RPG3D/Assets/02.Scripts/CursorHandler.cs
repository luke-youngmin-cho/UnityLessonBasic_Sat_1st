using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class CursorHandler : MonoBehaviour
{
    public static bool controllable = true;
    private GraphicRaycaster _graphicRaycaster;
    private PointerEventData _pointerEventData;
    private EventSystem _eventSystem;

    public static void ShowCursor()
    {
        if (Cursor.visible == false)
            Cursor.visible = true;

        if (Cursor.lockState != CursorLockMode.Confined)
            Cursor.lockState = CursorLockMode.Confined;
    }

    public static void HideCursor()
    {
        if (Cursor.visible)
            Cursor.visible = false;

        if (Cursor.lockState != CursorLockMode.Locked)
            Cursor.lockState = CursorLockMode.Locked;
    }

    private void Awake()
    {
        _graphicRaycaster = GetComponent<GraphicRaycaster>();
        _eventSystem = GetComponent<EventSystem>();
    }

    private void Update()
    {
        if (controllable)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                _pointerEventData = new PointerEventData(_eventSystem);
                _pointerEventData.position = Input.mousePosition;

                List<RaycastResult> results = new List<RaycastResult>();
                _graphicRaycaster.Raycast(_pointerEventData, results);

                // UI Ä³½ºÆÃµÊ
                if (results.Count > 0)
                    ShowCursor();
                else
                    HideCursor();
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape))
            ShowCursor();
    }
}
