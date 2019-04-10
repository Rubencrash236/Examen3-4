using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts
{
    [DataContract]
    public class Game
    {
        [DataMember]
        public string PlayerName { get; set; }
        [DataMember]
        public Level CurrentLevel { get; set; }

        #region constructor
        public Game()
        {
            CurrentLevel = new Level();
        }
        #endregion

    }
}
