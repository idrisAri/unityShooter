using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface GameObjectProperties
{
    public float getHp();

    public void deductHp(float damage);
    public float getDamage();
    public float getSpeed();



}
