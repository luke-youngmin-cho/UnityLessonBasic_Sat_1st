using UnityEngine;
public class Player : MonoBehaviour
{
    public static Player instance;

    private void Awake() =>
        instance = this;

    public void Move(Vector3 target) =>
        transform.position = target;
}