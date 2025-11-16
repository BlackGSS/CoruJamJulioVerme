using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class JulioSpriteManager : MonoBehaviour
{
    [SerializeField]
    private Image _julioImage;

    [SerializeField]
    private GameObject _accesoriesImagePrefab;

    [SerializeField]
    private Transform _accesoriesReferencePoint;

    [SerializeField]
    private JulioSpritesScriptable _julioSprites;
    [SerializeField]
    private AccesoriesScriptable[] _accesories;

    [SerializeField]
    private bool isThisNarrativa;

    void Start()
    {
        if (isThisNarrativa)
        {
            _julioImage.sprite = _julioSprites.narrativeSprites[Player.combatRound];

            var accesoriesDictionary = _accesories.ToDictionary(x => x.accesory);
			for (int i = 0; i < Player.Accesories.Count; i++)
			{
                Image newImage = Instantiate(_accesoriesImagePrefab, _accesoriesReferencePoint).GetComponent<Image>();
                newImage.sprite = accesoriesDictionary[Player.Accesories[i]].spriteFront;
            }
        }
    }

    public void UpdateCombatSprites()
    {
        _julioImage.sprite = _julioSprites.combatSprite;

        var accesoriesDictionary = _accesories.ToDictionary(x => x.accesory);
        for (int i = 0; i < Player.Accesories.Count; i++)
        {
            Image newImage = Instantiate(_accesoriesImagePrefab, _accesoriesReferencePoint).GetComponent<Image>();
            newImage.sprite = accesoriesDictionary[Player.Accesories[i]].spriteBack;
        }
    }
}