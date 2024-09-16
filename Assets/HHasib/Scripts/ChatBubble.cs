using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ChatBubble : MonoBehaviour
{

    [SerializeField]private SpriteRenderer backGroundSpriteRenderer;
    [SerializeField]private TextMeshPro textMeshPro;
    [SerializeField] string sentence;

    private void Awake()
    {
        backGroundSpriteRenderer = gameObject.GetComponentInChildren<SpriteRenderer>();
        textMeshPro = gameObject.transform.GetChild(0).gameObject.GetComponentInChildren<TextMeshPro>();
    }
    private void Start()
    {
        Setup(sentence);
    }

    private void Setup(string Text)
    {
        textMeshPro.SetText(Text);
        textMeshPro.ForceMeshUpdate();
        Vector2 textSize = textMeshPro.GetRenderedValues(false);
        Vector2 padding = new Vector2(4f,2f);
        backGroundSpriteRenderer.size = textSize + padding;
    }


}
