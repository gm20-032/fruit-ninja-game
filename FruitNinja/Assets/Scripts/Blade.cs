using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blade : MonoBehaviour
{
    [SerializeField] private GameObject bladeTrailPrefab;
    [SerializeField] private float minCuttingVelocity = .001f;
    private bool isCutting = false;

    private Vector2 previousPosition;
    private GameObject currentBladeTrail;

    private Rigidbody2D rb;
    [SerializeField] private Camera cam;
    private CircleCollider2D circleCollider;

    //[SerializeField] private AudioSource audioSrc;
    [SerializeField] private AudioClip sliceSound;
    void Start(){
        cam = Camera.main;
        rb = this.GetComponent<Rigidbody2D>();
        circleCollider = GetComponent<CircleCollider2D>();

    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            StartCutting();
        } else if (Input.GetMouseButtonUp(0))
        {
            StopCutting();
        }

        if(isCutting)
        {
            UpdateCut();
        }
    }
    void UpdateCut()
    {
        Vector2 newPosition = cam.ScreenToWorldPoint(Input.mousePosition);
        this.transform.position = newPosition;

        float velocity = (newPosition - previousPosition).magnitude / Time.deltaTime;
        if (velocity > minCuttingVelocity)
        {
            circleCollider.enabled = true;
            SoundManager.Instance.PlaySfx(sliceSound);
        }
        else
        {
            circleCollider.enabled = false;
        }

        previousPosition = newPosition;

    }
    void StartCutting()
    {
        isCutting = true;
        currentBladeTrail = Instantiate(bladeTrailPrefab, transform);
        previousPosition = cam.ScreenToWorldPoint(Input.mousePosition);
        circleCollider.enabled = false;
    }

    void StopCutting()
    {
        isCutting = false;
        currentBladeTrail.transform.SetParent(null);
        Destroy(currentBladeTrail, 2f);
        circleCollider.enabled = false;
    }
}
