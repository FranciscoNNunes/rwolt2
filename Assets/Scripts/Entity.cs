using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[Serializable]
public class ENtity
{
    [Header("Name")]
    public string Name;

    [Header("Health")]
    public int currentHeath;
    public int maxHeath;

    [Header("Mana")]
    public int currentMana;
    public int maxMana;

    [Header("Stamina")]
    public int currentStamina;
    public int maxStamina;

    [Header("Stats")]

    public int strength = 1;
    public int resistence = 1;
    public int damage = 1;
    public int defense = 1;
    public float speed = 2f;

}
