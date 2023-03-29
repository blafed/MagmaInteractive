using UnityEngine;

public class Power : MonoBehaviour
{
    public Prop power = new Prop(100);

    public float regenRate = 200;


    private void FixedUpdate()
    {
        power.current += regenRate * Time.fixedDeltaTime / 60;
    }


    public void UsePower(float amount)
    {
        power.current -= amount;
    }

}