using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum expState { drop, get }
public class EXPObject : MonoBehaviour
{
    private expState state;

    [SerializeField]
    private LayerMask playerMask;

    private float checkRadius = 3.5f;

    private int expPoint = 10;

    private PlayerController player = null;

    private Coroutine dropEXP = null;

    private YieldInstruction destroyTimer = new WaitForSeconds(5f);

    private Vector3 firstPosition;

    private float lerp = 0f;

    private void Awake()
    {
        state = expState.drop;
        firstPosition = transform.position;
    }
    private void Start()
    {
        dropEXP = StartCoroutine(DropEXP());
    }

    private void Update()
    {
        switch (state)
        {
            case expState.drop:
                CheckPlayer();
                break;
            case expState.get:
                PlayerGetEXP();
                break;
        }
    }

    private void CheckPlayer()
    {
        Collider[] col = Physics.OverlapSphere(transform.position, checkRadius, playerMask);

        if (col.Length == 0)
            return;
        else
        {
            player = col[0].gameObject.GetComponentInParent<PlayerController>();
            state = expState.get;
            StopCoroutine(dropEXP);
            dropEXP = null;
        }
    }

    private void PlayerGetEXP()
    {
        lerp = Mathf.Clamp01(lerp +  (2 * Time.deltaTime));
        transform.position = Vector3.Lerp(firstPosition, player.gameObject.transform.position, lerp);
    }

    private IEnumerator DropEXP()
    {
        yield return destroyTimer;
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            other.gameObject.GetComponentInParent<PlayerController>().EXPUp(expPoint);

            Destroy(gameObject, 0.1f);
        }
    }
}
