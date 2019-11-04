using System;
using System.Collections.Generic;
using System.Linq;

namespace FSM_Games.TowerOfHanoi
{
    public class GameField
    {
        public class Ring
        {
            public int Size { get; internal set; }

            public override string ToString()
            {
                return Size.ToString();
            }
        }

        public class Tower
        {
            public Dictionary<int, Ring> Rings = new Dictionary<int, Ring>();
            public bool IsSelected { get; internal set; }
        }

        public enum SetStickResult
        {
            InvalidMove,
            WaitMove,
            PlayerWon
        }

        private bool _isModeFrom;
        private int _stickIndexFrom;
        private KeyValuePair<int, Ring> _towersRingFrom;
        public Dictionary<int, Tower> Towers = new Dictionary<int, Tower>();

        internal GameField()
        {
            Towers.Add(1, new Tower());
            Towers.Add(2, new Tower());
            Towers.Add(3, new Tower());

            Clear();
        }

        internal void Clear()
        {
            Towers[1].Rings.Clear();
            Towers[2].Rings.Clear();
            Towers[3].Rings.Clear();

            Towers[1].Rings.Add(1, new Ring { Size = 8 });
            Towers[1].Rings.Add(2, new Ring { Size = 7 });
            Towers[1].Rings.Add(3, new Ring { Size = 6 });
            Towers[1].Rings.Add(4, new Ring { Size = 5 });
            Towers[1].Rings.Add(5, new Ring { Size = 4 });
            Towers[1].Rings.Add(6, new Ring { Size = 3 });
            Towers[1].Rings.Add(7, new Ring { Size = 2 });
            Towers[1].Rings.Add(8, new Ring { Size = 1 });

            Towers[1].IsSelected = false;
            Towers[2].IsSelected = false;
            Towers[3].IsSelected = false;

            _isModeFrom = true;
        }

        internal SetStickResult SetStick(int stickIndex)
        {
            if (stickIndex < 1 || stickIndex > 3)
            {
                throw new ArgumentException("Stick index must be in [1-3] range!", nameof(stickIndex));
            }

            if (_isModeFrom)
            {
                _towersRingFrom = Towers[stickIndex].Rings.LastOrDefault();

                if (_towersRingFrom.Value == null)
                {
                    return SetStickResult.InvalidMove;
                }

                _stickIndexFrom = stickIndex;
                _isModeFrom = false;
                Towers[_stickIndexFrom].IsSelected = true;

                return SetStickResult.WaitMove;
            }

            _isModeFrom = true;
            Towers[_stickIndexFrom].IsSelected = false;
            var towersRingLastTo = Towers[stickIndex].Rings.LastOrDefault();

            if (_stickIndexFrom == stickIndex ||
                (towersRingLastTo.Value != null && towersRingLastTo.Value.Size < _towersRingFrom.Value.Size))
            {
                return SetStickResult.InvalidMove;
            }

            Towers[stickIndex].Rings.Add(towersRingLastTo.Key + 1, _towersRingFrom.Value);
            Towers[_stickIndexFrom].Rings.Remove(_towersRingFrom.Key);

            return Verify() ? SetStickResult.PlayerWon : SetStickResult.WaitMove;
        }

        private bool Verify()
        {
            return Towers[2].Rings.Count == 8 || Towers[3].Rings.Count == 8;
        }
    }
}