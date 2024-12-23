using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class PlaceHolder : MonoBehaviour
    {
        private Renderer objectRenderer;
        private Color originalColor;
        private Color hoverColor; // Change this to your desired hover color
        private Color clickedColor = Color.yellow;// Change this to your desired clicked color
        private bool isClicked = false;
        public static GameObject selectedPlace;

        void Start()
        {
            // Get the Renderer component to change the object's color
            objectRenderer = GetComponent<Renderer>();
            hoverColor = new Color(0.7626768f, 0.8339623f, 0f, 0.7019608f);

            // Store the original color of the object
            if (objectRenderer != null)
            {
                originalColor = objectRenderer.material.color;
            }
        }


        void OnMouseEnter()
        {
            if ((!isClicked && objectRenderer != null) && !MenuManager.isUnitMenuActive)
            {
                // Change color when hovering
                objectRenderer.material.color = hoverColor;
            }
        }

        void OnMouseExit()
        {
            if (!isClicked && objectRenderer != null)
            {
                // Revert to the original color when not hovering
                ChangeOriginal();
            }
        }

        void OnMouseDown()
        {
            if (objectRenderer != null && !MenuManager.isUnitMenuActive)
            {
                // Change to clicked color and lock the state
                SelectPlace();
            }
        }

        public void SelectPlace()
        {
            objectRenderer.material.color = clickedColor;
            isClicked = true;
            MenuManager.MenuManagerInstance.ShowUnitMenu();
            selectedPlace = gameObject;
        }

        public void ChangeOriginal()
        {
            objectRenderer.material.color = originalColor;
            isClicked = false;
        }
    }
}