using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts
{
    [DataContract]
   public class Level
    {
        [DataMember]
        public int Number { get; set; }
        [DataMember]
        public List<string> Map { get; set; }
        [DataMember]
        public List<Character> Characters { get; set; }
        [DataMember]
        public List<Item> Items { get; set; }

        #region Constructores
        public Level()
        {
            Map = new List<string>();
            Characters = new List<Character>();
            Items = new List<Item>();
        }

        #endregion
    }
}
