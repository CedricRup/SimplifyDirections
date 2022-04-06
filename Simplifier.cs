using System.Collections.Generic;
using System.Linq;

namespace SimplifyDirections;

public static class Simplifier
{
    public static string[] Simplify(string[] initialDirections)
    {
        return initialDirections.Aggregate(new Stack<string>(), Folder).ToArray();

        Stack<string> Folder(Stack<string> currentInstruction, string newInstruction)
        {
            if (currentInstruction.TryPeek(out var lastInstruction) &&
                AreOpposite(lastInstruction, newInstruction))
                currentInstruction.Pop();
            else
                currentInstruction.Push(newInstruction);
            return currentInstruction;
        }
        
        bool AreOpposite(string firstDirection, string secondDirection)
        {
            return (firstDirection, secondDirection) switch
            {
                ("NORTH", "SOUTH") => true,
                ("SOUTH", "NORTH") => true,
                ("EAST", "WEST") => true,
                ("WEST", "EAST") => true,
                _ => false
            };
        }
    }
}