using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Collections;

namespace MillStrategy.Structure
{
    public enum PiesaColor { None, White, Black };
    public enum PiesaState { Nepusa, Pusa, Luata };
    public enum PlayerState { Pune, Ia, Muta };

    public abstract class IPozitie
    {
        public abstract OctalNumber Cod { get; }
        public abstract List<OctalNumber> Vecini { get; }
        public abstract int Square { get; }
        public abstract bool IsDiagonal { get; }
        public abstract bool IsLine { get; }
        public abstract override string ToString();
        public abstract void FromString(string pozitie);
    }

    public abstract class IPozitii : IEnumerable<IPozitie>
    {
        List<IPozitie> Pozitii { get; set; }
        public abstract override string ToString();
        public abstract void FromString(string pozitii);

        public IEnumerator<IPozitie> GetEnumerator() => Pozitii.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public interface IPiesa
    {
        bool Ocupata { get; }
        bool Libera { get; set; }
        bool IsBlack { get; set; }
        bool IsWhite { get; set; }
        PiesaColor PlayerColor { get; set; }
    }

    public interface IPlayer
    {
        string Nume { get; set; }
        PiesaColor PiesaColor { get; set; }
        PlayerState State { get; set; }
        List<IPiesa> DePus { get; set; }
        List<IPiesa> Luate { get; set; }

        void Reset(); // reseteaza piesele
        IPiesa Pune();
        void Ia(IPiesa piesa);
    }
    
    public interface ITabla
    {
        event EventHandler PlayerChanged;

        bool SePunPiese { get; } // daca inca se pun piese sau se muta
        IPlayer Player1 { get; set; }
        IPlayer Player2 { get; set; }
        IPlayer Player { get; set; }

        IPozitii PozitiiValide { get; } // toate pozitiile disponibile
        Dictionary<IPozitie, IPiesa> Piese { get; set; }

        void ChangePlayer();
    }
}
