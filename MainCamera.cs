using UnityEngine;
namespace Match3.InGame.LevelSystems
{
    public class MainCamera : Map
    {
        void Start()
        {
            //Camera.main.transform.position = new Vector3(0, 0, -10);
            Camera.main.transform.position = new Vector3(BottomCenter.x + 1.1f, BottomCenter.y + 9.0f, BottomCenter.z -23);
            if(SizeX > SizeY)
            {
                Camera.main.orthographicSize = SizeX / 2 + NodeWidth + NodeHeight;
            }
            else
            {
                Camera.main.orthographicSize = SizeY / 2 + NodeWidth + NodeHeight;
            }
            //Camera.main.orthographicSize = (SizeY * NodeHeight) / 2 + 1;
            //Camera.main.transform.position = new Vector3(0, SizeY * NodeHeight / 2, -10);

            // 1.1, 6.6, -23
        }
    }
}
