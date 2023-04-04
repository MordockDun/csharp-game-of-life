using GameOfLife;

namespace GameOfLifeTests;

public class GameOfLifeTests
{

    [Theory]
    [InlineData(CellState.Alive,0,CellState.Dead)]
    [InlineData(CellState.Alive,1,CellState.Dead)]
    [InlineData(CellState.Alive,2,CellState.Alive)]
    [InlineData(CellState.Alive,3,CellState.Alive)]
    [InlineData(CellState.Alive,4,CellState.Dead)]
    [InlineData(CellState.Alive,5,CellState.Dead)]
    [InlineData(CellState.Alive,6,CellState.Dead)]
    [InlineData(CellState.Alive,7,CellState.Dead)]
    [InlineData(CellState.Alive,8,CellState.Dead)]
    [InlineData(CellState.Dead,0,CellState.Dead)]
    [InlineData(CellState.Dead,1,CellState.Dead)]
    [InlineData(CellState.Dead,2,CellState.Dead)]
    [InlineData(CellState.Dead,3,CellState.Alive)]
    [InlineData(CellState.Dead,4,CellState.Dead)]
    [InlineData(CellState.Dead,5,CellState.Dead)]
    [InlineData(CellState.Dead,6,CellState.Dead)]
    [InlineData(CellState.Dead,7,CellState.Dead)]
    [InlineData(CellState.Dead,8,CellState.Dead)]
    public void LiveRules(CellState initialState, int numberOfNeighbors, CellState expectedState)
    {
        CellState result = GameOfLife.Rule.GetNewCellState(initialState, numberOfNeighbors);
        
        Assert.Equal(result, expectedState);
    }
    
}