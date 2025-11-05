using Gamekit3D;
using UnityEngine;

public class SurvivalMod : MonoBehaviour
{
    public float thirstLevel = 100;
    public float thirstSpeed;
    public float damageTimer = 10;

    public bool thirsty;
    public bool parched;

    public Damageable playerDamageable;
    
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            DrinkWater();
        }
        
        thirstLevel -= Mathf.Clamp(thirstSpeed * Time.deltaTime, 0, thirstLevel);

        if (thirstLevel <= 50 && !thirsty)
        {
            Debug.Log("Getting thirsty...");
            thirsty = true;
        }
        
        if (thirstLevel <= 30 && !parched)
        {
            Debug.Log("I need to drink NOW!");
            parched = true;
        }

        if (thirstLevel <= 0)
        {
            damageTimer -= Time.deltaTime;
            if (damageTimer <= 0)
            {
                Damageable.DamageMessage msg = new Damageable.DamageMessage()
                {
                    damager = this,
                    amount = 1,
                    damageSource = new Vector3(0, 0, 0),
                    direction = new Vector3(0, 0, 0),
                    stopCamera = false,
                    throwing = false
                };
                
                playerDamageable.ApplyDamage(msg);
                Debug.Log("Damage by thirst!");
                damageTimer = 10;
            }
            
        }

    }

    void DrinkWater()
    {
        thirstLevel = 100;
        playerDamageable.ResetDamage();
        thirsty = false;
        parched = false;
    }
    
}
