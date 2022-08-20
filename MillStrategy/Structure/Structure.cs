using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using static MillStrategy.Utils;

namespace MillStrategy.Structure
{
    public enum PiesaColor { None, White, Black };
    public enum PiesaState { Nepusa, Pusa, Luata };
    public enum PlayerState { Pune, Ia, Muta };

    public interface IPozitie
    {
        OctalNumber Cod { get; set; }
        List<OctalNumber> Vecini { get; }
        int Square { get; set; }
        bool IsDiagonal { get; }
        bool IsLine { get; }
    }

    public interface IPozitiePeTabla : IPozitie
    {
        bool Ocupat { get; set; }
        bool Liber { get; set; }
    }

    public interface IPiesa
    {
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
    }
    
    public interface ITabla
    {
        bool SePunPiese { get; } // daca inca se pun piese sau se muta
        IPlayer Player1 { get; set; }
        IPlayer Player2 { get; set; }

        List<IPozitie> PozitiiValide { get; } // toate pozitiile disponibile
        Dictionary<IPozitie, IPiesa> Piese { get; set; }

        bool Ocupata(IPozitie pozitie);
    }
}
