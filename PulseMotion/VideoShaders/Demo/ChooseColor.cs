using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChooseColor : MonoBehaviour
{
    [SerializeField] Camera camera;

    public void ChangeColorWall()
    {
        camera.backgroundColor = gameObject.GetComponent<Image>().color;
    }
}
