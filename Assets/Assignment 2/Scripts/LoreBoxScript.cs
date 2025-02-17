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

    bool revealingWindow = false;
    bool collapsingWindow = false;

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

        if (windowExpanded)
        {

            ExpandLoreWindow();

        }
        else if (windowCollapsed)
        {

            if (collapsingWindow)
            {

                ExpandedToCollapseLoreWindow();

            }else if (revealingWindow)
            {

                HiddenToCollapseLoreWindow();

            }

        }
        else if (windowHidden)
        {

            HideLoreWindow();

        }
               
    }

    public void ExpandButtonHandler()
    {

        SmoothInTime = 0;

        if (windowCollapsed)
        {
           
            windowExpanded = true;
            windowCollapsed = false;

            revealingWindow = true;
            collapsingWindow = false;

        }else if(windowHidden)
        {
            
            windowCollapsed = true;
            windowHidden = false;

            revealingWindow = false;
            collapsingWindow = true;

        }

    }

    public void CollapseButtonHandler()
    {

        SmoothInTime = 0;

        if (windowExpanded)
        {

            windowExpanded = false;
            windowCollapsed = true;

            collapsingWindow = true;
            revealingWindow = false;

        }else if (windowCollapsed)
        {
          
            windowCollapsed = false;
            windowHidden = true;

            collapsingWindow = false;
            revealingWindow = false;

        }

    }

    public void ExpandLoreWindow()
    {

        SmoothInTime += Time.deltaTime;

        LoreBoxSize.localScale = Vector3.Lerp(Vector3.one, expandedSize, SmoothInCurve.Evaluate(SmoothInTime));
        LoreBoxSize.position = Vector2.Lerp(windowCollapsedPos, windowExpandedPos, SmoothInCurve.Evaluate(SmoothInTime));

        ExpandButton.position = expandButtonExpandedPos;
        CollapseButton.position = collapseButtonExpandedPos;

    }

    public void ExpandedToCollapseLoreWindow()
    {

        SmoothInTime += Time.deltaTime;

        LoreBoxSize.localScale = Vector3.Lerp(expandedSize, Vector3.one, SmoothInCurve.Evaluate(SmoothInTime));
        LoreBoxSize.position = Vector2.Lerp(windowExpandedPos, windowCollapsedPos, SmoothInCurve.Evaluate(SmoothInTime));

        ExpandButton.position = expandbuttonCollapsedPos;
        CollapseButton.position = collapsebuttonCollapsedPos;

    }

    public void HiddenToCollapseLoreWindow()
    {

        SmoothInTime += Time.deltaTime;

        LoreBoxSize.position = Vector2.Lerp(windowHiddenPos, windowCollapsedPos, SmoothInCurve.Evaluate(SmoothInTime));

        LoreBoxSize.localScale = Vector3.one;

        ExpandButton.position = expandbuttonCollapsedPos;
        CollapseButton.position = collapsebuttonCollapsedPos;

    }

    public void HideLoreWindow()
    {

        SmoothInTime += Time.deltaTime;

        LoreBoxSize.localScale = Vector3.one;

        LoreBoxSize.position = Vector2.Lerp(windowCollapsedPos, windowHiddenPos, SmoothInCurve.Evaluate(SmoothInTime));

        //LoreBoxSize.position = windowHiddenPos;
        ExpandButton.position = expandbuttonHiddenPos;
        CollapseButton.position = collapsebuttonHiddenPos;

    }


}
