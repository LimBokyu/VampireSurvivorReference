using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum flashType { player, enemy }

public class HitFlash : MonoBehaviour
{
    [SerializeField]
    private flashType type;

    private Color flashColor;
    private Color[] originColor;

    [SerializeField]
    private Renderer[] rend;

    [SerializeField]
    private float flashTime = 0.1f;
    private Coroutine flashCoroutine = null;

    private void Awake()
    {
        rend = GetComponentsInChildren<Renderer>();
        originColor = new Color[rend.Length];

        SetFlashColor();
    }

    private void SetFlashColor()
    {
        switch (type)
        {
            case flashType.player:
                flashColor = Color.red;
                break;
            case flashType.enemy:
                flashColor = Color.gray;
                break;

        }

        for(int i=0; i<rend.Length; i++)
        {
            originColor[i] = rend[i].material.color;
        }
    }

    public void Flash()
    {
        if (flashCoroutine != null)
        {
            StopCoroutine(flashCoroutine);
        }

        flashCoroutine = StartCoroutine(FlashCoroutine());
    }
    
    private IEnumerator FlashCoroutine()
    {
        foreach (Renderer rend in rend)
        {
            rend.material.color = flashColor;
        }

        yield return new WaitForSeconds(flashTime);

        for(int i =0; i< rend.Length; i++)
        {
            rend[i].material.color = originColor[i];
        }

        flashCoroutine = null;
    }
}
