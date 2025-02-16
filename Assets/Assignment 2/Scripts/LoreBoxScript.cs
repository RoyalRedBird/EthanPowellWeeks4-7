using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoreBoxScript : MonoBehaviour
{

    [SerializeField] RectTransform LoreBoxSize;
    [SerializeField] RectTransform ExpandButton;
    [SerializeField] RectTransform CollapseButton;

    Vector3 expandedSize = new Vector3(4.5f, 1f, 1f);
    int buttonPartialPosX = 300;
    int buttonFullPosX = 1225;
    int buttonCollapsedPosX = 30;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

               
    }

    public void ExpandLoreWindow()
    {

        LoreBoxSize.localScale = expandedSize;

        Vector2 boxPos = LoreBoxSize.position;
        Vector2 expPos = ExpandButton.position;
        Vector2 colPos = CollapseButton.position;

        boxPos.x = Screen.width / 2;
        boxPos.y = 0;

        LoreBoxSize.anchoredPosition = boxPos;

        expPos.x = buttonFullPosX;
        colPos.x = buttonFullPosX;

        ExpandButton.position = expPos;
        CollapseButton.position = colPos;

    }

    public void CollapseLoreWindow()
    {

        LoreBoxSize.localScale = Vector3.one;

        Vector2 boxPos = LoreBoxSize.position;
        Vector2 expPos = ExpandButton.position;
        Vector2 colPos = CollapseButton.position;

        boxPos.x = 150;
        boxPos.y = 0;

        LoreBoxSize.anchoredPosition = boxPos;

        expPos.x = buttonPartialPosX;
        colPos.x = buttonPartialPosX;

        ExpandButton.position = expPos;
        CollapseButton.position = colPos;

    }

}
