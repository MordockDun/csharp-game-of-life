namespace GameOfLife;

public enum CellState
{
    Alive, Dead
}

public class Rule
{
    public static CellState GetNewCellState(CellState currentState, int numberOfNeighbors)
    {
        if ((currentState == CellState.Alive && numberOfNeighbors == 2) || numberOfNeighbors==3)
        {
            return CellState.Alive;
        }

        return CellState.Dead;
    }
}