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

        transform.localScale = new Vector3(PlayerController.Instance.preppedSpell.splashRange * 2, 0.5f, PlayerController.Instance.preppedSpell.splashRange * 2);
        transform.position = Utils.CalculateMousePosition();
    }
}
