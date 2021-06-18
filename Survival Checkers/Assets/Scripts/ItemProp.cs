using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemProp
{
    public int id;
    public string name;
    public int type; // 0 Can't pick up, 1 drop, 2 merged material, 3 tool, 4 placeable, 5 consumable
    public int[] activeParams;

    public ItemProp(int id, string name, int type, int[] activeParams)
    {
        this.id = id;
        this.name = name;
        this.type = type;
        this.activeParams = activeParams;
    }

    public void activate(tileScript playerOn, tileScript playerFront) {
        switch (type){
            case 1:
                //TO DO
                break;
            case 2:
                //TO DO
                break;
            case 3:
                if(activeParams[0] == playerFront.getContent() && playerOn.getContent() == -1){
                    playerFront.setContent(activeParams[1]);
                    playerOn.setContent(activeParams[1]);
                } else if (playerFront.getContent() == 3){
                    ItemProp.levelUpTool(id);
                }
                break;
            case 4:
                if (activeParams[0] == playerFront.getState()){
                    playerFront.setContent(activeParams[1]);
                    //item lost TO DO
                }
                break;
            case 5:
                //Like healing or eating, TO DO
                break;
        }
    }

    public static ItemProp[] library = new ItemProp[]
    {
        new ItemProp(0,"Tree", 0, new int[]{ }),
        new ItemProp(1,"Rock", 0, new int[]{ }),
        new ItemProp(2,"Upgrade Bench", 0, new int[]{ }),
        new ItemProp(3,"Upgrade Bench (charged)", 0, new int[]{ }),
        new ItemProp(4,"Axe", 3, new int[]{0,6}),
        new ItemProp(5,"Pickaxe", 3, new int[]{1,7}),
        new ItemProp(6,"Wood", 1, new int[]{ }),
        new ItemProp(7,"Stone", 1, new int[]{ }),
        new ItemProp(8,"Enemy drop", 1, new int[]{ }),
    };
    public static int axeLevel = 1;
    public static int pickaxeLevel = 1;
    public static void levelUpTool(int id)
    {
        switch (id)
        {
            case 4:
                ItemProp.axeLevel++;
                break;
            case 5:
                ItemProp.pickaxeLevel++;
                break;
        }
    }
}
