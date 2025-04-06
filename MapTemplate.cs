using UnityEngine;
namespace Match3.InGame.LevelSystems
{
    public class MapTemplate : Map
    {

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {

            GameObject Tail1 = GameObject.Find("Bound");
            GameObject Tail2 = GameObject.Find("Bound (1)");
            GameObject Tail3 = GameObject.Find("Bound (2)");
            GameObject Tail4 = GameObject.Find("Bound (3)");

            if (Tail1 == null || Tail2 == null || Tail3 == null || Tail4 == null)
            {
                Debug.LogError("One or more GameObjects not found");
            }

            int _width = SizeX;
            int _height = SizeY;
            float _nodeWidth = NodeWidth;
            float _nodeHeight = NodeHeight;
            Vector3 _bottomCenter = BottomCenter;

            //Tail1.transform.position = new Vector3(_bottomCenter.x - (_width * _nodeWidth) / 2, _bottomCenter.y, _bottomCenter.z);
            //Tail2.transform.position = new Vector3(_bottomCenter.x + (_width * _nodeWidth) / 2, _bottomCenter.y, _bottomCenter.z);
            //Tail3.transform.position = new Vector3(_bottomCenter.x, _bottomCenter.y + (_height * _nodeHeight) / 2, _bottomCenter.z);
            //Tail4.transform.position = new Vector3(_bottomCenter.x, _bottomCenter.y - (_height * _nodeHeight) / 2, _bottomCenter.z);
            //Tail1.transform.localScale = new Vector3(_nodeWidth, _height * _nodeHeight, 1);
            //Tail2.transform.localScale = new Vector3(_nodeWidth, _height * _nodeHeight, 1);
            //Tail3.transform.localScale = new Vector3(_width * _nodeWidth, _nodeHeight, 1);
            //Tail4.transform.localScale = new Vector3(_width * _nodeWidth, _nodeHeight, 1);
            //Tail1.transform.rotation = Quaternion.Euler(0, 0, 90);
            //Tail2.transform.rotation = Quaternion.Euler(0, 0, 90);
            //Tail3.transform.rotation = Quaternion.Euler(0, 0, 0);
            //Tail4.transform.rotation = Quaternion.Euler(0, 0, 0);
            //Tail1.transform.position = new Vector3(10, 10, 10);
            Tail1.transform.localScale = new Vector3(1, _height * _nodeHeight + 2, 1);
            Tail2.transform.localScale = new Vector3(1, _height * _nodeHeight + 2, 1);
            Tail3.transform.localScale = new Vector3(_width * _nodeWidth + 2, 1, 1);
            Tail4.transform.localScale = new Vector3(_width * _nodeWidth + 2, 1, 1);

            Debug.Log($"{_bottomCenter.x}, {_bottomCenter.y}, {_bottomCenter.z}");

            Tail1.transform.position = new Vector3(_bottomCenter.x - (_width * _nodeWidth / 2) -0.5f, _bottomCenter.y + (_height * _nodeHeight / 2), _bottomCenter.z);
            Tail2.transform.position = new Vector3(_bottomCenter.x + (_width * _nodeWidth / 2) + 0.5f, _bottomCenter.y + (_height * _nodeHeight / 2), _bottomCenter.z);
            Tail3.transform.position = new Vector3(_bottomCenter.x, _bottomCenter.y - 0.5f, _bottomCenter.z);
            Tail4.transform.position = new Vector3(_bottomCenter.x, _bottomCenter.y + _height * _nodeHeight + 0.5f, _bottomCenter.z);
            // 4.5 3.6 ,  0 -2.9 0 10.123
            // 1.1, 6.6, -23

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
