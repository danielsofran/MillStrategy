using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MillStrategy.Structure;

namespace MillStrategy.Domain
{
    public class Piesa : IPiesa
    {
        public Piesa(PiesaColor playerColor = PiesaColor.None, PiesaState state = PiesaState.Nepusa)
        {
            PlayerColor = playerColor;
            State = state;
        }

        public PiesaColor PlayerColor { get; set; } = PiesaColor.None;
        public bool IsBlack { get => PlayerColor == PiesaColor.Black; set => PlayerColor = value == true ? PiesaColor.Black : PiesaColor.None; }
        public bool IsWhite { get => PlayerColor == PiesaColor.White; set => PlayerColor = value == true ? PiesaColor.White : PiesaColor.None; }
        public PiesaState State { get; set; }
    }

    public class Player : IPlayer
    {
        public Player(PiesaColor piesaColor = PiesaColor.None, string nume = "Player")
        {
            Nume = nume;
            PiesaColor = piesaColor;
            List<IPiesa> depus = new List<IPiesa>();
            for(int i=0;i<9;++i)
            {
                Piesa p = new Piesa(PiesaColor, PiesaState.Nepusa);
                depus.Add(p);
            }
            DePus = depus;
            Luate = new List<IPiesa>();
        }

        public string Nume { get; set; } = "Player";
        public PiesaColor PiesaColor { get; set; } = PiesaColor.None;
        public PlayerState State { get; set; } = PlayerState.Pune;
        public List<IPiesa> DePus { get; set; }
        public List<IPiesa> Luate { get; set; }

        public 
    }
}
