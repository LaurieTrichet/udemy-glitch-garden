using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class DefenderButton : MonoBehaviour
{
    private SpriteRenderer spriteRenderer = null;
    private DefenderButton[] siblings = null;
    private List<SpriteRenderer> siblingRenderers = null;
    private Color color;



    [SerializeField] DefenderSpawner defenderSpawner = null;
    [SerializeField] GameObject defenderPrefab = null;
    void Start()
    {
        siblings = FindObjectsOfType<DefenderButton>();
        siblingRenderers = siblings.Select(sibling => sibling.gameObject.GetComponent<SpriteRenderer>()).ToList();
        spriteRenderer = GetComponent<SpriteRenderer>();
        color = spriteRenderer.color;
    }

    private void OnMouseDown()
    {
        siblingRenderers.ForEach(siblingRenderer => siblingRenderer.color = color);

        spriteRenderer.color = Color.white;

        SelectDefender();
    }

    private void SelectDefender()
    {
        defenderSpawner.SetDefenderPrefab(defenderPrefab);
    }
}
