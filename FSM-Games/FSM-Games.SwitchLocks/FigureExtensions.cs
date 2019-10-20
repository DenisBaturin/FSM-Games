namespace FSM_Games.SwitchLocks
{
    public static class FigureExtensions
    {
        public static Figure GetOpponentsFigure(this Figure figure)
        {
            return 1 - figure;
        }
    }
}