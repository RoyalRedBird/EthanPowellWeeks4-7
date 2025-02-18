using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LoreBoxScript : MonoBehaviour
{

    //The RectTransforms of the Lore Box and accompanying expand/collapse buttons.
    [SerializeField] RectTransform LoreBoxSize;
    [SerializeField] RectTransform ExpandButton;
    [SerializeField] RectTransform CollapseButton;

    //The gameObjects for the collapsed text entry and the full text entry.
    [SerializeField] GameObject CollapsedText;
    [SerializeField] GameObject FullText;

    //Bools to check if the collapsed and full text entires are being actively hidden or shown.
    bool hidingCollapsedText = false;
    bool showingCollapsedText = true;

    bool hidingFullText = true;
    bool showingFullText = false;

    //Bools used by the expand and collapse managers to determine which state to transition the lore box
    //into when the buttons are clicked.
    bool windowCollapsed = true;
    bool windowExpanded = false;
    bool windowHidden = false;

    //Bools used to check if the window is being revealed or being collapsed.
    //Used to gradually expand or shrink the window as it moves.
    bool revealingWindow = false;
    bool collapsingWindow = false;

    //Used to stretch the lore window when expanded.
    Vector3 expandedSize = new Vector3(4.5f, 1f, 1f);

    //Used to position the expand/collapse buttons when the window moves.
    int buttonPartialPosX = 300;
    int buttonFullPosX = 1260;
    int buttonCollapsedPosX = 30;

    //The positions of the lore window in its various states, configured in the start method.
    Vector2 windowExpandedPos;
    Vector2 windowCollapsedPos;
    Vector2 windowHiddenPos;

    //The positions of the expand button, configured in the start method.
    Vector2 expandButtonExpandedPos;
    Vector2 expandbuttonCollapsedPos;
    Vector2 expandbuttonHiddenPos;

    //The positions of the collapse button, configured in the start method.
    Vector2 collapseButtonExpandedPos;
    Vector2 collapsebuttonCollapsedPos;
    Vector2 collapsebuttonHiddenPos;

    //Animation curve used in conjuction with Lerps for smooth movement of the lore panel.
    //SmoothInTime is evaluated against the curve when working with the curve.
    [SerializeField] AnimationCurve SmoothInCurve;
    float SmoothInTime = 0f;

    //The delay between the expand/collape button being pressed and the text being displayed.
    float revealDelayTime = 1.5f;

    // Start is called before the first frame update
    void Start()
    {

        //Grabs the starting position of the window and splits it into three different positions for the
        //three different states it is expected to be in.

        Vector2 windowExpandPos = LoreBoxSize.position;
        Vector2 windowCollapsePos = LoreBoxSize.position;
        Vector2 windowObscurePos = LoreBoxSize.position;

        windowExpandPos.x = Screen.width / 2;
        windowCollapsePos.x = 150;
        windowObscurePos.x = -400;

        windowExpandedPos = windowExpandPos;
        windowCollapsedPos = windowCollapsePos;
        windowHiddenPos = windowObscurePos;

        //Grabs the starting position of the expand button and splits it into three different positions for the
        //three different states it is expected to be in.
        //It also uses the buttonPos ints to set button locations.

        Vector2 expBtnExpPos = ExpandButton.position;
        Vector2 expBtnColPos = ExpandButton.position;
        Vector2 expBtnHdnPos = ExpandButton.position;

        expBtnExpPos.x = buttonFullPosX;
        expBtnColPos.x = buttonPartialPosX;
        expBtnHdnPos.x = buttonCollapsedPosX;

        expandButtonExpandedPos = expBtnExpPos;
        expandbuttonCollapsedPos = expBtnColPos;
        expandbuttonHiddenPos = expBtnHdnPos;

        //Grabs the starting position of the collapse button and splits it into three different positions for the
        //three different states it is expected to be in.
        //It also uses the buttonPos ints to set button locations.

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

        //The following amalgamation of If and Else If statements handles the movement and
        //resizing of the lore window.
        
        if (windowExpanded)//If the window has been set to its expanded state...
        {

            //Expand the lore window and reveal the full lore text.
            ExpandLoreWindow();
            RevealFullText();

        }
        else if (windowCollapsed) //Otherise, if the window has been set to collapsed.
        {

            if (collapsingWindow) //and the window is collapsing... (Going from full to collapsed.)
            {

                //Shrink and move the lore window.
                ExpandedToCollapseLoreWindow();

            }else if (revealingWindow) //or if the window is being revealed... (Going from hidden to collapsed.)
            {

                //Move the lore window back onto the screen.
                HiddenToCollapseLoreWindow();

            }

            //Reveal the collapsed text entry.
            RevealCollapsedText();

        }
        else if (windowHidden) //Or if the window is being hidden.
        {

            //Hide the text and the window.
            HideText();
            HideLoreWindow();

        }
               
    }


    void RevealFullText() //Hides the collapsed text and reveals the full text entry after a brief waiting period.
    {

        CollapsedText.SetActive(false);

        revealDelayTime -= Time.deltaTime;

        if(revealDelayTime <= 0)
        {

            FullText.SetActive(true);

        }

    }

    void RevealCollapsedText() //Hides the full text and reveals the collapsed text entry after a brief waiting period.
    {

        FullText.SetActive(false);

        revealDelayTime -= Time.deltaTime;

        if (revealDelayTime <= 0)
        {

            CollapsedText.SetActive(true);

        }

    }

    void HideText() //Hides all the text when the window is hidden.
    {

        FullText.SetActive(false);
        CollapsedText.SetActive(false);

    }

    public void ExpandButtonHandler() //Handles what to do with the window when the expand button is pressed.
    {

        //Reset the smoothInTime and the delay timer.
        SmoothInTime = 0;
        revealDelayTime = 1.5f;

        if (windowCollapsed) //If the window was collapsed when the expand button was pressed...
        {
           
            //Set the window as being expanded.
            windowExpanded = true;
            windowCollapsed = false;

            //Displays the full text.
            showingFullText = true;
            hidingFullText = false;

            //Hides the collapsed text.
            showingCollapsedText = false;
            hidingCollapsedText = true;

        }else if(windowHidden) //If the window was hidden when the expand button was pressed...
        {
            
            //Set the window to to collapsed.
            windowCollapsed = true;
            windowHidden = false;

            //Tell the script the window is going from hidden to collapsed.
            revealingWindow = true;
            collapsingWindow = false;

            //Keep the full text hidden.
            showingFullText = false;
            hidingFullText = true;

            //Show the collapsed text.
            showingCollapsedText = true;
            hidingCollapsedText = false;

        }

    }

    public void CollapseButtonHandler() //Handles what to do with the window when the collapse button is pressed.
    {

        //Reset the smoothInTime and the delay timer.
        SmoothInTime = 0;
        revealDelayTime = 1.5f;

        if (windowExpanded) //If the window was expanded when the collapse button was pressed...
        {

            //Set the window to be collapsed.
            windowExpanded = false;
            windowCollapsed = true;

            //Tell the script the window is going from expanded to collapsed.
            collapsingWindow = true;
            revealingWindow = false;

            //Hide the full text.
            showingFullText = false;
            hidingFullText = true;

            //Show the collapsed text.
            showingCollapsedText = false;
            hidingCollapsedText = true;

        }
        else if (windowCollapsed) //If the window was collapsed when the collapse button was pressed...
        {
          
            //Set the window to hidden/
            windowCollapsed = false;
            windowHidden = true;

            //Hide all the text.
            showingFullText = false;
            hidingFullText = true;

            showingCollapsedText = false;
            hidingCollapsedText = true;

        }

    }

    //The following four methods are all similar in their function as they are designed to move and scale the
    //lore window around with the expand and collapse buttons are clicked. When either button is clicked and the
    //Expand/Collapse button handler flicks the bools around, the update method switches which function is in use.
    //Each function works as follows.

    //Increase the SmoothInTime by deltaTime.
    //Horizontally stretches or squishes the lore window depending on if it was collapsed or fully open. Lerped with AnimCurves to make it smooth.
    //Lerps the window between its last position and its new position, also using the SmoothInTime variable and animCurve.
    //Sets the expand and collapse buttons to their appropriate position.

    //In cases where the window does not need to be expanded, the scale is set to Vector3.one and left at that.

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

        ExpandButton.position = expandbuttonHiddenPos;
        CollapseButton.position = collapsebuttonHiddenPos;

    }


}
