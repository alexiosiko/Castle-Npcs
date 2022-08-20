using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Librarian : Entity
{
    public Transform player;
    public override void Action()
    {
        base.Action();
        canvas.Alert(text);

        LookTowards(player);

    }
}
