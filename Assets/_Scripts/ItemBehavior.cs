using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Assets._Scripts
{
    class ItemBehaviour : MonoBehaviour
    {
        ObjectPooler objectPooler;
        Transform slimeSpawn;
        public void Start()
        {
            objectPooler = ObjectPooler.Instance;
            slimeSpawn = GetComponent<ObjectPooler>().transform;
        }

        public void useInventoryItem()
        {
            Transform itemSlot = transform;
            GameObject itemIcon = itemSlot.gameObject.transform.GetChild(0).GetChild(0).transform.gameObject;

            // using heart
            if (itemSlot.tag == "Heart")
            {
                Debug.Log("Item is heart:" + GameObject.Find("Jammo_Player").GetComponent<PlayerCollision>().getHealth());
                switch (GameObject.Find("Jammo_Player").GetComponent<PlayerCollision>().getHealth())
                {
                    case 1:
                        // add health and use heart
                        GameObject.Find("Jammo_Player").GetComponent<PlayerCollision>().setHealth(2);
                        itemIcon.SetActive(false);
                        //objectPooler.SpawnFromPool("Slime", slimeSpawn.position, Quaternion.identity);
                        Debug.Log("spawn used");
                        break;
                    case 2:
                        // add health and use heart
                        GameObject.Find("Jammo_Player").GetComponent<PlayerCollision>().setHealth(3);
                        itemIcon.SetActive(false);
                        //objectPooler.SpawnFromPool("Slime", slimeSpawn.position, Quaternion.identity);
                        break;
                    default:
                        break;
                }
                // update health in UI
                GameObject.Find("Jammo_Player").GetComponent<PlayerCollision>().UpdateHealth();
            }

            // using battery
            if (itemSlot.tag == "Battery")
            {
                if (!PlayerBehaviour.hasSuperSpeed)
                {
                    GiveSuperSpeed();
                    Debug.Log("Has super jump: " + PlayerBehaviour.hasSuperJump);
                    itemIcon.SetActive(false);
                }
                else
                {
                    Debug.Log("Player already has super speed");
                }
            }

            // using chip
            if (itemSlot.tag == "Chip")
            {
                if (!PlayerBehaviour.hasSuperJump)
                {
                    PlayerBehaviour.hasSuperJump = true;
                    Debug.Log("Has super jump: " + PlayerBehaviour.hasSuperJump);
                    itemIcon.SetActive(false);
                }
                else
                {
                    Debug.Log("Player already has super jump");
                }
            }
        }

        // give super speed
        private async void GiveSuperSpeed()
        {
            Debug.Log("Super speed enabled");
            PlayerBehaviour.hasSuperSpeed = true;
            PlayerBehaviour.currSpeedMultiplier = PlayerBehaviour.superSpeedMultiplier;
            await Task.Delay(PlayerBehaviour.superSpeedDuration);
            Debug.Log("Super speed disabled");
            PlayerBehaviour.hasSuperSpeed = false;
            PlayerBehaviour.currSpeedMultiplier = 1.0f;
        }
    }
}
