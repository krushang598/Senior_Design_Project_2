/*
    When the player touches the walls,
    Add popups or menus at line 56

    When level pass,
    line 63
*/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float moveSpeed = 100f;
    public string loadNextSceneName;
    public string loadGameOverScene;


    private Vector3 mousePosition;
    private Rigidbody2D rb;
    private Vector2 direction;
    private bool start = false;
    private bool movementDisable;

    void Awake(){
        movementDisable = false;
        Kill.onKill += onTouch;
        PassLevel.onPass += onLevelPass;
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {   
        if(movementDisable) return;

        if(Input.GetMouseButton(0) && start == false) start = true;
        
        if(start == true ){
            mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            direction = (mousePosition - transform.position).normalized;
            rb.velocity = new Vector2(direction.x * moveSpeed, direction.y * moveSpeed);
        }
    }

    void onTouch(){
        Debug.Log("Touch!");
        movementDisable = true;
        rb.velocity = Vector2.zero;
        SceneManager.LoadScene(loadGameOverScene);
    }

    void onLevelPass(){
        Debug.Log("Level pass!");
        
        //load next level;
        // or display option
        //Scene scene = SceneManager.GetActiveScene();

        SceneManager.LoadScene(loadNextSceneName);
       

    }

    void OnDestroy() {
        Kill.onKill -= onTouch;
    }
}
