using System.Xml;
using UnityEngine;

public class Mana : MonoBehaviour
{
    public Prop mana = new Prop(100);
    //per minute
    public int regenRate = 100;

    private void FixedUpdate()
    {
        mana.current += regenRate * Time.fixedDeltaTime / 60;
    }



    public void AddMana(float amount)
    {
        mana.current += amount;
    }
    public void UseMana(float amount)
    {
        mana.current -= amount;
    }

    public bool HasAmount(float amount)
    {
        return mana.current >= amount;
    }
}