using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Clickable : MonoBehaviour, IPointerClickHandler, IPointerDownHandler,
    IPointerUpHandler, IPointerExitHandler, IPointerEnterHandler,
    IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Action clickedAction = () => { };
    public Action pointerEnterAction = () => { };
    public Action pointerExitAction = () => { };
    public Action pointerDownAction = () => { };
    public Action pointerUpAction = () => { };
    public Action beginDragAction = () => { };
    public Action onDragAction = () => { };
    public Action onEndDragAction = () => { };
    public Action rightClickedAction = () => { };

   
    public Image myImage = null;
    public Color originalColor = Color.white;
    public Color hoverColor = Color.red;
    public Color downColor = Color.blue;
    public Material meshMaterial;
    public List<Material> allMeshMaterials = new List<Material>();
    private List<Color> originalMaterialColors = new List<Color>();
    public bool active = true;

    public void OnBeginDrag(PointerEventData eventData)
    {
       if(active) beginDragAction();
    }

    public void OnDrag(PointerEventData eventData)
    {
       if(active) onDragAction();
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (active)
        {
            if (myImage != null)
            {

                myImage.color = originalColor;
            }
            if (meshMaterial != null) meshMaterial.color = originalColor; ChangeAllMeshMaterialsToOriginalColor();
            onEndDragAction();
        }
    }

    public void OnPointerClick(PointerEventData ed)
    {
        
        if(active) clickedAction();
    }
    bool rightclicked = false;
    public void OnPointerDown(PointerEventData eventData)
    {
        if (active)
        {
            if (myImage != null)
            {
                if (active) myImage.color = downColor;
            }
            if (meshMaterial != null) meshMaterial.color = downColor; ChangeAllMeshMaterialColors(downColor);
            pointerDownAction();


            if (Input.GetMouseButton(1))
            {
                rightclicked = true;
            }
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (active)
        {
            if (myImage != null)
            {
                myImage.color = hoverColor;
            }
            if (meshMaterial != null) meshMaterial.color = hoverColor; ChangeAllMeshMaterialColors(hoverColor);
            pointerEnterAction();
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (active)
        {
            if (myImage != null)
            {
                myImage.color = originalColor;
            }
            if (meshMaterial != null) meshMaterial.color = originalColor; ChangeAllMeshMaterialsToOriginalColor();
            pointerExitAction();
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (active)
        {
            if (myImage != null)
            {
                myImage.color = hoverColor;
            }

            if (meshMaterial != null) meshMaterial.color = hoverColor; ChangeAllMeshMaterialColors(hoverColor);

            if (!rightclicked)
            {
                pointerUpAction();
            }
            else
            {
                
                rightClickedAction();
                rightclicked = false;
            }
        }
    }

    public void SetImage(Image tmp)
    {
        myImage = tmp;
        originalColor = tmp.color;
    }


    private void ChangeAllMeshMaterialColors(Color colr)
    {
        for(int i = 0; i < allMeshMaterials.Count; i++)
        {

            allMeshMaterials[i].SetColor("_EmissionColor", colr);
            allMeshMaterials[i].EnableKeyword("_EMISSION");
   
        }
    }

    private void ChangeAllMeshMaterialsToOriginalColor()
    {

        for (int i = 0; i < allMeshMaterials.Count; i++)
        {

            allMeshMaterials[i].DisableKeyword("_EMISSION");
        
        }
    }
}
