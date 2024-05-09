using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class checkboxScript : MonoBehaviour
{
    public TextMeshProUGUI modalTextObject;

    public void changetextFirst()
    {
        // Get the current text
        string currentText = modalTextObject.text;

        // Find the index of the sentence "Wear a pair of Latex Gloves" in the text
        int index = currentText.IndexOf("Wear a pair of Latex Gloves");

        // If the sentence is found
        if (index != -1)
        {
            // Apply strikethrough to the sentence
            string newText = currentText.Insert(index, "<s>").Insert(index + 30, "</s>");

            // Update the text with the strikethrough applied
            modalTextObject.text = newText;
        }
    }
    public void changetextSecond()
    {
        // Get the current text
        string currentText = modalTextObject.text;

        // Find the index of the sentence "Wear a pair of Latex Gloves" in the text
        int index = currentText.IndexOf("Wear a Lab Coat");

        // If the sentence is found
        if (index != -1)
        {
            // Apply strikethrough to the sentence
            string newText = currentText.Insert(index, "<s>").Insert(index + 18, "</s>");

            // Update the text with the strikethrough applied
            modalTextObject.text = newText;
        }
    }

    public void changetextThird()
    {
        // Get the current text
        string currentText = modalTextObject.text;

        // Find the index of the sentence "Wear a pair of Latex Gloves" in the text
        int index = currentText.IndexOf("Wear a pair of Goggles");

        // If the sentence is found
        if (index != -1)
        {
            // Apply strikethrough to the sentence
            string newText = currentText.Insert(index, "<s>").Insert(index + 25, "</s>");

            // Update the text with the strikethrough applied
            modalTextObject.text = newText;
        }
    }
}
