using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeIndicator : MonoBehaviour
{
    MeshRenderer mesh;
    void Start()
    {
        mesh = GetComponent<MeshRenderer>();
    }
    void Update()
    {
        if (PlayerController.Instance.preppedSpell == null) {
            mesh.enabled = false;
            return;
        }
        else if (mesh.enabled == false) mesh.enabled = true;
        float diameter = PlayerController.Instance.preppedSpell.SpellToCast.splashRadius * 2;
        transform.localScale = new Vector3(diameter, 0.5f, diameter);
        transform.position = Utils.CalculateMousePosition();
    }
}
