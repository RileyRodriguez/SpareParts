using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonInteract : MonoBehaviour {

    [SerializeField] private GameObject displayed;
    private GameObject trig;
    private bool searched=false;

    public GameObject UIElement;

    void Start()
    {
        displayed.SetActive(false);
    }

    void Update()
    {
        if (trig != null && searched==false)
        {
            if (UIElement != null)
            {
                UIElement.SetActive(true);
            }
            if (Input.GetButtonDown("Teleport"))
            {
                displayed.SetActive(true);
                UIElement.SetActive(false);
                searched = true;
            }
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.tag.Equals("Player"))
        {
            trig = null;
            UIElement.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag.Equals("Player"))
        {
            trig = collision.gameObject;
        }
    }

}
