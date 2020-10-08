using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    [SerializeField] private bool[] openings;//0 = up / 1 = down / 2 = left / 3 = right

    private RoomsGenerator roomGenerator;

    public int x;
    public int y;

    [SerializeField] private bool isStart;
    public bool isEnd;

    private void Start()
    {
        roomGenerator = FindObjectOfType<RoomsGenerator>();
        if (isStart)
        {
            x = roomGenerator.length / 2;
            y = roomGenerator.length / 2;
            roomGenerator.RoomPlacements[x, y] = true;
        }


        if(roomGenerator.CurrentNumberOfRooms < roomGenerator.MaxNumberOfRooms)
        {
            for(int i = 0; i < openings.Length; i++)
            {
                if (openings[i] == false) 
                {
                    continue;
                }
                GameObject room;


                int r;
                switch (i)
                {
                    case 0:
                        if (y + 1 < roomGenerator.length - 1)
                        {
                            if (roomGenerator.RoomPlacements[x, y + 1] == false)
                            {
                                r = Random.Range(0, roomGenerator.downRooms.Length);
                                room = Instantiate(roomGenerator.downRooms[r], new Vector3(transform.position.x, transform.position.y + 6.042f, transform.position.z), Quaternion.identity);
                                room.GetComponent<Room>().x = x;
                                room.GetComponent<Room>().y = y + 1;
                                roomGenerator.RoomPlacements[x, y + 1] = true;
                                roomGenerator.CurrentNumberOfRooms++;
                            }
                        }
                        else
                        {
                            roomGenerator.AddToOpenings(i, gameObject);
                        }
                        break;
                    case 1:
                        if (y - 1 >= 0)
                        {
                            if (roomGenerator.RoomPlacements[x, y - 1] == false)
                            {
                                r = Random.Range(0, roomGenerator.upRooms.Length);
                                room = Instantiate(roomGenerator.upRooms[r], new Vector3(transform.position.x, transform.position.y - 6.042f, transform.position.z), Quaternion.identity);
                                room.GetComponent<Room>().x = x;
                                room.GetComponent<Room>().y = y - 1;
                                roomGenerator.RoomPlacements[x, y - 1] = true;
                                roomGenerator.CurrentNumberOfRooms++;
                            }
                        }
                        else
                        {
                            roomGenerator.AddToOpenings(i, gameObject);
                        }
                        break;
                    case 2:
                        if (x - 1 >= 0)
                        {
                            if (roomGenerator.RoomPlacements[x - 1, y] == false)
                            {
                                r = Random.Range(0, roomGenerator.rightRooms.Length);
                                room = Instantiate(roomGenerator.rightRooms[r], new Vector3(transform.position.x - 6.042f, transform.position.y, transform.position.z), Quaternion.identity);
                                room.GetComponent<Room>().x = x - 1;
                                room.GetComponent<Room>().y = y;
                                roomGenerator.RoomPlacements[x - 1, y] = true;
                                roomGenerator.CurrentNumberOfRooms++;
                            }
                        }
                        else
                        {
                            roomGenerator.AddToOpenings(i, gameObject);
                        }
                        break;
                    case 3:
                        if (x + 1 < roomGenerator.length - 1)
                        { 
                            if (roomGenerator.RoomPlacements[x + 1, y] == false)
                            {
                                r = Random.Range(0, roomGenerator.leftRooms.Length);
                                room = Instantiate(roomGenerator.leftRooms[r], new Vector3(transform.position.x + 6.042f, transform.position.y, transform.position.z), Quaternion.identity);
                                room.GetComponent<Room>().x = x + 1;
                                room.GetComponent<Room>().y = y;
                                roomGenerator.RoomPlacements[x + 1, y] = true;
                                roomGenerator.CurrentNumberOfRooms++;
                            }
                        }
                        else
                        {
                            roomGenerator.AddToOpenings(i, gameObject);
                        }
                        break;
                }
            }
        }
    }
}
