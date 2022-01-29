using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(PlayerNav))]
public class PlayerController : MonoBehaviour
{
    Camera camera_main;
    PlayerNav navigator;

    public Interactable focus;

    // Layer for the ground/walkable
    int layermask = 1 << 7;
    void Start()
    {
        camera_main = Camera.main;
        navigator = GetComponent<PlayerNav>();
    }

    // Update is called once per frame
    void Update()
    {

        // Don't click to move if the UI is open
        if (EventSystem.current.IsPointerOverGameObject()) {return;}

        if (Input.GetMouseButtonDown(0)) {
            Ray ray = camera_main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit)) {
                UnityEngine.Debug.Log("Moving to point: " +  hit.collider.name + " " + hit.point);
                LookAway();
                navigator.navigate(hit.point);
            }

        }

        if (Input.GetMouseButtonDown(1)) {
            Ray ray = camera_main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100)) {
                Interactable interactable = hit.collider.GetComponent<Interactable>();
                if (interactable != null) {
                    LookAt(interactable);
                }
            }

        }
    }

    void LookAt(Interactable _interactable)
    {
        if (_interactable != focus) {
            if (focus != null) {focus.OnDefocused();}
            focus = _interactable;
            navigator.FollowTarget(_interactable);
        }

        _interactable.OnFocused(transform);

    }

    void LookAway()
    {
        if (focus != null) {
            focus.OnDefocused();
        }

        focus = null;
        navigator.StopFollow();
    }
}
