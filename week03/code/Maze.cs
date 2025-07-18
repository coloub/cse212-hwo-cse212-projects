/// <summary>
/// Defines a maze using a dictionary. The dictionary is provided by the
/// user when the Maze object is created. The dictionary will contain the
/// following mapping:
///
/// (x,y) : [left, right, up, down]
///
/// 'x' and 'y' are integers and represents locations in the maze.
/// 'left', 'right', 'up', and 'down' are boolean are represent valid directions
///
/// If a direction is false, then we can assume there is a wall in that direction.
/// If a direction is true, then we can proceed.  
///
/// If there is a wall, then throw an InvalidOperationException with the message "Can't go that way!".  If there is no wall,
/// then the 'currX' and 'currY' values should be changed.
/// </summary>
public class Maze
{
    private readonly Dictionary<ValueTuple<int, int>, bool[]> _mazeMap;
    private int _currX = 1;
    private int _currY = 1;

    // Direction indices for the boolean array
    private const int LEFT_INDEX = 0;
    private const int RIGHT_INDEX = 1;
    private const int UP_INDEX = 2;
    private const int DOWN_INDEX = 3;

    public Maze(Dictionary<ValueTuple<int, int>, bool[]> mazeMap)
    {
        _mazeMap = mazeMap;
    }

    // TODO Problem 4 - ADD YOUR CODE HERE
    /// <summary>
    /// Check to see if you can move left.  If you can, then move.  If you
    /// can't move, throw an InvalidOperationException with the message "Can't go that way!".
    /// </summary>
    public void MoveLeft()
    {
        // FILL IN CODE
        var currentPosition = new ValueTuple<int, int>(_currX, _currY);
        
        // Check if current position exists in the maze map
        if (_mazeMap.TryGetValue(currentPosition, out bool[] directions))
        {
            // Check if we can move left (index 0 in the boolean array)
            if (directions[LEFT_INDEX])
            {
                _currX--; // Move left means decrease X coordinate
            }
            else
            {
                throw new InvalidOperationException("Can't go that way!");
            }
        }
        else
        {
            throw new InvalidOperationException("Can't go that way!");
        }
    }

    /// <summary>
    /// Check to see if you can move right.  If you can, then move.  If you
    /// can't move, throw an InvalidOperationException with the message "Can't go that way!".
    /// </summary>
    public void MoveRight()
    {
        // FILL IN CODE
        var currentPosition = new ValueTuple<int, int>(_currX, _currY);
        
        // Check if current position exists in the maze map
        if (_mazeMap.TryGetValue(currentPosition, out bool[] directions))
        {
            // Check if we can move right (index 1 in the boolean array)
            if (directions[RIGHT_INDEX])
            {
                _currX++; // Move right means increase X coordinate
            }
            else
            {
                throw new InvalidOperationException("Can't go that way!");
            }
        }
        else
        {
            throw new InvalidOperationException("Can't go that way!");
        }
    }

    /// <summary>
    /// Check to see if you can move up.  If you can, then move.  If you
    /// can't move, throw an InvalidOperationException with the message "Can't go that way!".
    /// </summary>
    public void MoveUp()
    {
        // FILL IN CODE
        var currentPosition = new ValueTuple<int, int>(_currX, _currY);
        
        // Check if current position exists in the maze map
        if (_mazeMap.TryGetValue(currentPosition, out bool[] directions))
        {
            // Check if we can move up (index 2 in the boolean array)
            if (directions[UP_INDEX])
            {
                _currY--; // Move up means decrease Y coordinate (assuming Y increases downward)
            }
            else
            {
                throw new InvalidOperationException("Can't go that way!");
            }
        }
        else
        {
            throw new InvalidOperationException("Can't go that way!");
        }
    }

    /// <summary>
    /// Check to see if you can move down.  If you can, then move.  If you
    /// can't move, throw an InvalidOperationException with the message "Can't go that way!".
    /// </summary>
    public void MoveDown()
    {
        // FILL IN CODE
        var currentPosition = new ValueTuple<int, int>(_currX, _currY);
        
        // Check if current position exists in the maze map
        if (_mazeMap.TryGetValue(currentPosition, out bool[] directions))
        {
            // Check if we can move down (index 3 in the boolean array)
            if (directions[DOWN_INDEX])
            {
                _currY++; // Move down means increase Y coordinate
            }
            else
            {
                throw new InvalidOperationException("Can't go that way!");
            }
        }
        else
        {
            throw new InvalidOperationException("Can't go that way!");
        }
    }

    public string GetStatus()
    {
        return $"Current location (x={_currX}, y={_currY})";
    }

    // 💡 BONUS FEATURE: Add method to get available directions from current position
    /// <summary>
    /// Returns a list of available directions from the current position.
    /// This is a bonus feature that provides additional functionality.
    /// </summary>
    /// <returns>List of available direction names</returns>
    public List<string> GetAvailableDirections()
    {
        var availableDirections = new List<string>();
        var currentPosition = new ValueTuple<int, int>(_currX, _currY);
        
        if (_mazeMap.TryGetValue(currentPosition, out bool[] directions))
        {
            if (directions[LEFT_INDEX]) availableDirections.Add("Left");
            if (directions[RIGHT_INDEX]) availableDirections.Add("Right");
            if (directions[UP_INDEX]) availableDirections.Add("Up");
            if (directions[DOWN_INDEX]) availableDirections.Add("Down");
        }
        
        return availableDirections;
    }

    // 💡 BONUS FEATURE: Add method to check if a specific direction is available
    /// <summary>
    /// Checks if movement in a specific direction is possible from current position.
    /// This is a bonus feature that provides additional functionality.
    /// </summary>
    /// <param name="direction">Direction to check ("left", "right", "up", "down")</param>
    /// <returns>True if movement is possible, false otherwise</returns>
    public bool CanMove(string direction)
    {
        var currentPosition = new ValueTuple<int, int>(_currX, _currY);
        
        if (!_mazeMap.TryGetValue(currentPosition, out bool[] directions))
            return false;
        
        return direction.ToLowerInvariant() switch
        {
            "left" => directions[LEFT_INDEX],
            "right" => directions[RIGHT_INDEX],
            "up" => directions[UP_INDEX],
            "down" => directions[DOWN_INDEX],
            _ => false
        };
    }
}