using UnityEngine;

public class GlyphDetectiion : MonoBehaviour
{
    [SerializeField] Color32 solvedColor;
    [SerializeField] Color32 defaultColor;
    [SerializeField] SpriteRenderer glyphRef;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //store the original color of the glyph
        defaultColor = glyphRef.color;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            glyphRef.color = solvedColor;
            Debug.Log("Player has entered the glyph detection area.");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            glyphRef.color = defaultColor;
            Debug.Log("Player has exited the glyph detection area.");
        }
    }
}
