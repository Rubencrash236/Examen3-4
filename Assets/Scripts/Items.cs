using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts
{
    [DataContract]
    public class Item
    {
        #region properties
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string UniqueObjectName { get; set; }
        [DataMember]
        public string PrefabName { get; set; }
        [DataMember]
        public float PosX { get; set; }
        [DataMember]
        public float PosY { get; set; }
        #endregion

        #region Constructors
        public Item()
        {

        }

        public Item(int id, string uniqueObjectName, string prefabName, float posX, float posY)
        {
            Id = id;
            UniqueObjectName = uniqueObjectName;
            PrefabName = prefabName;
            PosX = posX;
            PosY = posY;
        }
        #endregion

    }
}
