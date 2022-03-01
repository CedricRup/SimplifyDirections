using System;
using Xunit;

namespace SimplifyDirections;

public class SimplifierTest
{
    [Fact]
    public void NoDirectionGivesEmptyResult()
    {
        var newDirections = Simplifier.Simplify(Array.Empty<string>());
        Assert.Equal(Array.Empty<string>(), newDirections);
    }

    [Fact]
    public void OneDirectionGivesTheSameDirections()
    {
        var listeDirection = Simplifier.Simplify(new[] { "NORTH" });
        Assert.Equal(new[] { "NORTH" }, listeDirection);
    }

    [Fact]
    public void NorthAndSouthAreOppositeAndDoCancelThemselves()
    {
        var listeDirection = Simplifier.Simplify(new[] { "NORTH", "SOUTH" });
        Assert.Equal(Array.Empty<string>(), listeDirection);
    }

    [Fact]
    public void SouthAndNorthAreOppositeAndDoCancelThemselves()
    {
        var listeDirection = Simplifier.Simplify(new[] { "SOUTH", "NORTH" });
        Assert.Equal(Array.Empty<string>(), listeDirection);
    }

    [Fact]
    public void EastAndWestAreOppositeAndDoCancelThemselves()
    {
        var listeDirection = Simplifier.Simplify(new[] { "EAST", "WEST" });
        Assert.Equal(Array.Empty<string>(), listeDirection);
    }

    [Fact]
    public void WestAndEastAreOppositeAndDoCancelThemselves()
    {
        var listeDirection = Simplifier.Simplify(new[] { "WEST", "EAST" });
        Assert.Equal(Array.Empty<string>(), listeDirection);
    }

    [Fact]
    public void UnMatchedDirectionRemainsInResult()
    {
        var listeDirection = Simplifier.Simplify(new[] { "NORTH", "SOUTH", "NORTH" });
        Assert.Equal(new[] { "NORTH" }, listeDirection);
    }

    [Fact]
    public void TwoOppositeDirectionCancelWhenTheyAreSeparatedByTwoOppositeDirections()
    {
        var listeDirection = Simplifier.Simplify(new[] { "NORTH", "EAST", "WEST", "SOUTH" });
        Assert.Equal(Array.Empty<string>(), listeDirection);
    }
}