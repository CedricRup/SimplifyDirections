using System.Collections.Generic;
using System.Linq;

namespace SimplifyDirections;

public static class Simplifier
{
    public static string[] Simplify(string[] initialDirections)
    {
        var instructions = new Stack<string>();
        return initialDirections.Aggregate(new Stack<string>(), Folder).ToArray();

        Stack<string> Folder(Stack<string> currentInstruction, string newInstruction)
        {
            if (instructions.TryPeek(out var lastInstruction) &&
                AreOpposite(lastInstruction, newInstruction))
                instructions.Pop();
            else
                instructions.Push(newInstruction);
            return instructions;
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