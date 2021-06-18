using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tileScript : MonoBehaviour
{
    public int state; // 0 void, 1 ground, 2 bridge, 3 infected
    public int content;
    public int cooldown;

    void Start()
    {
        state = 0;
        content = -1;
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
            if ((state == 0 || state == 3) && content != -1){
                this.transform.GetChild(1).GetChild(content).gameObject.SetActive(false);
                content = -1;
            }
            this.state = state;
        }
    }
    public int getState() { return state; }
    public bool canWalk() { return (state == 1 || state == 2) && ItemProp.library[content].type != 0; }
    public void setContent(int content) {
        if (this.content != -1)
            this.transform.GetChild(1).GetChild(this.content).gameObject.SetActive(false);
        if(content != -1)
            this.transform.GetChild(1).GetChild(content).gameObject.SetActive(true);
        this.content = content;
    }
    public int getContent() { return content; }
}