using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tileScript : MonoBehaviour
{
    private int state;
    private int content;
    private int cooldown;

    void Start()
    {
        state = 0;
        content = 0;
    }

    void Update()
    {
        if(state == 3){
            if(cooldown < 20){
                cooldown--;
            } else {
                //spread infection TO DO
            }
        }
    }

    public void setState(int state)
    {
        if(this.state != state){
            if (this.state == 3)
                cooldown = 0;
            if (this.state != 0)
                this.transform.GetChild(0).GetChild(this.state-1).gameObject.SetActive(false);
            if (state != 0)
                this.transform.GetChild(0).GetChild(state-1).gameObject.SetActive(true);
            if ((state == 0 || state == 3) && content != 0){
                this.transform.GetChild(1).GetChild(content-1).gameObject.SetActive(false);
                content = 0;
            }
            this.state = state;
        }
    }
    public int getState() { return state; }
    public bool canWalk() { return (state == 1 || state == 2); }
    public void setContent(int content) {
        this.content = content;
        this.transform.GetChild(1).GetChild(content - 1).gameObject.SetActive(true);
    }
    public int getContent() { return content; }
}