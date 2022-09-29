using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sector : MonoBehaviour
{
    public bool IsGood = true;
    public Material GoodMaterial;
    public Material BadMaterial;
    public Player Player;
   
    

    private void Awake()
    {
        Renderer sectorRenderer = GetComponent<Renderer>();
        sectorRenderer.sharedMaterial = IsGood ? GoodMaterial : BadMaterial;
    
    }

    private void OnCollisionEnter(Collision collision)
    { 
       
       if (!collision.collider.TryGetComponent(out Player player))
        {
            return;
        }

            Vector3 normal = -collision.contacts[0].normal.normalized;
            float dot = Vector3.Dot(normal, Vector3.up);
            if (dot >= 0.5)
            {
                if(IsGood)
            player.Bounce();
                else
                    Player.Die();
                    
            }
        }
    private void OnValidate()
    {
        Renderer sectorRenderer = GetComponent<Renderer>();
        sectorRenderer.sharedMaterial = IsGood ? GoodMaterial : BadMaterial;
    }

    }

