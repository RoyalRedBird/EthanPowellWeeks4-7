using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoreBoxScript : MonoBehaviour
{

    [SerializeField] RectTransform LoreBoxSize;
    [SerializeField] RectTransform ExpandButton;
    [SerializeField] RectTransform CollapseButton;

    bool windowCollapsed = true;
    bool windowExpanded = false;
    bool windowHidden = false;

    Vector3 expandedSize = new Vector3(4.5f, 1f, 1f);
    int buttonPartialPosX = 300;
    int buttonFullPosX = 1225;
    int buttonCollapsedPosX = 30;

    Vector2 windowExpandedPos;
    Vector2 windowCollapsedPos;
    Vector2 windowHiddenPos;

    Vector2 expandButtonExpandedPos;
    Vector2 expandbuttonCollapsedPos;
    Vector2 expandbuttonHiddenPos;

    Vector2 collapseButtonExpandedPos;
    Vector2 collapsebuttonCollapsedPos;
    Vector2 collapsebuttonHiddenPos;

    [SerializeField] AnimationCurve SmoothInCurve;
    float SmoothInTime = 0f;


    // Start is called before the first frame update
    void Start()
    {

        Vector2 windowExpandPos = LoreBoxSize.position;
        Vector2 windowCollapsePos = LoreBoxSize.position;
        Vector2 windowObscurePos = LoreBoxSize.position;

        windowExpandPos.x = Screen.width / 2;
        windowCollapsePos.x = 150;
        windowObscurePos.x = -400;

        windowExpandedPos = windowExpandPos;
        windowCollapsedPos = windowCollapsePos;
        windowHiddenPos = windowObscurePos;

        //

        Vector2 expBtnExpPos = ExpandButton.position;
        Vector2 expBtnColPos = ExpandButton.position;
        Vector2 expBtnHdnPos = ExpandButton.position;

        expBtnExpPos.x = buttonFullPosX;
        expBtnColPos.x = buttonPartialPosX;
        expBtnHdnPos.x = buttonCollapsedPosX;

        expandButtonExpandedPos = expBtnExpPos;
        expandbuttonCollapsedPos = expBtnColPos;
        expandbuttonHiddenPos = expBtnHdnPos;

        //

        Vector2 colBtnExpPos = CollapseButton.position;
        Vector2 colBtnColPos = CollapseButton.position;
        Vector2 colBtnHdnPos = CollapseButton.position;

        colBtnExpPos.x = buttonFullPosX;
        colBtnColPos.x = buttonPartialPosX;
        colBtnHdnPos.x = buttonCollapsedPosX;

        collapseButtonExpandedPos = colBtnExpPos;
        collapsebuttonCollapsedPos = colBtnColPos;
        collapsebuttonHiddenPos = colBtnHdnPos;

    }

    // Update is called once per frame
    void Update()
    {

               
    }

    public void ExpandButtonHandler()
    {

        if (windowCollapsed)
        {

            ExpandLoreWindow();
            windowExpanded = true;
            windowCollapsed = false;

        }else if(windowHidden)
        {

            CollapseLoreWindow();
            windowCollapsed = true;
            windowHidden = false;

        }

    }

    public void CollapseButtonHandler()
    {

        if (windowExpanded)
        {

            CollapseLoreWindow();
            windowExpanded = false;
            windowCollapsed = true;

        }else if (windowCollapsed)
        {

            HideLoreWindow();
            windowCollapsed = false;
            windowHidden = true;

        }

    }

    public void ExpandLoreWindow()
    {

        LoreBoxSize.localScale = expandedSize;

        LoreBoxSize.position = windowExpandedPos;
        ExpandButton.position = expandButtonExpandedPos;
        CollapseButton.position = collapseButtonExpandedPos;

    }

    public void CollapseLoreWindow()
    {

        LoreBoxSize.localScale = Vector3.one;

        LoreBoxSize.position = windowCollapsedPos;
        ExpandButton.position = expandbuttonCollapsedPos;
        CollapseButton.position = collapsebuttonCollapsedPos;

    }

    public void HideLoreWindow()
    {

        LoreBoxSize.localScale = Vector3.one;

        LoreBoxSize.position = windowHiddenPos;
        ExpandButton.position = expandbuttonHiddenPos;
        CollapseButton.position = collapsebuttonHiddenPos;

    }


}
