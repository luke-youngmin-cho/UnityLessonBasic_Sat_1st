using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    public Item item;
    private bool isPickedUp;

    [Header("Floating Effect")]
    public bool doFloatingEffect = true;
    public float floatingSpeed = 1.5f;
    public float floatingHeight = 0.2f;

    [Header("PickUp Effect")]
    public float pickUpSpeed = 5f;

    [Header("Dropping Effect")]
    public float popForce = 1f;
    public float rotateSpeed = 1f;

    [Header("Kinematics")]
    private Rigidbody rb;
    private BoxCollider col;

    public LayerMask groundLayer;
    public Transform rendererTransform;
    private Vector3 rendererOffset;
    private Vector3 rendererAngle;
    private float elapsedFixedTime;

    //=================================================
    //***************** Public Methods ****************
    //=================================================

    public virtual void PickUp(Player player)
    {
        if (isPickedUp)
            return;

        InventoryModel.instance.AddItemData(item);
        isPickedUp = true;
        Debug.Log($"{player.name} 이 아이템 {tag} 를 획득했습니다!");
        StartCoroutine(E_PickUpEffect(player));
    }

    //=================================================
    //***************** Private Methods ***************
    //=================================================

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        col = GetComponent<BoxCollider>();
        rendererOffset = rendererTransform.localPosition;
        rendererAngle = rendererTransform.localEulerAngles;
    }

    private void FixedUpdate()
    {
        if (doFloatingEffect)
            Floating();
    }

    private void Floating()
    {
        rendererTransform.localPosition = rendererOffset +
                                          new Vector3(0f,
                                                      floatingHeight * Mathf.Sin(floatingSpeed * elapsedFixedTime),
                                                      0f);
        elapsedFixedTime += Time.fixedDeltaTime;
    }

    private IEnumerator E_PickUpEffect(Player player)
    {
        doFloatingEffect = false;
        rb.velocity = Vector3.zero;
        rb.useGravity = false;

        bool isReachedToPlayer = false;

        Vector3 playerOffset = Vector3.up * player.GetComponent<CapsuleCollider>().height / 2;
        Vector3 targetPos = player.transform.position + playerOffset;
        while (isReachedToPlayer == false)
        {
            float distance = Vector3.Distance(player.transform.position + playerOffset, rb.position);
            // 아이템이 플레이어한테 도달함
            if (distance < 0.2f)
            {
                isReachedToPlayer = true;
                rb.velocity = Vector3.zero;
                break;
            }

            Vector3 moveVec = (player.transform.position + playerOffset - rb.position) * pickUpSpeed;
            rb.MovePosition(rb.position + moveVec * Time.deltaTime);
            yield return null;
        }
        Destroy(gameObject);
    }
}
