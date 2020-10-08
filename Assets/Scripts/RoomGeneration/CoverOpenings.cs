using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class CoverOpenings : MonoBehaviour
{
    RoomsGenerator roomGenerator;

    [SerializeField] private float waitTime;

    private WaitForSeconds timeTillCover;

    private bool choseEnd;

    private void Awake()
    {
        timeTillCover = new WaitForSeconds(waitTime);
        roomGenerator = FindObjectOfType<RoomsGenerator>();
    }

    private void Start()
    {
        StartCoroutine(CoverCo());
    }

    private IEnumerator CoverCo()
    {
        yield return timeTillCover;
        Cover();
    }

    private void Cover()
    {
        GameObject roomObject = null;
        if (roomGenerator.openings.ContainsKey(0))
        {
            foreach (GameObject room in roomGenerator.openings[0])
            {
                roomObject = Instantiate(roomGenerator.closingRoomDown, new Vector3(room.transform.position.x, room.transform.position.y + 6.042f, room.transform.position.z), Quaternion.identity);
                if (!choseEnd)
                {
                    roomObject.GetComponent<Room>().isEnd = Random.Range(0, 2) == 0;
                    if (roomObject.GetComponent<Room>().isEnd)
                        choseEnd = true;
                }
            }
        }
        if (roomGenerator.openings.ContainsKey(1))
        {
            foreach (GameObject room in roomGenerator.openings[1])
            {
                roomObject = Instantiate(roomGenerator.closingRoomUp, new Vector3(room.transform.position.x, room.transform.position.y - 6.042f, room.transform.position.z), Quaternion.identity);

                if (!choseEnd)
                {
                    roomObject.GetComponent<Room>().isEnd = Random.Range(0, 2) == 0;
                    if (roomObject.GetComponent<Room>().isEnd)
                        choseEnd = true;
                }
            }
        }

        if (roomGenerator.openings.ContainsKey(2))
        {
            foreach (GameObject room in roomGenerator.openings[2])
            {
                roomObject = Instantiate(roomGenerator.closingRoomRight, new Vector3(room.transform.position.x - 6.042f, room.transform.position.y, room.transform.position.z), Quaternion.identity);
                if (!choseEnd)
                {
                    roomObject.GetComponent<Room>().isEnd = Random.Range(0, 2) == 0;
                    if (roomObject.GetComponent<Room>().isEnd)
                        choseEnd = true;
                }
            }
        }
        if (roomGenerator.openings.ContainsKey(3))
        {
            foreach (GameObject room in roomGenerator.openings[3])
            {
                roomObject = Instantiate(roomGenerator.closingRoomLeft, new Vector3(room.transform.position.x + 6.042f, room.transform.position.y, room.transform.position.z), Quaternion.identity);
                if (!choseEnd)
                {
                    roomObject.GetComponent<Room>().isEnd = Random.Range(0, 2) == 0;
                    if (roomObject.GetComponent<Room>().isEnd)
                        choseEnd = true;
                }
            }
        }

        if (!choseEnd)
        {
            roomObject.GetComponent<Room>().isEnd = true;
        }
    }
}
