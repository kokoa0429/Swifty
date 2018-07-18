using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseHoverController : MonoBehaviour {

    private void OnMouseEnter()
    {
        this.transform.localScale = this.transform.localScale * 1.25f;
    }

    private void OnMouseExit()
    {
        this.transform.localScale = this.transform.localScale * 0.8f;
    }

}
