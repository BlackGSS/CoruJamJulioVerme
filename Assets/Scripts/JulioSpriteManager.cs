using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JulioSpriteManager : MonoBehaviour
{
    [SerializeField]
    private Image _julioImage;

    [SerializeField]
    private bool isThisNarrativa;

    // Start is called before the first frame update
    void Start()
    {
        if (isThisNarrativa)
        {
            //GEstion de en base a cansancio y en base a si consiguio la camisa o no (pa mañana sino)
        }
    }
    
}
