using System;
using System.Runtime.InteropServices;
using UnityEngine;
using Random = UnityEngine.Random; // 모호한 참조에 대한 명시를 하는 using 키워드

namespace Match3.InGame.LevelSystems
{
    public class Map : MonoBehaviour
    {
        [SerializeField] int _sizeX = 16;
        [SerializeField] int _sizeY = 18;
        [SerializeField] float _nodeWidth = 1;
        [SerializeField] float _nodeHeight = 1;
        [SerializeField] Vector3 _bottomCenter;
        Node[,] _nodes;
        [SerializeField] GameObject[] _basicBlocks;

        public int SizeX { get => _sizeX;}  
        public int SizeY => _sizeY;
        public float NodeWidth => _nodeWidth;
        public float NodeHeight => _nodeHeight;
        public Vector3 BottomCenter => _bottomCenter;

        private void Awake()
        {
            _nodes = new Node[_sizeY, _sizeX];
        }

        //public Map(int x, int y)
        //{
        //    _nodes = new Node[y, x];
        //}


        //Node[,] _nodes;

        private void Start()
        {
            SetNodesRandomly();
        }

        public void SetNodesRandomly()
        {
            Array typeArray = Enum.GetValues(typeof(NodeTypes));
            int blockIndex;
            NodeTypes nodeType;
            int totalNodeType = typeArray.Length - 1; //0은 Nothing이므로 제외
            GameObject block;

            for (int i = 0; i < _nodes.GetLength(0); i++)
            {
                for (int j = 0; j < _nodes.GetLength(1); j++)
                {
                    blockIndex = Random.Range(0, totalNodeType);
                    nodeType = (NodeTypes)(1 << blockIndex);
                    _nodes[i, j] = new Node(j, i, nodeType);
                    block = Instantiate(_basicBlocks[blockIndex]);

                    block.transform.position
                        = new Vector3(x: (j - (_sizeX - 1) * 0.5f) * _nodeWidth,
                                      y: (i + 0.5f) * _nodeHeight,
                                      z: 0f)
                          +_bottomCenter;
                }
            }
        }
    }
}