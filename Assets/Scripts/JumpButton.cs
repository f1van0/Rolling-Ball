using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class JumpButton : MonoBehaviour, IPointerClickHandler
{
    public BallController ball;

    public void OnPointerClick(PointerEventData eventData)
    {
        ball.Jump();
    }

    // Start is called before the first frame update
    void Start()
    {
        ball = FindObjectOfType<BallController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
	
}
