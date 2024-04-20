using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEditor;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public PowerUpSpec[] mySpecs;
    public int startingSpec;
    public Vector3 size;
    private Renderer m_Renderer;
    public void SetPowerUpSpec(PowerUpSpec spec)
    {
        m_Renderer.material.color = spec.defaultSpec.player_color;
    }

    // Start is called before the first frame update
    void Start()
    {
        m_Renderer = GetComponent<Renderer>();
        startingSpec = Random.Range(0, mySpecs.Length);
        SetPowerUpSpec(mySpecs[startingSpec]);

        this.transform.localScale = size;
    }

    // Update is called once per frame
    void Update()
    {
        Collider[] hitColliders = Physics.OverlapSphere(this.transform.position, size.x * 0.5f);
        foreach (var hitCollider in hitColliders)
        {
            Debug.Log("found hit");
            Player playerHit;
            playerHit = hitCollider.GetComponent<Player>();
            if (playerHit != null)
            {
                Debug.Log("found player");

                //check is player already has power ups
                if (playerHit.currentType != PowerUpTypes.Types.GREY)
                {
                    //if player has power up, set to specified power up combination
                    playerHit.SetPlayerSpec(mySpecs[startingSpec].combinations[(int)playerHit.currentType]);
                }
                else
                {
                    //otherwise, set to default power up
                    playerHit.SetPlayerSpec(mySpecs[startingSpec].defaultSpec);
                    playerHit.currentType = mySpecs[startingSpec].myType;
                }

                Destroy(this.gameObject);
            }
        }

        // if (Physics.SphereCast(this.transform.position, size.x * 0.5f, this.transform.forward, out hitInfo, 10f))
        // {
        //     Debug.Log("found hit");
        //     Player playerHit;
        //     playerHit = hitInfo.collider.GetComponent<Player>();
        //     if (playerHit != null)
        //     {
        //         Debug.Log("found player");
        //         playerHit.SetPlayerSpec(mySpec.defaultSpec);
        //     }
        // }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawSphere(this.transform.position, size.x * 0.5f);
    }
}
