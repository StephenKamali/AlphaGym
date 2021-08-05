using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class SpriteResizer : MonoBehaviour
{
    Texture sprite;

    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<MeshRenderer>().sharedMaterial.mainTexture;
        transform.localScale = new Vector3(sprite.width * 0.02f, sprite.height * 0.02f, 1.0f);
    }
}
