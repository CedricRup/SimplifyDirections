using System.Collections.Generic;
using System.Linq;

namespace SimplifyDirections;

public static class Simplifier
{
    public static string[] Simplify(string[] initialDirections)
    {
        return initialDirections.Aggregate(new Stack<string>(), Folder).ToArray();

        Stack<string> Folder(Stack<string> previousInstructions, string newInstruction)
        {
            if (previousInstructions.TryPeek(out var lastInstruction) &&
                AreOpposite(lastInstruction, newInstruction))
                previousInstructions.Pop();
            else
                previousInstructions.Push(newInstruction);
            return previousInstructions;
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