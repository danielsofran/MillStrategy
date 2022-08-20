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
        public bool Ocupata { get => PlayerColor != PiesaColor.None; }
        public bool Libera { get => PlayerColor == PiesaColor.None; set => PlayerColor = PiesaColor.None; }
        public PiesaState State { get; set; }
    }

    public class Player : IPlayer
    {
        public Player(PiesaColor piesaColor = PiesaColor.None, string nume = "Player")
        {
            Nume = nume;
            PiesaColor = piesaColor;
            Reset();
        }

        public string Nume { get; set; } = "Player";
        public PiesaColor PiesaColor { get; set; } = PiesaColor.None;
        public PlayerState State { get; set; } = PlayerState.Pune;
        public List<IPiesa> DePus { get; set; }
        public List<IPiesa> Luate { get; set; }

        public void Reset()
        {
            List<IPiesa> depus = new List<IPiesa>();
            for (int i = 0; i < 9; ++i)
            {
                Piesa p = new Piesa(PiesaColor, PiesaState.Nepusa);
                depus.Add(p);
            }
            DePus = depus;
            Luate = new List<IPiesa>();
        }
        public IPiesa Pune()
        {
            var piesa = DePus.Last();
            DePus.RemoveAt(DePus.Count - 1);
            return piesa;
        }
        public void Ia(IPiesa piesa)
        {
            Luate.Add(piesa);
        }
    }

    public class Tabla : ITabla
    {
        IPlayer player = new Player();

        public Tabla()
        {
            Player1 = new Player(PiesaColor.White);
            Player2 = new Player(PiesaColor.Black);
            Player = Player1;

        }

        public event EventHandler PlayerChanged;

        public bool SePunPiese { get => Player1.State == PlayerState.Pune || Player2.State == PlayerState.Pune; }
        public IPlayer Player1 { get; set; }
        public IPlayer Player2 { get; set; }
        public IPlayer Player { get => player; 
            set
            {
                player = value;
                OnPlayerChanged(new EventArgs());
            }
        }
        protected virtual void OnPlayerChanged(EventArgs e = null)
        {
            PlayerChanged?.Invoke(this, e);
        }

        public IPozitii PozitiiValide { get => valpoz; }
        public Dictionary<IPozitie, IPiesa> Piese { get; set; }

        public void ChangePlayer()
        {   
                 if(Player == Player1) Player = Player2;
            else if(Player == Player2) Player = Player1;
        }
    }

    public class Pozitie : IPozitie
    {
        OctalNumber cod;

        public Pozitie(OctalNumber number)
        {
            cod = number;
        }

        public override OctalNumber Cod => cod;
        public override int Square => cod.FirstDigit;
        public override bool IsDiagonal => OctalNumber.DigitPredicates.Odd(cod.LastDigit);
        public override bool IsLine => OctalNumber.DigitPredicates.Even(cod.LastDigit);

        public override string ToString() => cod;
        public override void FromString(string pozitie) => cod = pozitie;

        public override List<OctalNumber> Vecini
        {
            get
            {

            }
        }
    }
}
